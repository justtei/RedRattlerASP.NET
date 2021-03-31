using MSLivingChoices.Entities.Client;
using MSLivingChoices.Entities.Client.Enums;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Entities.Client.Search
{
	[Serializable]
	public class FeaturedCommunitySearchModel : SearchModel<List<Community>>
	{
		public MSLivingChoices.Entities.Client.Enums.ListingType ListingType
		{
			get;
			set;
		}

		public int MaxCount
		{
			get;
			set;
		}

		public FeaturedCommunitySearchModel()
		{
		}
	}
}