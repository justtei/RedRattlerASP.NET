using System;
using System.Linq;
using System.Linq.Expressions;
using UserManagementSystem.DAL;

namespace UserManagementSystem.DAL.Commands
{
	internal class SetLeadsCommand : BaseCommand
	{
		private Guid _userId;

		private bool _leadsNotifications;

		public SetLeadsCommand(Guid userId, bool hasLeads)
		{
			this._userId = userId;
			this._leadsNotifications = hasLeads;
		}

		protected override void CommandBody(UMSEntities context)
		{
			User user = context.Users.FirstOrDefault<User>((User u) => u.UserId == this._userId);
			if (user != null)
			{
				user.HasLeadsNotifications = this._leadsNotifications;
			}
		}
	}
}