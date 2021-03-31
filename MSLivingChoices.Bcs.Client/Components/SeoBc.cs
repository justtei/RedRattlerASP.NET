using MSLivingChoices.Bcs.Client;
using MSLivingChoices.Entities.Client.Enums;
using MSLivingChoices.Entities.Client.Search.Criteria;
using MSLivingChoices.IDacs.Client;
using MSLivingChoices.IDacs.Client.Components;
using System;

namespace MSLivingChoices.Bcs.Client.Components
{
	public class SeoBc
	{
		private readonly ISeoDac _seoDac;

		private static SeoBc _seoBc;

		private readonly static object Locker;

		public static SeoBc Instance
		{
			get
			{
				if (SeoBc._seoBc == null)
				{
					lock (SeoBc.Locker)
					{
						if (SeoBc._seoBc == null)
						{
							SeoBc._seoBc = new SeoBc();
						}
					}
				}
				return SeoBc._seoBc;
			}
		}

		static SeoBc()
		{
			SeoBc.Locker = new object();
		}

		private SeoBc()
		{
			this._seoDac = ClientDacFactoryClient.GetConcreteFactory().GetSeoDac();
		}

		public string GetCommunityMarketCopy(SearchCriteria criteria, ListingType listingType)
		{
			return this._seoDac.GetCommunitiesMarketCopy(criteria.ToSearchableCriteria(), listingType);
		}

		public string GetServiceProvidersMarketCopy(SearchCriteria criteria)
		{
			return this._seoDac.GetServiceProvidersMarketCopy(criteria.ToSearchableCriteria());
		}
	}
}