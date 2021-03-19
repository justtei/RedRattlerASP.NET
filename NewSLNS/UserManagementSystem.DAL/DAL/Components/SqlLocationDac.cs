using System;
using System.Collections.Generic;
using UserManagementSystem.DAL.Commands;
using UserManagementSystem.DAL.Interfaces.Components;
using UserManagementSystem.Entities;

namespace UserManagementSystem.DAL.Components
{
	public class SqlLocationDac : ILocationDac
	{
		public SqlLocationDac()
		{
		}

		public List<UserManagementSystem.Entities.Country> GetAllCountries()
		{
			GetCountriesCommand getCountriesCommand = new GetCountriesCommand();
			getCountriesCommand.Execute();
			return getCountriesCommand.CommandResult;
		}

		public List<UserManagementSystem.Entities.State> GetAllStates(int countryId)
		{
			GetStatesCommand getStatesCommand = new GetStatesCommand(countryId);
			getStatesCommand.Execute();
			return getStatesCommand.CommandResult;
		}

		public List<UserManagementSystem.Entities.City> GetCities(int stateId)
		{
			GetCitiesCommand getCitiesCommand = new GetCitiesCommand(stateId);
			getCitiesCommand.Execute();
			return getCitiesCommand.CommandResult;
		}
	}
}