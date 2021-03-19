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
		internal static DataTable GetAdditionalInfoTable(this Coupon item, int couponTypeId)
		{
			return (new List<Coupon>()
			{
				item
			}).GetAdditionalInfoTable(couponTypeId);
		}

		internal static DataTable GetAdditionalInfoTable(this IEnumerable<Coupon> items, int couponTypeId)
		{
			DataTable dataTable = TableParamsExtensions.PrepareAdditionalInfoTable();
			if (items == null)
			{
				return dataTable;
			}
			DateTime dtNow = DateTime.Now;
			int sequenceCounter = 1;
			foreach (Coupon item in items)
			{
				if (item == null)
				{
					continue;
				}
				long? additionalInfoId = null;
				int? additionalInfoClassId = new int?(5);
				int? additionalInfoTypeId = new int?(couponTypeId);
				long? communityId = null;
				long? communityUnitId = null;
				long? serviceId = null;
				string shortText = item.Name;
				string longText = item.Description;
				DateTime? startDate = item.PublishDate;
				DateTime? endDate = item.ExpirationDate;
				bool isActive = true;
				int num = sequenceCounter;
				sequenceCounter = num + 1;
				int? sequence = new int?(num);
				Guid? createUserId = null;
				DateTime? createDate = new DateTime?(dtNow);
				Guid? modifyUserId = null;
				DateTime? modifyDate = new DateTime?(dtNow);
				dataTable.Rows.Add(new object[] { additionalInfoId, communityId, communityUnitId, serviceId, additionalInfoClassId, additionalInfoTypeId, shortText, longText, startDate, endDate, isActive, sequence, createUserId, createDate, modifyUserId, modifyDate });
			}
			return dataTable;
		}

		internal static DataTable GetAdditionalInfoTable(this IEnumerable<CommunityService> items, int customCommunityServiceTypeId)
		{
			DataTable dataTable = TableParamsExtensions.PrepareAdditionalInfoTable();
			if (items == null)
			{
				return dataTable;
			}
			DateTime now = DateTime.Now;
			int sequenceCounter = 1;
			foreach (CommunityService item in items)
			{
				if (item == null)
				{
					continue;
				}
				long? additionalInfoId = null;
				int? additionalInfoClassId = new int?(6);
				int? additionInfoTypeId = item.AdditionInfoTypeId;
				long? additionalInfoTypeId = new long?((long)((additionInfoTypeId.HasValue ? additionInfoTypeId.GetValueOrDefault() : customCommunityServiceTypeId)));
				long? communityId = null;
				long? communityUnitId = null;
				long? serviceId = null;
				string shortText = item.Name;
				string longText = null;
				DateTime? startDate = null;
				DateTime? endDate = null;
				bool isActive = true;
				int num = sequenceCounter;
				sequenceCounter = num + 1;
				int? sequence = new int?(num);
				Guid? createUserId = null;
				DateTime? createDate = new DateTime?(now);
				Guid? modifyUserId = null;
				DateTime? modifyDate = new DateTime?(now);
				dataTable.Rows.Add(new object[] { additionalInfoId, communityId, communityUnitId, serviceId, additionalInfoClassId, additionalInfoTypeId, shortText, longText, startDate, endDate, isActive, sequence, createUserId, createDate, modifyUserId, modifyDate });
			}
			return dataTable;
		}

		internal static DataTable GetAdditionalInfoTable(this PackageType? item, bool isService = false)
		{
			return (new List<PackageType?>()
			{
				item
			}).GetAdditionalInfoTable(isService);
		}

		internal static DataTable GetAdditionalInfoTable(this PackageType item, bool isService = false)
		{
			return (new List<PackageType?>()
			{
				new PackageType?(item)
			}).GetAdditionalInfoTable(isService);
		}

		internal static DataTable GetAdditionalInfoTable(this IEnumerable<PackageType?> items, bool isService = false)
		{
			DataTable dataTable = TableParamsExtensions.PrepareAdditionalInfoTable();
			if (items == null)
			{
				return dataTable;
			}
			DateTime dtNow = DateTime.Now;
			int sequenceCounter = 1;
			foreach (PackageType? nullable in items)
			{
				PackageType item = nullable.Value;
				long? additionalInfoId = null;
				int? additionalInfoClassId = new int?((isService ? 9 : 1));
				int? additionalInfoTypeId = new int?(item);
				long? communityId = null;
				long? communityUnitId = null;
				long? serviceId = null;
				string shortText = null;
				string longText = null;
				DateTime? startDate = null;
				DateTime? endDate = null;
				bool isActive = true;
				int num = sequenceCounter;
				sequenceCounter = num + 1;
				int? sequence = new int?(num);
				Guid? createUserId = null;
				DateTime? createDate = new DateTime?(dtNow);
				Guid? modifyUserId = null;
				DateTime? modifyDate = new DateTime?(dtNow);
				dataTable.Rows.Add(new object[] { additionalInfoId, communityId, communityUnitId, serviceId, additionalInfoClassId, additionalInfoTypeId, shortText, longText, startDate, endDate, isActive, sequence, createUserId, createDate, modifyUserId, modifyDate });
			}
			return dataTable;
		}

		internal static DataTable GetAdditionalInfoTable(this IEnumerable<PublishingStatus> items)
		{
			DataTable dataTable = TableParamsExtensions.PrepareAdditionalInfoTable();
			if (items == null)
			{
				return dataTable;
			}
			DateTime dtNow = DateTime.Now;
			int sequenceCounter = 1;
			foreach (PackageType item in items)
			{
				long? additionalInfoId = null;
				int? additionalInfoClassId = new int?(4);
				int? additionalInfoTypeId = new int?(item);
				long? communityId = null;
				long? communityUnitId = null;
				long? serviceId = null;
				string shortText = null;
				string longText = null;
				DateTime? startDate = null;
				DateTime? endDate = null;
				bool isActive = true;
				int num = sequenceCounter;
				sequenceCounter = num + 1;
				int? sequence = new int?(num);
				Guid? createUserId = null;
				DateTime? createDate = new DateTime?(dtNow);
				Guid? modifyUserId = null;
				DateTime? modifyDate = new DateTime?(dtNow);
				dataTable.Rows.Add(new object[] { additionalInfoId, communityId, communityUnitId, serviceId, additionalInfoClassId, additionalInfoTypeId, shortText, longText, startDate, endDate, isActive, sequence, createUserId, createDate, modifyUserId, modifyDate });
			}
			return dataTable;
		}

		internal static DataTable GetAdditionalInfoTable(this IEnumerable<KeyValuePair<int, string>> items)
		{
			DataTable dataTable = TableParamsExtensions.PrepareAdditionalInfoTable();
			if (items == null)
			{
				return dataTable;
			}
			DateTime dtNow = DateTime.Now;
			int sequenceCounter = 1;
			foreach (KeyValuePair<int, string> item in items)
			{
				long? additionalInfoId = null;
				int? additionalInfoClassId = new int?(2);
				int? additionalInfoTypeId = new int?(item.Key);
				long? communityId = null;
				long? communityUnitId = null;
				long? serviceId = null;
				string shortText = null;
				string longText = null;
				DateTime? startDate = null;
				DateTime? endDate = null;
				bool isActive = true;
				int num = sequenceCounter;
				sequenceCounter = num + 1;
				int? sequence = new int?(num);
				Guid? createUserId = null;
				DateTime? createDate = new DateTime?(dtNow);
				Guid? modifyUserId = null;
				DateTime? modifyDate = new DateTime?(dtNow);
				dataTable.Rows.Add(new object[] { additionalInfoId, communityId, communityUnitId, serviceId, additionalInfoClassId, additionalInfoTypeId, shortText, longText, startDate, endDate, isActive, sequence, createUserId, createDate, modifyUserId, modifyDate });
			}
			return dataTable;
		}

		internal static DataTable GetAdditionInfoTypeTable(this List<KeyValuePair<int, string>> additionInfo, AdditionalInfoClass additionInfoClass)
		{
			DataTable dataTable = new DataTable("AdditionalInformationTypeTable");
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<int>("AdditionalInformationTypeId", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<int>("AdditionalInformationClassId", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<string>("Description", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<bool>("IsActive", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<int>("Sequence", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<Guid>("CreateUserId", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<DateTime>("CreateDate", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<Guid>("ModifyUserId", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<DateTime>("ModifyDate", true));
			bool isActive = true;
			int? sequence = new int?(1);
			Guid? createUserId = null;
			DateTime? createDate = new DateTime?(DateTime.Now);
			Guid? modifyUserId = null;
			DateTime? modifyDate = new DateTime?(DateTime.Now);
			foreach (KeyValuePair<int, string> type in additionInfo)
			{
				object key = (type.Key > 0 ? type.Key : null);
				dataTable.Rows.Add(new object[] { key, additionInfoClass, type.Value, isActive, sequence, createUserId, createDate, modifyUserId, modifyDate });
			}
			return dataTable;
		}

		internal static DataTable GetAddressTable(this Address address)
		{
			return (new List<Address>()
			{
				address
			}).GetAddressTable();
		}

		internal static DataTable GetAddressTable(this IEnumerable<Address> items)
		{
			DataTable dataTable = new DataTable("AddressTableType");
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<long>("AddressId", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<long>("OwnerId", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<long>("CommunityId", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<long>("ContactId", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<long>("CommunityUnitId", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<int>("AddressTypeId", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<string>("AddressLine1", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<string>("AddressLine2", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<int>("CityId", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<int>("StateId", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<int>("CountyId", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<int>("CountryId", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<string>("PostalCode", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<string>("OriginalAddressLine1", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<string>("OriginalAddressLine2", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<int>("OriginalCityId", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<int>("OriginalStateId", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<int>("OriginalCountyId", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<int>("OriginalCountryId", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<string>("OriginalPostalCode", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<float>("Latitude", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<float>("Longitude", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<bool>("IsVerIFied", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<bool>("IsActive", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<int>("Sequence", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<Guid>("CreateUserId", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<DateTime>("CreateDate", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<Guid>("ModifyUserId", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<DateTime>("ModifyDate", true));
			if (items == null)
			{
				return dataTable;
			}
			foreach (Address item in items)
			{
				if (item == null)
				{
					continue;
				}
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
				double? latitude = new double?(item.Location.Latitude);
				double? longitude = new double?(item.Location.Longitude);
				bool isVerified = true;
				bool isActive = true;
				int? sequence = new int?(item.Sequence);
				Guid? createUserId = null;
				DateTime? createDate = new DateTime?(DateTime.Now);
				Guid? modifyUserId = null;
				DateTime? modifyDate = new DateTime?(DateTime.Now);
				dataTable.Rows.Add(new object[] { addressId, ownerId, communityId, contactId, communityUnitId, addressTypeId, addressLine1, addressLine2, cityId, stateId, countyId, countryId, postalCode, originalAddressLine1, originaladdressLine2, originalCityId, originalStateId, originalCountyId, originalCountryId, originalPostalCode, latitude, longitude, isVerified, isActive, sequence, createUserId, createDate, modifyUserId, modifyDate });
			}
			return dataTable;
		}

		internal static DataTable GetAmenityIdTable(this List<long> amenityIds)
		{
			DataTable table = new DataTable("AmenityTypeIdTable");
			table.Columns.Add(TableParamsExtensions.GetDataColumn<long>("Id", true));
			if (amenityIds == null)
			{
				return table;
			}
			foreach (long amenityId in amenityIds)
			{
				table.Rows.Add(new object[] { amenityId });
			}
			return table;
		}

		internal static DataTable GetAmenityTable(this IEnumerable<Amenity> items)
		{
			long? nullable;
			DataTable dataTable = new DataTable("AmenityTableType");
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<long>("AmenityId", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<long>("CommunityId", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<long>("CommunityUnitId", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<int>("AmenityTypeId", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<string>("AdditionalDescription", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<bool>("IsActive", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<int>("Sequence", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<Guid>("CreateUserId", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<DateTime>("CreateDate", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<Guid>("ModifyUserId", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<DateTime>("ModifyDate", true));
			if (items == null)
			{
				return dataTable;
			}
			int sequenceCounter = 1;
			foreach (Amenity item in items)
			{
				if (item == null)
				{
					continue;
				}
				long? amenityId = item.Id;
				long? communityId = null;
				long? communityUnitId = null;
				int? classId = item.ClassId;
				if (classId.HasValue)
				{
					classId = item.ClassId;
					if (!(classId.GetValueOrDefault() == -1 & classId.HasValue))
					{
						goto Label0;
					}
				}
				item.ClassId = new int?(0);
			Label0:
				classId = item.ClassId;
				if (classId.HasValue)
				{
					nullable = new long?((long)classId.GetValueOrDefault());
				}
				else
				{
					nullable = null;
				}
				long? amenityTypeId = nullable;
				string additionalDescription = null;
				classId = item.ClassId;
				if (classId.GetValueOrDefault() == 0 & classId.HasValue)
				{
					additionalDescription = item.Name;
				}
				bool isActive = true;
				int num = sequenceCounter;
				sequenceCounter = num + 1;
				int? sequence = new int?(num);
				Guid? createUserId = null;
				DateTime? createDate = new DateTime?(DateTime.Now);
				Guid? modifyUserId = null;
				DateTime? modifyDate = new DateTime?(DateTime.Now);
				dataTable.Rows.Add(new object[] { amenityId, communityId, communityUnitId, amenityTypeId, additionalDescription, isActive, sequence, createUserId, createDate, modifyUserId, modifyDate });
			}
			return dataTable;
		}

		internal static DataTable GetAmenityTypeTable(this List<Amenity> amenities, CommunityType? communityType, CommunityUnitType? communityUnitType)
		{
			DataTable dataTable = new DataTable("AmenityTypeTable");
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<int>("AmenityTypeId", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<int>("CommunityClassId", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<int>("CommunityUnitClassId", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<string>("Description", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<bool>("IsActive", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<int>("Sequence", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<Guid>("CreateUserId", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<DateTime>("CreateDate", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<Guid>("ModifyUserId", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<DateTime>("ModifyDate", true));
			bool isActive = true;
			int? sequence = new int?(1);
			Guid? createUserId = null;
			DateTime? createDate = new DateTime?(DateTime.Now);
			Guid? modifyUserId = null;
			DateTime? modifyDate = new DateTime?(DateTime.Now);
			foreach (Amenity amenity in amenities)
			{
				long? id = amenity.Id;
				long num = (long)0;
				object key = (id.GetValueOrDefault() > num & id.HasValue ? amenity.Id : null);
				dataTable.Rows.Add(new object[] { key, communityType, communityUnitType, amenity.Name, isActive, sequence, createUserId, createDate, modifyUserId, modifyDate });
			}
			return dataTable;
		}

		internal static DataTable GetBookTable(this IEnumerable<Book> books)
		{
			DataTable dataTable = new DataTable("BookTableType");
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<long>("BookId", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<string>("BookNumber", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<long>("BrandId", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<string>("BrandDescription", true));
			if (books == null)
			{
				return dataTable;
			}
			foreach (Book book in books)
			{
				if (book == null)
				{
					continue;
				}
				long? bookId = book.Id;
				string bookNumber = null;
				int? brandId = null;
				string brandDescription = null;
				dataTable.Rows.Add(new object[] { bookId, bookNumber, brandId, brandDescription });
			}
			return dataTable;
		}

		internal static DataTable GetCommunityUnitTable(IEnumerable<FloorPlan> floorPlans, IEnumerable<SpecHome> specHomes, IEnumerable<House> houses)
		{
			int sequenceCounter;
			DataTable dataTable = new DataTable("CommunityUnitTableType");
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<long>("CommunityUnitId", false));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<int>("CommunityUnitClassId", false));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<long>("CommunityId", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<string>("Name", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<bool>("IsActive", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<int>("Sequence", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<Guid>("CreateUserId", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<DateTime>("CreateDate", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<Guid>("ModifyUserId", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<DateTime>("ModifyDate", true));
			if (floorPlans != null)
			{
				sequenceCounter = 1;
				foreach (FloorPlan item in floorPlans)
				{
					if (!item.Id.HasValue)
					{
						continue;
					}
					long communityUnitId = item.Id.Value;
					int communityUnitClassId = 1;
					long? communityId = item.Community.Id;
					string name = item.Name;
					bool isActive = true;
					int num = sequenceCounter;
					sequenceCounter = num + 1;
					int? sequence = new int?(num);
					Guid? createUserId = null;
					DateTime? createDate = new DateTime?(DateTime.Now);
					Guid? modifyUserId = null;
					DateTime? modifyDate = new DateTime?(DateTime.Now);
					dataTable.Rows.Add(new object[] { communityUnitId, communityUnitClassId, communityId, name, isActive, sequence, createUserId, createDate, modifyUserId, modifyDate });
				}
			}
			if (specHomes != null)
			{
				sequenceCounter = 1;
				foreach (SpecHome item in specHomes)
				{
					if (!item.Id.HasValue)
					{
						continue;
					}
					long communityUnitId = item.Id.Value;
					int communityUnitClassId = 2;
					long? communityId = item.Community.Id;
					string name = item.Name;
					bool isActive = true;
					int num1 = sequenceCounter;
					sequenceCounter = num1 + 1;
					int? sequence = new int?(num1);
					Guid? createUserId = null;
					DateTime? createDate = new DateTime?(DateTime.Now);
					Guid? modifyUserId = null;
					DateTime? modifyDate = new DateTime?(DateTime.Now);
					dataTable.Rows.Add(new object[] { communityUnitId, communityUnitClassId, communityId, name, isActive, sequence, createUserId, createDate, modifyUserId, modifyDate });
				}
			}
			if (houses != null)
			{
				sequenceCounter = 1;
				foreach (House item in houses)
				{
					if (!item.Id.HasValue)
					{
						continue;
					}
					long communityUnitId = item.Id.Value;
					int communityUnitClassId = 3;
					long? communityId = item.Community.Id;
					string name = item.Name;
					bool isActive = true;
					int num2 = sequenceCounter;
					sequenceCounter = num2 + 1;
					int? sequence = new int?(num2);
					Guid? createUserId = null;
					DateTime? createDate = new DateTime?(DateTime.Now);
					Guid? modifyUserId = null;
					DateTime? modifyDate = new DateTime?(DateTime.Now);
					dataTable.Rows.Add(new object[] { communityUnitId, communityUnitClassId, communityId, name, isActive, sequence, createUserId, createDate, modifyUserId, modifyDate });
				}
			}
			return dataTable;
		}

		internal static DataTable GetContactTable(this IEnumerable<Contact> items)
		{
			DataTable dataTable = new DataTable("ContactTableType");
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<long>("ContactId", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<long>("OwnerId", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<long>("CommunityId", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<int>("ContactTypeId", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<string>("FirstName", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<string>("LastName", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<bool>("IsActive", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<int>("Sequence", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<Guid>("CreateUserId", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<DateTime>("CreateDate", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<Guid>("ModifyUserId", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<DateTime>("ModifyDate", true));
			if (items == null)
			{
				return dataTable;
			}
			foreach (Contact item in items)
			{
				if (item == null)
				{
					continue;
				}
				long? contactId = item.Id;
				long? ownerId = null;
				long? communityId = null;
				int contactTypeId = (int)item.ContactTypeId.Value;
				string firstName = item.FirstName;
				string lastName = item.LastName;
				bool isActive = true;
				int? sequence = new int?(item.Sequence);
				Guid? createUserId = null;
				DateTime? createDate = new DateTime?(DateTime.Now);
				int? modifyUserId = null;
				DateTime? modifyDate = new DateTime?(DateTime.Now);
				dataTable.Rows.Add(new object[] { contactId, ownerId, communityId, contactTypeId, firstName, lastName, isActive, sequence, createUserId, createDate, modifyUserId, modifyDate });
			}
			return dataTable;
		}

		private static DataColumn GetDataColumn<T>(string colunmName, bool allowDbNull)
		{
			DataColumn result = new DataColumn(colunmName)
			{
				DataType = typeof(T),
				AllowDBNull = allowDbNull
			};
			if (allowDbNull)
			{
				result.DefaultValue = null;
			}
			return result;
		}

		internal static DataTable GetDateTable(DateTime? startDate, DateTime? endDate, AdditionalInfoClass? infoClass, int additionalInfoTypeId)
		{
			DateTime value;
			int num;
			DateTime? nullable;
			DateTime? nullable1;
			DataTable dataTable = TableParamsExtensions.PrepareAdditionalInfoTable();
			long? additionalInfoId = null;
			if (infoClass.HasValue)
			{
				num = (int)infoClass.Value;
			}
			else
			{
				num = 0;
			}
			int? additionalInfoClassId = new int?(num);
			int? dbAdditionalInfoTypeId = new int?(additionalInfoTypeId);
			long? communityId = null;
			long? communityUnitId = null;
			long? serviceId = null;
			string shortText = null;
			string longText = null;
			if (!startDate.HasValue)
			{
				nullable = startDate;
			}
			else if (startDate.Value.Year < 1900)
			{
				value = startDate.Value;
				int month = value.Month;
				value = startDate.Value;
				nullable = new DateTime?(new DateTime(1900, month, value.Day));
			}
			else if (startDate.Value.Year > 2070)
			{
				value = startDate.Value;
				int month1 = value.Month;
				value = startDate.Value;
				nullable = new DateTime?(new DateTime(2070, month1, value.Day));
			}
			else
			{
				nullable = startDate;
			}
			DateTime? dbStartDate = nullable;
			if (!endDate.HasValue)
			{
				nullable1 = endDate;
			}
			else if (endDate.Value.Year < 1900)
			{
				value = endDate.Value;
				int num1 = value.Month;
				value = endDate.Value;
				nullable1 = new DateTime?(new DateTime(1900, num1, value.Day));
			}
			else if (endDate.Value.Year > 2070)
			{
				value = endDate.Value;
				int month2 = value.Month;
				value = endDate.Value;
				nullable1 = new DateTime?(new DateTime(2070, month2, value.Day));
			}
			else
			{
				nullable1 = endDate;
			}
			DateTime? dbEndDate = nullable1;
			bool isActive = true;
			int? sequence = new int?(1);
			Guid? createUserId = null;
			DateTime? createDate = new DateTime?(DateTime.Now);
			Guid? modifyUserId = null;
			DateTime? modifyDate = new DateTime?(DateTime.Now);
			dataTable.Rows.Add(new object[] { additionalInfoId, communityId, communityUnitId, serviceId, additionalInfoClassId, dbAdditionalInfoTypeId, shortText, longText, dbStartDate, dbEndDate, isActive, sequence, createUserId, createDate, modifyUserId, modifyDate });
			return dataTable;
		}

		internal static DataTable GetEmailTable(this IEnumerable<Email> items)
		{
			DataTable dataTable = new DataTable("EmailTableType");
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<long>("EmailId", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<long>("OwnerId", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<long>("CommunityId", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<long>("ContactId", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<int>("EmailTypeId", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<string>("Email", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<bool>("IsActive", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<int>("Sequence", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<Guid>("CreateUserId", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<DateTime>("CreateDate", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<Guid>("ModifyUserId", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<DateTime>("ModifyDate", true));
			if (items == null)
			{
				return dataTable;
			}
			foreach (Email item in items)
			{
				if (item == null)
				{
					continue;
				}
				long? emailId = item.Id;
				long? ownerId = null;
				long? communityId = null;
				long? contactId = null;
				int emailTypeId = (int)item.EmailTypeId.Value;
				string email = item.Value;
				bool isActive = true;
				int? sequence = new int?(item.Sequence);
				Guid? createUserId = null;
				DateTime? createDate = new DateTime?(DateTime.Now);
				int? modifyUserId = null;
				DateTime? modifyDate = new DateTime?(DateTime.Now);
				dataTable.Rows.Add(new object[] { emailId, ownerId, communityId, contactId, emailTypeId, email, isActive, sequence, createUserId, createDate, modifyUserId, modifyDate });
			}
			return dataTable;
		}

		internal static DataTable GetImageTable(this IEnumerable<Image> items)
		{
			DataTable dataTable = new DataTable("ImageTableType");
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<long>("ImageId", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<long>("OwnerId", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<long>("CommunityId", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<long>("CommunityUnitId", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<long>("ContactId", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<long>("ServiceId", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<int>("ImageTypeId", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<string>("UserUploadPathFileName", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<string>("PathFileName", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<string>("OriginalPath", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<string>("ThumbnailPath", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<int>("ProcessingStatusId", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<string>("Caption", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<string>("Description", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<DateTime>("UploadDate", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<Guid>("UploadUserId", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<bool>("IsActive", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<int>("Sequence", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<Guid>("CreateUserId", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<DateTime>("CreateDate", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<Guid>("ModifyUserId", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<DateTime>("ModifyDate", true));
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
				int? imageTypeId = new int?(item.ImageType);
				string userUploadPathFileName = parentDirectory;
				string pathFileName = item.Name;
				string originalUrl = item.Url;
				string thumbnailUrl = item.ThumbnailUrl;
				string caption = null;
				string description = null;
				DateTime? uploadDate = new DateTime?(DateTime.Now);
				Guid? uploadUserId = null;
				bool isActive = true;
				int num = sequenceCounter;
				sequenceCounter = num + 1;
				int? sequence = new int?(num);
				Guid? createUserId = null;
				DateTime? createDate = new DateTime?(DateTime.Now);
				Guid? modifyUserId = null;
				DateTime? modifyDate = new DateTime?(DateTime.Now);
				dataTable.Rows.Add(new object[] { imageId, ownerId, communityId, communityUnitId, contactId, serviceId, imageTypeId, userUploadPathFileName, pathFileName, originalUrl, thumbnailUrl, DBNull.Value, caption, description, uploadDate, uploadUserId, isActive, sequence, createUserId, createDate, modifyUserId, modifyDate });
			}
			return dataTable;
		}

		internal static DataTable GetOfficeHoursTable(this IEnumerable<OfficeHours> officeHoursList)
		{
			int num;
			DataTable dataTable = new DataTable("CommunityOfficeHoursTableType");
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<long>("CommunityOfficeHoursId", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<long>("CommunityId", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<long>("ServiceId", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<int>("DayOfWeekId", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<DateTime>("StartTime", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<DateTime>("EndTime", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<string>("Note", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<bool>("IsActive", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<int>("Sequence", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<Guid>("CreateUserId", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<DateTime>("CreateDate", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<Guid>("ModifyUserId", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<DateTime>("ModifyDate", true));
			if (officeHoursList == null)
			{
				return dataTable;
			}
			int sequenceCounter = 1;
			foreach (OfficeHours officeHours in officeHoursList)
			{
				if (officeHours == null)
				{
					continue;
				}
				num = (int)((officeHours.StartDay.HasValue ? officeHours.StartDay.Value : officeHours.EndDay.Value));
				int endDayInt = (int)((officeHours.EndDay.HasValue ? officeHours.EndDay.Value : officeHours.StartDay.Value));
				for (int i = num; i <= endDayInt; i++)
				{
					long? communityOfficeHoursId = null;
					long? communityId = null;
					long? serviceId = null;
					int? dayOfWeekId = new int?(i);
					DateTime? startTime = officeHours.StartTime;
					DateTime? endTime = officeHours.EndTime;
					string note = officeHours.Note;
					int num1 = sequenceCounter;
					sequenceCounter = num1 + 1;
					int? sequence = new int?(num1);
					Guid? createUserId = null;
					DateTime? createDate = new DateTime?(DateTime.Now);
					Guid? modifyUserId = null;
					DateTime? modifyDate = new DateTime?(DateTime.Now);
					dataTable.Rows.Add(new object[] { communityOfficeHoursId, communityId, serviceId, dayOfWeekId, startTime, endTime, note, true, sequence, createUserId, createDate, modifyUserId, modifyDate });
				}
			}
			return dataTable;
		}

		internal static DataTable GetPaymentAdditionalInfoTable(this IEnumerable<long> paymentTypeIds, bool isService = false)
		{
			DataTable dataTable = TableParamsExtensions.PrepareAdditionalInfoTable();
			if (paymentTypeIds == null)
			{
				return dataTable;
			}
			DateTime dtNow = DateTime.Now;
			int sequenceCounter = 1;
			foreach (int item in paymentTypeIds)
			{
				long? additionalInfoId = null;
				int? additionalInfoClassId = new int?((isService ? 11 : 8));
				int? additionalInfoTypeId = new int?(item);
				long? communityId = null;
				long? communityUnitId = null;
				long? serviceId = null;
				string shortText = null;
				string longText = null;
				DateTime? startDate = null;
				DateTime? endDate = null;
				bool isActive = true;
				int num = sequenceCounter;
				sequenceCounter = num + 1;
				int? sequence = new int?(num);
				Guid? createUserId = null;
				DateTime? createDate = new DateTime?(dtNow);
				Guid? modifyUserId = null;
				DateTime? modifyDate = new DateTime?(dtNow);
				dataTable.Rows.Add(new object[] { additionalInfoId, communityId, communityUnitId, serviceId, additionalInfoClassId, additionalInfoTypeId, shortText, longText, startDate, endDate, isActive, sequence, createUserId, createDate, modifyUserId, modifyDate });
			}
			return dataTable;
		}

		internal static DataTable GetPhoneIdTable(this List<CallTrackingPhone> callTrackingPhones)
		{
			DataTable table = new DataTable("PhoneIdTable");
			table.Columns.Add(TableParamsExtensions.GetDataColumn<long>("Id", true));
			if (callTrackingPhones == null)
			{
				return table;
			}
			foreach (CallTrackingPhone callTrackingPhone in callTrackingPhones)
			{
				long? callTrackingPhoneId = callTrackingPhone.Id;
				table.Rows.Add(new object[] { callTrackingPhoneId });
			}
			return table;
		}

		internal static DataTable GetPhonesTable(this IEnumerable<CallTrackingPhone> items)
		{
			DataTable dataTable = new DataTable("PhoneTableType");
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<long>("PhoneId", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<long>("OwnerId", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<long>("CommunityId", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<long>("ContactId", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<long>("ServiceId", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<int>("PhoneTypeId", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<string>("Phone", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<string>("PhoneExtension", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<string>("CampaignId", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<string>("ProvisionPhone", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<string>("ProvisionPhoneExtension", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<string>("ListingPhone", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<DateTime>("StartDate", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<DateTime>("ExpirationDate", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<DateTime>("WindDownDate", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<DateTime>("DisconnectDate", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<DateTime>("ReconnectDate", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<bool>("IsClickToCall", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<bool>("IsWhisper", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<bool>("IsCallReview", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<bool>("IsDisconnected", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<Guid>("DisconnectedUserId", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<bool>("IsActive", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<int>("Sequence", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<Guid>("CreateUserId", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<DateTime>("CreateDate", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<Guid>("ModifyUserId", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<DateTime>("ModifyDate", true));
			if (items == null)
			{
				return dataTable;
			}
			int sequenceCounter = 1;
			foreach (CallTrackingPhone item in items)
			{
				if (item == null)
				{
					continue;
				}
				long? phoneId = item.Id;
				long? ownerId = null;
				long? communityId = null;
				long? contactId = null;
				long? serviceId = null;
				int? phoneTypeId = new int?(item.PhoneType);
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
				int num = sequenceCounter;
				sequenceCounter = num + 1;
				int? sequence = new int?(num);
				Guid? createUserId = null;
				DateTime? createDate = new DateTime?(DateTime.Now);
				int? modifyUserId = null;
				DateTime? modifyDate = new DateTime?(DateTime.Now);
				dataTable.Rows.Add(new object[] { phoneId, ownerId, communityId, contactId, serviceId, phoneTypeId, phone, phoneExtension, campaignId, provisionPhone, provisionPhoneExtension, listingPhone, startDate, expirationDate, windDownDate, disconnectDate, reconnectDate, isClickToCall, isWhisper, isCallReview, isDisconencted, disconnectedUserId, isActive, sequence, createUserId, createDate, modifyUserId, modifyDate });
			}
			return dataTable;
		}

		internal static DataTable GetPhoneTable(this IEnumerable<Phone> items)
		{
			DataTable dataTable = new DataTable("PhoneTableType");
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<long>("PhoneId", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<long>("OwnerId", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<long>("CommunityId", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<long>("ContactId", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<long>("ServiceId", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<int>("PhoneTypeId", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<string>("Phone", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<string>("PhoneExtension", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<string>("CampaignId", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<string>("ProvisionPhone", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<string>("ProvisionPhoneExtension", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<string>("ListingPhone", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<DateTime>("StartDate", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<DateTime>("ExpirationDate", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<DateTime>("WindDownDate", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<DateTime>("DisconnectDate", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<DateTime>("ReconnectDate", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<bool>("IsClickToCall", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<bool>("IsWhisper", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<bool>("IsCallReview", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<bool>("IsDisconnected", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<Guid>("DisconnectedUserId", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<bool>("IsActive", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<int>("Sequence", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<Guid>("CreateUserId", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<DateTime>("CreateDate", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<Guid>("ModifyUserId", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<DateTime>("ModifyDate", true));
			if (items == null)
			{
				return dataTable;
			}
			foreach (Phone item in items)
			{
				if (item == null)
				{
					continue;
				}
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
				int? sequence = new int?(item.Sequence);
				Guid? createUserId = null;
				DateTime? createDate = new DateTime?(DateTime.Now);
				int? modifyUserId = null;
				DateTime? modifyDate = new DateTime?(DateTime.Now);
				dataTable.Rows.Add(new object[] { phoneId, ownerId, communityId, contactId, serviceId, phoneTypeId, phone, phoneExtension, campaignId, provisionPhone, provisionPhoneExtension, listingPhone, startDate, expirationDate, windDownDate, disconnectDate, reconnectDate, isClickToCall, isWhisper, isCallReview, isDisconnected, disconnectedUserId, isActive, sequence, createUserId, createDate, modifyUserId, modifyDate });
			}
			return dataTable;
		}

		internal static DataTable GetSeniorHousingAdditionalInfoTable(this IEnumerable<long> seniorHousingTypeIds, bool isService = false)
		{
			DataTable dataTable = TableParamsExtensions.PrepareAdditionalInfoTable();
			if (seniorHousingTypeIds == null)
			{
				return dataTable;
			}
			int sequenceCounter = 1;
			foreach (int item in seniorHousingTypeIds)
			{
				long? additionalInfoId = null;
				int? additionalInfoClassId = new int?((isService ? 10 : 2));
				int? additionalInfoTypeId = new int?(item);
				long? dbCommunityId = null;
				long? communityUnitId = null;
				long? serviceId = null;
				string shortText = null;
				string longText = null;
				DateTime? startDate = null;
				DateTime? endDate = null;
				bool isActive = true;
				int num = sequenceCounter;
				sequenceCounter = num + 1;
				int? sequence = new int?(num);
				Guid? createUserId = null;
				DateTime? createDate = new DateTime?(DateTime.Now);
				Guid? modifyUserId = null;
				DateTime? modifyDate = new DateTime?(DateTime.Now);
				dataTable.Rows.Add(new object[] { additionalInfoId, dbCommunityId, communityUnitId, serviceId, additionalInfoClassId, additionalInfoTypeId, shortText, longText, startDate, endDate, isActive, sequence, createUserId, createDate, modifyUserId, modifyDate });
			}
			return dataTable;
		}

		internal static DataTable GetServiceCountiesServedTable(this IEnumerable<County> counties)
		{
			DataTable dataTable = new DataTable("CountiesServedTableType");
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<long>("ServiceId", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<long>("CountyId", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<Guid>("CreateUserId", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<DateTime>("CreateDate", true));
			if (counties == null)
			{
				return dataTable;
			}
			foreach (County county in counties)
			{
				if (county == null)
				{
					continue;
				}
				long? serviceId = new long?((long)-1);
				long? countyId = county.Id;
				Guid? createUserId = null;
				DateTime? createDate = new DateTime?(DateTime.Now);
				dataTable.Rows.Add(new object[] { serviceId, countyId, createUserId, createDate });
			}
			return dataTable;
		}

		private static DataTable PrepareAdditionalInfoTable()
		{
			DataTable dataTable = new DataTable("AdditionalInformationTableType");
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<long>("AdditionalInformationId", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<long>("CommunityId", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<long>("CommunityUnitId", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<long>("ServiceId", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<int>("AdditionalInformationClassId", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<int>("AdditionalInformationTypeId", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<string>("ShortText", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<string>("LongText", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<DateTime>("StartDate", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<DateTime>("EndDate", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<bool>("IsActive", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<int>("Sequence", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<Guid>("CreateUserId", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<DateTime>("CreateDate", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<Guid>("ModifyUserId", true));
			dataTable.Columns.Add(TableParamsExtensions.GetDataColumn<DateTime>("ModifyDate", true));
			return dataTable;
		}
	}
}