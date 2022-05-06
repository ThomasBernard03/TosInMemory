using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TosInMemory.Tests.Models;
using TosInMemory.Tests.Services.Interfaces;

namespace TosInMemory.Tests.Services
{
	public class PlayerService : IFactory<Player>
	{
        private readonly TosInMemoryContext _tosInMemoryContext;
        private readonly Random _random = new();
        private readonly List<string> _names = new List<string>() { "Baptiste", "Thibaut", "Thomas", "Tristan", "Quentin", "Teddy", "Alexis", "Clément", "Aurélien" };

        public PlayerService()
		{
            _tosInMemoryContext = new TosInMemoryContext();
        }

        public IEnumerable<Player> Generate(int numberOfItems)
        {
            try
            {
                var players = new List<Player>();
                var clubs = _tosInMemoryContext.Clubs.ToList();

                for (int i = 0; i < numberOfItems; i++)
                {
                    var club = clubs[_random.Next(clubs.Count - 1)];
                    var player = new Player()
                    {
                        Club = club,
                        ClubId = club.Id,
                        Number = _random.Next(1, 99),
                        Firstname = _names[_random.Next(_names.Count())],
                        Lastname = _names[_random.Next(_names.Count())]
                    };

                    players.Add(player);
                }
                _tosInMemoryContext.AddRange(players);
                _tosInMemoryContext.SaveChanges();
                return players;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
            return null;
        }
    }
}

