using System;

namespace MSLivingChoices.Entities.Client.Search
{
	[Serializable]
	public class CommunitySearchModel : CommunitySearchModel<CommunitySearchResult>
	{
		public CommunitySearchModel()
		{
			base.Result = new CommunitySearchResult();
		}
	}
}