using System.ComponentModel.DataAnnotations;

namespace Application.Utility
{
    public class DateNotGreaterThanCurrent : ValidationAttribute
    {
        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null)
            {
                DateTime dateValue = (DateTime)value;
                if (dateValue > DateTime.Now)
                {
                    return new ValidationResult("Date cannot be greater than the current date");
                }
            }
            return ValidationResult.Success!;
        }
    }
}
