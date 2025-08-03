using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC02.Models;

public class crsResult
{
    [Required]
    public int CourseId { get; set; }
    public Course? Course { get; set; }

    [Required]
    public int TraineeId { get; set; }
    public Trainee? Trainee { get; set; }

    public int Degree { get; set; }
}