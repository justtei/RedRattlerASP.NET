using System;
using System.Linq;
using System.Linq.Expressions;
using UserManagementSystem.DAL;
using UserManagementSystem.Entities;

namespace UserManagementSystem.DAL.Commands
{
	internal class GetShortenedAccountCommand : BaseCommand<Account>
	{
		private readonly Guid _userId;

		public GetShortenedAccountCommand(Guid userId)
		{
			this._userId = userId;
		}

		protected override void CommandBody(UMSEntities context)
		{
			User user = context.Users.SingleOrDefault<User>((User a) => a.UserId == this._userId);
			if (user == null)
			{
				throw new Exception("Selected null account form DB");
			}
			Account account = new Account()
			{
				Id = user.UserId,
				PrimaryEmail = user.PrimaryEmail,
				FirstName = user.FirstName,
				LastName = user.LastName
			};
			account.CommunicationSettings.HasLeads = user.HasLeadsNotifications;
			account.CommunicationSettings.HasNotifications = user.HasNotifications;
			account.CreateUserId = user.CreateUserId;
			account.CreateDate = user.CreateDate;
			account.ModifyUserId = user.ModifyUserId;
			account.ModifyDate = user.ModifyDate;
			this.CommandResult = account;
		}
	}
}