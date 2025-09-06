using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EDU.Models;
using EDU.ViewModel;

namespace EDU.Controllers;

public class TraineeController : Controller
{
    private readonly AppDbContext _context;

    public TraineeController (AppDbContext context)
    {
        _context = context;
    }
    public IActionResult Index()
    {
        var TraineeList = _context.Trainees
            .Include(t => t.department)
            .ToList();
        return View("Index", TraineeList);
    }    
    
    [HttpGet]
    public IActionResult Add()
    {
        var viewModel = new TraineeWithDepWithCourceViewModel
        {
            DepartmentsList = _context.Departments.ToList()
        };
        return View("Add", viewModel);
    }
    [HttpPost]
    public IActionResult SaveAdd (Trainee newTraineeFromRequest)
    {
        if (!ModelState.IsValid)
        {
            var viewModel = new TraineeWithDepWithCourceViewModel
            {
                DepartmentsList = _context.Departments.ToList()
            };
            return View("Add", viewModel);
        }

        _context.Trainees.Add(newTraineeFromRequest);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    public IActionResult Edit(int Id)
    {
        var Trainee = _context.Trainees.FirstOrDefault(t => t.Id == Id);
        if (Trainee == null)
            return NotFound();
        var viewModel = new TraineeWithDepWithCourceViewModel
        {
            Id = Trainee.Id,
            Name = Trainee.Name,
            ImageURL = Trainee.ImageURL,
            Address = Trainee.Address,
            Grad = Trainee.Grad,
            departmentId = Trainee.departmentId,
            department = Trainee.department,
            DepartmentsList = _context.Departments.ToList()
        };
        return View("Edit", viewModel);
    }
    public IActionResult SaveEdit(Trainee TraineeFromRequest)
    {
        if (!ModelState.IsValid)
        {
            var viewModel = new TraineeWithDepWithCourceViewModel
            {
                Id = TraineeFromRequest.Id,
                Name = TraineeFromRequest.Name,
                ImageURL = TraineeFromRequest.ImageURL,
                Address = TraineeFromRequest.Address,
                Grad = TraineeFromRequest.Grad,
                departmentId = TraineeFromRequest.departmentId,
                DepartmentsList = _context.Departments.ToList()
            };
            return View("Edit", viewModel);
        }
        _context.Trainees.Update(TraineeFromRequest);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
    public IActionResult Delete(int id)
    {
        var TraineeFromDB = _context.Trainees.Find(id);
        if (TraineeFromDB == null)
            return NotFound();

        _context.Trainees.Remove(TraineeFromDB);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

}