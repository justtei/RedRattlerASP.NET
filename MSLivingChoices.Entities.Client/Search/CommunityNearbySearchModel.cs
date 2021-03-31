using MSLivingChoices.Entities.Client.Enums;
using System;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Entities.Client.Search
{
	[Serializable]
	public class CommunityNearbySearchModel : NearbySearchModel
	{
		public MSLivingChoices.Entities.Client.Enums.ListingType ListingType
		{
			get;
			set;
		}

		public CommunityNearbySearchModel()
		{
		}
	}
}