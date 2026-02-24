using Soenneker.Maf.Cache.Abstract;
using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.Maf.Cache.Tests;

[Collection("Collection")]
public sealed class MafCacheTests : FixturedUnitTest
{
    private readonly IMafCache _util;

    public MafCacheTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _util = Resolve<IMafCache>(true);
    }

    [Fact]
    public void Default()
    {

    }
}
