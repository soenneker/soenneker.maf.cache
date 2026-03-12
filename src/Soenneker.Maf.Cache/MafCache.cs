using Microsoft.Agents.AI;
using Microsoft.Extensions.Logging;
using Soenneker.Dictionaries.Singletons;
using Soenneker.Extensions.ValueTask;
using Soenneker.Maf.Cache.Abstract;
using Soenneker.Maf.Dtos.Options;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Maf.Cache;

/// <inheritdoc cref="IMafCache"/>
public sealed class MafCache : IMafCache
{
    private readonly ILogger<MafCache> _logger;
    private readonly SingletonDictionary<AIAgent, MafOptions> _agents;

    public MafCache(ILogger<MafCache> logger)
    {
        _logger = logger;
        _agents = new SingletonDictionary<AIAgent, MafOptions>(CreateAgent);
    }

    private async ValueTask<AIAgent> CreateAgent(string id, MafOptions options, CancellationToken cancellationToken)
    {
        if (options?.AgentFactory == null)
            throw new ArgumentNullException(nameof(options), "MafOptions.AgentFactory must be set.");

        _logger.LogInformation("Creating a new AIAgent instance for id ({Id}), model ({ModelId})...", id, options.ModelId);

        AIAgent agent = await options.AgentFactory(options, cancellationToken).NoSync();

        _logger.LogDebug("AIAgent instance ({Id}) has been initialized", id);
        return agent;
    }

    public ValueTask<AIAgent> Get(string id, MafOptions options, CancellationToken cancellationToken = default)
    {
        if (options?.AgentFactory == null)
            throw new ArgumentNullException(nameof(options), "MafOptions.AgentFactory must be set.");

        return _agents.Get(id, options, cancellationToken);
    }

    public ValueTask Remove(string id, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Removing AIAgent instance ({Id})...", id);
        return _agents.Remove(id, cancellationToken);
    }

    public ValueTask Clear(CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Clearing AIAgent instances...");
        return _agents.Clear(cancellationToken);
    }

    public ValueTask<Dictionary<string, AIAgent>> GetAll(CancellationToken cancellationToken = default)
    {
        return _agents.GetAll(cancellationToken);
    }
}
