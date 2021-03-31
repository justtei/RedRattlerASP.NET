using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Entities.Client.Search
{
	[Serializable]
	public class CountryStubSearchModel : SearchModel<List<CityListingsInfo>>
	{
		public bool IsMarketAreaOnly
		{
			get;
			set;
		}

		public int MaxCount
		{
			get;
			set;
		}

		public CountryStubSearchModel()
		{
			base.Result = new List<CityListingsInfo>();
		}
	}
}