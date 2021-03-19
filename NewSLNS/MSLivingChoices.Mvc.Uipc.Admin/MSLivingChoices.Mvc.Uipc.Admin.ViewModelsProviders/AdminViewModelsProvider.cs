using MSLivingChoices.Bcs.Admin.Components;
using MSLivingChoices.Bcs.Components;
using MSLivingChoices.Entities.Admin;
using MSLivingChoices.Entities.Admin.Enums;
using MSLivingChoices.Localization;
using MSLivingChoices.Mvc.Uipc.Admin.Helpers;
using MSLivingChoices.Mvc.Uipc.Admin.MappingExtentions;
using MSLivingChoices.Mvc.Uipc.Admin.ViewModels;
using MSLivingChoices.Mvc.Uipc.Admin.ViewModels.Common;
using MSLivingChoices.Mvc.Uipc.Helpers;
using MSLivingChoices.Mvc.Uipc.Legacy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web.Mvc;
using UserManagementSystem.Shared.Entities;
using UserManagementSystem.Shared.Entities.Enum;

namespace MSLivingChoices.Mvc.Uipc.Admin.ViewModelsProviders
{
	public static class AdminViewModelsProvider
	{
		public static AdditionalInfoTypesVm GatAdditionalInfoTypesVm(AdditionalInfoClass additionalInfoClass)
		{
			return new AdditionalInfoTypesVm()
			{
				Types = MSLivingChoices.Bcs.Admin.Components.ItemTypeBc.Instance.GetAdditionalInfo(additionalInfoClass).MapToKeyValuePairVm<int, string>(),
				CategoryClass = additionalInfoClass
			};
		}

		public static EditAmenitiesVm GatEditAmenitiesVm(AmenityType amenityType)
		{
			EditAmenitiesVm model = new EditAmenitiesVm();
			List<Amenity> list = new List<Amenity>();
			model.CategoryClass = amenityType;
			switch (amenityType)
			{
				case AmenityType.Community:
				{
					list.AddRange(AmenityBc.Instance.GetDefaultAmenities(CommunityType.Community));
					break;
				}
				case AmenityType.FloorPlan:
				{
					list.AddRange(AmenityBc.Instance.GetDefaultAmenities(CommunityUnitType.FloorPlan));
					break;
				}
				case AmenityType.SpecHome:
				{
					list.AddRange(AmenityBc.Instance.GetDefaultAmenities(CommunityUnitType.SpecHome));
					break;
				}
				case AmenityType.House:
				{
					list.AddRange(AmenityBc.Instance.GetDefaultAmenities(CommunityUnitType.House));
					break;
				}
			}
			model.Types = list.MapToKeyValuePairVm();
			return model;
		}

		public static AddressValidationVm GetAddressValidationVm(AddressVm addressVm)
		{
			return LocationBc.Instance.GeocodeAddress(addressVm.ToEntity()).MapToAddressValidationVm();
		}

		public static AddressVm GetAddressVm()
		{
			return (new Address()).MapToAddressVm();
		}

		public static GridVm<CallTrackingPhoneForGridVm> GetCallTrackingPhonesGridVm(int? pageNumber, int? pageSize)
		{
			int totalCount;
			GridVm<CallTrackingPhoneForGridVm> callTrackingGrid = new GridVm<CallTrackingPhoneForGridVm>();
			List<CallTrackingPhone> callTrackingPhones = CallTrackingBc.Instance.GetAll(pageNumber, pageSize, out totalCount);
			callTrackingGrid.List = callTrackingPhones.MapToCallTrackingPhoneForGridVmList();
			if (pageNumber.HasValue)
			{
				callTrackingGrid.PageNumber = pageNumber.Value;
			}
			if (pageSize.HasValue)
			{
				callTrackingGrid.PageSize = pageSize.Value;
			}
			callTrackingGrid.TotalCount = totalCount;
			callTrackingGrid.GridUrl = MSLivingChoices.Mvc.Uipc.Legacy.MslcUrlBuilder.GetDefaultRouteUrl("CallTracking", "Grid");
			callTrackingGrid.JsonGridUrl = MSLivingChoices.Mvc.Uipc.Legacy.MslcUrlBuilder.GetDefaultRouteUrl("CallTracking", "JsonGrid");
			return callTrackingGrid;
		}

		public static List<CallTrackingPhoneVm> GetCallTrackingPhoneVmList(List<CallTrackingPhone> callTrackingPhones)
		{
			if (callTrackingPhones != null && callTrackingPhones.Any<CallTrackingPhone>())
			{
				return callTrackingPhones.MapToCallTrackingPhoneVmList();
			}
			return new List<CallTrackingPhoneVm>()
			{
				new CallTrackingPhoneVm()
			};
		}

		public static List<SearchSelectListItemVm> GetCities(long stateId, SearchType selectedType)
		{
			MSLivingChoices.Entities.Admin.State state = LocationBc.Instance.GetStateById(new long?(stateId));
			string stateCode = (state != null ? state.Code : string.Empty);
			return LocationBc.Instance.GetCities(stateCode, selectedType).MapToSearchSelectListItemVmList(string.Empty);
		}

		public static List<SelectListItem> GetCitiesForSeo(SearchType searchType, long? stateId)
		{
			return (
				from c in LocationBc.Instance.GetCities(stateId, searchType)
				select new SelectListItem()
				{
					Text = c.Name,
					Value = c.Id.ToString()
				}).ToList<SelectListItem>();
		}

