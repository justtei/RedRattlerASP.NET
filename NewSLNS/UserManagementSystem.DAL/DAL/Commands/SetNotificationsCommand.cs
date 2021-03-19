using System;
using System.Linq;
using System.Linq.Expressions;
using UserManagementSystem.DAL;

namespace UserManagementSystem.DAL.Commands
{
	internal class SetNotificationsCommand : BaseCommand
	{
		private Guid _userId;

		private bool _notifications;

		public SetNotificationsCommand(Guid userId, bool hasNotifications)
		{
			this._userId = userId;
			this._notifications = hasNotifications;
		}

		protected override void CommandBody(UMSEntities context)
		{
			User user = context.Users.FirstOrDefault<User>((User u) => u.UserId == this._userId);
			if (user != null)
			{
				user.HasNotifications = this._notifications;
			}
		}
	}
}