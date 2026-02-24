using Microsoft.Agents.AI;
using Soenneker.Maf.Dtos.Options;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Maf.Cache.Abstract;

/// <summary>
/// Provides async thread-safe caching of Microsoft Agent Framework <see cref="AIAgent"/> instances.
/// </summary>
public interface IMafCache
{
    /// <summary>
    /// Retrieves an <see cref="AIAgent"/> instance asynchronously, creating it via options if necessary.
    /// </summary>
    ValueTask<AIAgent> Get(string id, MafOptions options, CancellationToken cancellationToken = default);

    /// <summary>
    /// Removes an agent instance from the cache.
    /// </summary>
    ValueTask Remove(string id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Clears all cached agent instances.
    /// </summary>
    ValueTask Clear(CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns all cached agents by id.
    /// </summary>
    ValueTask<Dictionary<string, AIAgent>> GetAll(CancellationToken cancellationToken = default);
}
