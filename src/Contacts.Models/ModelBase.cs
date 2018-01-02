using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Contacts.Models
{
    public abstract class ModelBase : INotifyPropertyChanged
    {
		#region INotifyPropertyChanged Implementation
		public event PropertyChangedEventHandler PropertyChanged;

		protected void RaisePropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		#endregion

	}
}
