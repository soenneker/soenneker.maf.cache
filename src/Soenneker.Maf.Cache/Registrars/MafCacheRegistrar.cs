using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Maf.Cache.Abstract;
using Soenneker.Maf.Cache;

namespace Soenneker.Maf.Cache.Registrars;

/// <summary>
/// Registration extensions for <see cref="IMafCache"/>.
/// </summary>
public static class MafCacheRegistrar
{
    /// <summary>
    /// Adds <see cref="IMafCache"/> as a singleton service.
    /// </summary>
    /// <param name="services">Service collection that receives the registration.</param>
    /// <returns>The same service collection, so additional registrations can be chained.</returns>
    public static IServiceCollection AddMafCacheAsSingleton(this IServiceCollection services)
    {
        services.TryAddSingleton<IMafCache, MafCache>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="IMafCache"/> as a scoped service.
    /// </summary>
    /// <param name="services">Service collection that receives the registration.</param>
    /// <returns>The same service collection, so additional registrations can be chained.</returns>
    public static IServiceCollection AddMafCacheAsScoped(this IServiceCollection services)
    {
        services.TryAddScoped<IMafCache, MafCache>();

        return services;
    }
}
