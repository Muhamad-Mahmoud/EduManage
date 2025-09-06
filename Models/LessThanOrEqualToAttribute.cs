using System.ComponentModel.DataAnnotations;

namespace EDU.Models
{
    public class LessThanOrEqualToAttribute : ValidationAttribute
    {
        private readonly string _otherProperty;

        public LessThanOrEqualToAttribute(string otherProperty)
        {
            _otherProperty = otherProperty;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var currentValue = Convert.ToInt32(value);

            var property = validationContext.ObjectType.GetProperty(_otherProperty);
            if (property == null)
                return new ValidationResult($"Unknown property: {_otherProperty}");

            var otherValue = Convert.ToInt32(property.GetValue(validationContext.ObjectInstance));

            if (currentValue > otherValue)
            {
                return new ValidationResult($"{validationContext.MemberName} must be less than or equal to {_otherProperty}.");
            }

            return ValidationResult.Success;
        }
    }
}