using Musicana.Api.Models;
using Musicana.Api.Requests;
using Musicana.Api.Responses;

namespace Musicana.Api.Services;

public interface IMusicianService
{
    Task CreateMusicianAsync(CreateMusicianDto musician);
    Task<MusicianResponse?> GetMusicianByIdAsync(int id);
    Task<IEnumerable<MusicianResponse?>> GetMusicianByNameAsync(string name);
    Task<IEnumerable<MusicianResponse>> GetAllMusiciansAsync();
    Task UpdateMusicianAsync(int id, EditMusicianDto musicianDto);
    Task DeleteMusicianAsync(int id);
    Task<bool> MusicianExistsAsync(int id);
}
