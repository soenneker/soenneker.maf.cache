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
    /// <param name="id">Identifier of the maf cache instance or registration to target.</param>
    /// <param name="options">Options to configure for the maf cache.</param>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    /// <returns>A task whose result is the requested AI Agent.</returns>
    ValueTask<AIAgent> Get(string id, MafOptions options, CancellationToken cancellationToken = default);

    /// <summary>
    /// Removes an agent instance from the cache.
    /// </summary>
    /// <param name="id">Identifier of the maf cache instance or registration to target.</param>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    /// <returns>true if removes an agent instance from the cache; otherwise, false.</returns>
    ValueTask<bool> Remove(string id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Clears all cached agent instances.
    /// </summary>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    /// <returns>A task that completes when the Maf Cache has been cleared.</returns>
    ValueTask Clear(CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns all cached agents by id.
    /// </summary>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    /// <returns>A task whose result is the requested dictionary.</returns>
    ValueTask<Dictionary<string, AIAgent>> GetAll(CancellationToken cancellationToken = default);
}
