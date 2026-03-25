using System.ComponentModel.DataAnnotations;

namespace Musicana.Api.Requests;

public class AssignInstrumentDto
{
    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Invalid MusicianId")]
    public int MusicianId { get; set; }

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Invalid InstrumentId")]
    public int InstrumentId { get; set; }
}