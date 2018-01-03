using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contacts.Models;

namespace Contacts.ViewModels
{
	public class MainWindowViewModel : ModelBase
	{
		private ContactViewModel _contactViewModel;
		private ContactsViewModel _contactsViewModel;

		public MainWindowViewModel()
		{
			_contactsViewModel = new ContactsViewModel();
			_contactViewModel = new ContactViewModel();
		}

		public ContactViewModel ContactViewModel
		{
			get => _contactViewModel;
			set
			{
				_contactViewModel = value;
			}
		}

		public ContactsViewModel ContactsViewModel
		{
			get => _contactsViewModel;
			set
			{
				_contactsViewModel = value;
			}
		}
	}
}
