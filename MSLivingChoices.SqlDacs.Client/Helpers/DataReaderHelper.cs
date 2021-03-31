using MSLivingChoices.Entities.Client;
using MSLivingChoices.Entities.Client.DisplayOptions;
using MSLivingChoices.Entities.Client.Enums;
using MSLivingChoices.Entities.Client.Search.Criteria;
using MSLivingChoices.SqlDacs.Helpers;
using MSLivingChoices.Utilities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.SqlDacs.Client.Helpers
{
	internal static class DataReaderHelper
	{
		public static Community GetFeaturedCommunity(this SqlDataReader reader)
		{
			Community community = new Community();
			community.Id = reader.GetValueOrDefault<long>("CommunityId");
			community.Name = reader.GetValueOrDefault<string>("Name");
			community.Phone = reader.GetValueOrDefault<string>("Phone");
			community.PackageId = reader.GetValueOrDefault<int>("PackageTypeId");
			community.BookNumber = reader.GetValueOrDefault<string>("BookNumber");
			community.Price = GetPrice(reader);
			community.Address = GetAddress(reader);
			community.Images = new List<Image>();
			community.Images.Add(GetImage(reader));
			community.DisplayOptions = GetCommunityDisplayOptions(reader);
			return community;
		}

		public static ServiceProvider GetFeaturedService(this SqlDataReader reader)
		{
			ServiceProvider serviceProvider = new ServiceProvider();
			serviceProvider.Id = reader.GetValueOrDefault<long>("ServiceId");
			serviceProvider.Name = reader.GetValueOrDefault<string>("Name");
			serviceProvider.Phone = reader.GetValueOrDefault<string>("Phone");
			serviceProvider.PackageId = reader.GetValueOrDefault<int>("PackageTypeId");
			serviceProvider.BookNumber = reader.GetValueOrDefault<string>("BookNumber");
			serviceProvider.Address = GetAddress(reader);
			serviceProvider.Images = new List<Image>();
			serviceProvider.Images.Add(GetImage(reader));
			serviceProvider.DisplayOptions = GetServiceDisplayOptions(reader);
			return serviceProvider;
		}

		public static Community GetSearchCommunity(this SqlDataReader reader)
		{
			Community community = new Community();
			community.Id = reader.GetValueOrDefault<long>("CommunityId");
			if (community.Id == 0L)
			{
				return null;
			}
			community.Description = reader.GetValueOrDefault<string>("Description");
			community.Name = reader.GetValueOrDefault<string>("Name");
			community.BookNumber = reader.GetValueOrDefault<string>("BookNumber");
			community.SearchResultRadius = reader.GetValueOrDefault<int>("Distance");
			community.Phone = reader.GetValueOrDefault<string>("Phone");
			community.Price = GetPrice(reader);
			community.Beds = GetBeds(reader);
			community.Bathes = GetBathes(reader);
			community.LivingSpace = GetLivingSpace(reader);
			community.PackageId = reader.GetValueOrDefault<int>("PackageTypeId");
			community.VirtualTour = reader.GetValueOrDefault<string>("iTourUrl");
			community.SearchResultRadius = reader.GetValueOrDefault<int>("Distance");
			community.Address = GetAddress(reader);
			community.DisplayOptions = GetCommunityDisplayOptions(reader);
			community.Images = new List<Image>();
			community.Amenities = new List<string>();
			return community;
		}

		public static ServiceProvider GetSearchService(this SqlDataReader reader)
		{
			ServiceProvider serviceProvider = new ServiceProvider();
			serviceProvider.Id = reader.GetValueOrDefault<long>("ServiceId");
			if (serviceProvider.Id == 0L)
			{
				return null;
			}
			serviceProvider.Name = reader.GetValueOrDefault<string>("Name");
			serviceProvider.BookNumber = reader.GetValueOrDefault<string>("BookNumber");
			serviceProvider.SearchResultRadius = reader.GetValueOrDefault<int>("Distance");
			serviceProvider.Phone = reader.GetValueOrDefault<string>("Phone");
			serviceProvider.PackageId = reader.GetValueOrDefault<int>("PackageTypeId");
			serviceProvider.SearchResultRadius = reader.GetValueOrDefault<int>("Distance");
			serviceProvider.Address = GetAddress(reader);
			serviceProvider.DisplayOptions = GetServiceDisplayOptions(reader);
			serviceProvider.Images = new List<Image>();
			serviceProvider.ServiceCategories = new List<string>();
			return serviceProvider;
		}

		public static ServiceProvider GetServiceDetail(this SqlDataReader reader)
		{
			ServiceProvider searchService = GetSearchService(reader);
			if (searchService == null)
			{
				return null;
			}
			searchService.Description = reader.GetValueOrDefault<string>("Description");
			searchService.WebsiteUrl = reader.GetValueOrDefault<string>("WebsiteURL");
			return searchService;
		}

		public static Community GetCommunityDetail(this SqlDataReader reader)
		{
			Community searchCommunity = GetSearchCommunity(reader);
			if (searchCommunity == null)
			{
				return null;
			}
			searchCommunity.Description = reader.GetValueOrDefault<string>("Description");
			searchCommunity.WebsiteUrl = reader.GetValueOrDefault<string>("WebsiteURL");
			searchCommunity.ApplicationFee = GetApplicationFee(reader);
			searchCommunity.Deposit = GetDeposit(reader);
			searchCommunity.PetDeposit = GetPetDeposit(reader);
			searchCommunity.ListingTypes = GetListingTypes(reader);
			searchCommunity.AgeRestrictions = GetAgeRestrictions(reader);
			return searchCommunity;
		}

		public static void FillCommunityUnits(this SqlDataReader reader, List<FloorPlan> floorPlanContainer, List<SpecHome> specHomeContainer, List<Home> homeContainer)
		{
			while (reader.Read())
			{
				switch (reader.GetEnum<CommunityUnitType>("CommunityUnitClassId"))
				{
					case CommunityUnitType.FloorPlan:
						{
							FloorPlan floorPlan = GetFloorPlan(reader);
							floorPlanContainer.Add(floorPlan);
							break;
						}
					case CommunityUnitType.SpecHome:
						{
							SpecHome specHome = GetSpecHome(reader);
							specHomeContainer.Add(specHome);
							break;
						}
					case CommunityUnitType.Home:
						{
							Home home = GetHome(reader);
							homeContainer.Add(home);
							break;
						}
				}
			}
		}

		public static FloorPlan GetFloorPlan(this SqlDataReader reader)
		{
			return new FloorPlan
			{
				Id = reader.GetValueOrDefault<long>("CommunityUnitId"),
				Name = reader.GetValueOrDefault<string>("Name"),
				PackageId = reader.GetValueOrDefault<int>("PackageTypeId"),
				Beds = GetBeds(reader),
				Bathes = GetBathes(reader),
				LivingSpace = GetLivingSpace(reader),
				Price = GetPrice(reader),
				ApplicationFee = GetApplicationFee(reader),
				Deposit = GetDeposit(reader),
				PetDeposit = GetPetDeposit(reader)
			};
		}

		public static SpecHome GetSpecHome(this SqlDataReader reader)
		{
			return new SpecHome
			{
				Id = reader.GetValueOrDefault<long>("CommunityUnitId"),
				Name = reader.GetValueOrDefault<string>("Name"),
				PackageId = reader.GetValueOrDefault<int>("PackageTypeId"),
				Beds = GetBeds(reader),
				Bathes = GetBathes(reader),
				LivingSpace = GetLivingSpace(reader),
				Price = GetPrice(reader),
				ApplicationFee = GetApplicationFee(reader),
				Deposit = GetDeposit(reader),
				PetDeposit = GetPetDeposit(reader),
				Description = reader.GetValueOrDefault<string>("Description"),
				SaleType = reader.GetEnum<SaleType>("SaleTypeId"),
				Status = reader.GetEnum<BuildStatus>("SpecHomeStatusTypeId")
			};
		}

		public static Home GetHome(this SqlDataReader reader)
		{
			return new Home
			{
				Id = reader.GetValueOrDefault<long>("CommunityUnitId"),
				YearBuilt = reader.GetNullableValue<int>("YearBuilt"),
				Name = reader.GetValueOrDefault<string>("Name"),
				PackageId = reader.GetValueOrDefault<int>("PackageTypeId"),
				Beds = GetBeds(reader),
				Bathes = GetBathes(reader),
				LivingSpace = GetLivingSpace(reader),
				Price = GetPrice(reader),
				ApplicationFee = GetApplicationFee(reader),
				Deposit = GetDeposit(reader),
				PetDeposit = GetPetDeposit(reader),
				Description = reader.GetValueOrDefault<string>("Description"),
				SaleType = reader.GetEnum<SaleType>("SaleTypeId"),
				Address = GetAddress(reader)
			};
		}

		public static List<ListingType> GetListingTypes(this SqlDataReader reader)
		{
			List<ListingType> list = new List<ListingType>();
			if (reader.GetValueOrDefault<bool>("HasAdultApartments"))
			{
				list.Add(ListingType.ActiveAdultCommunities);
			}
			if (reader.GetValueOrDefault<bool>("HasAdultHomes"))
			{
				list.Add(ListingType.ActiveAdultHomes);
			}
			if (reader.GetValueOrDefault<bool>("HasSeniorHousing"))
			{
				list.Add(ListingType.SeniorHousingAndCare);
			}
			return list;
		}

		public static List<AgeRestriction> GetAgeRestrictions(this SqlDataReader reader)
		{
			List<AgeRestriction> list = new List<AgeRestriction>();
			if (reader.GetValueOrDefault<bool>("IsAllAges"))
			{
				list.Add(AgeRestriction.AllAges);
			}
			if (reader.GetValueOrDefault<bool>("IsAgeTargeted"))
			{
				list.Add(AgeRestriction.AgeTargeted);
			}
			if (reader.GetValueOrDefault<bool>("IsAgeQualified"))
			{
				list.Add(AgeRestriction.AgeQualified);
			}
			return list;
		}

		public static List<OfficeHours> GetOfficeHours(this SqlDataReader reader)
		{
			List<OfficeHours> list = new List<OfficeHours>();
			while (reader.Read())
			{
				OfficeHours officeHours = new OfficeHours();
				officeHours.StartDay = (EuropeanDayOfWeek?)reader.GetNullableValue<int>("DayOfWeekId");
				officeHours.EndDay = (EuropeanDayOfWeek?)reader.GetNullableValue<int>("DayOfWeekId");
				DateTime? nullableValue = reader.GetNullableValue<DateTime>("StartTime");
				if (nullableValue.HasValue)
				{
					officeHours.StartTime = nullableValue.Value;
				}
				DateTime? nullableValue2 = reader.GetNullableValue<DateTime>("EndTime");
				if (nullableValue2.HasValue)
				{
					officeHours.EndTime = nullableValue2.Value;
				}
				officeHours.Note = reader["Note"].ToString();
				list.Add(officeHours);
			}
			return NormalizeOfficeHours(list);
		}

		public static string GetShortAdditionalInfo(this SqlDataReader reader)
		{
			return reader.GetValueOrDefault<string>("Description");
		}

		public static Address GetAddress(this SqlDataReader reader)
		{
			return new Address
			{
				CountryCode = reader.GetValueOrDefault<string>("CountryCode").SafeTrim(),
				StateCode = reader.GetValueOrDefault<string>("StateCode").SafeTrim(),
				City = reader.GetValueOrDefault<string>("City").SafeTrim().SafeToTitleCase(),
				Zip = reader.GetValueOrDefault<string>("PostalCode").SafeTrim(),
				Line = reader.GetValueOrDefault<string>("AddressLine1").SafeTrim(),
				Latitude = reader.GetValueOrDefault<double>("Latitude"),
				Longitude = reader.GetValueOrDefault<double>("Longitude")
			};
		}

		public static Image GetImage(this SqlDataReader reader)
		{
			return new Image
			{
				Type = reader.GetEnum<ImageType>("ImageTypeId", ImageType.Image),
				Url = reader.GetValueOrDefault<string>("OriginalPath"),
				ThumbnailUrl = reader.GetValueOrDefault<string>("ThumbnailPath")
			};
		}

		public static Owner GetOwner(this SqlDataReader reader)
		{
			return new Owner
			{
				Name = reader.GetValueOrDefault<string>("Name"),
				Phone = reader.GetValueOrDefault<string>("Phone"),
				WebsiteUrl = reader.GetValueOrDefault<string>("WebsiteUrl"),
				Address = GetAddress(reader),
				DisplayOptions = GetOwnerDisplayOptions(reader)
			};
		}

		public static Coupon GetCoupon(this SqlDataReader reader)
		{
			return new Coupon
			{
				ExpirationDate = reader.GetNullableValue<DateTime>("EndDate"),
				Title = reader.GetValueOrDefault<string>("ShortText"),
				Description = reader.GetValueOrDefault<string>("LongText")
			};
		}

		public static List<County> GetCounties(this SqlDataReader reader)
		{
			List<County> list = new List<County>();
			while (reader.Read())
			{
				int num = (int)reader["CountyId"];
				string name = reader["County"].ToString().Trim();
				if (num != 0)
				{
					list.Add(new County
					{
						Id = num,
						Name = name
					});
				}
			}
			return list;
		}

		public static CommunityDisplayOptions GetCommunityDisplayOptions(this SqlDataReader reader)
		{
			return new CommunityDisplayOptions
			{
				Address = reader.GetValueOrDefault<bool>("IsDisplayAddress"),
				FloorPlans = reader.GetValueOrDefault<bool>("HasFloorPlan"),
				SpecHomes = reader.GetValueOrDefault<bool>("HasSpecHome"),
				Homes = reader.GetValueOrDefault<bool>("HasHome"),
				Website = reader.GetValueOrDefault<bool>("IsDisplayWebsiteURL")
			};
		}

		public static ServiceDisplayOptions GetServiceDisplayOptions(this SqlDataReader reader)
		{
			return new ServiceDisplayOptions
			{
				Address = reader.GetValueOrDefault<bool>("IsDisplayAddress"),
				Website = reader.GetValueOrDefault<bool>("IsDisplayWebsiteURL")
			};
		}

		public static OwnerDisplayOptions GetOwnerDisplayOptions(this SqlDataReader reader)
		{
			return new OwnerDisplayOptions
			{
				Address = reader.GetValueOrDefault<bool>("IsDisplayAddress"),
				Logo = reader.GetValueOrDefault<bool>("IsDisplayLogo"),
				Name = reader.GetValueOrDefault<bool>("IsDisplayName"),
				Phone = reader.GetValueOrDefault<bool>("IsDisplayPhone"),
				Website = reader.GetValueOrDefault<bool>("IsDisplayWebsite")
			};
		}

		public static Boundary<long> GetBathes(this SqlDataReader reader)
		{
			return new Boundary<long>
			{
				Min = reader.GetNullableValue<int>("BathroomFromId"),
				Max = reader.GetNullableValue<int>("BathroomToId")
			};
		}

		public static Boundary<long> GetBeds(this SqlDataReader reader)
		{
			return new Boundary<long>
			{
				Min = reader.GetNullableValue<int>("BedroomFromId"),
				Max = reader.GetNullableValue<int>("BedroomToId")
			};
		}

		public static MeasureBoundary<decimal, Currency> GetPrice(this SqlDataReader reader)
		{
			return new MeasureBoundary<decimal, Currency>
			{
				Min = reader.GetValueOrDefault<decimal>("PricedFrom"),
				Max = reader.GetValueOrDefault<decimal>("PricedTo"),
				Measure = reader.GetEnum<Currency>("PriceCurrencyTypeId")
			};
		}

		public static MeasureBoundary<decimal, Currency> GetApplicationFee(this SqlDataReader reader)
		{
			return new MeasureBoundary<decimal, Currency>
			{
				Min = reader.GetValueOrDefault<decimal>("ApplicationFeeFrom"),
				Max = reader.GetValueOrDefault<decimal>("ApplicationFeeTo"),
				Measure = reader.GetEnum<Currency>("ApplicationFeeCurrencyTypeId")
			};
		}

		public static MeasureBoundary<decimal, Currency> GetDeposit(this SqlDataReader reader)
		{
			return new MeasureBoundary<decimal, Currency>
			{
				Min = reader.GetValueOrDefault<decimal>("DepositFrom"),
				Max = reader.GetValueOrDefault<decimal>("DepositTo"),
				Measure = reader.GetEnum<Currency>("DepositCurrencyTypeId")
			};
		}

		public static MeasureBoundary<decimal, Currency> GetPetDeposit(this SqlDataReader reader)
		{
			return new MeasureBoundary<decimal, Currency>
			{
				Min = reader.GetValueOrDefault<decimal>("PetDepositFrom"),
				Max = reader.GetValueOrDefault<decimal>("PetDepositTo"),
				Measure = reader.GetEnum<Currency>("PetDepositCurrencyTypeId")
			};
		}

		public static MeasureBoundary<int, Area> GetLivingSpace(this SqlDataReader reader)
		{
			return new MeasureBoundary<int, Area>
			{
				Min = reader.GetValueOrDefault<int>("LivingSpaceFrom"),
				Max = reader.GetValueOrDefault<int>("LivingSpaceTo"),
				Measure = reader.GetEnum<Area>("LivingSpaceUnitOfMeasureTypeId")
			};
		}

		public static List<SearchCriteria> GetAddressAutoCompleteVariants(this SqlDataReader reader)
		{
			List<SearchCriteria> list = new List<SearchCriteria>();
			while (reader.Read())
			{
				SearchCriteria addressCriteria = GetAddressCriteria(reader);
				list.Add(addressCriteria);
			}
			return list;
		}

		public static List<SearchCriteria> GetZipAutoCompleteVariants(this SqlDataReader reader)
		{
			List<SearchCriteria> list = new List<SearchCriteria>();
			while (reader.Read())
			{
				SearchCriteria zipCriteria = GetZipCriteria(reader);
				list.Add(zipCriteria);
			}
			return list;
		}

		public static SearchCriteria GetAddressCriteria(this SqlDataReader reader)
		{
			SearchCriteria searchCriteria = new SearchCriteria();
			string valueOrDefault = reader.GetValueOrDefault<string>("Country");
			string valueOrDefault2 = reader.GetValueOrDefault<string>("State");
			string valueOrDefault3 = reader.GetValueOrDefault<string>("City");
			if (!valueOrDefault.IsNullOrEmpty())
			{
				searchCriteria.CountryCode(valueOrDefault);
			}
			if (!valueOrDefault2.IsNullOrEmpty())
			{
				searchCriteria.StateCode(valueOrDefault2);
			}
			if (!valueOrDefault3.IsNullOrEmpty())
			{
				searchCriteria.City(valueOrDefault3.SafeToTitleCase());
			}
			return searchCriteria;
		}

		public static SearchCriteria GetZipCriteria(this SqlDataReader reader)
		{
			SearchCriteria searchCriteria = new SearchCriteria();
			string valueOrDefault = reader.GetValueOrDefault<string>("Country");
			string valueOrDefault2 = reader.GetValueOrDefault<string>("State");
			string valueOrDefault3 = reader.GetValueOrDefault<string>("Zip");
			string valueOrDefault4 = reader.GetValueOrDefault<string>("City");
			if (!valueOrDefault.IsNullOrEmpty())
			{
				searchCriteria.CountryCode(valueOrDefault);
			}
			if (!valueOrDefault2.IsNullOrEmpty())
			{
				searchCriteria.StateCode(valueOrDefault2);
			}
			if (!valueOrDefault4.IsNullOrEmpty())
			{
				searchCriteria.City(valueOrDefault4);
			}
			if (!valueOrDefault3.IsNullOrEmpty())
			{
				searchCriteria.Zip(valueOrDefault3);
			}
			return searchCriteria;
		}

		public static Dictionary<int, List<CompetitiveItem>> GetTrebClassesWithItems(this SqlDataReader reader, bool isActiveOnly)
		{
			Dictionary<int, List<CompetitiveItem>> dictionary = new Dictionary<int, List<CompetitiveItem>>();
			while (reader.Read())
			{
				int valueOrDefault = reader.GetValueOrDefault<int>("PackageId");
				dictionary.Add(valueOrDefault, new List<CompetitiveItem>());
			}
			if (!reader.NextResult())
			{
				return dictionary;
			}
			while (reader.Read())
			{
				int valueOrDefault2 = reader.GetValueOrDefault<int>("PackageId");
				bool valueOrDefault3 = reader.GetValueOrDefault<bool>("IsActive");
				if (!isActiveOnly || valueOrDefault3)
				{
					CompetitiveItem competitiveItem = new CompetitiveItem();
					competitiveItem.Id = reader.GetValueOrDefault<int>("ItemId");
					competitiveItem.Key = reader.GetValueOrDefault<string>("ItemKey");
					dictionary[valueOrDefault2].Add(competitiveItem);
				}
			}
			return dictionary;
		}

		private static List<OfficeHours> NormalizeOfficeHours(List<OfficeHours> officeHours)
		{
			if (!officeHours.Any())
			{
				return officeHours;
			}
			List<OfficeHours> list = new List<OfficeHours>();
			OfficeHours officeHours2 = officeHours.First();
			for (int i = 1; i < officeHours.Count; i++)
			{
				bool flag = (string.IsNullOrWhiteSpace(officeHours2.Note) && string.IsNullOrWhiteSpace(officeHours[i].Note)) || (!string.IsNullOrWhiteSpace(officeHours2.Note) && !string.IsNullOrWhiteSpace(officeHours[i].Note) && officeHours2.Note.Equals(officeHours[i].Note));
				if (officeHours2.StartTime == officeHours[i].StartTime && officeHours2.EndTime == officeHours[i].EndTime && flag && officeHours2.EndDay + 1 == officeHours[i].EndDay)
				{
					officeHours2.EndDay = officeHours[i].EndDay;
					continue;
				}
				list.Add(officeHours2);
				officeHours2 = officeHours[i];
			}
			list.Add(officeHours2);
			return list;
		}
	}

}