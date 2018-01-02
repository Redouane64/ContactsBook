using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contacts.Data
{
	public interface IRepository<T> where T: class
    {
		Task<IEnumerable<T>> GetAll();
		Task<T> Get();
		Task Add(T item);
		Task Delete(T item);
		Task Update(T item);
    }
}
