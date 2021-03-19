using MSLivingChoices.Entities.Admin;
using MSLivingChoices.Entities.Admin.Enums;
using MSLivingChoices.IDacs.Admin.Components;
using MSLivingChoices.SqlDacs.Admin.SqlCommands;
using MSLivingChoices.SqlDacs.SqlCommands;
using System;
using System.Collections.Generic;

namespace MSLivingChoices.SqlDacs.Admin.Components
{
	public class SqlLocationDac : ILocationDac
	{
		public SqlLocationDac()
		{
		}

		public List<County> GetAllCounties()
		{
			GetCountiesCommand getCountiesCommand = new GetCountiesCommand();
			getCountiesCommand.Execute();
			return getCountiesCommand.CommandResult;
		}

		public List<Country> GetAllCountries()
		{
			GetCountriesCommand getCountriesCommand = new GetCountriesCommand();
			getCountriesCommand.Execute();
			return getCountriesCommand.CommandResult;
		}

		public List<City> GetCities(long? stateId)
		{
			GetCitiesCommand getCitiesCommand = new GetCitiesCommand(stateId);
			getCitiesCommand.Execute();
			return getCitiesCommand.CommandResult;
		}

		public List<City> GetCities(string stateCode, SearchType searchType)
		{
			GetUsableCitiesCommand getUsableCitiesCommand = new GetUsableCitiesCommand(stateCode, searchType);
			getUsableCitiesCommand.Execute();
			return getUsableCitiesCommand.CommandResult;
		}

		public List<City> GetCities(long? stateId, SearchType searchType)
		{
			GetUsableCitiesByStateIdCommand getUsableCitiesByStateIdCommand = new GetUsableCitiesByStateIdCommand(stateId, searchType);
			getUsableCitiesByStateIdCommand.Execute();
			return getUsableCitiesByStateIdCommand.CommandResult;
		}

		public List<City> GetCities(long? stateId, Guid userId)
		{
			return this.GetCities(stateId);
		}

		public List<City> GetCitiesForServices(string stateCode)
		{
			GetUsableCitiesForServicesCommand getUsableCitiesForServicesCommand = new GetUsableCitiesForServicesCommand(stateCode);
			getUsableCitiesForServicesCommand.Execute();
			return getUsableCitiesForServicesCommand.CommandResult;
		}

		public City GetCityById(long? id)
		{
			GetCityByIdCommand getCityByIdCommand = new GetCityByIdCommand(id);
			getCityByIdCommand.Execute();
			return getCityByIdCommand.CommandResult;
		}

		public Country GetCountryById(long? id)
		{
			GetCountryByIdCommand getCountryByIdCommand = new GetCountryByIdCommand(id);
			getCountryByIdCommand.Execute();
			return getCountryByIdCommand.CommandResult;
		}

		public State GetStateById(long? id)
		{
			GetStateByIdCommand getStateByIdCommand = new GetStateByIdCommand(id);
			getStateByIdCommand.Execute();
			return getStateByIdCommand.CommandResult;
		}

		public List<State> GetStates(long? countryId)
		{
			GetStatesCommand getStatesCommand = new GetStatesCommand(countryId);
			getStatesCommand.Execute();
			return getStatesCommand.CommandResult;
		}

		public List<State> GetStates(long? countryId, SearchType searchType)
		{
			GetUsableStatesCommand getUsableStatesCommand = new GetUsableStatesCommand(countryId, searchType);
			getUsableStatesCommand.Execute();
			return getUsableStatesCommand.CommandResult;
		}

		public List<State> GetStates(long? countryId, Guid userId)
		{
			return this.GetStates(countryId);
		}

		public List<State> GetStatesForServices(long? countryId)
		{
			GetUsableStatesForServicesCommand getUsableStatesForServicesCommand = new GetUsableStatesForServicesCommand(countryId);
			getUsableStatesForServicesCommand.Execute();
			return getUsableStatesForServicesCommand.CommandResult;
		}

		public List<Country> GetUsableCountries()
		{
			GetUsableCountriesCommand getUsableCountriesCommand = new GetUsableCountriesCommand();
			getUsableCountriesCommand.Execute();
			return getUsableCountriesCommand.CommandResult;
		}
	}
}