[![](https://img.shields.io/nuget/v/soenneker.maf.cache.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.maf.cache/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.maf.cache/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.maf.cache/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.maf.cache.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.maf.cache/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.maf.cache/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.maf.cache/actions/workflows/codeql.yml)

# Soenneker.Maf.Cache

Provides async thread-safe caching of Microsoft Agent Framework `AIAgent` instances.

## Install

```bash
dotnet add package Soenneker.Maf.Cache
```

## Quick start

```csharp
using Soenneker.Maf.Cache.Registrars;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
var result = services.AddMafCacheAsSingleton();
```

Adds `IMafCache` as a singleton service.

## What you get

- `IMafCache` — Provides async thread-safe caching of Microsoft Agent Framework `AIAgent` instances.
- `MafCacheRegistrar` — Registration extensions for `IMafCache`.

## API at a glance

| API | What it does | Result / important behavior |
| --- | --- | --- |
| `IMafCache.Get(id, options, cancellationToken)` | Retrieves an `AIAgent` instance asynchronously, creating it via options if necessary. | A task whose result is the requested AI Agent. |
| `IMafCache.Remove(id, cancellationToken)` | Removes an agent instance from the cache. | true if removes an agent instance from the cache; otherwise, false. |
| `IMafCache.Clear(cancellationToken)` | Clears all cached agent instances. | A task that completes when the Maf Cache has been cleared. |
| `IMafCache.GetAll(cancellationToken)` | Returns all cached agents by id. | A task whose result is the requested dictionary. |
| `MafCacheRegistrar.AddMafCacheAsSingleton(services)` | Adds `IMafCache` as a singleton service. | The same service collection, so additional registrations can be chained. |
| `MafCacheRegistrar.AddMafCacheAsScoped(services)` | Adds `IMafCache` as a scoped service. | The same service collection, so additional registrations can be chained. |

## Practical notes

- Cancellation stops pending work; it does not undo work that has already completed.
- Calls that return a cached or singleton value reuse the same instance until the owning service is disposed.
