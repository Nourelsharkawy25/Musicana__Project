namespace Musicana.Api.Models;

public class Album
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string? Description { get; set; }
    public DateTime ReleaseDate { get; set; }
    public string? CoverImagePath { get; set; }
    public bool IsDeleted { get; set; }

    // FK — One Musician has Many Albums
    public int MusicianId { get; set; }
    public Musician Musician { get; set; }

    // One Album has Many Songs
    public List<Song> Songs { get; set; }
}
