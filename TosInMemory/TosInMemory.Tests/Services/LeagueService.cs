using System;
using System.Collections.Generic;
using TosInMemory.Tests.Models;
using TosInMemory.Tests.Services.Interfaces;

namespace TosInMemory.Tests.Services
{
	public class LeagueService : IFactory<League>
	{
		private readonly TosInMemoryContext _tosInMemoryContext;
        private readonly List<string> _leagueNames = new List<string>() { "Ligue 1", "Ligue 2", "Seconde division", "Ligua" };
        private readonly Random _random = new ();

		public LeagueService()
		{
			_tosInMemoryContext = new();
		}

        public IEnumerable<League> Generate(int numberOfItems)
        {
            var leagues = new List<League>();

            for (int i = 0; i < numberOfItems; i++)
            {
                var league = new League() { Name = _leagueNames[_random.Next(_leagueNames.Count)], Country = "France"};
                leagues.Add(league);
            }
            _tosInMemoryContext.AddRange(leagues);
            return leagues;
        }
    }
}

