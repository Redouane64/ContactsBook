using System;
using System.Collections.ObjectModel;
using Contacts.Data;
using Contacts.Models;
using Contacts.ViewModels.Commands;

namespace Contacts.ViewModels
{
	public class ContactsViewModel : ModelBase
	{
		private readonly IContactsRepository _repository;

		private ObservableCollection<Contact> _contacts;
		private Contact _selectedContact;
		private string _searchQuery = String.Empty;

		public event EventHandler<Contact> CreateOrEdit;

		public ContactsViewModel()
		{
			CreateCommand = new RelayCommand(Create, CanCreate);
			EditCommand = new RelayCommand<Contact>(Edit, CanEdit);
			DeleteCommand = new RelayCommand<Contact>(DeleteAsync, CanDelete);
			SearchCommand = new RelayCommand(Search, CanSearch);

			// TODO: 
			_repository = DummyContactsRepository.Singleton;
			FetchContacts();
		}

		public async void FetchContacts()
		{
			Contacts = new ObservableCollection<Contact>(await _repository.GetAllAsync());
		}

		private bool CanCreate()
		{
			return true;
		}

		private void Create()
		{
			CreateOrEdit?.Invoke(this, new Contact() { Id = 0 });
		}

		private bool CanEdit(Contact parameter)
		{
			return SelectedContact != null;
		}

		private void Edit(Contact parameter)
		{
			CreateOrEdit?.Invoke(this, SelectedContact);
		}

		private bool CanDelete(Contact parameter)
		{
			return SelectedContact != null;
		}

		private async void DeleteAsync(Contact parameter)
		{
			await _repository.DeleteAsync(SelectedContact);
			FetchContacts();
		}

		private bool CanSearch()
		{
			return ! String.IsNullOrEmpty(SearchQuery);
		}

		private void Search()
		{
			// TODO:
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
					SearchCommand.OnCanExecuteChanged();
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
					EditCommand.OnCanExecuteChanged();
					DeleteCommand.OnCanExecuteChanged();
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
