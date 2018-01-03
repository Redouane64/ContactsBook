using System;
using System.Collections.ObjectModel;
using Contacts.Data;
using Contacts.Models;
using Contacts.ViewModels.Commands;

namespace Contacts.ViewModels
{
	public class ContactsViewModel : ModelBase
	{
		private readonly DummyContactsRepository _repository;

		private ObservableCollection<Contact> _contacts;
		private string _searchQuery = String.Empty;
		private Contact _selectedContact;

		public ContactsViewModel()
		{
			CreateCommand = new RelayCommand(Create, CanCreate);
			EditCommand = new RelayCommand(Edit, CanEdit);
			DeleteCommand = new RelayCommand(Delete, CanDelete);
			SearchCommand = new RelayCommand(Search, CanSearch);

			// TODO: 
			_repository = new DummyContactsRepository();
			FetchContacts();
		}

		public async void FetchContacts()
		{
			Contacts = new ObservableCollection<Contact>(await _repository.GetAllAsync());
		}

		private bool CanCreate(object obj)
		{
			return true;
		}

		private void Create(object obj)
		{
			//throw new NotImplementedException();
		}

		private bool CanEdit(object obj)
		{
			return SelectedContact != null;
		}

		private void Edit(object obj)
		{
			throw new NotImplementedException();
		}

		private bool CanDelete(object obj)
		{
			return SelectedContact != null;
		}

		private void Delete(object obj)
		{
			throw new NotImplementedException();
		}

		private bool CanSearch(object obj)
		{
			return ! String.IsNullOrEmpty(SearchQuery);
		}

		private void Search(object obj)
		{
			throw new NotImplementedException();
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

		public Contact SelectedContact
		{
			get => _selectedContact;
			set
			{
				if (SetProperty(ref _selectedContact, value, nameof(SelectedContact)))
				{
					EditCommand.RaiseCanExecuteChangedEvent();
					DeleteCommand.RaiseCanExecuteChangedEvent();
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
