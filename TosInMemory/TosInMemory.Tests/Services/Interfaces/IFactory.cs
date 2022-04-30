using System.Collections.Generic;
using System.Threading.Tasks;

namespace TosInMemory.Tests.Services.Interfaces
{
	public interface IFactory<T>
	{
		Task<IEnumerable<T>> Generate(int numberOfItems);
	}
}

