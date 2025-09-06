using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EDU.Models
{
  public class Trainee
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
        [Range(1,4)]
    public int Grad { get; set; }
    
    [Required]
    public int departmentId { get; set; }
    public Department? department { get; set; }

    public List<crsResult> Crs { get; set; } = new List<crsResult>();
  }
}
