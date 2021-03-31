using System;

namespace MSLivingChoices.SqlDacs.Client.SqlCommands
{
	internal struct ClientStoredProcedures
	{
		public static string SpGetCommunityClientDetail;

		public static string SpGetCommunityUnitsByCommunity;

		public static string SpGetCountryStubCities;

		public static string SpGetFeaturedCommunities;

		public static string SpGetFeaturedServices;

		public static string SpGetServiceClientDetail;

		public static string SpSearchCommunitiesMap;

		public static string SpSearchServicesMap;

		public static string GetSearchAutocompleteVariantsForAddress;

		public static string GetSearchAutocompleteVariantsForZip;

		public static string SpValidateAddress;

		public static string SpValidateZip;

		public static string SpGetCrosslinkCities;

		public static string SpGetMarketCopy;

		public static string SpGetCompetitiveItems;

		public static string SpPutNewLead;

		static ClientStoredProcedures()
		{
			ClientStoredProcedures.SpGetCommunityClientDetail = "spGetCommunityDetailClient";
			ClientStoredProcedures.SpGetCommunityUnitsByCommunity = "spGetCommunityUnitsByCommunity";
			ClientStoredProcedures.SpGetCountryStubCities = "spGetCountryStubCities";
			ClientStoredProcedures.SpGetFeaturedCommunities = "spGetFeaturedCommunities";
			ClientStoredProcedures.SpGetFeaturedServices = "spGetFeaturedServices";
			ClientStoredProcedures.SpGetServiceClientDetail = "SpGetServiceDetailClient";
			ClientStoredProcedures.SpSearchCommunitiesMap = "spSearchCommunities_map";
			ClientStoredProcedures.SpSearchServicesMap = "spSearchServices_map";
			ClientStoredProcedures.GetSearchAutocompleteVariantsForAddress = "spGetSearchAutocompleteVariantsForCity";
			ClientStoredProcedures.GetSearchAutocompleteVariantsForZip = "spGetSearchAutocompleteVariantsForZip";
			ClientStoredProcedures.SpValidateAddress = "spValidateAddress";
			ClientStoredProcedures.SpValidateZip = "spValidateZip";
			ClientStoredProcedures.SpGetCrosslinkCities = "spGetCrosslinkCities";
			ClientStoredProcedures.SpGetMarketCopy = "spGetMarketCopy";
			ClientStoredProcedures.SpGetCompetitiveItems = "spGetPackageItems";
			ClientStoredProcedures.SpPutNewLead = "spPutNewLead";
		}
	}
}