using System;
using UserManagementSystem.DAL;

namespace UserManagementSystem.DAL.Commands
{
	internal class GetChangePimaryEmailCommand : BaseCommand
	{
		private readonly string _oldPrimaryEmail;

		private readonly string _newPrimaryEmail;

		public GetChangePimaryEmailCommand(string oldPrimaryEmail, string newPrimaryEmail)
		{
			this._oldPrimaryEmail = oldPrimaryEmail;
			this._newPrimaryEmail = newPrimaryEmail;
		}

		protected override void CommandBody(UMSEntities context)
		{
			context.ChangeUserName(this._oldPrimaryEmail, this._newPrimaryEmail);
		}
	}
}