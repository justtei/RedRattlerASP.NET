using MSLivingChoices.Entities.Client.Search.Criteria;
using MSLivingChoices.Utilities;
using System;
using System.Collections.Generic;

namespace MSLivingChoices.Entities.Client.Utils
{
	public class SearchCriteriaComparer : IEqualityComparer<ISearchCriteria>
	{
		public SearchCriteriaComparer()
		{
		}

		public bool Equals(ISearchCriteria x, ISearchCriteria y)
		{
			return string.Equals(x.ToString(), y.ToString(), StringComparison.InvariantCultureIgnoreCase);
		}

		public int GetHashCode(ISearchCriteria obj)
		{
			return HashCodeHelper.CombineHashCodes(new object[] { obj.CountryCode(), obj.StateCode(), obj.City(), obj.Zip() });
		}
	}
}