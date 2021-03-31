using MSLivingChoices.Entities.Client.Search.Criteria;
using MSLivingChoices.IDacs.Client.Components;
using MSLivingChoices.SqlDacs.Client.SqlCommands;
using MSLivingChoices.SqlDacs.SqlCommands;
using System;
using System.Collections.Generic;

namespace MSLivingChoices.SqlDacs.Client.Components
{
	public class SqlLocationDac : ILocationDac
	{
		public SqlLocationDac()
		{
		}

		public List<SearchCriteria> GetSearchAutocompleteVariantsForAddress(SearchCriteria criteria, int maxCount)
		{
			GetAddressAutocompleteCommand getAddressAutocompleteCommand = new GetAddressAutocompleteCommand(criteria, maxCount);
			getAddressAutocompleteCommand.Execute();
			return getAddressAutocompleteCommand.CommandResult;
		}

		public List<SearchCriteria> GetSearchAutocompleteVariantsForZip(SearchCriteria criteria, int maxCount)
		{
			GetZipAutocompleteCommand getZipAutocompleteCommand = new GetZipAutocompleteCommand(criteria, maxCount);
			getZipAutocompleteCommand.Execute();
			return getZipAutocompleteCommand.CommandResult;
		}

		public Dictionary<string, string> GetStates(int countryId)
		{
			GetStatesCommand getStatesCommand = new GetStatesCommand(new long?((long)countryId));
			getStatesCommand.Execute();
			return getStatesCommand.CommandResult;
		}

		public SearchCriteria ValidateAddress(SearchCriteria criteria)
		{
			ValidateAddressCommand validateAddressCommand = new ValidateAddressCommand(criteria);
			validateAddressCommand.Execute();
			return validateAddressCommand.CommandResult;
		}

		public SearchCriteria ValidateZip(SearchCriteria criteria)
		{
			ValidateZipCommand validateZipCommand = new ValidateZipCommand(criteria);
			validateZipCommand.Execute();
			return validateZipCommand.CommandResult;
		}
	}
}