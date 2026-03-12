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
    public static IServiceCollection AddMafCacheAsSingleton(this IServiceCollection services)
    {
        services.TryAddSingleton<IMafCache, MafCache>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="IMafCache"/> as a scoped service.
    /// </summary>
    public static IServiceCollection AddMafCacheAsScoped(this IServiceCollection services)
    {
        services.TryAddScoped<IMafCache, MafCache>();

        return services;
    }
}
