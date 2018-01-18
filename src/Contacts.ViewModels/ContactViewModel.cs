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

		public event EventHandler<Contact> Complete;
		public event EventHandler Cancel;

		public ContactViewModel()
		{
			CancelCommand = new RelayCommand(Canceling);
			SaveCommand = new RelayCommand<Contact>(Save, CanSave);
			_repository = DummyContactsRepository.Singleton;

		}

		private void Canceling()
		{
			// TODO:
			OnCancel();
		}

		private bool CanSave(Contact parameter)
		{
			// TODO:
			return true;
		}

		private async void Save(Contact parameter)
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

			OnComplete();
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

		public RelayCommand CancelCommand
		{
			get;
		}

		protected virtual void OnComplete()
		{
			Complete?.Invoke(this, _contact);
		}

		protected virtual void OnCancel()
		{
			Cancel?.Invoke(this, EventArgs.Empty);
		}
	}
}
