using Musicana.Api.Repositories;
using Musicana.Api.Services;

namespace Musicana.Api.DependencyInjection;

public static class SongDI
{
    public static IServiceCollection SongServices(this IServiceCollection services)
    {
        services.AddScoped<ISongRepo, SongRepo>();
        services.AddScoped<ISongService, SongService>();
        return services;
    }
}