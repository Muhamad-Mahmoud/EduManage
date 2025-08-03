using MVC02.Models;
using System.ComponentModel.DataAnnotations;

namespace MVC02.ViewModel;

public class TraineeWithCourseViewModel
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Name is required")]
    [MaxLength(50)]
    [MinLength(2)]
    [Display(Name = "Trainee Name")]
    [UninqueName()]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Image URL is required")]
    public string ImageURL { get; set; } = string.Empty;

    [Required(ErrorMessage = "Address is required")]
    public string Address { get; set; } = string.Empty;

    [Required()]
    [Range(1, 4)]
    public int Grad { get; set; }

    public int courseId { get; set; }
    public Course course { get; set; }
    public List<Course> courses { get; set; }
}
