using System;
using System.Collections.Generic;
using System.Text;
using Contacts.Models;
using Microsoft.EntityFrameworkCore;

namespace Contacts.Data.EntityFrameworkCore
{
	public class ContactsContext : DbContext
	{
		public const string ConnectionString = "Data Source=contacts.db";

		public ContactsContext(DbContextOptions options) 
			: base(options)
		{
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlite(ConnectionString);
		}

		public DbSet<Contact> Contacts
		{
			get; set;
		}
	}
}