		public static CommunityCallTrackingPhonesVm GetCommunityCallTrackingPhonesVm(long communityId)
		{
			if (!CommunityBc.Instance.IsUsersCommunity(communityId))
			{
				return null;
			}
			CommunityCallTrackingPhonesVm communityCallTrackingPhonesVm = new CommunityCallTrackingPhonesVm();
			Community community = CommunityBc.Instance.GetById(communityId);
			communityCallTrackingPhonesVm.CommunityId = new long?(communityId);
			communityCallTrackingPhonesVm.CommunityName = community.Name;
			communityCallTrackingPhonesVm.CallTrackingPhones = AdminViewModelsProvider.GetCallTrackingPhoneVmList(community.CallTrackingPhones);
			communityCallTrackingPhonesVm.ProvisionCallTrackingNumbers = communityCallTrackingPhonesVm.CallTrackingPhones.Any<CallTrackingPhoneVm>();
			communityCallTrackingPhonesVm.PublishStart = community.Publishing.StartDate;
			communityCallTrackingPhonesVm.PublishEnd = community.Publishing.EndDate;
			return communityCallTrackingPhonesVm;
		}

		public static CommunityDetailsVm GetCommunityDetailsVm()
		{
			CommunityDetailsVm communityDetailsVm = new CommunityDetailsVm()
			{
				PaymentTypes = ConverterHelpers.DictionaryToCheckBoxList(MSLivingChoices.Bcs.Admin.Components.ItemTypeBc.Instance.GetPaymentTypes()),
				PriceRange = new MeasureBoundaryVm<decimal, MoneyType>(),
				Deposit = new MeasureBoundaryVm<decimal, MoneyType>(),
				ApplicationFee = new MeasureBoundaryVm<decimal, MoneyType>(),
				PetDeposit = new MeasureBoundaryVm<decimal, MoneyType>(),
				LivingSpace = new MeasureBoundaryVm<int, LivingSpaceMeasure>(),
				AvailableBedroomsFromQuantity = MSLivingChoices.Bcs.Components.ItemTypeBc.Instance.GetBedrooms().ToSelectListItemList(),
				AvailableBedroomsToQuantity = communityDetailsVm.AvailableBedroomsFromQuantity,
				AvailableBathroomsFromQuantity = MSLivingChoices.Bcs.Components.ItemTypeBc.Instance.GetBathrooms().ToSelectListItemList(),
				AvailableBathroomsToQuantity = communityDetailsVm.AvailableBathroomsFromQuantity,
				DefaultAmenities = AmenityBc.Instance.GetDefaultAmenities(CommunityType.Community).ConvertAll<CheckBoxVm>((Amenity m) => new CheckBoxVm()
				{
					Value = m.ClassId.ToString(),
					Text = m.Name
				}),
				CustomAmenities = new List<AmenityVm>()
				{
					new AmenityVm()
				},
				DefaultCommunityServices = CommunityServiceBc.Instance.GetDefaultCommunityServices().ConvertAll<CheckBoxVm>((CommunityService m) => new CheckBoxVm()
				{
					Value = m.AdditionInfoTypeId.ToString(),
					Text = m.Name
				}),
				CustomCommunityServices = new List<CommunityServiceVm>()
				{
					new CommunityServiceVm(),
					new CommunityServiceVm()
				}
			};
			communityDetailsVm.CustomCommunityServices = new List<CommunityServiceVm>()
			{
				new CommunityServiceVm()
			};
			communityDetailsVm.Coupon = new CouponVm();
			communityDetailsVm.FloorPlans = new List<FloorPlanVm>()
			{
				AdminViewModelsProvider.GetCommunityUnit(CommunityUnitType.FloorPlan)
			};
			communityDetailsVm.SpecHomes = new List<SpecHomeVm>()
			{
				AdminViewModelsProvider.GetCommunityUnit(CommunityUnitType.SpecHome)
			};
			communityDetailsVm.Houses = new List<HouseVm>()
			{
				AdminViewModelsProvider.GetHouseUnit()
			};
			communityDetailsVm.Images = new ImageListVm(DisplayNames.CommunityImages);
			communityDetailsVm.LogoImages = new ImageListVm(DisplayNames.CommunityLogo);
			return communityDetailsVm;
		}

