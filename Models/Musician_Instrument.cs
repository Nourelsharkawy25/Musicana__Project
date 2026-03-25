namespace Musicana.Api.Models;

public class Musician_Instrument
{
    public int MusicianId { get; set; }
    public int InstrumentId { get; set; }
    public Musician Musician { get; set; }
    public Instrument Instrument { get; set; }
}