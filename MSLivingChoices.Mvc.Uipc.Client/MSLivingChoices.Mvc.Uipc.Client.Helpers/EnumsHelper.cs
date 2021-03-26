using MSLivingChoices.Entities.Client.Enums;
using MSLivingChoices.Mvc.Uipc.Client.Enums;
using MSLivingChoices.Mvc.Uipc.Enums;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Mvc.Uipc.Client.Helpers
{
	public static class EnumsHelper
	{
		public static bool IsStaticPage(this PageType pageType)
		{
			if (pageType != PageType.Index && (int)pageType - (int)PageType.PrivacyPolicy > (int)PageType.ShcByState)
			{
				return false;
			}
			if(pageType == PageType.ShcByCity)
            {
				return false;
            }
			return true;
		}

		public static ListingType ToListingType(this SearchType searchTypeType)
		{
			switch (searchTypeType)
			{
				case SearchType.SeniorHousingAndCare:
				{
					return ListingType.SeniorHousingAndCare;
				}
				case SearchType.ActiveAdultCommunities:
				{
					return ListingType.ActiveAdultCommunities;
				}
				case SearchType.ActiveAdultHomes:
				{
					return ListingType.ActiveAdultHomes;
				}
			}
			throw new IndexOutOfRangeException(string.Format("Can't convert from '{0}' search type to appropriate community listing type.", searchTypeType));
		}

		public static RefineType ToRefineType(this PageType pageType)
		{
			switch (pageType)
			{
				case PageType.ShcByState:
				case PageType.ShcByCity:
				{
					return RefineType.SeniorHousing;
				}
				case PageType.ShcByZip:
				case PageType.AacByType:
				case PageType.AacByZip:
				case PageType.AahByType:
				case PageType.AahByZip:
				case PageType.ServiceProvidersByType:
				{
					return RefineType.Empty;
				}
				case PageType.AacByState:
				case PageType.AacByCity:
				{
					return RefineType.ActiveCommunity;
				}
				case PageType.AahByState:
				case PageType.AahByCity:
				{
					return RefineType.ActiveHome;
				}
				case PageType.ServiceProvidersByState:
				case PageType.ServiceProvidersByCity:
				{
					return RefineType.Service;
				}
				default:
				{
					return RefineType.Empty;
				}
			}
		}

		public static SearchDepth ToSearchDepth(this PageType pageType)
		{
			switch (pageType)
			{
				case PageType.ShcByType:
				case PageType.AacByType:
				case PageType.AahByType:
				case PageType.ServiceProvidersByType:
				{
					return SearchDepth.Country;
				}
				case PageType.ShcByState:
				case PageType.AacByState:
				case PageType.AahByState:
				case PageType.ServiceProvidersByState:
				{
					return SearchDepth.State;
				}
				case PageType.ShcByCity:
				case PageType.AacByCity:
				case PageType.AahByCity:
				case PageType.ServiceProvidersByCity:
				{
					return SearchDepth.City;
				}
				case PageType.ShcByZip:
				case PageType.AacByZip:
				case PageType.AahByZip:
				case PageType.ServiceProvidersByZip:
				{
					return SearchDepth.Zip;
				}
			}
			return SearchDepth.Invalid;
		}

		public static SearchType ToSearchType(this PageType pageType)
		{
			switch (pageType)
			{
				case PageType.ShcByType:
				case PageType.ShcByState:
				case PageType.ShcByCity:
				case PageType.ShcByZip:
				case PageType.ShcDetails:
				{
					return SearchType.SeniorHousingAndCare;
				}
				case PageType.AacByType:
				case PageType.AacByState:
				case PageType.AacByCity:
				case PageType.AacByZip:
				case PageType.AacDetails:
				{
					return SearchType.ActiveAdultCommunities;
				}
				case PageType.AahByType:
				case PageType.AahByState:
				case PageType.AahByCity:
				case PageType.AahByZip:
				case PageType.AahDetails:
				{
					return SearchType.ActiveAdultHomes;
				}
				case PageType.ServiceProvidersByType:
				case PageType.ServiceProvidersByState:
				case PageType.ServiceProvidersByCity:
				case PageType.ServiceProvidersByZip:
				case PageType.ServiceProviderDetails:
				{
					return SearchType.ProductsAndServices;
				}
			}
			return SearchType.SeniorHousingAndCare;
		}

		public static SearchType ToSearchType(this ListingType listingType)
		{
			switch (listingType)
			{
				case ListingType.ActiveAdultCommunities:
				{
					return SearchType.ActiveAdultCommunities;
				}
				case ListingType.ActiveAdultHomes:
				{
					return SearchType.ActiveAdultHomes;
				}
				case ListingType.SeniorHousingAndCare:
				{
					return SearchType.SeniorHousingAndCare;
				}
			}
			throw new IndexOutOfRangeException(string.Format("Can't convert from '{0}' community listing type to appropriate search type.", listingType));
		}

		public static SearchType ToSearchType(this List<ListingType> listingTypes)
		{
			SearchType searchType = SearchType.ActiveAdultHomes;
			if (listingTypes.Contains(ListingType.SeniorHousingAndCare))
			{
				searchType = SearchType.SeniorHousingAndCare;
			}
			else if (listingTypes.Contains(ListingType.ActiveAdultCommunities))
			{
				searchType = SearchType.ActiveAdultCommunities;
			}
			return searchType;
		}

		public static bool TryToListingType(this SearchType searchTypeType, out ListingType type)
		{
			switch (searchTypeType)
			{
				case SearchType.SeniorHousingAndCare:
				{
					type = ListingType.SeniorHousingAndCare;
					break;
				}
				case SearchType.ActiveAdultCommunities:
				{
					type = ListingType.ActiveAdultCommunities;
					break;
				}
				case SearchType.ActiveAdultHomes:
				{
					type = ListingType.ActiveAdultHomes;
					break;
				}
				default:
				{
					type = (ListingType)0;
					return false;
				}
			}
			return true;
		}
	}
}