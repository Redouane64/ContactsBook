using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contacts.Models;

namespace Contacts.Data
{
	public class DummyContactsRepository : IContactsRepository
	{
		private static object _syncroot = new object();
		private static DummyContactsRepository _singleton;
		public static DummyContactsRepository Singleton
		{
			get
			{
				lock (_syncroot)
				{
					if (_singleton == null)
					{
						_singleton = new DummyContactsRepository();
					}
				}

				return _singleton;
			}
		}

		private readonly ObservableCollection<Contact> _contacts;

		public DummyContactsRepository()
		{
			_contacts = new ObservableCollection<Contact>(new Contact[]
			{
				new Contact { Id = 0, FirstName = "Mohamed", LastName = "Sobaihi", Email = "mohamed@sobaihi.com", Comments = "." },
				new Contact { Id = 1, FirstName = "Rachid", LastName = "Hamadev", Email = "rachid@hamedev.com", Comments = "." },
				new Contact { Id = 2, FirstName = "Anwar", LastName = "Ali", Email = "anwar@gmail.com", Comments = "." },
				new Contact { Id = 3, FirstName = "Rassim", LastName = "Nahl", Email = "rassim.nahl@live.com", Comments = "." },
				new Contact { Id = 4, FirstName = "Eve", LastName = "Stinger", Email = "eve.sting@gmail.com", Comments = "." },
				new Contact { Id = 5, FirstName = "Redouane", LastName = "Sobaihi", Email = "redouane@sobaihi.com", Comments = "." },
				new Contact { Id = 6, FirstName = "Fathi", LastName = "Ahmed", Email = "ahmed.fethi@gmail.com", Comments = "." }
			});
		}

		public async Task AddAsync(Contact item) => await Task.Run(() => _contacts.Add(item));
		public async Task DeleteAsync(Contact item) => await Task.FromResult(_contacts.Remove(item));
		public Task<Contact> Get() => throw new NotImplementedException();
		public async Task<IEnumerable<Contact>> GetAllAsync() => await Task.FromResult(_contacts.ToArray());
		public Task Update(Contact item) => throw new NotImplementedException();
	}
}
