using MSLivingChoices.Entities.Admin;
using MSLivingChoices.Entities.Admin.Enums;
using MSLivingChoices.IDacs.Admin.Components;
using MSLivingChoices.SqlDacs.Admin.SqlCommands;
using MSLivingChoices.SqlDacs.SqlCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.SqlDacs.Admin.Components
{
	public class SqlItemTypeDac : IItemTypeDac
	{
		public SqlItemTypeDac()
		{
		}

		public List<KeyValuePair<int, string>> GetAdditionalInfo(AdditionalInfoClass additionalInfoClass)
		{
			GetAdditionalInfoCommand getAdditionalInfoCommand = new GetAdditionalInfoCommand(additionalInfoClass);
			getAdditionalInfoCommand.Execute();
			return getAdditionalInfoCommand.CommandResult;
		}

		public List<KeyValuePair<int, string>> GetAddressTypes(CommunityType communityType)
		{
			GetAddressTypesCommand getAddressTypesCommand = new GetAddressTypesCommand(communityType);
			getAddressTypesCommand.Execute();
			return getAddressTypesCommand.CommandResult;
		}

		public List<KeyValuePair<int, string>> GetAddressTypes(OwnerType ownerType)
		{
			GetAddressTypesCommand getAddressTypesCommand = new GetAddressTypesCommand(ownerType);
			getAddressTypesCommand.Execute();
			return getAddressTypesCommand.CommandResult;
		}

		public List<KeyValuePair<int, string>> GetAddressTypes(ServiceType serviceType)
		{
			GetAddressTypesCommand getAddressTypesCommand = new GetAddressTypesCommand(serviceType);
			getAddressTypesCommand.Execute();
			return getAddressTypesCommand.CommandResult;
		}

		public List<KeyValuePair<int, string>> GetCommunities(int bookId)
		{
			GetCommunityByUserCommand getCommunityByUserCommand = new GetCommunityByUserCommand(bookId);
			getCommunityByUserCommand.Execute();
			return getCommunityByUserCommand.CommandResult;
		}

		public List<KeyValuePair<int, string>> GetContactTypes(CommunityType communityType)
		{
			GetContactTypesCommand getContactTypesCommand = new GetContactTypesCommand(communityType);
			getContactTypesCommand.Execute();
			return getContactTypesCommand.CommandResult;
		}

		public List<KeyValuePair<int, string>> GetContactTypes(OwnerType ownerType)
		{
			GetContactTypesCommand getContactTypesCommand = new GetContactTypesCommand(ownerType);
			getContactTypesCommand.Execute();
			return getContactTypesCommand.CommandResult;
		}

		public List<KeyValuePair<int, string>> GetContactTypes(ServiceType serviceType)
		{
			GetContactTypesCommand getContactTypesCommand = new GetContactTypesCommand(serviceType);
			getContactTypesCommand.Execute();
			return getContactTypesCommand.CommandResult;
		}

		public KeyValuePair<int, string> GetCouponType()
		{
			return this.GetAdditionalInfo(AdditionalInfoClass.Coupon).First<KeyValuePair<int, string>>();
		}

		public KeyValuePair<int, string> GetCustomCommunityServiceType()
		{
			return this.GetAdditionalInfo(AdditionalInfoClass.Service).First<KeyValuePair<int, string>>((KeyValuePair<int, string> s) => s.Value == "Custom Community Service");
		}

		public List<KeyValuePair<int, string>> GetEmailTypes(CommunityType communityType)
		{
			GetEmailTypesCommand getEmailTypesCommand = new GetEmailTypesCommand(communityType);
			getEmailTypesCommand.Execute();
			return getEmailTypesCommand.CommandResult;
		}

		public List<KeyValuePair<int, string>> GetEmailTypes(OwnerType ownerType)
		{
			GetEmailTypesCommand getEmailTypesCommand = new GetEmailTypesCommand(ownerType);
			getEmailTypesCommand.Execute();
			return getEmailTypesCommand.CommandResult;
		}

		public List<KeyValuePair<int, string>> GetEmailTypes(ServiceType serviceType)
		{
			GetEmailTypesCommand getEmailTypesCommand = new GetEmailTypesCommand(serviceType);
			getEmailTypesCommand.Execute();
			return getEmailTypesCommand.CommandResult;
		}

		public KeyValuePair<int, string> GetFeatureType()
		{
			return this.GetAdditionalInfo(AdditionalInfoClass.Feature).First<KeyValuePair<int, string>>();
		}

		public List<KeyValuePair<int, string>> GetPaymentTypes()
		{
			return this.GetAdditionalInfo(AdditionalInfoClass.Payment);
		}

		public List<KeyValuePair<int, string>> GetPhoneTypes(CommunityType communityType)
		{
			GetPhoneTypesCommand getPhoneTypesCommand = new GetPhoneTypesCommand(communityType);
			getPhoneTypesCommand.Execute();
			return getPhoneTypesCommand.CommandResult;
		}

		public List<KeyValuePair<int, string>> GetPhoneTypes(OwnerType ownerType)
		{
			GetPhoneTypesCommand getPhoneTypesCommand = new GetPhoneTypesCommand(ownerType);
			getPhoneTypesCommand.Execute();
			return getPhoneTypesCommand.CommandResult;
		}

		public List<KeyValuePair<int, string>> GetPhoneTypes(ServiceType serviceType)
		{
			GetPhoneTypesCommand getPhoneTypesCommand = new GetPhoneTypesCommand(serviceType);
			getPhoneTypesCommand.Execute();
			return getPhoneTypesCommand.CommandResult;
		}

		public KeyValuePair<int, string> GetPublishType()
		{
			return this.GetAdditionalInfo(AdditionalInfoClass.Publish).First<KeyValuePair<int, string>>();
		}

		public List<KeyValuePair<int, string>> GetSHCCategoriesForCommunity()
		{
			return this.GetAdditionalInfo(AdditionalInfoClass.SeniorHousingAndCareCategory);
		}

		public List<KeyValuePair<int, string>> GetSHCCategoriesForServiceProvider()
		{
			return this.GetAdditionalInfo(AdditionalInfoClass.SeniorHousingAndCareCategoryService);
		}

		public KeyValuePair<int, string> GetShowcaseType()
		{
			return this.GetAdditionalInfo(AdditionalInfoClass.Showcase).First<KeyValuePair<int, string>>();
		}

		public void SaveAdditionalInfo(List<KeyValuePair<int, string>> additionInfo, AdditionalInfoClass additionalInfoClass)
		{
			(new SaveAdditionInfoCommand(additionInfo, additionalInfoClass)).Execute();
		}

		public void SaveDefaultCommunityAmenities(CommunityType communityType, List<Amenity> amenities)
		{
			(new SaveDefaultAmenities(communityType, amenities)).Execute();
		}

		public void SaveDefaultCommunityUnitAmenities(CommunityUnitType communityUnitType, List<Amenity> amenities)
		{
			(new SaveDefaultAmenities(communityUnitType, amenities)).Execute();
		}
	}
}