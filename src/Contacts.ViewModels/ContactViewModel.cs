using Contacts.Models;
using System;
using System.Windows.Input;

namespace Contacts.ViewModels
{
    public class ContactViewModel : ViewModelBase
    {
		public Contact Contact { get; set; }

		public ICommand SaveCommand { get; set; }
	}
}
