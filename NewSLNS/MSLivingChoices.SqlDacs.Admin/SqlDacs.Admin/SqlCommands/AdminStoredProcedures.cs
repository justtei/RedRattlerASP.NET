using System;

namespace MSLivingChoices.SqlDacs.Admin.SqlCommands
{
	internal static class AdminStoredProcedures
	{
		public static string SpGetAdditionalInformationType;

		public static string SpGetAddressType;

		public static string SpGetCallTrackingGridWithPaging;

		public static string SpGetCallTrackingPhones;

		public static string SpGetCities;

		public static string SpGetCityById;

		public static string SpGetCommunityByBook;

		public static string SpGetCommunityDetail;

		public static string SpGetCommunityGridWithPaging;

		public static string SpGetCommunityUnitAmenityType;

		public static string SpGetCommunityUnitDetail;

		public static string SpGetContactType;

		public static string SpGetCounties;

		public static string SpGetCountiesServedForServices;

		public static string SpGetCountries;

		public static string SpGetCountryById;

		public static string SpGetEmailType;

		public static string SpGetUnprocessedImages;

		public static string SpGetOwner;

		public static string SpGetOwnerGridByClass;

		public static string SpGetOwnerGridByClassWithPaging;

		public static string SpGetPhone;

		public static string SpGetPhoneType;

		public static string SpGetSEOData;

		public static string SpGetServiceDetail;

		public static string SpGetServiceGridWithPaging;

		public static string SpGetStateById;

		public static string SpGetUsableCities;

		public static string SpGetUsableCitiesByStateId;

		public static string SpGetUsableCitiesForServices;

		public static string SpGetUsableCountries;

		public static string SpGetUsableStates;

		public static string SpGetUsableStatesForServices;

		public static string SpIsUsersCommunity;

		public static string SpIsUsersService;

		public static string SpDeleteCallTrackingPhones;

		public static string SpDeleteCommunity;

		public static string SpDisconnectCallTrackingPhones;

		public static string SpValidateCallTrackingPhones;

		public static string SpPutAdditionalInformation;

		public static string SpPutAdditionalInformationType;

		public static string SpPutAmenityType;

		public static string SpPutCommunityDetail;

		public static string SpPutCommunityListingType;

		public static string SpPutCommunityUnitDetail;

		public static string SpPutOwner;

		public static string SpPutPhone;

		public static string SpPutSEOData;

		public static string SpPutServiceDetail;

		public static string SpUpdateImage;

		static AdminStoredProcedures()
		{
			AdminStoredProcedures.SpGetAdditionalInformationType = "spGetAdditionalInformationType";
			AdminStoredProcedures.SpGetAddressType = "spGetAddressType";
			AdminStoredProcedures.SpGetCallTrackingGridWithPaging = "spGetCallTrackingGridWithPaging";
			AdminStoredProcedures.SpGetCallTrackingPhones = "spGetCallTrackingPhones";
			AdminStoredProcedures.SpGetCities = "spGetCities";
			AdminStoredProcedures.SpGetCityById = "spGetCityById";
			AdminStoredProcedures.SpGetCommunityByBook = "spGetCommunityByBook";
			AdminStoredProcedures.SpGetCommunityDetail = "spGetCommunityDetail";
			AdminStoredProcedures.SpGetCommunityGridWithPaging = "SpGetCommunityGridWithPagingAndFilters";
			AdminStoredProcedures.SpGetCommunityUnitAmenityType = "spGetCommunityUnitAmenityType";
			AdminStoredProcedures.SpGetCommunityUnitDetail = "spGetCommunityUnitDetail";
			AdminStoredProcedures.SpGetContactType = "spGetContactType";
			AdminStoredProcedures.SpGetCounties = "spGetCounties";
			AdminStoredProcedures.SpGetCountiesServedForServices = "spGetCountiesServedForServices";
			AdminStoredProcedures.SpGetCountries = "spGetCountries";
			AdminStoredProcedures.SpGetCountryById = "spGetCountryById";
			AdminStoredProcedures.SpGetEmailType = "spGetEmailType";
			AdminStoredProcedures.SpGetUnprocessedImages = "spGetUnprocessedImages";
			AdminStoredProcedures.SpGetOwner = "spGetOwner";
			AdminStoredProcedures.SpGetOwnerGridByClass = "spGetOwnerGridByClass";
			AdminStoredProcedures.SpGetOwnerGridByClassWithPaging = "spGetOwnerGridByClassWithPaging";
			AdminStoredProcedures.SpGetPhone = "spGetPhone";
			AdminStoredProcedures.SpGetPhoneType = "spGetPhoneType";
			AdminStoredProcedures.SpGetSEOData = "spGetSEOData";
			AdminStoredProcedures.SpGetServiceDetail = "SpGetServiceDetail";
			AdminStoredProcedures.SpGetServiceGridWithPaging = "spGetServiceGridWithPagingAndFilters";
			AdminStoredProcedures.SpGetStateById = "spGetStateById";
			AdminStoredProcedures.SpGetUsableCities = "spGetUsableCities";
			AdminStoredProcedures.SpGetUsableCitiesByStateId = "spGetUsableCitiesByStateId";
			AdminStoredProcedures.SpGetUsableCitiesForServices = "spGetUsableCitiesForServices";
			AdminStoredProcedures.SpGetUsableCountries = "spGetUsableCountries";
			AdminStoredProcedures.SpGetUsableStates = "spGetUsableStates";
			AdminStoredProcedures.SpGetUsableStatesForServices = "spGetUsableStatesForServices";
			AdminStoredProcedures.SpIsUsersCommunity = "spIsUsersCommunity";
			AdminStoredProcedures.SpIsUsersService = "spIsUsersService";
			AdminStoredProcedures.SpDeleteCallTrackingPhones = "spDeleteCallTrackingPhones";
			AdminStoredProcedures.SpDeleteCommunity = "spDeleteCommunity";
			AdminStoredProcedures.SpDisconnectCallTrackingPhones = "spDisconnectCallTrackingPhones";
			AdminStoredProcedures.SpValidateCallTrackingPhones = "spValidateCallTrackingPhones";
			AdminStoredProcedures.SpPutAdditionalInformation = "spPutAdditionalInformation";
			AdminStoredProcedures.SpPutAdditionalInformationType = "spPutAdditionalInformationType";
			AdminStoredProcedures.SpPutAmenityType = "spPutAmenityType";
			AdminStoredProcedures.SpPutCommunityDetail = "spPutCommunityDetail";
			AdminStoredProcedures.SpPutCommunityListingType = "spPutCommunityListingType";
			AdminStoredProcedures.SpPutCommunityUnitDetail = "spPutCommunityUnitDetail";
			AdminStoredProcedures.SpPutOwner = "spPutOwner";
			AdminStoredProcedures.SpPutPhone = "spPutPhone";
			AdminStoredProcedures.SpPutSEOData = "spPutSEOData";
			AdminStoredProcedures.SpPutServiceDetail = "spPutServiceDetail";
			AdminStoredProcedures.SpUpdateImage = "spUpdateImage";
		}
	}
}