		public static CommunityGridVm GetCommunityGridVm(int? pageNumber, int? pageSize, CommunityGridSortByOption? sortBy, OrderBy? orderBy, CommunityGridFilter filter)
		{
			int totalCount;
			CommunityGridVm communityGrid = new CommunityGridVm()
			{
				IsAdmin = AccountBc.Instance.IsUserInRole(UmsRoles.Admin)
			};
			List<Community> communities = CommunityBc.Instance.GetAll(pageNumber, pageSize, sortBy, orderBy, filter, out totalCount);
			communityGrid.List = communities.MapToCommunityForGridVmList();
			if (pageNumber.HasValue)
			{
				communityGrid.PageNumber = pageNumber.Value;
			}
			if (pageSize.HasValue)
			{
				communityGrid.PageSize = pageSize.Value;
			}
			communityGrid.TotalCount = totalCount;
			communityGrid.SortBy = sortBy;
			communityGrid.OrderBy = orderBy;
			communityGrid.GridUrl = MSLivingChoices.Mvc.Uipc.Legacy.MslcUrlBuilder.GetRouteUrl("iList", new { Controller = "Community", Action = "Grid" });
			communityGrid.JsonGridUrl = MSLivingChoices.Mvc.Uipc.Legacy.MslcUrlBuilder.GetRouteUrl("iList", new { Controller = "Community", Action = "JsonGrid" });
			communityGrid.ChangeListingTypeStateUrl = MSLivingChoices.Mvc.Uipc.Legacy.MslcUrlBuilder.GetRouteUrl("iList", new { Controller = "Community", Action = "ChangeListingTypeState" });
			communityGrid.ChangePackageTypeUrl = MSLivingChoices.Mvc.Uipc.Legacy.MslcUrlBuilder.GetRouteUrl("iList", new { Controller = "Community", Action = "ChangePackageType" });
			communityGrid.ChangeSeniorHousingAndCareCategoriesUrl = MSLivingChoices.Mvc.Uipc.Legacy.MslcUrlBuilder.GetRouteUrl("iList", new { Controller = "Community", Action = "ChangeSeniorHousingAndCareCategories" });
			communityGrid.ChangeShowcaseDatesUrl = MSLivingChoices.Mvc.Uipc.Legacy.MslcUrlBuilder.GetRouteUrl("iList", new { Controller = "Community", Action = "ChangeShowcaseDates" });
			communityGrid.ChangePublishDatesUrl = MSLivingChoices.Mvc.Uipc.Legacy.MslcUrlBuilder.GetRouteUrl("iList", new { Controller = "Community", Action = "ChangePublishDates" });
			communityGrid.DeleteCommunityUrl = MSLivingChoices.Mvc.Uipc.Legacy.MslcUrlBuilder.GetRouteUrl("iList", new { Controller = "Community", Action = "Delete" });
			communityGrid.Filter = filter.MapToFilterForCommunityGridVm();
			return communityGrid;
		}

		public static SpecHomeVm GetCommunityUnit(CommunityUnitType communityUnitType)
		{
			SpecHomeVm specHomeVm = new SpecHomeVm()
			{
				PriceRange = new MeasureBoundaryVm<decimal, MoneyType>(),
				LivingSpace = new MeasureBoundaryVm<int, LivingSpaceMeasure>(),
				Deposit = new MeasureBoundaryVm<decimal, MoneyType>(),
				ApplicationFee = new MeasureBoundaryVm<decimal, MoneyType>(),
				PetDeposit = new MeasureBoundaryVm<decimal, MoneyType>(),
				AvailableBedroomsFromQuantity = MSLivingChoices.Bcs.Components.ItemTypeBc.Instance.GetBedrooms().ToSelectListItemList(),
				AvailableBedroomsToQuantity = specHomeVm.AvailableBedroomsFromQuantity,
				AvailableBathroomsFromQuantity = MSLivingChoices.Bcs.Components.ItemTypeBc.Instance.GetBathrooms().ToSelectListItemList(),
				AvailableBathroomsToQuantity = specHomeVm.AvailableBathroomsFromQuantity,
				CustomAmenities = new List<AmenityVm>()
				{
					new AmenityVm()
				},
				DefaultAmenities = AmenityBc.Instance.GetDefaultAmenities(communityUnitType).ConvertAll<CheckBoxVm>((Amenity m) => new CheckBoxVm()
				{
					Value = m.ClassId.ToString(),
					Text = m.Name
				}),
				Images = new ImageListVm(DisplayHelpers.GetDisplayNameForCommunityUnitImages(communityUnitType))
			};
			return specHomeVm;
		}

		public static ContactVm GetContactVm(CommunityType communityType)
		{
			return new ContactVm()
			{
				ContactTypes = MSLivingChoices.Bcs.Admin.Components.ItemTypeBc.Instance.GetContactTypes(communityType).ToSelectListItemList()
			};
		}

		public static ContactVm GetContactVm(OwnerType ownerType)
		{
			return new ContactVm()
			{
				ContactTypes = MSLivingChoices.Bcs.Admin.Components.ItemTypeBc.Instance.GetContactTypes(ownerType).ToSelectListItemList()
			};
		}

		public static ContactVm GetContactVm(ServiceType serviceType)
		{
			return new ContactVm()
			{
				ContactTypes = MSLivingChoices.Bcs.Admin.Components.ItemTypeBc.Instance.GetContactTypes(serviceType).ToSelectListItemList()
			};
		}

		public static ContactVm GetContactVm(Contact contact, List<KeyValuePair<int, string>> contactTypes)
		{
			ContactVm result = new ContactVm()
			{
				Id = contact.Id,
				ContactTypeId = contact.ContactTypeId,
				FirstName = contact.FirstName,
				LastName = contact.LastName,
				ContactTypes = contactTypes.ToSelectListItemList(result.ContactTypeId)
			};
			return result;
		}

		public static List<County> GetCounties()
		{
			return LocationBc.Instance.GetAllCounties();
		}

		public static List<SelectListItem> GetCountriesForSeo()
		{
			return (
				from c in LocationBc.Instance.GetUsableCountries()
				select new SelectListItem()
				{
					Text = c.Name,
					Value = c.Id.ToString()
				}).ToList<SelectListItem>();
		}

		public static List<SelectListItem> GetEditableAmenities()
		{
			List<SelectListItem> selectListItems = new List<SelectListItem>();
			selectListItems.AddRange(ConverterHelpers.EnumToKoSelectListItems<AmenityType>());
			return selectListItems;
		}

