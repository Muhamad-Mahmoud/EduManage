using System.ComponentModel.DataAnnotations;

namespace MVC02.Models;

public class UninqueNameAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value == null) return null;

        var name = value.ToString();

        // Retrieve the AppDbContext instance from the validationContext
        var context = (AppDbContext)validationContext.GetService(typeof(AppDbContext));

        Trainee? trainee = context.Trainees.FirstOrDefault(t => t.Name == name);
        if (trainee != null)
        {
            return new ValidationResult("Name must be unique.");
        }
        return ValidationResult.Success;
    }
}
