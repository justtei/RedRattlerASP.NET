using MSLivingChoices.Entities.Client.Enums;
using System;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.SqlDacs.Client.Helpers
{
	internal static class SearchTypeExtensions
	{
		public static int GetSearchTypeId(this ListingType? listingType)
		{
			int num = 0;
			ListingType? nullable = listingType;
			if (!nullable.HasValue)
			{
				num = 4;
			}
			else
			{
				switch (nullable.GetValueOrDefault())
				{
					case ListingType.ActiveAdultCommunities:
					{
						num = 2;
						break;
					}
					case ListingType.ActiveAdultHomes:
					{
						num = 3;
						break;
					}
					case ListingType.SeniorHousingAndCare:
					{
						num = 1;
						break;
					}
				}
			}
			return num;
		}

		public static string GetSearchTypeParamName(this ListingType? listingType)
		{
			string str;
			ListingType? nullable = listingType;
			if (nullable.HasValue)
			{
				switch (nullable.GetValueOrDefault())
				{
					case ListingType.ActiveAdultCommunities:
					{
						str = "@HasAdultApartments";
						return str;
					}
					case ListingType.ActiveAdultHomes:
					{
						str = "@HasAdultHomes";
						return str;
					}
					case ListingType.SeniorHousingAndCare:
					{
						str = "@HasSeniorHousing";
						return str;
					}
				}
			}
			str = "@HasServices";
			return str;
		}
	}
}