		public static List<SelectListItem> GetEditableCategories()
		{
			return new List<SelectListItem>()
			{
				new SelectListItem()
				{
					Text = AdditionalInfoClass.SeniorHousingAndCareCategoryService.GetEnumLocalizedValue<AdditionalInfoClass>() ?? AdditionalInfoClass.SeniorHousingAndCareCategoryService.ToString(),
					Value = 10.ToString()
				},
				new SelectListItem()
				{
					Text = AdditionalInfoClass.SeniorHousingAndCareCategory.GetEnumLocalizedValue<AdditionalInfoClass>() ?? AdditionalInfoClass.SeniorHousingAndCareCategory.ToString(),
					Value = 2.ToString()
				}
			};
		}

		public static EditCommunityVm GetEditCommunityVm(long id)
		{
			if (!CommunityBc.Instance.IsUsersCommunity(id))
			{
				return null;
			}
			Community community = CommunityBc.Instance.GetById(id);
			EditCommunityVm editCommunityVm = new EditCommunityVm()
			{
				Id = community.Id,
				MarchexAccountId = community.MarchexAccountId,
				BookId = community.Book.Id,
				Books = AccountBc.Instance.GetBooks().ToSelectListItemList(),
				Package = community.Package,
				ListingTypes = ConverterHelpers.EnumToCheckBoxList<ListingType>(community.ListingTypes),
				SeniorHousingAndCareCategories = ConverterHelpers.DictionaryToCheckBoxList(MSLivingChoices.Bcs.Admin.Components.ItemTypeBc.Instance.GetSHCCategoriesForCommunity(), community.SeniorHousingAndCareCategoryIds),
				AgeRestrictions = ConverterHelpers.EnumToCheckBoxList<AgeRestriction>(community.AgeRestrictions),
				Name = community.Name,
				Address = community.Address.MapToAddressVm(),
				DoNotDisplayAddress = !community.DisplayAddress,
				PhoneList = community.Phones.MapToPhoneListVm(CommunityType.Community)
			};
			editCommunityVm.PhoneList.AdditionalPhones.ForEach((PhoneVm ph) => ph.PhoneTypes.RemoveAll((SelectListItem pt) => pt.Text.Contains("Provision")));
			editCommunityVm.EmailList = community.Emails.MapToEmailListVm(CommunityType.Community);
			List<KeyValuePair<int, string>> contactTypes = MSLivingChoices.Bcs.Admin.Components.ItemTypeBc.Instance.GetContactTypes(CommunityType.Community);
			editCommunityVm.Contacts = (community.Contacts == null || !community.Contacts.Any<Contact>() ? new List<ContactVm>()
			{
				AdminViewModelsProvider.GetContactVm(CommunityType.Community)
			} : community.Contacts.ConvertAll<ContactVm>((Contact m) => AdminViewModelsProvider.GetContactVm(m, contactTypes)));
			editCommunityVm.OfficeHours = (community.OfficeHours == null || !community.OfficeHours.Any<OfficeHours>() ? new List<OfficeHoursVm>()
			{
				AdminViewModelsProvider.GetOfficeHoursVm()
			} : community.OfficeHours.ConvertAll<OfficeHoursVm>((OfficeHours m) => new OfficeHoursVm(m)));
			editCommunityVm.Description = community.Description;
			editCommunityVm.WebsiteUrl = community.WebsiteUrl;
			editCommunityVm.DisplayWebsiteUrl = community.DisplayWebsiteUrl;
			editCommunityVm.ListingDetails = community.MapToListingDetailsVm();
			editCommunityVm.CommunityDetails = community.MapToCommunityDetailsVm();
			editCommunityVm.PublishStart = community.Publishing.StartDate;
			editCommunityVm.PublishEnd = community.Publishing.EndDate;
			editCommunityVm.ShowcaseStart = community.Showcase.StartDate;
			editCommunityVm.ShowcaseEnd = community.Showcase.EndDate;
			return editCommunityVm;
		}

