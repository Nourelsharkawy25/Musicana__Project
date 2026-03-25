namespace Musicana.Api.Models;

public class Musician_Song
{
    public int SongId { get; set; }
    public int MusicianId { get; set; }
    public Musician Musician { get; set; }
    public Song Song { get; set; }

}