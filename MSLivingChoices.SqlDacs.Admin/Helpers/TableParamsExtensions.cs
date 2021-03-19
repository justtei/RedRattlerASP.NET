using MSLivingChoices.Configuration;
using MSLivingChoices.Entities.Admin;
using MSLivingChoices.Entities.Admin.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.SqlDacs.Admin.Helpers
{

	internal static class TableParamsExtensions
	{
		internal static DataTable GetEmailTable(this IEnumerable<Email> items)
		{
			DataTable dataTable = new DataTable("EmailTableType");
			dataTable.Columns.Add(GetDataColumn<long>("EmailId", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<long>("OwnerId", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<long>("CommunityId", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<long>("ContactId", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<int>("EmailTypeId", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<string>("Email", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<bool>("IsActive", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<int>("Sequence", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<Guid>("CreateUserId", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<DateTime>("CreateDate", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<Guid>("ModifyUserId", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<DateTime>("ModifyDate", allowDbNull: true));
			if (items == null)
			{
				return dataTable;
			}
			foreach (Email item in items)
			{
				if (item != null)
				{
					long? emailId = item.Id;
					long? ownerId = null;
					long? communityId = null;
					long? contactId = null;
					int emailTypeId = (int)item.EmailTypeId.Value;
					string email = item.Value;
					bool isActive = true;
					int? sequence = item.Sequence;
					Guid? createUserId = null;
					DateTime? createDate = DateTime.Now;
					int? modifyUserId = null;
					DateTime? modifyDate = DateTime.Now;
					dataTable.Rows.Add(emailId, ownerId, communityId, contactId, emailTypeId, email, isActive, sequence, createUserId, createDate, modifyUserId, modifyDate);
				}
			}
			return dataTable;
		}

		internal static DataTable GetPhoneTable(this IEnumerable<Phone> items)
		{
			DataTable dataTable = new DataTable("PhoneTableType");
			dataTable.Columns.Add(GetDataColumn<long>("PhoneId", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<long>("OwnerId", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<long>("CommunityId", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<long>("ContactId", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<long>("ServiceId", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<int>("PhoneTypeId", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<string>("Phone", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<string>("PhoneExtension", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<string>("CampaignId", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<string>("ProvisionPhone", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<string>("ProvisionPhoneExtension", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<string>("ListingPhone", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<DateTime>("StartDate", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<DateTime>("ExpirationDate", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<DateTime>("WindDownDate", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<DateTime>("DisconnectDate", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<DateTime>("ReconnectDate", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<bool>("IsClickToCall", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<bool>("IsWhisper", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<bool>("IsCallReview", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<bool>("IsDisconnected", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<Guid>("DisconnectedUserId", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<bool>("IsActive", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<int>("Sequence", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<Guid>("CreateUserId", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<DateTime>("CreateDate", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<Guid>("ModifyUserId", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<DateTime>("ModifyDate", allowDbNull: true));
			if (items == null)
			{
				return dataTable;
			}
			foreach (Phone item in items)
			{
				if (item != null)
				{
					long? phoneId = item.Id;
					long? ownerId = null;
					long? communityId = null;
					long? contactId = null;
					long? serviceId = null;
					int phoneTypeId = (int)item.PhoneTypeId.Value;
					string phone = item.Number;
					string phoneExtension = null;
					string campaignId = null;
					string provisionPhone = null;
					string provisionPhoneExtension = null;
					string listingPhone = null;
					DateTime? startDate = null;
					DateTime? expirationDate = null;
					DateTime? windDownDate = null;
					DateTime? disconnectDate = null;
					DateTime? reconnectDate = null;
					bool isClickToCall = false;
					bool isWhisper = false;
					bool isCallReview = false;
					bool isDisconnected = false;
					Guid? disconnectedUserId = null;
					bool isActive = true;
					int? sequence = item.Sequence;
					Guid? createUserId = null;
					DateTime? createDate = DateTime.Now;
					int? modifyUserId = null;
					DateTime? modifyDate = DateTime.Now;
					dataTable.Rows.Add(phoneId, ownerId, communityId, contactId, serviceId, phoneTypeId, phone, phoneExtension, campaignId, provisionPhone, provisionPhoneExtension, listingPhone, startDate, expirationDate, windDownDate, disconnectDate, reconnectDate, isClickToCall, isWhisper, isCallReview, isDisconnected, disconnectedUserId, isActive, sequence, createUserId, createDate, modifyUserId, modifyDate);
				}
			}
			return dataTable;
		}

		internal static DataTable GetPhonesTable(this IEnumerable<CallTrackingPhone> items)
		{
			DataTable dataTable = new DataTable("PhoneTableType");
			dataTable.Columns.Add(GetDataColumn<long>("PhoneId", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<long>("OwnerId", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<long>("CommunityId", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<long>("ContactId", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<long>("ServiceId", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<int>("PhoneTypeId", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<string>("Phone", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<string>("PhoneExtension", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<string>("CampaignId", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<string>("ProvisionPhone", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<string>("ProvisionPhoneExtension", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<string>("ListingPhone", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<DateTime>("StartDate", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<DateTime>("ExpirationDate", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<DateTime>("WindDownDate", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<DateTime>("DisconnectDate", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<DateTime>("ReconnectDate", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<bool>("IsClickToCall", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<bool>("IsWhisper", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<bool>("IsCallReview", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<bool>("IsDisconnected", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<Guid>("DisconnectedUserId", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<bool>("IsActive", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<int>("Sequence", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<Guid>("CreateUserId", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<DateTime>("CreateDate", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<Guid>("ModifyUserId", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<DateTime>("ModifyDate", allowDbNull: true));
			if (items == null)
			{
				return dataTable;
			}
			int sequenceCounter = 1;
			foreach (CallTrackingPhone item in items)
			{
				if (item != null)
				{
					long? phoneId = item.Id;
					long? ownerId = null;
					long? communityId = null;
					long? contactId = null;
					long? serviceId = null;
					int? phoneTypeId = (int)item.PhoneType;
					string phone = item.Phone;
					string listingPhone = item.ListingPhone;
					string phoneExtension = item.PhoneExtension;
					string campaignId = item.CampaignId;
					string provisionPhone = item.ProvisionPhone;
					string provisionPhoneExtension = item.ProvisionPhoneExtension;
					DateTime? startDate = item.StartDate;
					DateTime? expirationDate = item.EndDate;
					DateTime? windDownDate = null;
					DateTime? disconnectDate = item.DisconnectDate;
					DateTime? reconnectDate = item.ReconnectDate;
					bool isClickToCall = item.IsClickToCall;
					bool isWhisper = item.IsWhisper;
					bool isCallReview = item.IsCallReview;
					bool isDisconencted = item.IsDisconnected;
					Guid? disconnectedUserId = null;
					bool isActive = true;
					int? sequence = sequenceCounter++;
					Guid? createUserId = null;
					DateTime? createDate = DateTime.Now;
					int? modifyUserId = null;
					DateTime? modifyDate = DateTime.Now;
					dataTable.Rows.Add(phoneId, ownerId, communityId, contactId, serviceId, phoneTypeId, phone, phoneExtension, campaignId, provisionPhone, provisionPhoneExtension, listingPhone, startDate, expirationDate, windDownDate, disconnectDate, reconnectDate, isClickToCall, isWhisper, isCallReview, isDisconencted, disconnectedUserId, isActive, sequence, createUserId, createDate, modifyUserId, modifyDate);
				}
			}
			return dataTable;
		}

		internal static DataTable GetContactTable(this IEnumerable<Contact> items)
		{
			DataTable dataTable = new DataTable("ContactTableType");
			dataTable.Columns.Add(GetDataColumn<long>("ContactId", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<long>("OwnerId", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<long>("CommunityId", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<int>("ContactTypeId", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<string>("FirstName", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<string>("LastName", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<bool>("IsActive", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<int>("Sequence", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<Guid>("CreateUserId", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<DateTime>("CreateDate", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<Guid>("ModifyUserId", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<DateTime>("ModifyDate", allowDbNull: true));
			if (items == null)
			{
				return dataTable;
			}
			foreach (Contact item in items)
			{
				if (item != null)
				{
					long? contactId = item.Id;
					long? ownerId = null;
					long? communityId = null;
					int contactTypeId = (int)item.ContactTypeId.Value;
					string firstName = item.FirstName;
					string lastName = item.LastName;
					bool isActive = true;
					int? sequence = item.Sequence;
					Guid? createUserId = null;
					DateTime? createDate = DateTime.Now;
					int? modifyUserId = null;
					DateTime? modifyDate = DateTime.Now;
					dataTable.Rows.Add(contactId, ownerId, communityId, contactTypeId, firstName, lastName, isActive, sequence, createUserId, createDate, modifyUserId, modifyDate);
				}
			}
			return dataTable;
		}

		internal static DataTable GetAddressTable(this Address address)
		{
			return GetAddressTable(new List<Address>
		{
			address
		});
		}

		internal static DataTable GetAddressTable(this IEnumerable<Address> items)
		{
			DataTable dataTable = new DataTable("AddressTableType");
			dataTable.Columns.Add(GetDataColumn<long>("AddressId", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<long>("OwnerId", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<long>("CommunityId", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<long>("ContactId", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<long>("CommunityUnitId", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<int>("AddressTypeId", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<string>("AddressLine1", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<string>("AddressLine2", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<int>("CityId", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<int>("StateId", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<int>("CountyId", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<int>("CountryId", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<string>("PostalCode", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<string>("OriginalAddressLine1", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<string>("OriginalAddressLine2", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<int>("OriginalCityId", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<int>("OriginalStateId", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<int>("OriginalCountyId", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<int>("OriginalCountryId", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<string>("OriginalPostalCode", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<float>("Latitude", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<float>("Longitude", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<bool>("IsVerIFied", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<bool>("IsActive", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<int>("Sequence", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<Guid>("CreateUserId", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<DateTime>("CreateDate", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<Guid>("ModifyUserId", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<DateTime>("ModifyDate", allowDbNull: true));
			if (items == null)
			{
				return dataTable;
			}
			foreach (Address item in items)
			{
				if (item != null)
				{
					long? addressId = item.Id;
					long? ownerId = null;
					long? communityId = null;
					long? contactId = null;
					long? communityUnitId = null;
					long? addressTypeId = null;
					string addressLine1 = item.AddressLine1;
					string addressLine2 = item.AddressLine2;
					long? cityId = item.City.Id;
					long? stateId = item.State.Id;
					int? countyId = null;
					long? countryId = item.Country.Id;
					string postalCode = item.PostalCode;
					string originalAddressLine1 = item.AddressLine1;
					string originaladdressLine2 = item.AddressLine2;
					long? originalCityId = item.City.Id;
					long? originalStateId = item.State.Id;
					long? originalCountyId = item.State.Id;
					long? originalCountryId = item.Country.Id;
					string originalPostalCode = item.PostalCode;
					double? latitude = item.Location.Latitude;
					double? longitude = item.Location.Longitude;
					bool isVerified = true;
					bool isActive = true;
					int? sequence = item.Sequence;
					Guid? createUserId = null;
					DateTime? createDate = DateTime.Now;
					Guid? modifyUserId = null;
					DateTime? modifyDate = DateTime.Now;
					dataTable.Rows.Add(addressId, ownerId, communityId, contactId, communityUnitId, addressTypeId, addressLine1, addressLine2, cityId, stateId, countyId, countryId, postalCode, originalAddressLine1, originaladdressLine2, originalCityId, originalStateId, originalCountyId, originalCountryId, originalPostalCode, latitude, longitude, isVerified, isActive, sequence, createUserId, createDate, modifyUserId, modifyDate);
				}
			}
			return dataTable;
		}

		internal static DataTable GetAmenityTable(this IEnumerable<Amenity> items)
		{
			DataTable dataTable = new DataTable("AmenityTableType");
			dataTable.Columns.Add(GetDataColumn<long>("AmenityId", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<long>("CommunityId", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<long>("CommunityUnitId", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<int>("AmenityTypeId", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<string>("AdditionalDescription", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<bool>("IsActive", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<int>("Sequence", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<Guid>("CreateUserId", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<DateTime>("CreateDate", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<Guid>("ModifyUserId", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<DateTime>("ModifyDate", allowDbNull: true));
			if (items == null)
			{
				return dataTable;
			}
			int sequenceCounter = 1;
			foreach (Amenity item in items)
			{
				if (item != null)
				{
					long? amenityId = item.Id;
					long? communityId = null;
					long? communityUnitId = null;
					if (!item.ClassId.HasValue || item.ClassId == -1)
					{
						item.ClassId = 0;
					}
					long? amenityTypeId = item.ClassId;
					string additionalDescription = null;
					if (item.ClassId == 0)
					{
						additionalDescription = item.Name;
					}
					bool isActive = true;
					int? sequence = sequenceCounter++;
					Guid? createUserId = null;
					DateTime? createDate = DateTime.Now;
					Guid? modifyUserId = null;
					DateTime? modifyDate = DateTime.Now;
					dataTable.Rows.Add(amenityId, communityId, communityUnitId, amenityTypeId, additionalDescription, isActive, sequence, createUserId, createDate, modifyUserId, modifyDate);
				}
			}
			return dataTable;
		}

		internal static DataTable GetImageTable(this IEnumerable<Image> items)
		{
			DataTable dataTable = new DataTable("ImageTableType");
			dataTable.Columns.Add(GetDataColumn<long>("ImageId", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<long>("OwnerId", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<long>("CommunityId", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<long>("CommunityUnitId", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<long>("ContactId", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<long>("ServiceId", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<int>("ImageTypeId", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<string>("UserUploadPathFileName", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<string>("PathFileName", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<string>("OriginalPath", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<string>("ThumbnailPath", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<int>("ProcessingStatusId", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<string>("Caption", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<string>("Description", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<DateTime>("UploadDate", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<Guid>("UploadUserId", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<bool>("IsActive", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<int>("Sequence", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<Guid>("CreateUserId", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<DateTime>("CreateDate", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<Guid>("ModifyUserId", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<DateTime>("ModifyDate", allowDbNull: true));
			string parentDirectory = ConfigurationManager.Instance.TempImagesDirectoryPath;
			int sequenceCounter = 1;
			foreach (Image item in items)
			{
				long? imageId = item.Id;
				long? ownerId = null;
				long? communityId = null;
				long? communityUnitId = null;
				long? contactId = null;
				long? serviceId = null;
				int? imageTypeId = (int)item.ImageType;
				string userUploadPathFileName = parentDirectory;
				string pathFileName = item.Name;
				string originalUrl = item.Url;
				string thumbnailUrl = item.ThumbnailUrl;
				string caption = null;
				string description = null;
				DateTime? uploadDate = DateTime.Now;
				Guid? uploadUserId = null;
				bool isActive = true;
				int? sequence = sequenceCounter++;
				Guid? createUserId = null;
				DateTime? createDate = DateTime.Now;
				Guid? modifyUserId = null;
				DateTime? modifyDate = DateTime.Now;
				dataTable.Rows.Add(imageId, ownerId, communityId, communityUnitId, contactId, serviceId, imageTypeId, userUploadPathFileName, pathFileName, originalUrl, thumbnailUrl, DBNull.Value, caption, description, uploadDate, uploadUserId, isActive, sequence, createUserId, createDate, modifyUserId, modifyDate);
			}
			return dataTable;
		}

		internal static DataTable GetPaymentAdditionalInfoTable(this IEnumerable<long> paymentTypeIds, bool isService = false)
		{
			DataTable dataTable = PrepareAdditionalInfoTable();
			if (paymentTypeIds == null)
			{
				return dataTable;
			}
			DateTime dtNow = DateTime.Now;
			int sequenceCounter = 1;
			foreach (long paymentTypeId in paymentTypeIds)
			{
				int item = (int)paymentTypeId;
				long? additionalInfoId = null;
				int? additionalInfoClassId = (isService ? 11 : 8);
				int? additionalInfoTypeId = item;
				long? communityId = null;
				long? communityUnitId = null;
				long? serviceId = null;
				string shortText = null;
				string longText = null;
				DateTime? startDate = null;
				DateTime? endDate = null;
				bool isActive = true;
				int? sequence = sequenceCounter++;
				Guid? createUserId = null;
				DateTime? createDate = dtNow;
				Guid? modifyUserId = null;
				DateTime? modifyDate = dtNow;
				dataTable.Rows.Add(additionalInfoId, communityId, communityUnitId, serviceId, additionalInfoClassId, additionalInfoTypeId, shortText, longText, startDate, endDate, isActive, sequence, createUserId, createDate, modifyUserId, modifyDate);
			}
			return dataTable;
		}

		internal static DataTable GetSeniorHousingAdditionalInfoTable(this IEnumerable<long> seniorHousingTypeIds, bool isService = false)
		{
			DataTable dataTable = PrepareAdditionalInfoTable();
			if (seniorHousingTypeIds == null)
			{
				return dataTable;
			}
			int sequenceCounter = 1;
			foreach (long seniorHousingTypeId in seniorHousingTypeIds)
			{
				int item = (int)seniorHousingTypeId;
				long? additionalInfoId = null;
				int? additionalInfoClassId = (isService ? 10 : 2);
				int? additionalInfoTypeId = item;
				long? dbCommunityId = null;
				long? communityUnitId = null;
				long? serviceId = null;
				string shortText = null;
				string longText = null;
				DateTime? startDate = null;
				DateTime? endDate = null;
				bool isActive = true;
				int? sequence = sequenceCounter++;
				Guid? createUserId = null;
				DateTime? createDate = DateTime.Now;
				Guid? modifyUserId = null;
				DateTime? modifyDate = DateTime.Now;
				dataTable.Rows.Add(additionalInfoId, dbCommunityId, communityUnitId, serviceId, additionalInfoClassId, additionalInfoTypeId, shortText, longText, startDate, endDate, isActive, sequence, createUserId, createDate, modifyUserId, modifyDate);
			}
			return dataTable;
		}

		internal static DataTable GetAdditionalInfoTable(this Coupon item, int couponTypeId)
		{
			return GetAdditionalInfoTable(new List<Coupon>
		{
			item
		}, couponTypeId);
		}

		internal static DataTable GetAdditionalInfoTable(this IEnumerable<Coupon> items, int couponTypeId)
		{
			DataTable dataTable = PrepareAdditionalInfoTable();
			if (items == null)
			{
				return dataTable;
			}
			DateTime dtNow = DateTime.Now;
			int sequenceCounter = 1;
			foreach (Coupon item in items)
			{
				if (item != null)
				{
					long? additionalInfoId = null;
					int? additionalInfoClassId = 5;
					int? additionalInfoTypeId = couponTypeId;
					long? communityId = null;
					long? communityUnitId = null;
					long? serviceId = null;
					string shortText = item.Name;
					string longText = item.Description;
					DateTime? startDate = item.PublishDate;
					DateTime? endDate = item.ExpirationDate;
					bool isActive = true;
					int? sequence = sequenceCounter++;
					Guid? createUserId = null;
					DateTime? createDate = dtNow;
					Guid? modifyUserId = null;
					DateTime? modifyDate = dtNow;
					dataTable.Rows.Add(additionalInfoId, communityId, communityUnitId, serviceId, additionalInfoClassId, additionalInfoTypeId, shortText, longText, startDate, endDate, isActive, sequence, createUserId, createDate, modifyUserId, modifyDate);
				}
			}
			return dataTable;
		}

		internal static DataTable GetAdditionalInfoTable(this IEnumerable<CommunityService> items, int customCommunityServiceTypeId)
		{
			DataTable dataTable = PrepareAdditionalInfoTable();
			if (items == null)
			{
				return dataTable;
			}
			DateTime now = DateTime.Now;
			int sequenceCounter = 1;
			foreach (CommunityService item in items)
			{
				if (item != null)
				{
					long? additionalInfoId = null;
					int? additionalInfoClassId = 6;
					long? additionalInfoTypeId = item.AdditionInfoTypeId ?? customCommunityServiceTypeId;
					long? communityId = null;
					long? communityUnitId = null;
					long? serviceId = null;
					string shortText = item.Name;
					string longText = null;
					DateTime? startDate = null;
					DateTime? endDate = null;
					bool isActive = true;
					int? sequence = sequenceCounter++;
					Guid? createUserId = null;
					DateTime? createDate = now;
					Guid? modifyUserId = null;
					DateTime? modifyDate = now;
					dataTable.Rows.Add(additionalInfoId, communityId, communityUnitId, serviceId, additionalInfoClassId, additionalInfoTypeId, shortText, longText, startDate, endDate, isActive, sequence, createUserId, createDate, modifyUserId, modifyDate);
				}
			}
			return dataTable;
		}

		internal static DataTable GetAdditionalInfoTable(this PackageType? item, bool isService = false)
		{
			return GetAdditionalInfoTable(new List<PackageType?>
		{
			item
		}, isService);
		}

		internal static DataTable GetAdditionalInfoTable(this PackageType item, bool isService = false)
		{
			return GetAdditionalInfoTable(new List<PackageType?>
		{
			item
		}, isService);
		}

		internal static DataTable GetAdditionalInfoTable(this IEnumerable<PackageType?> items, bool isService = false)
		{
			DataTable dataTable = PrepareAdditionalInfoTable();
			if (items == null)
			{
				return dataTable;
			}
			DateTime dtNow = DateTime.Now;
			int sequenceCounter = 1;
			foreach (PackageType? item2 in items)
			{
				PackageType item = item2.Value;
				long? additionalInfoId = null;
				int? additionalInfoClassId = ((!isService) ? 1 : 9);
				int? additionalInfoTypeId = (int)item;
				long? communityId = null;
				long? communityUnitId = null;
				long? serviceId = null;
				string shortText = null;
				string longText = null;
				DateTime? startDate = null;
				DateTime? endDate = null;
				bool isActive = true;
				int? sequence = sequenceCounter++;
				Guid? createUserId = null;
				DateTime? createDate = dtNow;
				Guid? modifyUserId = null;
				DateTime? modifyDate = dtNow;
				dataTable.Rows.Add(additionalInfoId, communityId, communityUnitId, serviceId, additionalInfoClassId, additionalInfoTypeId, shortText, longText, startDate, endDate, isActive, sequence, createUserId, createDate, modifyUserId, modifyDate);
			}
			return dataTable;
		}

		internal static DataTable GetAdditionalInfoTable(this IEnumerable<PublishingStatus> items)
		{
			DataTable dataTable = PrepareAdditionalInfoTable();
			if (items == null)
			{
				return dataTable;
			}
			DateTime dtNow = DateTime.Now;
			int sequenceCounter = 1;
			foreach (PublishingStatus item in items)
			{
				long? additionalInfoId = null;
				int? additionalInfoClassId = 4;
				int? additionalInfoTypeId = (int)item;
				long? communityId = null;
				long? communityUnitId = null;
				long? serviceId = null;
				string shortText = null;
				string longText = null;
				DateTime? startDate = null;
				DateTime? endDate = null;
				bool isActive = true;
				int? sequence = sequenceCounter++;
				Guid? createUserId = null;
				DateTime? createDate = dtNow;
				Guid? modifyUserId = null;
				DateTime? modifyDate = dtNow;
				dataTable.Rows.Add(additionalInfoId, communityId, communityUnitId, serviceId, additionalInfoClassId, additionalInfoTypeId, shortText, longText, startDate, endDate, isActive, sequence, createUserId, createDate, modifyUserId, modifyDate);
			}
			return dataTable;
		}

		internal static DataTable GetAdditionalInfoTable(this IEnumerable<KeyValuePair<int, string>> items)
		{
			DataTable dataTable = PrepareAdditionalInfoTable();
			if (items == null)
			{
				return dataTable;
			}
			DateTime dtNow = DateTime.Now;
			int sequenceCounter = 1;
			foreach (KeyValuePair<int, string> item in items)
			{
				long? additionalInfoId = null;
				int? additionalInfoClassId = 2;
				int? additionalInfoTypeId = item.Key;
				long? communityId = null;
				long? communityUnitId = null;
				long? serviceId = null;
				string shortText = null;
				string longText = null;
				DateTime? startDate = null;
				DateTime? endDate = null;
				bool isActive = true;
				int? sequence = sequenceCounter++;
				Guid? createUserId = null;
				DateTime? createDate = dtNow;
				Guid? modifyUserId = null;
				DateTime? modifyDate = dtNow;
				dataTable.Rows.Add(additionalInfoId, communityId, communityUnitId, serviceId, additionalInfoClassId, additionalInfoTypeId, shortText, longText, startDate, endDate, isActive, sequence, createUserId, createDate, modifyUserId, modifyDate);
			}
			return dataTable;
		}

		internal static DataTable GetOfficeHoursTable(this IEnumerable<OfficeHours> officeHoursList)
		{
			DataTable dataTable = new DataTable("CommunityOfficeHoursTableType");
			dataTable.Columns.Add(GetDataColumn<long>("CommunityOfficeHoursId", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<long>("CommunityId", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<long>("ServiceId", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<int>("DayOfWeekId", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<DateTime>("StartTime", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<DateTime>("EndTime", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<string>("Note", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<bool>("IsActive", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<int>("Sequence", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<Guid>("CreateUserId", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<DateTime>("CreateDate", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<Guid>("ModifyUserId", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<DateTime>("ModifyDate", allowDbNull: true));
			if (officeHoursList == null)
			{
				return dataTable;
			}
			int sequenceCounter = 1;
			foreach (OfficeHours officeHours in officeHoursList)
			{
				if (officeHours != null)
				{
					EuropeanDayOfWeek num = (officeHours.StartDay.HasValue ? officeHours.StartDay.Value : officeHours.EndDay.Value);
					int endDayInt = (int)(officeHours.EndDay.HasValue ? officeHours.EndDay.Value : officeHours.StartDay.Value);
					for (int i = (int)num; i <= endDayInt; i++)
					{
						long? communityOfficeHoursId = null;
						long? communityId = null;
						long? serviceId = null;
						int? dayOfWeekId = i;
						DateTime? startTime = officeHours.StartTime;
						DateTime? endTime = officeHours.EndTime;
						string note = officeHours.Note;
						int? sequence = sequenceCounter++;
						Guid? createUserId = null;
						DateTime? createDate = DateTime.Now;
						Guid? modifyUserId = null;
						DateTime? modifyDate = DateTime.Now;
						dataTable.Rows.Add(communityOfficeHoursId, communityId, serviceId, dayOfWeekId, startTime, endTime, note, true, sequence, createUserId, createDate, modifyUserId, modifyDate);
					}
				}
			}
			return dataTable;
		}

		internal static DataTable GetCommunityUnitTable(IEnumerable<FloorPlan> floorPlans, IEnumerable<SpecHome> specHomes, IEnumerable<House> houses)
		{
			DataTable dataTable = new DataTable("CommunityUnitTableType");
			dataTable.Columns.Add(GetDataColumn<long>("CommunityUnitId", allowDbNull: false));
			dataTable.Columns.Add(GetDataColumn<int>("CommunityUnitClassId", allowDbNull: false));
			dataTable.Columns.Add(GetDataColumn<long>("CommunityId", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<string>("Name", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<bool>("IsActive", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<int>("Sequence", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<Guid>("CreateUserId", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<DateTime>("CreateDate", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<Guid>("ModifyUserId", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<DateTime>("ModifyDate", allowDbNull: true));
			if (floorPlans != null)
			{
				int sequenceCounter = 1;
				foreach (FloorPlan item3 in floorPlans)
				{
					if (item3.Id.HasValue)
					{
						long communityUnitId3 = item3.Id.Value;
						int communityUnitClassId3 = 1;
						long? communityId3 = item3.Community.Id;
						string name3 = item3.Name;
						bool isActive3 = true;
						int? sequence3 = sequenceCounter++;
						Guid? createUserId3 = null;
						DateTime? createDate3 = DateTime.Now;
						Guid? modifyUserId3 = null;
						DateTime? modifyDate3 = DateTime.Now;
						dataTable.Rows.Add(communityUnitId3, communityUnitClassId3, communityId3, name3, isActive3, sequence3, createUserId3, createDate3, modifyUserId3, modifyDate3);
					}
				}
			}
			if (specHomes != null)
			{
				int sequenceCounter = 1;
				foreach (SpecHome item2 in specHomes)
				{
					if (item2.Id.HasValue)
					{
						long communityUnitId2 = item2.Id.Value;
						int communityUnitClassId2 = 2;
						long? communityId2 = item2.Community.Id;
						string name2 = item2.Name;
						bool isActive2 = true;
						int? sequence2 = sequenceCounter++;
						Guid? createUserId2 = null;
						DateTime? createDate2 = DateTime.Now;
						Guid? modifyUserId2 = null;
						DateTime? modifyDate2 = DateTime.Now;
						dataTable.Rows.Add(communityUnitId2, communityUnitClassId2, communityId2, name2, isActive2, sequence2, createUserId2, createDate2, modifyUserId2, modifyDate2);
					}
				}
			}
			if (houses != null)
			{
				int sequenceCounter = 1;
				{
					foreach (House item in houses)
					{
						if (item.Id.HasValue)
						{
							long communityUnitId = item.Id.Value;
							int communityUnitClassId = 3;
							long? communityId = item.Community.Id;
							string name = item.Name;
							bool isActive = true;
							int? sequence = sequenceCounter++;
							Guid? createUserId = null;
							DateTime? createDate = DateTime.Now;
							Guid? modifyUserId = null;
							DateTime? modifyDate = DateTime.Now;
							dataTable.Rows.Add(communityUnitId, communityUnitClassId, communityId, name, isActive, sequence, createUserId, createDate, modifyUserId, modifyDate);
						}
					}
					return dataTable;
				}
			}
			return dataTable;
		}

		private static DataTable PrepareAdditionalInfoTable()
		{
			return new DataTable("AdditionalInformationTableType")
			{
				Columns =
			{
				GetDataColumn<long>("AdditionalInformationId", allowDbNull: true),
				GetDataColumn<long>("CommunityId", allowDbNull: true),
				GetDataColumn<long>("CommunityUnitId", allowDbNull: true),
				GetDataColumn<long>("ServiceId", allowDbNull: true),
				GetDataColumn<int>("AdditionalInformationClassId", allowDbNull: true),
				GetDataColumn<int>("AdditionalInformationTypeId", allowDbNull: true),
				GetDataColumn<string>("ShortText", allowDbNull: true),
				GetDataColumn<string>("LongText", allowDbNull: true),
				GetDataColumn<DateTime>("StartDate", allowDbNull: true),
				GetDataColumn<DateTime>("EndDate", allowDbNull: true),
				GetDataColumn<bool>("IsActive", allowDbNull: true),
				GetDataColumn<int>("Sequence", allowDbNull: true),
				GetDataColumn<Guid>("CreateUserId", allowDbNull: true),
				GetDataColumn<DateTime>("CreateDate", allowDbNull: true),
				GetDataColumn<Guid>("ModifyUserId", allowDbNull: true),
				GetDataColumn<DateTime>("ModifyDate", allowDbNull: true)
			}
			};
		}

		internal static DataTable GetBookTable(this IEnumerable<Book> books)
		{
			DataTable dataTable = new DataTable("BookTableType");
			dataTable.Columns.Add(GetDataColumn<long>("BookId", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<string>("BookNumber", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<long>("BrandId", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<string>("BrandDescription", allowDbNull: true));
			if (books == null)
			{
				return dataTable;
			}
			foreach (Book book in books)
			{
				if (book != null)
				{
					long? bookId = book.Id;
					string bookNumber = null;
					int? brandId = null;
					string brandDescription = null;
					dataTable.Rows.Add(bookId, bookNumber, brandId, brandDescription);
				}
			}
			return dataTable;
		}

		internal static DataTable GetDateTable(DateTime? startDate, DateTime? endDate, AdditionalInfoClass? infoClass, int additionalInfoTypeId)
		{
			DataTable dataTable = PrepareAdditionalInfoTable();
			long? additionalInfoId = null;
			int? additionalInfoClassId = (int)(infoClass.HasValue ? infoClass.Value : ((AdditionalInfoClass)0));
			int? dbAdditionalInfoTypeId = additionalInfoTypeId;
			long? communityId = null;
			long? communityUnitId = null;
			long? serviceId = null;
			string shortText = null;
			string longText = null;
			DateTime? dbStartDate = ((!startDate.HasValue) ? startDate : ((startDate.Value.Year < 1900) ? new DateTime?(new DateTime(1900, startDate.Value.Month, startDate.Value.Day)) : ((startDate.Value.Year > 2070) ? new DateTime?(new DateTime(2070, startDate.Value.Month, startDate.Value.Day)) : startDate)));
			DateTime? dbEndDate = ((!endDate.HasValue) ? endDate : ((endDate.Value.Year < 1900) ? new DateTime?(new DateTime(1900, endDate.Value.Month, endDate.Value.Day)) : ((endDate.Value.Year > 2070) ? new DateTime?(new DateTime(2070, endDate.Value.Month, endDate.Value.Day)) : endDate)));
			bool isActive = true;
			int? sequence = 1;
			Guid? createUserId = null;
			DateTime? createDate = DateTime.Now;
			Guid? modifyUserId = null;
			DateTime? modifyDate = DateTime.Now;
			dataTable.Rows.Add(additionalInfoId, communityId, communityUnitId, serviceId, additionalInfoClassId, dbAdditionalInfoTypeId, shortText, longText, dbStartDate, dbEndDate, isActive, sequence, createUserId, createDate, modifyUserId, modifyDate);
			return dataTable;
		}

		internal static DataTable GetPhoneIdTable(this List<CallTrackingPhone> callTrackingPhones)
		{
			DataTable table = new DataTable("PhoneIdTable");
			table.Columns.Add(GetDataColumn<long>("Id", allowDbNull: true));
			if (callTrackingPhones == null)
			{
				return table;
			}
			foreach (CallTrackingPhone callTrackingPhone in callTrackingPhones)
			{
				long? callTrackingPhoneId = callTrackingPhone.Id;
				table.Rows.Add(callTrackingPhoneId);
			}
			return table;
		}

		internal static DataTable GetAmenityIdTable(this List<long> amenityIds)
		{
			DataTable table = new DataTable("AmenityTypeIdTable");
			table.Columns.Add(GetDataColumn<long>("Id", allowDbNull: true));
			if (amenityIds == null)
			{
				return table;
			}
			foreach (long amenityId in amenityIds)
			{
				table.Rows.Add(amenityId);
			}
			return table;
		}

		private static DataColumn GetDataColumn<T>(string colunmName, bool allowDbNull)
		{
			DataColumn result = new DataColumn(colunmName);
			result.DataType = typeof(T);
			result.AllowDBNull = allowDbNull;
			if (allowDbNull)
			{
				result.DefaultValue = null;
			}
			return result;
		}

		internal static DataTable GetAdditionInfoTypeTable(this List<KeyValuePair<int, string>> additionInfo, AdditionalInfoClass additionInfoClass)
		{
			DataTable dataTable = new DataTable("AdditionalInformationTypeTable");
			dataTable.Columns.Add(GetDataColumn<int>("AdditionalInformationTypeId", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<int>("AdditionalInformationClassId", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<string>("Description", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<bool>("IsActive", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<int>("Sequence", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<Guid>("CreateUserId", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<DateTime>("CreateDate", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<Guid>("ModifyUserId", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<DateTime>("ModifyDate", allowDbNull: true));
			bool isActive = true;
			int? sequence = 1;
			Guid? createUserId = null;
			DateTime? createDate = DateTime.Now;
			Guid? modifyUserId = null;
			DateTime? modifyDate = DateTime.Now;
			foreach (KeyValuePair<int, string> type in additionInfo)
			{
				object key = ((type.Key > 0) ? ((object)type.Key) : null);
				dataTable.Rows.Add(key, additionInfoClass, type.Value, isActive, sequence, createUserId, createDate, modifyUserId, modifyDate);
			}
			return dataTable;
		}

		internal static DataTable GetAmenityTypeTable(this List<Amenity> amenities, CommunityType? communityType, CommunityUnitType? communityUnitType)
		{
			DataTable dataTable = new DataTable("AmenityTypeTable");
			dataTable.Columns.Add(GetDataColumn<int>("AmenityTypeId", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<int>("CommunityClassId", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<int>("CommunityUnitClassId", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<string>("Description", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<bool>("IsActive", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<int>("Sequence", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<Guid>("CreateUserId", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<DateTime>("CreateDate", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<Guid>("ModifyUserId", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<DateTime>("ModifyDate", allowDbNull: true));
			bool isActive = true;
			int? sequence = 1;
			Guid? createUserId = null;
			DateTime? createDate = DateTime.Now;
			Guid? modifyUserId = null;
			DateTime? modifyDate = DateTime.Now;
			foreach (Amenity amenity in amenities)
			{
				object key = ((amenity.Id > 0) ? ((object)amenity.Id) : null);
				dataTable.Rows.Add(key, communityType, communityUnitType, amenity.Name, isActive, sequence, createUserId, createDate, modifyUserId, modifyDate);
			}
			return dataTable;
		}

		internal static DataTable GetServiceCountiesServedTable(this IEnumerable<County> counties)
		{
			DataTable dataTable = new DataTable("CountiesServedTableType");
			dataTable.Columns.Add(GetDataColumn<long>("ServiceId", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<long>("CountyId", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<Guid>("CreateUserId", allowDbNull: true));
			dataTable.Columns.Add(GetDataColumn<DateTime>("CreateDate", allowDbNull: true));
			if (counties == null)
			{
				return dataTable;
			}
			foreach (County county in counties)
			{
				if (county != null)
				{
					long? serviceId = -1L;
					long? countyId = county.Id;
					Guid? createUserId = null;
					DateTime? createDate = DateTime.Now;
					dataTable.Rows.Add(serviceId, countyId, createUserId, createDate);
				}
			}
			return dataTable;
		}
	}

}