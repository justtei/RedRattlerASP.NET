using System;
using System.Collections.Generic;
using UserManagementSystem.DAL;
using UserManagementSystem.Entities;

namespace UserManagementSystem.DAL.Commands
{
	internal class GetEmailTypesCommand : BaseCommand<List<UserManagementSystem.Entities.EmailType>>
	{
		public GetEmailTypesCommand()
		{
		}

		protected override void CommandBody(UMSEntities context)
		{
			List<UserManagementSystem.Entities.EmailType> emailTypes = new List<UserManagementSystem.Entities.EmailType>();
			foreach (UserManagementSystem.DAL.EmailType emailType in (IEnumerable<UserManagementSystem.DAL.EmailType>)context.EmailTypes)
			{
				UserManagementSystem.Entities.EmailType emailType1 = new UserManagementSystem.Entities.EmailType()
				{
					Id = emailType.EmailTypeId,
					Description = emailType.Description
				};
				emailTypes.Add(emailType1);
			}
			this.CommandResult = emailTypes;
		}
	}
}