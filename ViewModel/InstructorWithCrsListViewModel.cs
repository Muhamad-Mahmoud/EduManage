using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MVC02.Models;

namespace MVC02.ViewModel
{
  public class InstructorWithCrsListViewModel
  {
    public int Id { get; set; }

    [Required(ErrorMessage = "Name is required")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Image URL is required")]
    public string ImageURL { get; set; } = string.Empty;

    [Required(ErrorMessage = "Address is required")]
    public string Address { get; set; } = string.Empty;

    public List<Instructor> InstructorList { get; set; } = new();

    public int Salary { get; set; }

    public int DepartmentId { get; set; }
    public Department? Department { get; set; }

    public int? CourseId { get; set; }
    public Course? Course { get; set; }

    public List<Department> DepartmentsList { get; set; } = new();
    public List<Course> CoursesList { get; set; } = new();
  }
}

