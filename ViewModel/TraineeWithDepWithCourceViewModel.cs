using MVC02.Models;
using System.ComponentModel.DataAnnotations;

namespace MVC02.ViewModel;

public class TraineeWithDepWithCourceViewModel
{
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Name is required")]
    public string Name { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Image URL is required")]
    public string ImageURL { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Address is required")]
    public string Address { get; set; } = string.Empty;
    
    public int Grad { get; set; }

    [Required(ErrorMessage = "Department is required")]
    public int departmentId { get; set; }
    
    public Department? department { get; set; }

    public List<Department> DepartmentsList { get; set; } = new();
}
