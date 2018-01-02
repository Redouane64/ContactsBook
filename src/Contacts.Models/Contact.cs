using System;

namespace Contacts.Models
{
	public class Contact : ModelBase
	{
		private string _firstName;
		private string _lastName;
		private string _email;
		private string _comments;

		public int Id
		{
			get;
			set;
		}
		public string FirstName
		{
			get => _firstName;
			set
			{
				if(!_firstName.Equals(value, StringComparison.OrdinalIgnoreCase))
				{
					_firstName = value;
					RaisePropertyChanged(nameof(FirstName));
				}
			}
		}
		public string LastName
		{
			get => _lastName;
			set
			{
				if (!_lastName.Equals(value, StringComparison.OrdinalIgnoreCase))
				{
					_lastName = value;
					RaisePropertyChanged(nameof(LastName));
				}
			}
		}
		public string Email
		{
			get => _email;
			set
			{
				if (!_email.Equals(value, StringComparison.OrdinalIgnoreCase))
				{
					_email = value;
					RaisePropertyChanged(nameof(Email));
				}
			}
		}
		public string Comments
		{
			get => _comments;
			set
			{
				if (!_comments.Equals(value, StringComparison.OrdinalIgnoreCase))
				{
					_comments = value;
					RaisePropertyChanged(nameof(Comments));
				}
			}
		}
	}
}
