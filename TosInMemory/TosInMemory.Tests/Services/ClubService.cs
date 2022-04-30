using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TosInMemory.Tests.Models;
using TosInMemory.Tests.Services.Interfaces;

namespace TosInMemory.Tests.Services
{
	public class ClubService : IFactory<Club>
	{
		private readonly TosInMemoryContext _tosInMemoryContext;
		private readonly Random _random = new Random();
        private readonly List<string> _clubsName = new List<string>() { "PSG", "Marseille", "Lyon", "Dijon", "Real", "Barcelone", "St-Etienne" };

		public ClubService()
		{
			_tosInMemoryContext = new();
		}

        public async Task<IEnumerable<Club>> Generate(int numberOfItems)
        {
            var clubs = new List<Club>();

            for (int i = 0; i < numberOfItems; i++)
            {
                var league = _tosInMemoryContext.Leagues.ToList()[_random.Next(_tosInMemoryContext.Leagues.Count())];
                var club = new Club() { Name = _clubsName[_random.Next(_clubsName.Count())], League = league, LeagueId = league.Id, Score = _random.Next(50) };
                clubs.Add(club);
            }
            _tosInMemoryContext.AddRange(clubs);
            await _tosInMemoryContext.SaveChangesAsync();
            return clubs;
        }
	}
}

