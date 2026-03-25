using Musicana.Api.Repositories;
using Musicana.Api.Services;

namespace Musicana.Api.DependencyInjection;

public static class InstrumentDI
{
    public static IServiceCollection InstrumentServices(this IServiceCollection services)
    {
        services.AddScoped<I_InstrumentRepo, InstrumentRepo>();
        services.AddScoped<I_InstrumentService, InstrumentService>();
        return services;
    }
}