		public static EditServiceProviderVm GetEditServiceProviderVm(long id)
		{
			if (!ServiceProviderBc.Instance.IsUsersService(id))
			{
				return null;
			}
			ServiceProvider serviceProvider = ServiceProviderBc.Instance.GetById(id);
			EditServiceProviderVm editServiceProviderVm = new EditServiceProviderVm()
			{
				Id = serviceProvider.Id,
				MarchexAccountId = serviceProvider.MarchexAccountId,
				BookId = serviceProvider.Book.Id,
				Books = AccountBc.Instance.GetBooks().ToSelectListItemList(),
				ServiceCategories = ConverterHelpers.DictionaryToCheckBoxList(MSLivingChoices.Bcs.Admin.Components.ItemTypeBc.Instance.GetSHCCategoriesForServiceProvider(), (
					from sc in serviceProvider.ServiceCategories
					select sc.Key).ToList<long>()),
				AllCounties = AdminViewModelsProvider.GetCounties(),
				CountiesServed = ServiceProviderBc.Instance.GetCountiesServedById(id),
				PhoneList = serviceProvider.Phones.MapToPhoneListVm(ServiceType.ProductsAndServices)
			};
			editServiceProviderVm.PhoneList.AdditionalPhones.ForEach((PhoneVm ph) => ph.PhoneTypes.RemoveAll((SelectListItem pt) => pt.Text.Contains("Provision")));
			editServiceProviderVm.EmailList = serviceProvider.Emails.MapToEmailListVm(ServiceType.ProductsAndServices);
			List<KeyValuePair<int, string>> contactTypes = MSLivingChoices.Bcs.Admin.Components.ItemTypeBc.Instance.GetContactTypes(ServiceType.ProductsAndServices);
			editServiceProviderVm.Contacts = (serviceProvider.Contacts == null || !serviceProvider.Contacts.Any<Contact>() ? new List<ContactVm>()
			{
				AdminViewModelsProvider.GetContactVm(ServiceType.ProductsAndServices)
			} : serviceProvider.Contacts.ConvertAll<ContactVm>((Contact m) => AdminViewModelsProvider.GetContactVm(m, contactTypes)));
			editServiceProviderVm.OfficeHours = (serviceProvider.OfficeHours == null || !serviceProvider.OfficeHours.Any<OfficeHours>() ? new List<OfficeHoursVm>()
			{
				AdminViewModelsProvider.GetOfficeHoursVm()
			} : serviceProvider.OfficeHours.ConvertAll<OfficeHoursVm>((OfficeHours m) => new OfficeHoursVm(m)));
			editServiceProviderVm.FeatureStartDate = serviceProvider.FeatureStartDate;
			editServiceProviderVm.FeatureEndDate = serviceProvider.FeatureEndDate;
			editServiceProviderVm.Description = serviceProvider.Description;
			editServiceProviderVm.WebsiteUrl = serviceProvider.WebsiteUrl;
			editServiceProviderVm.DisplayWebsiteUrl = serviceProvider.DisplayWebsiteUrl;
			editServiceProviderVm.Name = serviceProvider.Name;
			editServiceProviderVm.PublishEndDate = serviceProvider.PublishEndDate;
			editServiceProviderVm.PublishStartDate = serviceProvider.PublishStartDate;
			editServiceProviderVm.Package = serviceProvider.Package;
			editServiceProviderVm.Address = (serviceProvider.Address == null ? AdminViewModelsProvider.GetAddressVm() : serviceProvider.Address.MapToAddressVm());
			editServiceProviderVm.DoNotDisplayAddress = !serviceProvider.DisplayAddress;
			editServiceProviderVm.PaymentTypes = ConverterHelpers.DictionaryToCheckBoxList(MSLivingChoices.Bcs.Admin.Components.ItemTypeBc.Instance.GetPaymentTypes(), serviceProvider.PaymentTypeIds);
			editServiceProviderVm.Images = serviceProvider.Images.MapToImageListVm(DisplayNames.ServiceProviderImages);
			editServiceProviderVm.Coupon = (serviceProvider.Coupon != null ? serviceProvider.Coupon.MapToCouponVm() : new CouponVm());
			editServiceProviderVm.ProvisionCallTrackingNumbers = serviceProvider.CallTrackingPhones.Any<CallTrackingPhone>();
			editServiceProviderVm.CallTrackingPhones = AdminViewModelsProvider.GetCallTrackingPhoneVmList(serviceProvider.CallTrackingPhones);
			return editServiceProviderVm;
		}

		public static EmailListVm GetEmailListVm(CommunityType communityType)
		{
			return null.MapToEmailListVm(communityType);
		}

		public static EmailListVm GetEmailListVm(OwnerType ownerType)
		{
			return null.MapToEmailListVm(ownerType);
		}

		public static EmailListVm GetEmailListVm(ServiceType serviceType)
		{
			return null.MapToEmailListVm(serviceType);
		}

		public static HouseVm GetHouseUnit()
		{
			HouseVm houseVm = new HouseVm()
			{
				PriceRange = new MeasureBoundaryVm<decimal, MoneyType>(),
				LivingSpace = new MeasureBoundaryVm<int, LivingSpaceMeasure>(),
				Deposit = new MeasureBoundaryVm<decimal, MoneyType>(),
				ApplicationFee = new MeasureBoundaryVm<decimal, MoneyType>(),
				PetDeposit = new MeasureBoundaryVm<decimal, MoneyType>(),
				AvailableBedroomsFromQuantity = MSLivingChoices.Bcs.Components.ItemTypeBc.Instance.GetBedrooms().ToSelectListItemList(),
				AvailableBedroomsToQuantity = houseVm.AvailableBedroomsFromQuantity,
				AvailableBathroomsFromQuantity = MSLivingChoices.Bcs.Components.ItemTypeBc.Instance.GetBathrooms().ToSelectListItemList(),
				AvailableBathroomsToQuantity = houseVm.AvailableBathroomsFromQuantity,
				CustomAmenities = new List<AmenityVm>()
				{
					new AmenityVm()
				},
				DefaultAmenities = AmenityBc.Instance.GetDefaultAmenities(CommunityUnitType.House).ConvertAll<CheckBoxVm>((Amenity m) => new CheckBoxVm()
				{
					Value = m.ClassId.ToString(),
					Text = m.Name
				}),
				Images = new ImageListVm(DisplayHelpers.GetDisplayNameForCommunityUnitImages(CommunityUnitType.House)),
				Address = AdminViewModelsProvider.GetAddressVm()
			};
			return houseVm;
		}

