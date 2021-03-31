using MSLivingChoices.Entities.Client.Search.Criteria;
using MSLivingChoices.Utilities;
using System;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Entities.Client.Search
{
	[Serializable]
	public class CityListingsInfo
	{
		public int AdultCommunitiesCount
		{
			get;
			set;
		}

		public int AdultHomesCount
		{
			get;
			set;
		}

		public MSLivingChoices.Entities.Client.Search.Criteria.SearchCriteria SearchCriteria
		{
			get;
			set;
		}

		public int SeniorHousingCount
		{
			get;
			set;
		}

		public int ServicesCount
		{
			get;
			set;
		}

		public CityListingsInfo()
		{
			this.SearchCriteria = new MSLivingChoices.Entities.Client.Search.Criteria.SearchCriteria();
		}

		public override string ToString()
		{
			return this.SearchCriteria.SafeToString<MSLivingChoices.Entities.Client.Search.Criteria.SearchCriteria>();
		}
	}
}