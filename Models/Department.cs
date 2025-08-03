using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace MVC02.Models
{
  public class Department
  {
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Name is required")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Manager name is required")]
    public string Manger { get; set; } = string.Empty;

    public ICollection<Course> Courses { get; set; } = new List<Course>();
    public ICollection<Trainee> Trainees { get; set; } = new List<Trainee>();
    public ICollection<Instructor> Instructors { get; set; } = new List<Instructor>();
  }
}
