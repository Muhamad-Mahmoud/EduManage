using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MVC02.Models;

namespace MVC02.ViewModel
{
  public class CrsListwithDepViewModel
  {
    public int Id { get; set; }

    [Required(ErrorMessage = "Name is required")]
    public string Name { get; set; } = string.Empty;

    public int Degree { get; set; }
    public int MinDegree { get; set; }
    public int Hours { get; set; }

    public List<Course> CoursesList { get; set; } = new();

    public int DepartmentId { get; set; }
    public Department? Department { get; set; }

    public List<Department> DepartmentsList { get; set; } = new();
  }
}

