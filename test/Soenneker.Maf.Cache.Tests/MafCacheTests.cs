using Soenneker.Maf.Cache.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.Maf.Cache.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class MafCacheTests : HostedUnitTest
{
    private readonly IMafCache _util;

    public MafCacheTests(Host host) : base(host)
    {
        _util = Resolve<IMafCache>(true);
    }

    [Test]
    public void Default()
    {

    }
}
