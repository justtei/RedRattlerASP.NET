using System;
using System.Collections.Generic;

namespace MSLivingChoices.IDacs.Components
{
	public interface IItemTypeDac
	{
		List<KeyValuePair<int, string>> GetBathrooms();

		List<KeyValuePair<int, string>> GetBedrooms();

		List<KeyValuePair<int, string>> GetCommunityDefaultAmenities();

		List<KeyValuePair<int, string>> GetShcCategoriesForCommunity();

		List<KeyValuePair<int, string>> GetShcCategoriesForServiceProvider();
	}
}