using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Linq.Expressions;
using UserManagementSystem.DAL;

namespace UserManagementSystem.DAL.Commands
{
	internal class DeleteUserCommand : BaseCommand<bool>
	{
		private readonly Guid _userId;

		public DeleteUserCommand(Guid userId)
		{
			this._userId = userId;
		}

		protected override void CommandBody(UMSEntities context)
		{
			User user = context.Users.SingleOrDefault<User>((User u) => u.UserId == this._userId);
			if (user != null)
			{
				IQueryable<Phone> phones = 
					from p in context.Phones
					where p.UserId == this._userId
					select p;
				foreach (Phone phone in phones)
				{
					context.DeleteObject(phone);
				}
				IQueryable<Email> emails = 
					from p in context.Emails
					where p.UserId == this._userId
					select p;
				foreach (Email email in emails)
				{
					context.DeleteObject(email);
				}
				IQueryable<Address> addresses = 
					from p in context.Addresses
					where p.UserId == this._userId
					select p;
				foreach (Address address in addresses)
				{
					context.DeleteObject(address);
				}
				IQueryable<UserToBook> userToBooks = 
					from p in context.UserToBooks
					where p.UserId == this._userId
					select p;
				foreach (UserToBook userToBook in userToBooks)
				{
					context.DeleteObject(userToBook);
				}
				context.DeleteObject(user);
				this.CommandResult = 1;
			}
			else
			{
				this.CommandResult = 0;
			}
		}
	}
}