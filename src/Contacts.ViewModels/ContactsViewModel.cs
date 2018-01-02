using System;
using System.Collections.ObjectModel;

using Contacts.Models;
using Contacts.ViewModels.Commands;

namespace Contacts.ViewModels
{
	public class ContactsViewModel : ModelBase
	{
		private ObservableCollection<Contact> _contacts;
		private string _searchQuery = String.Empty;

		// TODO: Initialize commands.

		public ContactsViewModel()
		{
			
		}

		public ObservableCollection<Contact> Contacts
		{
			get => _contacts;
			set
			{
				SetProperty(ref _contacts, value, nameof(Contacts));
			}
		}
		public string SearchQuery
		{
			get => _searchQuery;
			set
			{
				if (SetProperty(ref _searchQuery, value, nameof(SearchQuery)))
				{
					SearchCommand.RaiseCanExecuteChangedEvent();
				}
			}
		}

		public RelayCommand SearchCommand
		{
			get;
		}
		public RelayCommand EditCommand
		{
			get;
		}
		public RelayCommand DeleteCommand
		{
			get;
		}
		public RelayCommand CreateCommand
		{
			get;
		}
	}
}
