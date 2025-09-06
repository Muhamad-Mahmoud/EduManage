using EDU.Models;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EDU.Models
{
  public class Course
  {
    public int Id { get; set; }

    [Required(ErrorMessage = "Name is required")]
    [StringLength(20, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 20 characters")]
    [UninqueName(ErrorMessage = "Name must be unique")]
    public string Name { get; set; } = string.Empty;

    [Required]
    [Range(50, 100, ErrorMessage = "Degree must be between 50 and 100")]
    public int Degree { get; set; }

    [LessThanOrEqualTo("Degree")]
    public int MinDegree { get; set; }

    public int Hours { get; set; }

    [Required]
    [ForeignKey("Department")]
    public int DepartmentId { get; set; }

    public Department? Department { get; set; }
    public ICollection<Instructor> Instructors { get; set; } = new List<Instructor>();
    public ICollection<crsResult> crsResults { get; set; } = new List<crsResult>();
  }
}
