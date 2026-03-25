using Musicana.Api.Models;

namespace Musicana.Api.Repositories;

public interface IMusicianSongRepo
{
    Task AddSongToMusicianAsync(Musician_Song musician_Song);
    Task SaveAsync();
}