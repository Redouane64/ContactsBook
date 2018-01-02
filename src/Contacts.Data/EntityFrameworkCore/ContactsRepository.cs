using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Contacts.Models;
using Microsoft.EntityFrameworkCore;

namespace Contacts.Data.EntityFrameworkCore
{
	public class ContactsRepository : IRepository<Contact>
	{
		private readonly DbContext _dbContext;

		public ContactsRepository(DbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public Task AddAsync(Contact item)
		{
			throw new NotImplementedException();
		}

		public Task DeleteAsync(Contact item)
		{
			throw new NotImplementedException();
		}

		public Task<Contact> Get()
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<Contact>> GetAllAsync()
		{
			throw new NotImplementedException();
		}

		public Task Update(Contact item)
		{
			throw new NotImplementedException();
		}
	}
}
