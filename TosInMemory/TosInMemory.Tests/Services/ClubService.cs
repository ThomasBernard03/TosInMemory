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

        public IEnumerable<Club> Generate(int numberOfItems)
        {
            var clubs = new List<Club>();
            var leagues = _tosInMemoryContext.Leagues.ToList();

            for (int i = 0; i < numberOfItems; i++)
            {
                var league = leagues[_random.Next(_tosInMemoryContext.Leagues.Count() - 1)];
                var club = new Club() { Name = _clubsName[_random.Next(_clubsName.Count() - 1)], League = league, LeagueId = league.Id, Score = _random.Next(50) };
                clubs.Add(club);
            }
            _tosInMemoryContext.AddRange(clubs);
            _tosInMemoryContext.SaveChanges();
            return clubs;
        }
	}
}

