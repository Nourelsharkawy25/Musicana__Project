using Musicana.Api.Enums;
using Musicana.Api.Models;
using Musicana.Api.Requests;
using Musicana.Api.Responses;

namespace Musicana.Api.Services;

public interface ISongService
{
    Task<IEnumerable<SongResponse>> GetSongsAsync();
    Task CreateSongAsync(CreateSongDto createSongDto);
    Task DeleteSongAsync(int songId);
    Task UpdateSongAsync(int songId, EditSongDto editSongDto);
    Task<SongResponse?> GetSongByIdAsync(int id);
    Task<IEnumerable<SongResponse>> GetSongsByGenreAsync(SongGenres genre);
    Task<IEnumerable<SongResponse>> GetSongsByTitleAsync(string title);
    Task<bool> SongExistsAsync(int id);
}