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
		public static MainWindowViewModel Singleton
		{
			get;
			private set;
		}

		private readonly ContactsViewModel _contactsViewModel;
		private readonly ContactViewModel _contactViewModel;
		private ModelBase _currentViewModel;

		public MainWindowViewModel()
		{
			Singleton = this;

			CurrentViewModel = _contactsViewModel = new ContactsViewModel();
			_contactsViewModel.CreateOrEdit += new EventHandler<Contact>(OnCreateOrEditContactRequested);

			_contactViewModel = new ContactViewModel();
			_contactViewModel.Complete += new EventHandler<Contact>(delegate (object sender, Contact contact)
			{
				_contactsViewModel.FetchContacts();
				CurrentViewModel = _contactsViewModel;
			});

			_contactViewModel.Cancel += new EventHandler((delegate (object sender, EventArgs args)
				{
					CurrentViewModel = _contactsViewModel;
				}));
		}

		private void OnCreateOrEditContactRequested(object sender, Contact contact)
		{
			CreateOrEditContact(contact);
		}

		public ModelBase CurrentViewModel
		{
			get => _currentViewModel;
			set
			{
				SetProperty(ref _currentViewModel, value, nameof(CurrentViewModel));
			}
		}

		public void CreateOrEditContact(Contact contact = null)
		{
			if (contact == null)
			{
				CurrentViewModel = _contactViewModel;
				return;
			}

			_contactViewModel.Contact = contact;
			CurrentViewModel = _contactViewModel;
		}
	}
}
