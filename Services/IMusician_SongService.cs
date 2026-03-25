using Musicana.Api.Requests;

namespace Musicana.Api.Services;

public interface IMusician_SongService
{
    Task AssignSongToMusicianAsync(AssignSongDto dto);
}