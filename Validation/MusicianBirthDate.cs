using System.ComponentModel.DataAnnotations;

namespace Musicana.Api.Validation;

public class DateAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is not DateTime date)
            return new ValidationResult("Invalid date format");

        if (date > DateTime.Today)
            return new ValidationResult("BirthDate cannot be in the future");

        if (date > DateTime.Today.AddYears(-18))
        return new ValidationResult("Musician must be at least 18 years old");

        return ValidationResult.Success;
    }
}