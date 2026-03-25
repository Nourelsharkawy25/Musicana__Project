using System.ComponentModel.DataAnnotations;
using Musicana.Api.Enums;
using Musicana.Api.Validation;

namespace Musicana.Api.Requests;

public class CreateSongDto
{
    [Required(ErrorMessage = "Title is required")]
    [StringLength(200, MinimumLength = 2, ErrorMessage = "Title must be between 2 and 200 characters")]
    public string Title { get; set; } = null!;

    [Required(ErrorMessage = "Genre is required")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "Genre must be between 3 and 50 characters")]
    public SongGenres Genre { get; set; }

    [StringLength(1000, ErrorMessage = "Description cannot exceed 1000 characters")]
    public string? Description { get; set; }

    [Required(ErrorMessage = "Duration is required")]
    public double Duration { get; set; }

    [Required(ErrorMessage = "Audio file is required")]
    [DataType(DataType.Upload)]
    [AllowedAudioExtensions]
    public IFormFile formFile { get; set; } = null!;
}