using Musicana.Api.Models;
using Musicana.Api.Responses;

namespace Musicana.Api.Repositories;

public interface IMusicianRepo
{
    Task<IEnumerable<Musician>> GetAllMusiciansAsync();
    Task<Musician?> GetMusicianByIdAsync(int id);
    Task<IEnumerable<Musician?>> GetMusicianByNameAsync(string name);
    Task AddMusicianAsync(Musician musician);
    Task<bool> MusicianExistsAsync(int id);
    Task SaveAsync();
}