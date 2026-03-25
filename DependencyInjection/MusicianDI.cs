using Musicana.Api.Repositories;
using Musicana.Api.Services;

namespace Musicana.Api.DependencyInjection;

public static class MusicianDi
{
    public static IServiceCollection MusicianServices(this IServiceCollection services)
    {
        services.AddScoped<IMusicianRepo, MusicianRepo>();
        services.AddScoped<IMusicianService, MusicianService>();
        return services;
    }
}