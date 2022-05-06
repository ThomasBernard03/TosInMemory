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
    private readonly IFactory<Player> _playerService;
    private readonly TosInMemoryContext _tosInMemoryContext;

    public TosInMemoryUnitTest()
    {
        _leagueService = new LeagueService();
        _clubService = new ClubService();
        _playerService = new PlayerService();
        _tosInMemoryContext = new TosInMemoryContext();

    }

    [Fact]
    public void TestGeneration()
    {
        _leagueService.Generate(10);
        Assert.Equal(10, _tosInMemoryContext.Leagues.Count());

        _clubService.Generate(30);
        Assert.Equal(30, _tosInMemoryContext.Clubs.Count());

        _playerService.Generate(200);
        Assert.Equal(200, _tosInMemoryContext.Players.Count());

    }
}