		public static CommunityForGridVm GetLastCommunityForGrid(int? pageNumber, int? pageSize, CommunityGridSortByOption? sortBy, OrderBy? orderBy, CommunityGridFilter filter)
		{
			int totalCount;
			int? nullable;
			CommunityBc instance = CommunityBc.Instance;
			int? nullable1 = pageNumber;
			int? nullable2 = pageSize;
			if (nullable1.HasValue & nullable2.HasValue)
			{
				nullable = new int?(nullable1.GetValueOrDefault() * nullable2.GetValueOrDefault());
			}
			else
			{
				nullable = null;
			}
			return instance.GetAll(nullable, new int?(1), sortBy, orderBy, filter, out totalCount).FirstOrDefault<Community>().MapToCommunityForGridVm();
		}

		public static ListingDetailsVm GetListingDetailsVm()
		{
			return new ListingDetailsVm()
			{
				PropertyManager = AdminViewModelsProvider.GetOwnerVm(OwnerType.PropertyManager),
				Builder = AdminViewModelsProvider.GetOwnerVm(OwnerType.Builder),
				CallTrackingPhones = new List<CallTrackingPhoneVm>()
				{
					new CallTrackingPhoneVm()
				}
			};
		}

		public static NewCommunityVm GetNewCommunityVm()
		{
			NewCommunityVm newCommunityVm = new NewCommunityVm()
			{
				Books = AccountBc.Instance.GetBooks().ToSelectListItemList(),
				ListingTypes = ConverterHelpers.EnumToCheckBoxList<ListingType>(),
				SeniorHousingAndCareCategories = ConverterHelpers.DictionaryToCheckBoxList(MSLivingChoices.Bcs.Admin.Components.ItemTypeBc.Instance.GetSHCCategoriesForCommunity()),
				AgeRestrictions = ConverterHelpers.EnumToCheckBoxList<AgeRestriction>(),
				Address = AdminViewModelsProvider.GetAddressVm(),
				PhoneList = AdminViewModelsProvider.GetPhoneList(CommunityType.Community)
			};
			newCommunityVm.PhoneList.AdditionalPhones.ForEach((PhoneVm ph) => ph.PhoneTypes.RemoveAll((SelectListItem pt) => pt.Text.Contains("Provision")));
			newCommunityVm.EmailList = AdminViewModelsProvider.GetEmailListVm(CommunityType.Community);
			newCommunityVm.Contacts = new List<ContactVm>()
			{
				AdminViewModelsProvider.GetContactVm(CommunityType.Community)
			};
			newCommunityVm.OfficeHours = new List<OfficeHoursVm>()
			{
				AdminViewModelsProvider.GetOfficeHoursVm()
			};
			newCommunityVm.CommunityDetails = AdminViewModelsProvider.GetCommunityDetailsVm();
			newCommunityVm.ListingDetails = AdminViewModelsProvider.GetListingDetailsVm();
			return newCommunityVm;
		}

		public static NewOwnerVm GetNewOwnerVm(OwnerType ownerType)
		{
			return new NewOwnerVm()
			{
				OwnerType = ownerType,
				Address = AdminViewModelsProvider.GetAddressVm(),
				PhoneList = AdminViewModelsProvider.GetPhoneList(ownerType),
				EmailList = AdminViewModelsProvider.GetEmailListVm(ownerType),
				Contacts = new List<ContactVm>()
				{
					AdminViewModelsProvider.GetContactVm(ownerType)
				},
				LogoImages = new ImageListVm(ownerType.MapToDisplayName())
			};
		}

		public static NewOwnerVm GetNewOwnerVm(Owner owner)
		{
			return owner.MapToNewOwnerVm();
		}

		public static NewServiceProviderVm GetNewServiceProviderVm()
		{
			NewServiceProviderVm newServiceProviderVm = new NewServiceProviderVm()
			{
				Package = new PackageType?(PackageType.Basic),
				Books = AccountBc.Instance.GetBooks().ToSelectListItemList(),
				ServiceCategories = ConverterHelpers.DictionaryToCheckBoxList(MSLivingChoices.Bcs.Admin.Components.ItemTypeBc.Instance.GetSHCCategoriesForServiceProvider()),
				AllCounties = AdminViewModelsProvider.GetCounties(),
				CountiesServed = new List<County>(),
				Address = AdminViewModelsProvider.GetAddressVm(),
				PhoneList = AdminViewModelsProvider.GetPhoneList(ServiceType.ProductsAndServices)
			};
			newServiceProviderVm.PhoneList.AdditionalPhones.ForEach((PhoneVm ph) => ph.PhoneTypes.RemoveAll((SelectListItem pt) => pt.Text.Contains("Provision")));
			newServiceProviderVm.EmailList = AdminViewModelsProvider.GetEmailListVm(ServiceType.ProductsAndServices);
			newServiceProviderVm.Contacts = new List<ContactVm>()
			{
				AdminViewModelsProvider.GetContactVm(ServiceType.ProductsAndServices)
			};
			newServiceProviderVm.OfficeHours = new List<OfficeHoursVm>()
			{
				AdminViewModelsProvider.GetOfficeHoursVm()
			};
			newServiceProviderVm.PaymentTypes = ConverterHelpers.DictionaryToCheckBoxList(MSLivingChoices.Bcs.Admin.Components.ItemTypeBc.Instance.GetPaymentTypes());
			newServiceProviderVm.Coupon = new CouponVm();
			newServiceProviderVm.Images = new ImageListVm(DisplayNames.ServiceProviderImages);
			newServiceProviderVm.CallTrackingPhones = new List<CallTrackingPhoneVm>()
			{
				new CallTrackingPhoneVm()
			};
			return newServiceProviderVm;
		}

