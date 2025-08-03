using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC02.Models;
using MVC02.Repository;
using MVC02.Repository.IRepository;
using MVC02.ViewModel;

namespace MVC02.Controllers;

[Authorize]
public class DepartmentController : Controller
{
    private readonly IBaseRepository<Department> _departmentRepository;
    
    public DepartmentController(IBaseRepository<Department> departmentRepository)
    {
        _departmentRepository = departmentRepository;
    }

    public IActionResult Index()
    {
        List<Department> departmentsModel = _departmentRepository.GetAll();
        return View("Index", departmentsModel);
    }

    // Add New Department
    [HttpGet]
    public IActionResult Add()
    {
        return View("Add");
    }

    [HttpPost]
    public IActionResult SaveAdd(Department departmentFromRequest)
    {
        _departmentRepository.Add(departmentFromRequest);
        _departmentRepository.Save();
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        var departmentFromDB = _departmentRepository.GetById(id);
            
        return View("Edit", departmentFromDB);
    }

    [HttpPost]
    public IActionResult SaveEdit(Department departmentFromRequest)
    {
        if (!ModelState.IsValid)
        {
            return View("Edit", departmentFromRequest);
        }

        var departmentFromDB = _departmentRepository.GetById(departmentFromRequest.Id);

        if (departmentFromDB == null)
            return NotFound();

        departmentFromDB.Name = departmentFromRequest.Name;
        departmentFromDB.Manger = departmentFromRequest.Manger;
        _departmentRepository.Save();
        
        return RedirectToAction("Index");
    }

    // Delete
    public IActionResult Delete(int id)
    {
        _departmentRepository.Delete(id);
        _departmentRepository.Save();

        return RedirectToAction("Index");
    }
}