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
				SetProperty(ref _firstName, value, nameof(FirstName));
			}
		}
		public string LastName
		{
			get => _lastName;
			set
			{
				SetProperty(ref _lastName, value, nameof(LastName));
			}
		}
		public string Email
		{
			get => _email;
			set
			{
				SetProperty(ref _email, value, nameof(Email));
			}
		}
		public string Comments
		{
			get => _comments;
			set
			{
				SetProperty(ref _comments, value, nameof(Comments));
			}
		}
	}
}
