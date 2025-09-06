using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EDU.Models;
using EDU.Repository;
using EDU.Repository.IRepository;
using EDU.ViewModel;

namespace EDU.Controllers;

public class InstructorController : Controller
{
    IBaseRepository<Instructor> instructorRepository;
    IBaseRepository<Course> courseRepository;
    IBaseRepository<Department> departmentRepository;
    public InstructorController(IBaseRepository<Instructor> InstructorRepository, IBaseRepository<Course> CourseRepository, IBaseRepository<Department> DepartmentRepository)
    {
        instructorRepository = InstructorRepository;
        courseRepository = CourseRepository;
        departmentRepository = DepartmentRepository;
    }

    public IActionResult Index()
    {

        InstructorWithCrsListViewModel InstructorViewModel = new()
        {
            InstructorList = instructorRepository.GetAll(),
            CoursesList = courseRepository.GetAll(),
            DepartmentsList = departmentRepository.GetAll(),
        };

        return View("Index", InstructorViewModel);
    }

    public IActionResult Detailes(int Id)
    {
        var instructorModel = instructorRepository
             .GetAll()
             .FirstOrDefault(x => x.Id == Id);

        return View("Detailes", instructorModel);
    } 
  
    [HttpGet]
    public IActionResult Add(int id)
    {
        InstructorWithCrsListViewModel InstructorViewModel = new()
        {
            InstructorList = instructorRepository.GetAll(),
            CoursesList = courseRepository.GetAll(),
            DepartmentsList = departmentRepository.GetAll(),
        };

        return View("Add", InstructorViewModel);
    }

    [HttpPost]
    public IActionResult SaveAdd(Instructor newInstructorFromRequest)
    {
        if (!ModelState.IsValid || newInstructorFromRequest.Salary < 10000)
        {
            InstructorWithCrsListViewModel InstructorViewModel = new()
            {
                Id = newInstructorFromRequest.Id,
                Name = newInstructorFromRequest.Name,
                Address = newInstructorFromRequest.Address,
                ImageURL = newInstructorFromRequest.ImageURL,
                Salary = newInstructorFromRequest.Salary,
                CourseId = newInstructorFromRequest.CourseId,
                DepartmentId = newInstructorFromRequest.DepartmentId,
                InstructorList = instructorRepository.GetAll(),
                CoursesList =  courseRepository.GetAll(),
                DepartmentsList = departmentRepository.GetAll(),
            };
            return View("Add", InstructorViewModel);
        }
        
        instructorRepository.Add(newInstructorFromRequest);
        instructorRepository.Save();
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        Instructor? InstructorModel = instructorRepository.GetById(id);

        if (InstructorModel == null)
        {
            return NotFound();
        }

        InstructorWithCrsListViewModel InstructorViewModel = new()
        {
            Id = InstructorModel.Id,
            Name = InstructorModel.Name,
            Address = InstructorModel.Address,
            ImageURL = InstructorModel.ImageURL,
            Salary = InstructorModel.Salary,
            CourseId = InstructorModel.CourseId,
            DepartmentId = InstructorModel.DepartmentId,
            InstructorList = instructorRepository.GetAll(),
            CoursesList = courseRepository.GetAll(),
            DepartmentsList = departmentRepository.GetAll(),
        };

        return View("Edit", InstructorViewModel);
    }

    [HttpPost]
    public IActionResult SaveEdit(int id, Instructor InstructorFromRequest)
    {
        if (!ModelState.IsValid)
        {
            return View("Edit", new InstructorWithCrsListViewModel
            {
                Id = InstructorFromRequest.Id,
                Name = InstructorFromRequest.Name,
                Address = InstructorFromRequest.Address,
                ImageURL = InstructorFromRequest.ImageURL,
                Salary = InstructorFromRequest.Salary,
                CourseId = InstructorFromRequest.CourseId,
                DepartmentId = InstructorFromRequest.DepartmentId,
                CoursesList = courseRepository.GetAll(),
                DepartmentsList = departmentRepository.GetAll(),
            });
        }

        var InstructorFromDB = instructorRepository.GetById(id);

        if (InstructorFromDB == null)
        {
            return NotFound();
        }

        InstructorFromDB.Name = InstructorFromRequest.Name;
        InstructorFromDB.Address = InstructorFromRequest.Address;
        InstructorFromDB.ImageURL = InstructorFromRequest.ImageURL;
        InstructorFromDB.CourseId = InstructorFromRequest.CourseId;
        InstructorFromDB.DepartmentId = InstructorFromRequest.DepartmentId;
        InstructorFromDB.Salary = InstructorFromRequest.Salary;

        instructorRepository.Save();
        return RedirectToAction("Index");
    }

    public IActionResult Delete(int id)
    {
        var instructor = instructorRepository.GetById(id);

        if (instructor == null)
        {
            return NotFound();
        }

        instructorRepository.Delete(id);
        instructorRepository.Save();

        return RedirectToAction("Index");
    }
}