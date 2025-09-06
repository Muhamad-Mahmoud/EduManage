using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EDU.Models;
using EDU.Repository.IRepository;
using EDU.ViewModel;

namespace EDU.Controllers;

public class CourseController : Controller
{
    private readonly ICourseRepository _courseRepository;
    private readonly IBaseRepository<Department> _departmentRepository;

    public CourseController(ICourseRepository courseRepository, IBaseRepository<Department> departmentRepository)
    {
        _courseRepository = courseRepository;
        _departmentRepository = departmentRepository;
    }

    public IActionResult Index()
    {
        var courses = _courseRepository.GetAllWithDepartments();
        var departments = _departmentRepository.GetAll();

        var viewModel = new CrsListwithDepViewModel
        {
            CoursesList = courses,
            DepartmentsList = departments
        };

        return View("Index", viewModel);
    }

    [HttpGet]
    public IActionResult Add()
    {
        var viewModel = new CrsListwithDepViewModel
        {
            DepartmentsList = _departmentRepository.GetAll()
        };

        return View("Add", viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult SaveAdd(Course newCourse)
    {
        if (!ModelState.IsValid)
        {
            var viewModel = new CrsListwithDepViewModel
            {
                DepartmentsList = _departmentRepository.GetAll()
            };
            return View("Add", viewModel);
        }

        _courseRepository.Add(newCourse);
        _courseRepository.Save();
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        var course = _courseRepository.GetByIdWithDepartment(id);
        if (course == null)
            return NotFound();

        ViewBag.Departments = _departmentRepository.GetAll();
        return View("Edit", course);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult SaveEdit(int id, Course updatedCourse)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.Departments = _departmentRepository.GetAll();
            return View("Edit", updatedCourse);
        }

        var courseFromDb = _courseRepository.GetById(id);
        if (courseFromDb == null)
            return NotFound();

        courseFromDb.Name = updatedCourse.Name;
        courseFromDb.Degree = updatedCourse.Degree;
        courseFromDb.MinDegree = updatedCourse.MinDegree;
        courseFromDb.Hours = updatedCourse.Hours;
        courseFromDb.DepartmentId = updatedCourse.DepartmentId;

        _courseRepository.Save();
        return RedirectToAction("Index");
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Delete(int id)
    {
        var course = _courseRepository.GetById(id);
        if (course == null)
            return NotFound();

        _courseRepository.Delete(id);
        _courseRepository.Save();
        return RedirectToAction("Index");
    }
}
