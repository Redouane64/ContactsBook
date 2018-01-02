using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contacts.Data
{
	public interface IRepository<T> where T: class
    {
		Task<IEnumerable<T>> GetAllAsync();
		Task<T> Get();
		Task AddAsync(T item);
		Task DeleteAsync(T item);
		Task Update(T item);
    }
}
