using MSLivingChoices.Bcs.Admin;
using MSLivingChoices.Entities.Admin;
using MSLivingChoices.Entities.Admin.Enums;
using MSLivingChoices.IDacs.Admin;
using MSLivingChoices.IDacs.Admin.Components;
using System;
using System.Collections.Generic;

namespace MSLivingChoices.Bcs.Admin.Components
{
	public class ItemTypeBc
	{
		private readonly IItemTypeDac _itemTypeDac;

		private static ItemTypeBc _itemTypeBc;

		private readonly static object Locker;

		public static ItemTypeBc Instance
		{
			get
			{
				if (ItemTypeBc._itemTypeBc == null)
				{
					lock (ItemTypeBc.Locker)
					{
						if (ItemTypeBc._itemTypeBc == null)
						{
							ItemTypeBc._itemTypeBc = new ItemTypeBc();
						}
					}
				}
				return ItemTypeBc._itemTypeBc;
			}
		}

		static ItemTypeBc()
		{
			ItemTypeBc.Locker = new object();
		}

		private ItemTypeBc()
		{
			this._itemTypeDac = AdminDacFactoryClient.GetConcreteFactory().GetItemTypeDac();
		}

		public List<KeyValuePair<int, string>> GetAdditionalInfo(AdditionalInfoClass additionalInfoClass)
		{
			return this._itemTypeDac.GetAdditionalInfo(additionalInfoClass);
		}

		public List<KeyValuePair<int, string>> GetAddressTypes(CommunityType communityType)
		{
			return this._itemTypeDac.GetAddressTypes(communityType);
		}

		public List<KeyValuePair<int, string>> GetAddressTypes(OwnerType ownerType)
		{
			return this._itemTypeDac.GetAddressTypes(ownerType);
		}

		public List<KeyValuePair<int, string>> GetAddressTypes(ServiceType serviceType)
		{
			return this._itemTypeDac.GetAddressTypes(serviceType);
		}

		public List<KeyValuePair<int, string>> GetCommunities(int bookId)
		{
			return this._itemTypeDac.GetCommunities(bookId);
		}

		public List<KeyValuePair<int, string>> GetContactTypes(CommunityType communityType)
		{
			return this._itemTypeDac.GetContactTypes(communityType);
		}

		public List<KeyValuePair<int, string>> GetContactTypes(OwnerType ownerType)
		{
			return this._itemTypeDac.GetContactTypes(ownerType);
		}

		public List<KeyValuePair<int, string>> GetContactTypes(ServiceType serviceType)
		{
			return this._itemTypeDac.GetContactTypes(serviceType);
		}

		public KeyValuePair<int, string> GetCouponType()
		{
			return this._itemTypeDac.GetCouponType();
		}

		public KeyValuePair<int, string> GetCustomCommunityServiceType()
		{
			return this._itemTypeDac.GetCustomCommunityServiceType();
		}

		public List<KeyValuePair<int, string>> GetEmailTypes(CommunityType communityType)
		{
			return this._itemTypeDac.GetEmailTypes(communityType);
		}

		public List<KeyValuePair<int, string>> GetEmailTypes(OwnerType ownerType)
		{
			return this._itemTypeDac.GetEmailTypes(ownerType);
		}

		public List<KeyValuePair<int, string>> GetEmailTypes(ServiceType serviceType)
		{
			return this._itemTypeDac.GetEmailTypes(serviceType);
		}

		public KeyValuePair<int, string> GetFeatureType()
		{
			return this._itemTypeDac.GetFeatureType();
		}

		public List<KeyValuePair<int, string>> GetPaymentTypes()
		{
			return this._itemTypeDac.GetPaymentTypes();
		}

		public List<KeyValuePair<int, string>> GetPhoneTypes(CommunityType communityType)
		{
			return this._itemTypeDac.GetPhoneTypes(communityType);
		}

		public List<KeyValuePair<int, string>> GetPhoneTypes(OwnerType ownerType)
		{
			return this._itemTypeDac.GetPhoneTypes(ownerType);
		}

		public List<KeyValuePair<int, string>> GetPhoneTypes(ServiceType serviceType)
		{
			return this._itemTypeDac.GetPhoneTypes(serviceType);
		}

		public KeyValuePair<int, string> GetPublishType()
		{
			return this._itemTypeDac.GetPublishType();
		}

		public List<KeyValuePair<int, string>> GetSHCCategoriesForCommunity()
		{
			return this._itemTypeDac.GetSHCCategoriesForCommunity();
		}

		public List<KeyValuePair<int, string>> GetSHCCategoriesForServiceProvider()
		{
			return this._itemTypeDac.GetSHCCategoriesForServiceProvider();
		}

		public KeyValuePair<int, string> GetShowcaseType()
		{
			return this._itemTypeDac.GetShowcaseType();
		}

		public void SaveAdditionalInfos(AdditionalInfoClass additionalInfoClass, List<KeyValuePair<int, string>> infos)
		{
			this._itemTypeDac.SaveAdditionalInfo(infos, additionalInfoClass);
		}

		public void SaveDefaultCommunityAmenities(CommunityType communityType, List<Amenity> amenities)
		{
			this._itemTypeDac.SaveDefaultCommunityAmenities(communityType, amenities);
		}

		public void SaveDefaultCommunityUnitAmenities(CommunityUnitType communityUnitType, List<Amenity> amenities)
		{
			this._itemTypeDac.SaveDefaultCommunityUnitAmenities(communityUnitType, amenities);
		}
	}
}