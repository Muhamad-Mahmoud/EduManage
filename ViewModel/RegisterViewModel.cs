using System.ComponentModel.DataAnnotations;

namespace MVC02.ViewModel
{
    public class RegisterViewModel
    {
        [Required()]
        public string UserName { get; set; }

        [Required()]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required()]
        [Compare("Password")]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        public string Address { get; set; }
    }
}
