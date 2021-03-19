using MSLivingChoices.Entities.Admin;
using MSLivingChoices.Entities.Admin.Enums;
using System;
using System.Collections.Generic;

namespace MSLivingChoices.IDacs.Admin.Components
{
	public interface IItemTypeDac
	{
		List<KeyValuePair<int, string>> GetAdditionalInfo(AdditionalInfoClass additionalInfoClass);

		List<KeyValuePair<int, string>> GetAddressTypes(CommunityType communityType);

		List<KeyValuePair<int, string>> GetAddressTypes(OwnerType ownerType);

		List<KeyValuePair<int, string>> GetAddressTypes(ServiceType serviceType);

		List<KeyValuePair<int, string>> GetCommunities(int bookId);

		List<KeyValuePair<int, string>> GetContactTypes(CommunityType communityType);

		List<KeyValuePair<int, string>> GetContactTypes(OwnerType ownerType);

		List<KeyValuePair<int, string>> GetContactTypes(ServiceType serviceType);

		KeyValuePair<int, string> GetCouponType();

		KeyValuePair<int, string> GetCustomCommunityServiceType();

		List<KeyValuePair<int, string>> GetEmailTypes(CommunityType communityType);

		List<KeyValuePair<int, string>> GetEmailTypes(OwnerType ownerType);

		List<KeyValuePair<int, string>> GetEmailTypes(ServiceType serviceType);

		KeyValuePair<int, string> GetFeatureType();

		List<KeyValuePair<int, string>> GetPaymentTypes();

		List<KeyValuePair<int, string>> GetPhoneTypes(CommunityType communityType);

		List<KeyValuePair<int, string>> GetPhoneTypes(OwnerType ownerType);

		List<KeyValuePair<int, string>> GetPhoneTypes(ServiceType serviceType);

		KeyValuePair<int, string> GetPublishType();

		List<KeyValuePair<int, string>> GetSHCCategoriesForCommunity();

		List<KeyValuePair<int, string>> GetSHCCategoriesForServiceProvider();

		KeyValuePair<int, string> GetShowcaseType();

		void SaveAdditionalInfo(List<KeyValuePair<int, string>> infos, AdditionalInfoClass additionalInfoClass);

		void SaveDefaultCommunityAmenities(CommunityType communityType, List<Amenity> amenities);

		void SaveDefaultCommunityUnitAmenities(CommunityUnitType communityUnitType, List<Amenity> amenities);
	}
}