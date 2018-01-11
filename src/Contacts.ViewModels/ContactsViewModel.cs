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
		private Contact _selectedContact;
		private string _searchQuery = String.Empty;

		public event Action<Contact> OnCreateOrEditRequested;

		public ContactsViewModel()
		{
			CreateCommand = new RelayCommand(Create, CanCreate);
			EditCommand = new RelayCommand(Edit, CanEdit);
			DeleteCommand = new RelayCommand(DeleteAsync, CanDelete);
			SearchCommand = new RelayCommand(Search, CanSearch);

			// TODO: 
			_repository = DummyContactsRepository.Singleton;
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
			OnCreateOrEditRequested?.Invoke(new Contact() { Id = 0 });
		}

		private bool CanEdit(object parameter)
		{
			return SelectedContact != null;
		}

		private void Edit(object parameter)
		{
			OnCreateOrEditRequested?.Invoke(SelectedContact);
		}

		private bool CanDelete(object parameter)
		{
			return SelectedContact != null;
		}

		private async void DeleteAsync(object parameter)
		{
			await _repository.DeleteAsync(SelectedContact);
			FetchContacts();
		}

		private bool CanSearch(object parameter)
		{
			return ! String.IsNullOrEmpty(SearchQuery);
		}

		private void Search(object obj)
		{
			// TO DO:
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
