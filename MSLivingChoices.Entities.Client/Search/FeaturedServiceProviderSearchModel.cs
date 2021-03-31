using MSLivingChoices.Entities.Client;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Entities.Client.Search
{
	[Serializable]
	public class FeaturedServiceProviderSearchModel : SearchModel<List<ServiceProvider>>
	{
		public long? CommunityId
		{
			get;
			set;
		}

		public int MaxCount
		{
			get;
			set;
		}

		public long? ServiceId
		{
			get;
			set;
		}

		public FeaturedServiceProviderSearchModel()
		{
			base.Result = new List<ServiceProvider>();
		}
	}
}