using System;
using System.Collections.Generic;
using TosInMemory.Tests.Models;
using TosInMemory.Tests.Services.Interfaces;

namespace TosInMemory.Tests.Services
{
	public class ClubService : IFactory<Club>
	{
		private readonly TosInMemoryContext _tosInMemoryContext;
		private readonly Random _random = new Random();

		public ClubService()
		{
			_tosInMemoryContext = new();
		}

        public IEnumerable<Club> Generate(int numberOfItems)
        {
            throw new NotImplementedException();
        }
	}
}

