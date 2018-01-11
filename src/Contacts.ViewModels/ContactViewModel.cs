using System;
using System.Linq;
using Contacts.Data;
using Contacts.Models;
using Contacts.ViewModels.Commands;

namespace Contacts.ViewModels
{
	public class ContactViewModel : ModelBase
	{
		private readonly DummyContactsRepository _repository;

		private Contact _contact;

		public event Action OnCompleted;

		public ContactViewModel()
		{
			SaveCommand = new RelayCommand(Save, CanSave);
			_repository = DummyContactsRepository.Singleton;

		}

		private bool CanSave(object obj)
		{
			return true;
		}

		private async void Save(object obj)
		{
			if (_contact.Id == 0)
			{
				// New 
				_contact.Id = (await _repository.GetAllAsync()).Max(c => c.Id) + 1;
				await _repository.AddAsync(_contact);
			}
			else
			{
				// Edit
				await _repository.DeleteAsync(_contact);
				await _repository.AddAsync(Contact);
			}

			OnCompleted?.Invoke();
		}

		public Contact Contact
		{
			get => _contact;
			set
			{
				SetProperty(ref _contact, value, nameof(Contact));
			}
		}

		public RelayCommand SaveCommand
		{
			get;
		}

	}
}
