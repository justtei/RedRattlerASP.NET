using MSLivingChoices.Entities.Client.Search.Criteria;
using MSLivingChoices.Mvc.Uipc.Enums;
using System;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Mvc.Uipc.Client.Helpers
{
	public static class SearchCriteriaVmHelper
	{
		public static ISearchCriteria SearchType(this ISearchCriteria criteria, SearchType searchType)
		{
			return criteria.Component("SearchType", searchType);
		}

		public static SearchType SearchType(this ISearchCriteria criteria)
		{
			return criteria.Component<SearchType>("SearchType");
		}
	}
}