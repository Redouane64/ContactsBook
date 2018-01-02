using System;

using Contacts.Models;
using Contacts.ViewModels.Commands;

namespace Contacts.ViewModels
{
	public class ContactViewModel : ModelBase
	{
		private Contact _contact;

		public ContactViewModel()
		{
			SaveCommand = new RelayCommand(Save, CanSave);
		}

		private bool CanSave(object obj)
		{
			return true;
		}

		private void Save(object obj)
		{
			throw new NotImplementedException();
		}

		public Contact Contact
		{
			get => _contact;
			set
			{
				if (_contact != value)
				{
					_contact = value;
					RaisePropertyChanged(nameof(Contact));
				}
			}
		}

		public RelayCommand SaveCommand
		{
			get;
		}
	}
}
