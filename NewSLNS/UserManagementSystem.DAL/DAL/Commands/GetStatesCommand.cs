using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using UserManagementSystem.DAL;
using UserManagementSystem.Entities;

namespace UserManagementSystem.DAL.Commands
{
	internal class GetStatesCommand : BaseCommand<List<UserManagementSystem.Entities.State>>
	{
		private readonly int? _countryId;

		public GetStatesCommand()
		{
			this._countryId = null;
		}

		public GetStatesCommand(int countryId)
		{
			this._countryId = new int?(countryId);
		}

		protected override void CommandBody(UMSEntities context)
		{
			List<UserManagementSystem.DAL.State> states = (this._countryId.HasValue ? (
				from s in context.States
				where (int?)s.CountryId == this._countryId
				select s).ToList<UserManagementSystem.DAL.State>() : context.States.ToList<UserManagementSystem.DAL.State>());
			List<UserManagementSystem.Entities.State> states1 = new List<UserManagementSystem.Entities.State>();
			foreach (UserManagementSystem.DAL.State state in states)
			{
				UserManagementSystem.Entities.State state1 = new UserManagementSystem.Entities.State()
				{
					Id = state.StateId,
					Name = state.Name,
					Code = state.Code
				};
				states1.Add(state1);
			}
			this.CommandResult = states1;
		}
	}
}