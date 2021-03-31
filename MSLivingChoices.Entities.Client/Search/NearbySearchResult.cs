using MSLivingChoices.Entities.Client.Enums;
using MSLivingChoices.Entities.Client.Search.Criteria;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Entities.Client.Search
{
	[Serializable]
	public class NearbySearchResult
	{
		public List<ListingType> AvailableListingTypes
		{
			get;
			set;
		}

		public bool IsServiceProvidersAvailable
		{
			get;
			set;
		}

		public List<SearchCriteria> NearbyCities
		{
			get;
			set;
		}

		public NearbySearchResult()
		{
			this.NearbyCities = new List<SearchCriteria>();
			this.AvailableListingTypes = new List<ListingType>();
		}
	}
}