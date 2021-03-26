using MSLivingChoices.Entities.Client.Enums;
using MSLivingChoices.Mvc.Uipc.Client.Enums;
using MSLivingChoices.Mvc.Uipc.Enums;
using MSLivingChoices.Utilities;
using System;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace MSLivingChoices.Mvc.Uipc.Client.Helpers
{
	public static class FluentHelper
	{
		public static CommunitySortType FromCommunitySortTypeUrlStr(this string sortType)
		{
			CommunitySortType communitySortType;
			if (sortType == "featured")
			{
				return CommunitySortType.Featured;
			}
			if (sortType == "price-asc")
			{
				return CommunitySortType.PriceAsc;
			}
			if (sortType == "price-desc")
			{
				return CommunitySortType.PriceDesc;
			}
			if (sortType == "beds-desc")
			{
				return CommunitySortType.BedsDesc;
			}
			if (sortType == "baths-desc")
			{
				return CommunitySortType.BathDesc;
			}
			if (sortType == "sqft-desc")
			{
				return CommunitySortType.SqftDesc;
			}
			if (!Enum.TryParse<CommunitySortType>(sortType, out communitySortType))
			{
				return CommunitySortType.Featured;
			}
			return communitySortType;
		}

		public static ServiceProviderSortType FromServiceProviderSortTypeUrlStr(this string sortType)
		{
			ServiceProviderSortType serviceProviderSortType;
			if (sortType == "featured")
			{
				return ServiceProviderSortType.Featured;
			}
			if (sortType == "name-asc")
			{
				return ServiceProviderSortType.NameAsc;
			}
			if (sortType == "name-desc")
			{
				return ServiceProviderSortType.NameDesc;
			}
			if (!Enum.TryParse<ServiceProviderSortType>(sortType, out serviceProviderSortType))
			{
				return ServiceProviderSortType.Featured;
			}
			return serviceProviderSortType;
		}

		public static string FromUrlSectionString(this string str)
		{
			if (!str.IsNullOrEmpty())
			{
				str = Regex.Replace(str.Trim(), "[^a-zA-Z0-9]{1,}", " ").Trim();
			}
			return str;
		}

		public static string RoutePrefix(this PageType pageType)
		{
			switch (pageType)
			{
				case PageType.ShcByType:
				case PageType.ShcByState:
				case PageType.ShcByCity:
				case PageType.ShcByZip:
				case PageType.ShcDetails:
				{
					return "Shc";
				}
				case PageType.AacByType:
				case PageType.AacByState:
				case PageType.AacByCity:
				case PageType.AacByZip:
				case PageType.AacDetails:
				{
					return "Aac";
				}
				case PageType.AahByType:
				case PageType.AahByState:
				case PageType.AahByCity:
				case PageType.AahByZip:
				case PageType.AahDetails:
				{
					return "Aah";
				}
				case PageType.ServiceProvidersByType:
				case PageType.ServiceProvidersByState:
				case PageType.ServiceProvidersByCity:
				case PageType.ServiceProvidersByZip:
				case PageType.ServiceProviderDetails:
				{
					return "ServiceProviders";
				}
			}
			return "Unknown";
		}

		public static string RoutePrefix(this SearchType searchTypeType)
		{
			switch (searchTypeType)
			{
				case SearchType.SeniorHousingAndCare:
				{
					return "Shc";
				}
				case SearchType.ActiveAdultCommunities:
				{
					return "Aac";
				}
				case SearchType.ActiveAdultHomes:
				{
					return "Aah";
				}
				case SearchType.ProductsAndServices:
				{
					return "ServiceProviders";
				}
			}
			return "unknown";
		}

		public static string ToSortTypeUrlStr(this CommunitySortType sortType)
		{
			switch (sortType)
			{
				case CommunitySortType.Featured:
				{
					return "featured";
				}
				case CommunitySortType.PriceAsc:
				{
					return "price-asc";
				}
				case CommunitySortType.PriceDesc:
				{
					return "price-desc";
				}
				case CommunitySortType.BedsDesc:
				{
					return "beds-desc";
				}
				case CommunitySortType.BathDesc:
				{
					return "baths-desc";
				}
				case CommunitySortType.SqftDesc:
				{
					return "sqft-desc";
				}
				default:
				{
					return "featured";
				}
			}
		}

		public static string ToSortTypeUrlStr(this ServiceProviderSortType sortType)
		{
			switch (sortType)
			{
				case ServiceProviderSortType.Featured:
				{
					return "featured";
				}
				case ServiceProviderSortType.NameAsc:
				{
					return "name-asc";
				}
				case ServiceProviderSortType.NameDesc:
				{
					return "name-desc";
				}
			}
			return "featured";
		}

		public static string ToUrlSectionString(this string str)
		{
			if (str.IsNullOrEmpty())
			{
				return null;
			}
			return Regex.Replace(str.FromUrlSectionString(), "[ ]", "-");
		}

		public static string UrlPrefix(this PageType pageType)
		{
			switch (pageType)
			{
				case PageType.ShcByType:
				case PageType.ShcByState:
				case PageType.ShcByCity:
				case PageType.ShcByZip:
				case PageType.ShcDetails:
				{
					return "senior-housing";
				}
				case PageType.AacByType:
				case PageType.AacByState:
				case PageType.AacByCity:
				case PageType.AacByZip:
				case PageType.AacDetails:
				{
					return "communities";
				}
				case PageType.AahByType:
				case PageType.AahByState:
				case PageType.AahByCity:
				case PageType.AahByZip:
				case PageType.AahDetails:
				{
					return "homes";
				}
				case PageType.ServiceProvidersByType:
				case PageType.ServiceProvidersByState:
				case PageType.ServiceProvidersByCity:
				case PageType.ServiceProvidersByZip:
				case PageType.ServiceProviderDetails:
				{
					return "senior-care";
				}
			}
			return "unknown";
		}

		public static string UrlPrefix(this SearchType searchTypeType)
		{
			switch (searchTypeType)
			{
				case SearchType.SeniorHousingAndCare:
				{
					return "senior-housing";
				}
				case SearchType.ActiveAdultCommunities:
				{
					return "communities";
				}
				case SearchType.ActiveAdultHomes:
				{
					return "homes";
				}
				case SearchType.ProductsAndServices:
				{
					return "senior-care";
				}
			}
			return "unknown";
		}
	}
}