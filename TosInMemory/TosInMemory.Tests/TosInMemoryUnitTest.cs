using System.Linq;
using TosInMemory.Tests.Models;
using TosInMemory.Tests.Services;
using TosInMemory.Tests.Services.Interfaces;
using Xunit;

namespace TosInMemory.Tests;

public class TosInMemoryUnitTest
{
    private readonly IFactory<League> _leagueService;
    private readonly IFactory<Club> _clubService;
    private readonly TosInMemoryContext _tosInMemoryContext;

    public TosInMemoryUnitTest()
    {
        _leagueService = new LeagueService();
        _clubService = new ClubService();
        _tosInMemoryContext = new TosInMemoryContext();

        _leagueService.Generate(100);
        _clubService.Generate(200);
    }

    [Fact]
    public void TestLeagueOk()
    {
        Assert.Equal(100, _tosInMemoryContext.Leagues.Count());
    }


    [Fact]
    public void TestLeagueKo()
    {
        var numberExpectedLeagues = 100;
        var leagues = _leagueService.Generate(numberExpectedLeagues);

        Assert.NotEqual(100, _tosInMemoryContext.Leagues.Count());
    }


    [Fact]
    public void TestClubsOk()
    {
        Assert.Equal(200, _tosInMemoryContext.Clubs.Count());
    }

}
