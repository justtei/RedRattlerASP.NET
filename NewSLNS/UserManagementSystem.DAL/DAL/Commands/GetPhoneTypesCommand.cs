using System;
using System.Collections.Generic;
using UserManagementSystem.DAL;
using UserManagementSystem.Entities;

namespace UserManagementSystem.DAL.Commands
{
	internal class GetPhoneTypesCommand : BaseCommand<List<UserManagementSystem.Entities.PhoneType>>
	{
		public GetPhoneTypesCommand()
		{
		}

		protected override void CommandBody(UMSEntities context)
		{
			List<UserManagementSystem.Entities.PhoneType> phoneTypes = new List<UserManagementSystem.Entities.PhoneType>();
			foreach (UserManagementSystem.DAL.PhoneType phoneType in (IEnumerable<UserManagementSystem.DAL.PhoneType>)context.PhoneTypes)
			{
				UserManagementSystem.Entities.PhoneType phoneType1 = new UserManagementSystem.Entities.PhoneType()
				{
					Id = phoneType.PhoneTypeId,
					Description = phoneType.Description
				};
				phoneTypes.Add(phoneType1);
			}
			this.CommandResult = phoneTypes;
		}
	}
}