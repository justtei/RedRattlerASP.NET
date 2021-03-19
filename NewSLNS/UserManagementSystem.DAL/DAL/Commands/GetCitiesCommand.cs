using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using UserManagementSystem.DAL;
using UserManagementSystem.Entities;

namespace UserManagementSystem.DAL.Commands
{
	internal class GetCitiesCommand : BaseCommand<List<UserManagementSystem.Entities.City>>
	{
		private readonly int _stateId;

		public GetCitiesCommand(int stateId)
		{
			this._stateId = stateId;
		}

		protected override void CommandBody(UMSEntities context)
		{
			List<UserManagementSystem.DAL.City> list = (
				from s in context.Cities
				where s.StateId == this._stateId
				select s).ToList<UserManagementSystem.DAL.City>();
			List<UserManagementSystem.Entities.City> cities = new List<UserManagementSystem.Entities.City>();
			foreach (UserManagementSystem.DAL.City city in list)
			{
				UserManagementSystem.Entities.City city1 = new UserManagementSystem.Entities.City()
				{
					Id = city.CityId,
					Name = city.Name
				};
				cities.Add(city1);
			}
			this.CommandResult = cities;
		}
	}
}