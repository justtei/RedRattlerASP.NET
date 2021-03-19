using MSLivingChoices.Entities.Client.Search.Criteria;
using System;
using System.Collections.Generic;

namespace MSLivingChoices.IDacs.Client.Components
{
	public interface ILocationDac
	{
		List<SearchCriteria> GetSearchAutocompleteVariantsForAddress(SearchCriteria criteria, int maxCount);

		List<SearchCriteria> GetSearchAutocompleteVariantsForZip(SearchCriteria criteria, int maxCount);

		Dictionary<string, string> GetStates(int countryId);

		SearchCriteria ValidateAddress(SearchCriteria criteria);

		SearchCriteria ValidateZip(SearchCriteria criteria);
	}
}