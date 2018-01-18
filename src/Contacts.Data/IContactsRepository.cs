using System;
using System.Collections.Generic;
using System.Text;
using Contacts.Models;

namespace Contacts.Data
{
	public interface IContactsRepository : IRepository<Contact>
	{
    }
}
