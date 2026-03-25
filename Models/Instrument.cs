using Musicana.Api.Enums;

namespace Musicana.Api.Models;

public class Instrument
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public InstrumentType Type { get; set; }
    public string? ImageUrl { get; set; }
    public bool IsDeleted { get; set; } = false;
    public List<Musician_Instrument> musician_Instruments { get; set; }
}