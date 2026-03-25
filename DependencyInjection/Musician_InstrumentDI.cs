using Musicana.Api.Repositories;
using Musicana.Api.Services;

namespace Musicana.Api.DependencyInjection;

public static class Musician_InstrumentDI
{
    public static IServiceCollection Musician_InstrumentServices(this IServiceCollection services)
    {
        services.AddScoped<IMusicianInstrumentRepo, MusicianInstrumentRepo>();
        services.AddScoped<IMusician_InstrumentService, Musician_InstrumentService>();
        return services;
    }
}