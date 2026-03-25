using Musicana.Api.Repositories;
using Musicana.Api.Services;

namespace Musicana.Api.DependencyInjection;

public static class MusicianSongServices
{
    public static IServiceCollection Song_MusicianService(this IServiceCollection service)
    {
        service.AddScoped<IMusician_SongService, Musician_SongService>();
        service.AddScoped<IMusicianSongRepo, MusicianSongRepo>();
        return service;
    }
}