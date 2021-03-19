using MSLivingChoices.Entities.Admin;
using MSLivingChoices.Entities.Admin.Enums;
using MSLivingChoices.SqlDacs.Admin;
using MSLivingChoices.SqlDacs.Admin.SqlCommands;
using MSLivingChoices.SqlDacs.Helpers;
using MSLivingChoices.SqlDacs.SqlCommands;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.SqlDacs.Admin.Helpers
{
	internal static class DataReaderHelper
	{
		private static string ClearPhone(string phone)
		{
			if (!string.IsNullOrEmpty(phone))
			{
				phone = new string(phone.Where<char>(new Func<char, bool>(char.IsDigit)).ToArray<char>());
			}
			return phone;
		}

		public static List<AdditionalInfo> GetAdditionalInfo(this SqlDataReader reader)
		{
			List<AdditionalInfo> result = new List<AdditionalInfo>();
			while (reader.Read())
			{
				bool? isActive = reader.GetNullableValue<bool>("IsActive");
				if (!isActive.HasValue || !isActive.Value)
				{
					continue;
				}
				AdditionalInfo item = new AdditionalInfo()
				{
					Id = reader.GetNullableValue<long>("AdditionalInformationId"),
					CommunityId = reader.GetNullableValue<long>("CommunityId"),
					CommunityUnitId = reader.GetNullableValue<long>("CommunityUnitId"),
					ServiceId = reader.GetNullableValue<long>("ServiceId"),
					AdditionalInfoClass = reader.GetEnum<AdditionalInfoClass>("AdditionalInformationClassId"),
					AdditionalInfoTypeId = reader.GetNullableValue<int>("AdditionalInformationTypeId"),
					Description = reader["Description"].ToString(),
					ShortText = reader["ShortText"].ToString(),
					LongText = reader["LongText"].ToString(),
					StartDate = reader.GetNullableValue<DateTime>("StartDate"),
					EndDate = reader.GetNullableValue<DateTime>("EndDate"),
					Sequence = (int)reader["Sequence"]
				};
				result.Add(item);
			}
			return result;
		}

		public static Address GetAddress(this SqlDataReader reader)
		{
			Address address = new Address();
			if (reader.Read())
			{
				address.Id = reader.GetNullableValue<long>("AddressId");
				int item = (int)reader["CityId"];
				int stateId = (int)reader["StateId"];
				int countryId = (int)reader["CountryId"];
				GetCityByIdCommand getCity = new GetCityByIdCommand(new long?((long)item));
				GetStateByIdCommand getState = new GetStateByIdCommand(new long?((long)stateId));
				GetCountryByIdCommand getCountry = new GetCountryByIdCommand(new long?((long)countryId));
				getCity.Execute();
				getState.Execute();
				getCountry.Execute();
				address.City = getCity.CommandResult;
				address.State = getState.CommandResult;
				address.Country = getCountry.CommandResult;
				address.StreetAddress = reader["AddressLine1"].ToString();
				address.PostalCode = reader["PostalCode"].ToString();
				address.Location.Latitude = reader.GetValue<double>("Latitude");
				address.Location.Longitude = reader.GetValue<double>("Longitude");
			}
			return address;
		}

		public static IEnumerable<Address> GetAddresses(this SqlDataReader reader)
		{
			List<Address> addresses = new List<Address>();
			while (reader.Read())
			{
				Address address = new Address()
				{
					Id = reader.GetNullableValue<long>("AddressId"),
					CommunityId = reader.GetNullableValue<long>("CommunityId"),
					ServiceId = reader.GetNullableValue<long>("ServiceId")
				};
				int cityId = (int)reader["CityId"];
				string cityName = reader["City"].ToString();
				int stateId = (int)reader["StateId"];
				string stateCode = reader["StateCode"].ToString().Trim();
				string stateName = reader["State"].ToString();
				int countryId = (int)reader["CountryId"];
				string countryCode = reader["CountryCode"].ToString().Trim();
				string countryName = reader["Country"].ToString();
				address.City = new City(new long?((long)cityId), cityName);
				address.State = new State(new long?((long)stateId), stateCode, stateName);
				address.Country = new Country(new long?((long)countryId), countryCode, countryName);
				address.StreetAddress = reader["AddressLine1"].ToString();
				address.PostalCode = reader["PostalCode"].ToString();
				double? latitude = reader.GetNullableValue<double>("Latitude");
				double? longitude = reader.GetNullableValue<double>("Longitude");
				address.Location.Latitude = (latitude.HasValue ? latitude.Value : 0);
				address.Location.Longitude = (longitude.HasValue ? longitude.Value : 0);
				addresses.Add(address);
			}
			return addresses;
		}

		public static List<Amenity> GetAmenities(this SqlDataReader reader, List<Amenity> dbDefaultAmenities)
		{
			int? classId;
			List<Amenity> amenities = new List<Amenity>();
			Dictionary<int, string> defaultAmenities = new Dictionary<int, string>();
			foreach (Amenity item in dbDefaultAmenities)
			{
				classId = item.ClassId;
				defaultAmenities.Add(classId.Value, item.Name);
			}
			while (reader.Read())
			{
				bool? isActive = reader.GetNullableValue<bool>("IsActive");
				if (!isActive.HasValue || !isActive.Value)
				{
					continue;
				}
				Amenity item = new Amenity()
				{
					Id = reader.GetNullableValue<long>("AmenityId"),
					CommunityId = reader.GetNullableValue<long>("CommunityId"),
					ClassId = reader.GetNullableValue<int>("AmenityTypeId")
				};
				string description = reader["AdditionalDescription"].ToString();
				if (!string.IsNullOrEmpty(description))
				{
					item.Name = description;
				}
				else if (item.ClassId.HasValue && defaultAmenities.ContainsKey(item.ClassId.Value))
				{
					classId = item.ClassId;
					item.Name = defaultAmenities[classId.Value];
				}
				amenities.Add(item);
			}
			return amenities;
		}

		public static List<CallTrackingPhone> GetCallTrackingPhones(this SqlDataReader dataReader)
		{
			List<CallTrackingPhone> result = new List<CallTrackingPhone>();
			while (dataReader.Read())
			{
				CallTrackingPhone callTrackingPhone = new CallTrackingPhone()
				{
					CommunityId = dataReader.GetValue<long?>("CommunityId"),
					ServiceId = dataReader.GetValue<long?>("ServiceId"),
					CommunityName = dataReader.GetValue<string>("Name"),
					MarchexAccountId = dataReader.GetValueOrDefault<string>("MARCHEX_AccountId"),
					Id = dataReader.GetValue<long?>("PhoneId"),
					PhoneType = (CallTrackingPhoneType)dataReader.GetValue<int>("PhoneTypeId"),
					Phone = DataReaderHelper.ClearPhone(dataReader.GetValue<string>("Phone")),
					ListingPhone = DataReaderHelper.ClearPhone(dataReader.GetValue<string>("ListingPhone")),
					PhoneExtension = dataReader.GetValue<string>("PhoneExtension"),
					CampaignId = dataReader.GetValue<string>("CampaignId"),
					ProvisionPhone = dataReader.GetValue<string>("ProvisionPhone"),
					ProvisionPhoneExtension = dataReader.GetValue<string>("ProvisionPhoneExtension"),
					StartDate = dataReader.GetValue<DateTime?>("StartDate"),
					EndDate = dataReader.GetValue<DateTime?>("ExpirationDate"),
					DisconnectDate = dataReader.GetValue<DateTime?>("DisconnectDate"),
					ReconnectDate = dataReader.GetValue<DateTime?>("ReconnectDate"),
					IsClickToCall = dataReader.GetValue<bool>("IsClickToCall"),
					IsWhisper = dataReader.GetValue<bool>("IsWhisper"),
					IsCallReview = dataReader.GetValue<bool>("IsCallReview"),
					IsDisconnected = dataReader.GetValue<bool>("IsDisconnected")
				};
				result.Add(callTrackingPhone);
			}
			return result;
		}

		public static List<Amenity> GetCommunityAmenities(this SqlDataReader reader)
		{
			GetDefaultAmenitiesCommand getDefaultAmenitiesCommand = new GetDefaultAmenitiesCommand(CommunityType.Community);
			getDefaultAmenitiesCommand.Execute();
			return reader.GetAmenities(getDefaultAmenitiesCommand.CommandResult);
		}

		public static Tuple<List<FloorPlan>, List<SpecHome>, List<House>> GetCommunityUnits(this SqlDataReader reader)
		{
			List<KeyValuePair<long, CommunityUnitType>> communityUnitIdsAndTypes = new List<KeyValuePair<long, CommunityUnitType>>();
			List<FloorPlan> floorPlans = new List<FloorPlan>();
			List<SpecHome> specHomes = new List<SpecHome>();
			List<House> houses = new List<House>();
			Tuple<List<FloorPlan>, List<SpecHome>, List<House>> tuple = new Tuple<List<FloorPlan>, List<SpecHome>, List<House>>(floorPlans, specHomes, houses);
			while (reader.Read())
			{
				long key = (long)reader["CommunityUnitId"];
				CommunityUnitType value = (CommunityUnitType)reader["CommunityUnitClassId"];
				communityUnitIdsAndTypes.Add(new KeyValuePair<long, CommunityUnitType>(key, value));
			}
			foreach (KeyValuePair<long, CommunityUnitType> item in 
				from x in communityUnitIdsAndTypes
				where x.Value == CommunityUnitType.FloorPlan
				select x)
			{
				GetFloorPlanCommand command = new GetFloorPlanCommand(item.Key);
				command.Execute();
				floorPlans.Add(command.CommandResult);
			}
			foreach (KeyValuePair<long, CommunityUnitType> item in 
				from x in communityUnitIdsAndTypes
				where x.Value == CommunityUnitType.SpecHome
				select x)
			{
				GetSpecHomeCommand command = new GetSpecHomeCommand(item.Key);
				command.Execute();
				specHomes.Add(command.CommandResult);
			}
			foreach (KeyValuePair<long, CommunityUnitType> item in 
				from x in communityUnitIdsAndTypes
				where x.Value == CommunityUnitType.House
				select x)
			{
				GetHouseCommand command = new GetHouseCommand(item.Key);
				command.Execute();
				houses.Add(command.CommandResult);
			}
			return tuple;
		}

		public static List<Contact> GetContacts(this SqlDataReader reader)
		{
			List<Contact> contacts = new List<Contact>();
			while (reader.Read())
			{
				bool? isActive = reader.GetNullableValue<bool>("IsActive");
				if (!isActive.HasValue || !isActive.Value)
				{
					continue;
				}
				Contact item = new Contact()
				{
					Id = new long?((long)reader["ContactId"]),
					ContactTypeId = new long?((long)((int)reader["ContactTypeId"])),
					FirstName = reader["FirstName"].ToString(),
					LastName = reader["LastName"].ToString(),
					Sequence = (int)reader["sequence"]
				};
				contacts.Add(item);
			}
			return contacts;
		}

		public static List<County> GetCounties(this SqlDataReader dataReader)
		{
			List<County> counties = new List<County>();
			while (dataReader.Read())
			{
				int id = (int)dataReader["CountyId"];
				string name = dataReader["County"].ToString().Trim();
				if (id == 0)
				{
					continue;
				}
				counties.Add(new County()
				{
					Id = new long?((long)id),
					Name = name
				});
			}
			return counties;
		}

		public static List<Country> GetCountries(this SqlDataReader dataReader)
		{
			List<Country> countries = new List<Country>();
			while (dataReader.Read())
			{
				int id = (int)dataReader["CountryId"];
				string name = dataReader["Country"].ToString().Trim();
				string code = dataReader["CountryCode"].ToString().Trim();
				if (id == 0)
				{
					continue;
				}
				countries.Add(new Country()
				{
					Id = new long?((long)id),
					Name = name,
					Code = code
				});
			}
			return countries;
		}

		public static Coupon GetCoupon(this SqlDataReader reader)
		{
			AdditionalInfo result = reader.GetAdditionalInfo().FirstOrDefault<AdditionalInfo>();
			Coupon coupon = null;
			if (result != null)
			{
				coupon = new Coupon()
				{
					Id = result.Id,
					PublishDate = result.StartDate,
					ExpirationDate = result.EndDate,
					Name = result.ShortText,
					Description = result.LongText
				};
			}
			return coupon;
		}

		public static List<Email> GetEmails(this SqlDataReader reader)
		{
			List<Email> emails = new List<Email>();
			while (reader.Read())
			{
				bool? isActive = reader.GetNullableValue<bool>("IsActive");
				if (!isActive.HasValue || !isActive.Value)
				{
					continue;
				}
				Email item = new Email()
				{
					Id = reader.GetNullableValue<long>("EmailId"),
					EmailTypeId = new long?((long)((int)reader["EmailTypeId"])),
					Value = reader["Email"].ToString(),
					Sequence = (int)reader["Sequence"]
				};
				emails.Add(item);
			}
			return emails;
		}

		public static List<Image> GetImages(this SqlDataReader reader)
		{
			List<Image> images = new List<Image>();
			while (reader.Read())
			{
				bool? isActive = reader.GetNullableValue<bool>("IsActive");
				if (!isActive.HasValue || !isActive.Value)
				{
					continue;
				}
				Image image = new Image()
				{
					Id = reader.GetNullableValue<long>("ImageId"),
					CommunityId = reader.GetNullableValue<long>("CommunityId"),
					CommunityUnitId = reader.GetNullableValue<long>("CommunityUnitId"),
					ServiceId = reader.GetNullableValue<long>("ServiceId"),
					ImageType = reader.GetEnum<ImageType>("ImageTypeId"),
					Status = reader.GetEnum<ImageStatus>("ProcessingStatusId"),
					Name = reader.GetValue<string>("PathFileName"),
					Url = reader.GetValueOrDefault<string>("OriginalPath"),
					ThumbnailUrl = reader.GetValueOrDefault<string>("ThumbnailPath")
				};
				images.Add(image);
			}
			return images;
		}

		public static List<OfficeHours> GetOfficeHours(this SqlDataReader reader)
		{
			EuropeanDayOfWeek? nullable;
			EuropeanDayOfWeek? nullable1;
			EuropeanDayOfWeek? nullable2;
			List<OfficeHours> officeHours = new List<OfficeHours>();
			while (reader.Read())
			{
				bool? isActive = reader.GetNullableValue<bool>("IsActive");
				if (!isActive.HasValue || !isActive.Value)
				{
					continue;
				}
				OfficeHours item = new OfficeHours()
				{
					Id = reader.GetNullableValue<long>("OfficeHoursId")
				};
				OfficeHours officeHour = item;
				int? nullableValue = reader.GetNullableValue<int>("DayOfWeekId");
				if (nullableValue.HasValue)
				{
					nullable1 = new EuropeanDayOfWeek?((EuropeanDayOfWeek)nullableValue.GetValueOrDefault());
				}
				else
				{
					nullable = null;
					nullable1 = nullable;
				}
				officeHour.StartDay = nullable1;
				OfficeHours officeHour1 = item;
				nullableValue = reader.GetNullableValue<int>("DayOfWeekId");
				if (nullableValue.HasValue)
				{
					nullable2 = new EuropeanDayOfWeek?((EuropeanDayOfWeek)nullableValue.GetValueOrDefault());
				}
				else
				{
					nullable = null;
					nullable2 = nullable;
				}
				officeHour1.EndDay = nullable2;
				DateTime? startTime = reader.GetNullableValue<DateTime>("StartTime");
				if (startTime.HasValue)
				{
					item.StartTime = new DateTime?(startTime.Value);
				}
				DateTime? endTime = reader.GetNullableValue<DateTime>("EndTime");
				if (endTime.HasValue)
				{
					item.EndTime = new DateTime?(endTime.Value);
				}
				item.Note = reader["Note"].ToString();
				officeHours.Add(item);
			}
			return DataReaderHelper.NormalizeOfficeHours(officeHours);
		}

		public static Tuple<List<Phone>, List<CallTrackingPhone>> GetPhones(this SqlDataReader reader)
		{
			List<Phone> phones = new List<Phone>();
			List<CallTrackingPhone> callTrackingPhones = new List<CallTrackingPhone>();
			Tuple<List<Phone>, List<CallTrackingPhone>> tuple = new Tuple<List<Phone>, List<CallTrackingPhone>>(phones, callTrackingPhones);
			while (reader.Read())
			{
				bool? isActive = reader.GetNullableValue<bool>("IsActive");
				if (!isActive.HasValue || !isActive.Value)
				{
					continue;
				}
				string provisionPhone = reader["ProvisionPhone"].ToString();
				if (!string.IsNullOrEmpty(provisionPhone))
				{
					CallTrackingPhone phone = new CallTrackingPhone()
					{
						Id = new long?((long)reader["PhoneId"]),
						CommunityId = reader.GetNullableValue<long>("CommunityId"),
						ServiceId = reader.GetNullableValue<long>("ServiceId"),
						PhoneType = (CallTrackingPhoneType)((int)reader["PhoneTypeId"]),
						Phone = DataReaderHelper.ClearPhone(reader["Phone"].ToString()),
						ListingPhone = DataReaderHelper.ClearPhone(reader["ListingPhone"].ToString()),
						ProvisionPhone = provisionPhone,
						StartDate = reader.GetNullableValue<DateTime>("StartDate"),
						EndDate = reader.GetNullableValue<DateTime>("ExpirationDate"),
						IsClickToCall = reader.GetNullableValue<bool>("IsClickToCall").FromNullable(),
						IsWhisper = reader.GetNullableValue<bool>("IsWhisper").FromNullable(),
						IsCallReview = reader.GetNullableValue<bool>("IsCallReview").FromNullable(),
						IsDisconnected = reader.GetNullableValue<bool>("IsDisconnected").FromNullable(),
						CampaignId = reader["CampaignId"].ToString(),
						DisconnectDate = reader.GetNullableValue<DateTime>("DisconnectDate"),
						ReconnectDate = reader.GetNullableValue<DateTime>("ReconnectDate")
					};
					callTrackingPhones.Add(phone);
				}
				else
				{
					Phone item = new Phone()
					{
						Id = new long?((long)reader["PhoneId"]),
						CommunityId = reader.GetNullableValue<long>("CommunityId"),
						ServiceId = reader.GetNullableValue<long>("ServiceId"),
						PhoneTypeId = new long?((long)((int)reader["PhoneTypeId"])),
						Number = reader["Phone"].ToString(),
						Sequence = (int)reader["Sequence"]
					};
					phones.Add(item);
				}
			}
			return tuple;
		}

		public static Seo GetSeo(this SqlDataReader dataReader)
		{
			Seo result = new Seo();
			while (dataReader.Read())
			{
				result.SeoId = new int?(dataReader.GetValue<int>("SEODataId"));
				result.MetaDescription = dataReader.GetValue<string>("MetaDescription");
				result.MetaKeyword = dataReader.GetValue<string>("MetaKeywords");
				result.SeoCopyText = dataReader.GetValue<string>("SEOCopy");
			}
			return result;
		}

		public static List<OfficeHours> NormalizeOfficeHours(List<OfficeHours> officeHours)
		{
			if (!officeHours.Any())
			{
				return officeHours;
			}
			List<OfficeHours> newList = new List<OfficeHours>();
			OfficeHours newItem = officeHours.First();
			for (int i = 1; i < officeHours.Count; i++)
			{
				bool isEqualNotes = (string.IsNullOrWhiteSpace(newItem.Note) && string.IsNullOrWhiteSpace(officeHours[i].Note)) || (!string.IsNullOrWhiteSpace(newItem.Note) && !string.IsNullOrWhiteSpace(officeHours[i].Note) && newItem.Note.Equals(officeHours[i].Note));
				if (newItem.StartTime == officeHours[i].StartTime && newItem.EndTime == officeHours[i].EndTime && isEqualNotes && newItem.EndDay + 1 == officeHours[i].EndDay)
				{
					newItem.EndDay = officeHours[i].EndDay;
					continue;
				}
				newList.Add(newItem);
				newItem = officeHours[i];
			}
			newList.Add(newItem);
			return newList;
		}
		
	}
}