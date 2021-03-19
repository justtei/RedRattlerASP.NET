using System;
using System.Collections.Generic;
using UserManagementSystem.Entities;

namespace UserManagementSystem.DAL.Interfaces.Components
{
	public interface ILocationDac
	{
		List<Country> GetAllCountries();

		List<State> GetAllStates(int countryId);

		List<City> GetCities(int stateId);
	}
}