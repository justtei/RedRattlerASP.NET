using System;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Entities.Client.Search
{
	[Serializable]
	public class NearbySearchModel : SearchModel<NearbySearchResult>
	{
		public int MaxCount
		{
			get;
			set;
		}

		public NearbySearchModel()
		{
			base.Result = new NearbySearchResult();
		}
	}
}