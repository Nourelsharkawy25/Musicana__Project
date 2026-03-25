using System.ComponentModel.DataAnnotations;
using Musicana.Api.Enums;
using Musicana.Api.Validation;

namespace Musicana.Api.Requests;

public class CreateInstrumentDto
{
    [Required(ErrorMessage = "Name is required")]
    [StringLength(100, MinimumLength = 5, ErrorMessage = "Name must be between 5 and 100 characters")]
    public string Name { get; set; }
    [Required(ErrorMessage = "Type is required")]
    [EnumDataType(typeof(InstrumentType), ErrorMessage = "Invalid instrument type")]
    public InstrumentType Type { get; set; }

    [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters")]
    public string? Description { get; set; }
    [AllowedExtensions]
    public IFormFile? ImageUrl { get; set; }
}