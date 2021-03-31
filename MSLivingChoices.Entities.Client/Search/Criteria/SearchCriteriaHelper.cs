using MSLivingChoices.Utilities;
using System;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Entities.Client.Search.Criteria
{
	public static class SearchCriteriaHelper
	{
		public static ISearchCriteria City(this ISearchCriteria criteria, string city)
		{
			return criteria.Component("City", city.SafeTrim());
		}

		public static string City(this ISearchCriteria criteria)
		{
			return criteria.Component<string>("City");
		}

		public static ISearchCriteria CountryCode(this ISearchCriteria criteria, string country)
		{
			return criteria.Component("CountryCode", country.SafeTrim());
		}

		public static string CountryCode(this ISearchCriteria criteria)
		{
			return criteria.Component<string>("CountryCode");
		}

		public static ISearchCriteria StateCode(this ISearchCriteria criteria, string state)
		{
			return criteria.Component("StateCode", state.SafeTrim());
		}

		public static string StateCode(this ISearchCriteria criteria)
		{
			return criteria.Component<string>("StateCode");
		}

		public static ISearchCriteria Zip(this ISearchCriteria criteria, string zip)
		{
			return criteria.Component("Zip", zip.SafeTrim());
		}

		public static string Zip(this ISearchCriteria criteria)
		{
			return criteria.Component<string>("Zip");
		}
	}
}