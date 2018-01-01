using Contacts.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace Contacts.ViewModels
{
    public class MasterPageViewModel : ViewModelBase
    {
		public ObservableCollection<Contact> Contacts { get; set; }
		public string SearchQuery { get; set; }

		public ICommand Search { get; set; }
		public ICommand EditCommand { get; set; }
		public ICommand DeleteCommand { get; set; }
		public ICommand CreateCommand { get; set; }
	}
}
