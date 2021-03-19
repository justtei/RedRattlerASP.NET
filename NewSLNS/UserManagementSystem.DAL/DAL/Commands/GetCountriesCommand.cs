using System;
using System.Collections.Generic;
using System.Linq;
using UserManagementSystem.DAL;
using UserManagementSystem.Entities;

namespace UserManagementSystem.DAL.Commands
{
	internal class GetCountriesCommand : BaseCommand<List<UserManagementSystem.Entities.Country>>
	{
		public GetCountriesCommand()
		{
		}

		protected override void CommandBody(UMSEntities context)
		{
			List<UserManagementSystem.DAL.Country> list = context.Countries.ToList<UserManagementSystem.DAL.Country>();
			List<UserManagementSystem.Entities.Country> countries = new List<UserManagementSystem.Entities.Country>();
			foreach (UserManagementSystem.DAL.Country country in list)
			{
				UserManagementSystem.Entities.Country country1 = new UserManagementSystem.Entities.Country()
				{
					Id = country.CountryId,
					Name = country.Name,
					Code = country.Code
				};
				countries.Add(country1);
			}
			this.CommandResult = countries;
		}
	}
}