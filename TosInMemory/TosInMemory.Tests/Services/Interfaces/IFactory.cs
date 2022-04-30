using System.Collections.Generic;

namespace TosInMemory.Tests.Services.Interfaces
{
	public interface IFactory<T>
	{
		IEnumerable<T> Generate(int numberOfItems);
	}
}

