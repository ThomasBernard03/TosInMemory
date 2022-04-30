using System.Linq;
using TosInMemory.Tests.Models;
using TosInMemory.Tests.Services;
using Xunit;

namespace TosInMemory.Tests;

public class TosInMemoryUnitTest
{
    private readonly LeagueService _leagueService;

    public TosInMemoryUnitTest()
    {
        _leagueService = new();
    }

    [Fact]
    public void TestLeagueOk()
    {
        var numberExpectedLeagues = 100;
        var leagues = _leagueService.Generate(numberExpectedLeagues);

        Assert.Equal(numberExpectedLeagues, leagues.Count());
    }

    [Fact]
    public void TestLeagueKo()
    {
        var numberExpectedLeagues = 100;
        var leagues = _leagueService.Generate(numberExpectedLeagues);

        Assert.NotEqual(numberExpectedLeagues, leagues.Count());
    }


    [Fact]
    public void TestClubs()
    {

    }
}
