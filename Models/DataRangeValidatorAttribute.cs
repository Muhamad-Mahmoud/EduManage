using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace MVC02.Models
{
    public class DataRangeValidatorAttribute : ValidationAttribute
    {
        /*
         * He Hase Two Dates FromDAte and ToDAte Compare this two
         */
        
        public string OtherPropertyName { get; set; }
        public DataRangeValidatorAttribute(string otherPropertyName)
        {
            OtherPropertyName = otherPropertyName;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null)
            {
                // Get To_Date 
                DateTime? ToDate = Convert.ToDateTime(value);

                // Get From Date 
                PropertyInfo? OtherProperty = validationContext.ObjectType.GetProperty(OtherPropertyName);

                //DateTime FromDate = Convert.ToDateTime(OtherProperty.GetValue(ValidationContext.ObjectInstance));

                DateTime FromDate = Convert.ToDateTime(OtherProperty.GetValue(validationContext.ObjectInstance));

                if (FromDate > ToDate)
                {
                    return new ValidationResult(ErrorMessage, new string[]
                    {
                        OtherPropertyName , validationContext.MemberName
                    });
                }
                else
                {
                    return ValidationResult.Success;
                } 

            }
            return null;
        }
    }
}
