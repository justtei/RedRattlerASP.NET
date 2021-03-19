using MSLivingChoices.Entities.Admin;
using MSLivingChoices.Entities.Admin.Enums;
using System;
using System.Collections.Generic;

namespace MSLivingChoices.IDacs.Admin.Components
{
	public interface ILocationDac
	{
		List<County> GetAllCounties();

		List<Country> GetAllCountries();

		List<City> GetCities(long? stateId);

		List<City> GetCities(string stateCode, SearchType searchType);

		List<City> GetCities(long? stateId, SearchType searchType);

		List<City> GetCities(long? stateId, Guid userId);

		List<City> GetCitiesForServices(string stateCode);

		City GetCityById(long? id);

		Country GetCountryById(long? id);

		State GetStateById(long? id);

		List<State> GetStates(long? countryId);

		List<State> GetStates(long? countryId, SearchType searchType);

		List<State> GetStates(long? countryId, Guid userId);

		List<State> GetStatesForServices(long? countryId);

		List<Country> GetUsableCountries();
	}
}