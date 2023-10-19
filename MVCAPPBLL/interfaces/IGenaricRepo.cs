using System.Collections.Generic;
using System.Threading.Tasks;

namespace MVCAPPBLL.interfaces
{
	public interface IGenaricRepo<T>
	{
		Task<IEnumerable<T>> GetAll();
		Task<T> Get(int id);
		Task Add(T item);
		void Update(T item);
		void Delete(T item);
	}
}
