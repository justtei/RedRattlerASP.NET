using MSLivingChoices.Entities.Client.Enums;
using MSLivingChoices.Entities.Client.Search.Criteria;
using System;

namespace MSLivingChoices.IDacs.Client.Components
{
	public interface ISeoDac
	{
		string GetCommunitiesMarketCopy(SearchCriteria criteria, ListingType listingType);

		string GetServiceProvidersMarketCopy(SearchCriteria criteria);
	}
}