		public static OfficeHoursVm GetOfficeHoursVm()
		{
			return new OfficeHoursVm()
			{
				StartTime = new DateTime?(new DateTime(1, 1, 1, 9, 0, 0)),
				EndTime = new DateTime?(new DateTime(1, 1, 1, 18, 0, 0))
			};
		}

		public static OwnerGridVm<OwnerForGridVm> GetOwnerGridVm(OwnerType type, int? pageNumber, int? pageSize)
		{
			int totalCount;
			OwnerGridVm<OwnerForGridVm> ownerGrid = new OwnerGridVm<OwnerForGridVm>();
			List<Owner> owners = OwnerBc.Instance.GetAllByOwnerType(type, pageNumber, pageSize, out totalCount);
			ownerGrid.List = owners.MapToOwnerForGridVmList();
			if (pageNumber.HasValue)
			{
				ownerGrid.PageNumber = pageNumber.Value;
			}
			if (pageSize.HasValue)
			{
				ownerGrid.PageSize = pageSize.Value;
			}
			ownerGrid.TotalCount = totalCount;
			ownerGrid.OwnerType = type;
			ownerGrid.GridUrl = MSLivingChoices.Mvc.Uipc.Legacy.MslcUrlBuilder.GetRouteUrl("iList", new { Controller = "Owner", Action = "Grid" });
			ownerGrid.JsonGridUrl = MSLivingChoices.Mvc.Uipc.Legacy.MslcUrlBuilder.GetRouteUrl("iList", new { Controller = "Owner", Action = "JsonGrid" });
			return ownerGrid;
		}

		public static OwnerVm GetOwnerVm(OwnerType ownerType)
		{
			return new OwnerVm()
			{
				NewOwner = new NewOwnerVm()
				{
					Address = AdminViewModelsProvider.GetAddressVm(),
					PhoneList = AdminViewModelsProvider.GetPhoneList(ownerType),
					EmailList = AdminViewModelsProvider.GetEmailListVm(ownerType),
					Contacts = new List<ContactVm>()
					{
						AdminViewModelsProvider.GetContactVm(ownerType)
					},
					LogoImages = new ImageListVm(ownerType.MapToDisplayName()),
					OwnerType = ownerType
				},
				Owners = (
					from m in OwnerBc.Instance.GetAllByOwnerType(ownerType)
					select new SelectListItem()
					{
						Value = m.Id.ToString(),
						Text = m.Name
					}).ToList<SelectListItem>()
			};
		}

		public static PhoneListVm GetPhoneList(CommunityType communityType)
		{
			return null.MapToPhoneListVm(communityType);
		}

		public static PhoneListVm GetPhoneList(OwnerType ownerType)
		{
			return null.MapToPhoneListVm(ownerType);
		}

		public static PhoneListVm GetPhoneList(ServiceType serviceType)
		{
			return null.MapToPhoneListVm(serviceType);
		}

		public static SeoVm GetSeoMetadata(SeoVm model)
		{
			Seo seo = new Seo()
			{
				SeoPage = model.SeoPage,
				SearchType = model.SearchType,
				CountryId = model.CountryId,
				StateId = model.StateId,
				CityId = model.CityId
			};
			Seo metaData = SeoBc.Instance.GetSeoMetaData(seo);
			SeoVm seoVm = new SeoVm()
			{
				SeoId = metaData.SeoId
			};
			seoVm.SeoMetadata.MetaDescription = metaData.MetaDescription;
			seoVm.SeoMetadata.MetaKeywords = metaData.MetaKeyword;
			seoVm.SeoMetadata.SeoCopyText = metaData.SeoCopyText;
			return seoVm;
		}

		public static ServiceProviderGridVm GetServiceProviderGridVm(int? pageNumber, int? pageSize, ServiceProviderGridSortByOption? sortBy, OrderBy? orderBy, ServiceProviderGridFilter filter)
		{
			int totalCount;
			ServiceProviderGridVm serviceProviderGrid = new ServiceProviderGridVm();
			List<ServiceProvider> serviceProviders = ServiceProviderBc.Instance.GetAll(pageNumber, pageSize, sortBy, orderBy, filter, out totalCount);
			serviceProviderGrid.List = serviceProviders.MapToServiceProviderForGridVmList();
			if (pageNumber.HasValue)
			{
				serviceProviderGrid.PageNumber = pageNumber.Value;
			}
			if (pageSize.HasValue)
			{
				serviceProviderGrid.PageSize = pageSize.Value;
			}
			serviceProviderGrid.SortBy = sortBy;
			serviceProviderGrid.OrderBy = orderBy;
			serviceProviderGrid.TotalCount = totalCount;
			serviceProviderGrid.GridUrl = MSLivingChoices.Mvc.Uipc.Legacy.MslcUrlBuilder.GetRouteUrl("iList", new { Controller = "ServiceProvider", Action = "Grid" });
			serviceProviderGrid.JsonGridUrl = MSLivingChoices.Mvc.Uipc.Legacy.MslcUrlBuilder.GetRouteUrl("iList", new { Controller = "ServiceProvider", Action = "JsonGrid" });
			serviceProviderGrid.ChangePackageTypeUrl = MSLivingChoices.Mvc.Uipc.Legacy.MslcUrlBuilder.GetRouteUrl("iList", new { Controller = "ServiceProvider", Action = "ChangePackageType" });
			serviceProviderGrid.ChangeSeniorHousingAndCareCategoriesUrl = MSLivingChoices.Mvc.Uipc.Legacy.MslcUrlBuilder.GetRouteUrl("iList", new { Controller = "ServiceProvider", Action = "ChangeSeniorHousingAndCareCategories" });
			serviceProviderGrid.ChangeFeatureDatesUrl = MSLivingChoices.Mvc.Uipc.Legacy.MslcUrlBuilder.GetRouteUrl("iList", new { Controller = "ServiceProvider", Action = "ChangeFeatureDates" });
			serviceProviderGrid.ChangePublishDatesUrl = MSLivingChoices.Mvc.Uipc.Legacy.MslcUrlBuilder.GetRouteUrl("iList", new { Controller = "ServiceProvider", Action = "ChangePublishDates" });
			serviceProviderGrid.Filter = filter.MapToFilterForServiceProviderGridVm();
			return serviceProviderGrid;
		}

