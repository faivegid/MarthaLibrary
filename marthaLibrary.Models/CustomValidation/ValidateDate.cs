using System.ComponentModel.DataAnnotations;

namespace marthaLibrary.Models.CustomValidation
{
    public static class ValidateDate
    {
        public static ValidationResult DateGreaterThanToday(DateTime dateToValidate, ValidationContext context)
        {
            if (dateToValidate.Date < DateTime.UtcNow.Date)
            {
                return new ValidationResult("The date must be at least the next day or in the future");
            }
            else
            {
                return ValidationResult.Success;
            }
        }
    }
}
