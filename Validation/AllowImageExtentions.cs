using System.ComponentModel.DataAnnotations;

namespace Musicana.Api.Validation;

public class AllowedImageExtensionsAttribute : ValidationAttribute
{
    private readonly string[] _extensions;
    public AllowedImageExtensionsAttribute()
    {
        _extensions = new[] { ".jpg", ".jpeg", ".png", ".webp" };
    }
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is null)
            return ValidationResult.Success;

        if (value is IFormFile file)
        {
            var extension = Path.GetExtension(file.FileName).ToLower();
            if (!_extensions.Contains(extension))
                return new ValidationResult($"Allowed extensions are: {string.Join(", ", _extensions)}");
        }
        return ValidationResult.Success;
    }
}