		public static List<SearchSelectListItemVm> GetStates(long countryId, SearchType selectedType)
		{
			return LocationBc.Instance.GetStates(new long?(countryId), selectedType).MapToSearchSelectListItemVmList(string.Empty);
		}

		public static List<SelectListItem> GetStatesForSeo(SearchType searchType, long? countryId)
		{
			return (
				from s in LocationBc.Instance.GetStates(countryId, searchType)
				select new SelectListItem()
				{
					Text = s.Name,
					Value = s.Id.ToString()
				}).ToList<SelectListItem>();
		}

		public static UserVm GetUserVm()
		{
			UserVm result = new UserVm();
			Account account = AccountBc.Instance.GetShortedAccount();
			if (account != null)
			{
				result.FirstName = account.FirstName;
				result.LastName = account.LastName;
			}
			return result;
		}

		public static void SaveAmenityTypes(EditAmenitiesVm model)
		{
			List<Amenity> list = (
				from a in model.Types
				select new Amenity(new long?((long)a.Key), new int?(model.CategoryClass), a.Value) into a
				where !string.IsNullOrWhiteSpace(a.Name)
				select a).ToList<Amenity>();
			switch (model.CategoryClass)
			{
				case AmenityType.Community:
				{
					MSLivingChoices.Bcs.Admin.Components.ItemTypeBc.Instance.SaveDefaultCommunityAmenities(CommunityType.Community, list);
					return;
				}
				case AmenityType.FloorPlan:
				{
					MSLivingChoices.Bcs.Admin.Components.ItemTypeBc.Instance.SaveDefaultCommunityUnitAmenities(CommunityUnitType.FloorPlan, list);
					return;
				}
				case AmenityType.SpecHome:
				{
					MSLivingChoices.Bcs.Admin.Components.ItemTypeBc.Instance.SaveDefaultCommunityUnitAmenities(CommunityUnitType.SpecHome, list);
					return;
				}
				case AmenityType.House:
				{
					MSLivingChoices.Bcs.Admin.Components.ItemTypeBc.Instance.SaveDefaultCommunityUnitAmenities(CommunityUnitType.House, list);
					return;
				}
				default:
				{
					return;
				}
			}
		}

		public static void SaveCategoryTypes(AdditionalInfoTypesVm model)
		{
			List<KeyValuePair<int, string>> list = (
				from c in model.Types
				select new KeyValuePair<int, string>(c.Key, c.Value) into c
				where !string.IsNullOrWhiteSpace(c.Value)
				select c).ToList<KeyValuePair<int, string>>();
			MSLivingChoices.Bcs.Admin.Components.ItemTypeBc.Instance.SaveAdditionalInfos(model.CategoryClass, list);
		}

		public static long? SaveSeoMetaData(SeoVm model)
		{
			Seo seo = new Seo()
			{
				SeoId = model.SeoId,
				SeoPage = model.SeoPage,
				SearchType = model.SearchType,
				CountryId = model.CountryId,
				StateId = model.StateId,
				CityId = model.CityId,
				MetaKeyword = model.SeoMetadata.MetaKeywords,
				MetaDescription = model.SeoMetadata.MetaDescription,
				SeoCopyText = model.SeoMetadata.SeoCopyText,
				UserId = AccountBc.Instance.GetCurrentUserId().Value
			};
			int? seoId = SeoBc.Instance.SaveSeoMetaData(seo).SeoId;
			if (!seoId.HasValue)
			{
				return null;
			}
			return new long?((long)seoId.GetValueOrDefault());
		}

		public static ImageVm UploadImage(UploadImageVm model)
		{
			byte[] data = Convert.FromBase64String(model.Base64Image.Substring(model.Base64Image.IndexOf(',') + 1));
			ImageVm imageVm = ((model.IsCropImage ? ImageBc.CropAndSave(data, model.X, model.Y, model.Width, model.Height) : ImageBc.ResizeAndSave(data, model.X, model.Y, model.Width, model.Height))).MapToImageVm();
			imageVm.Url = MSLivingChoices.Mvc.Uipc.Admin.Helpers.MslcUrlBuilder.ImageHandlerUrl(imageVm);
			return imageVm;
		}
	}
}