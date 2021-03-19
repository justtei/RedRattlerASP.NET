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
		public static GridVm<CallTrackingPhoneForGridVm> GetCallTrackingPhonesGridVm(int? pageNumber, int? pageSize)
		{
			GridVm<CallTrackingPhoneForGridVm> callTrackingGrid = new GridVm<CallTrackingPhoneForGridVm>();
			int totalCount;
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

		public static CommunityCallTrackingPhonesVm GetCommunityCallTrackingPhonesVm(long communityId)
		{
			if (!CommunityBc.Instance.IsUsersCommunity(communityId))
			{
				return null;
			}
			CommunityCallTrackingPhonesVm communityCallTrackingPhonesVm = new CommunityCallTrackingPhonesVm();
			Community community = CommunityBc.Instance.GetById(communityId);
			communityCallTrackingPhonesVm.CommunityId = communityId;
			communityCallTrackingPhonesVm.CommunityName = community.Name;
			communityCallTrackingPhonesVm.CallTrackingPhones = GetCallTrackingPhoneVmList(community.CallTrackingPhones);
			communityCallTrackingPhonesVm.ProvisionCallTrackingNumbers = communityCallTrackingPhonesVm.CallTrackingPhones.Any();
			communityCallTrackingPhonesVm.PublishStart = community.Publishing.StartDate;
			communityCallTrackingPhonesVm.PublishEnd = community.Publishing.EndDate;
			return communityCallTrackingPhonesVm;
		}

		public static List<CallTrackingPhoneVm> GetCallTrackingPhoneVmList(List<CallTrackingPhone> callTrackingPhones)
		{
			if (callTrackingPhones == null || !callTrackingPhones.Any())
			{
				return new List<CallTrackingPhoneVm>
			{
				new CallTrackingPhoneVm()
			};
			}
			return callTrackingPhones.MapToCallTrackingPhoneVmList();
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

		public static List<SearchSelectListItemVm> GetStates(long countryId, SearchType selectedType)
		{
			return LocationBc.Instance.GetStates(countryId, selectedType).MapToSearchSelectListItemVmList(string.Empty);
		}

		public static List<SearchSelectListItemVm> GetCities(long stateId, SearchType selectedType)
		{
			MSLivingChoices.Entities.Admin.State state = LocationBc.Instance.GetStateById(stateId);
			string stateCode = ((state != null) ? state.Code : string.Empty);
			return LocationBc.Instance.GetCities(stateCode, selectedType).MapToSearchSelectListItemVmList(string.Empty);
		}

		public static AddressVm GetAddressVm()
		{
			return new Address().MapToAddressVm();
		}

		public static AddressValidationVm GetAddressValidationVm(AddressVm addressVm)
		{
			return LocationBc.Instance.GeocodeAddress(addressVm.ToEntity()).MapToAddressValidationVm();
		}

		public static List<County> GetCounties()
		{
			return LocationBc.Instance.GetAllCounties();
		}

		public static List<SelectListItem> GetEditableCategories()
		{
			return new List<SelectListItem>
		{
			new SelectListItem
			{
				Text = (AdditionalInfoClass.SeniorHousingAndCareCategoryService.GetEnumLocalizedValue() ?? AdditionalInfoClass.SeniorHousingAndCareCategoryService.ToString()),
				Value = 10.ToString()
			},
			new SelectListItem
			{
				Text = (AdditionalInfoClass.SeniorHousingAndCareCategory.GetEnumLocalizedValue() ?? AdditionalInfoClass.SeniorHousingAndCareCategory.ToString()),
				Value = 2.ToString()
			}
		};
		}

		public static List<SelectListItem> GetEditableAmenities()
		{
			List<SelectListItem> list = new List<SelectListItem>();
			list.AddRange(ConverterHelpers.EnumToKoSelectListItems<AmenityType>());
			return list;
		}

		public static AdditionalInfoTypesVm GatAdditionalInfoTypesVm(AdditionalInfoClass additionalInfoClass)
		{
			return new AdditionalInfoTypesVm
			{
				Types = MSLivingChoices.Bcs.Admin.Components.ItemTypeBc.Instance.GetAdditionalInfo(additionalInfoClass).MapToKeyValuePairVm(),
				CategoryClass = additionalInfoClass
			};
		}

		public static void SaveCategoryTypes(AdditionalInfoTypesVm model)
		{
			List<KeyValuePair<int, string>> list = (from c in model.Types
													select new KeyValuePair<int, string>(c.Key, c.Value) into c
													where !string.IsNullOrWhiteSpace(c.Value)
													select c).ToList();
			MSLivingChoices.Bcs.Admin.Components.ItemTypeBc.Instance.SaveAdditionalInfos(model.CategoryClass, list);
		}

		public static EditAmenitiesVm GatEditAmenitiesVm(AmenityType amenityType)
		{
			EditAmenitiesVm model = new EditAmenitiesVm();
			List<Amenity> list = new List<Amenity>();
			model.CategoryClass = amenityType;
			switch (amenityType)
			{
				case AmenityType.Community:
					list.AddRange(AmenityBc.Instance.GetDefaultAmenities(CommunityType.Community));
					break;
				case AmenityType.FloorPlan:
					list.AddRange(AmenityBc.Instance.GetDefaultAmenities(CommunityUnitType.FloorPlan));
					break;
				case AmenityType.SpecHome:
					list.AddRange(AmenityBc.Instance.GetDefaultAmenities(CommunityUnitType.SpecHome));
					break;
				case AmenityType.House:
					list.AddRange(AmenityBc.Instance.GetDefaultAmenities(CommunityUnitType.House));
					break;
			}
			model.Types = list.MapToKeyValuePairVm();
			return model;
		}

		public static void SaveAmenityTypes(EditAmenitiesVm model)
		{
			List<Amenity> list = (from a in model.Types
								  select new Amenity(a.Key, (int)model.CategoryClass, a.Value) into a
								  where !string.IsNullOrWhiteSpace(a.Name)
								  select a).ToList();
			switch (model.CategoryClass)
			{
				case AmenityType.Community:
					MSLivingChoices.Bcs.Admin.Components.ItemTypeBc.Instance.SaveDefaultCommunityAmenities(CommunityType.Community, list);
					break;
				case AmenityType.FloorPlan:
					MSLivingChoices.Bcs.Admin.Components.ItemTypeBc.Instance.SaveDefaultCommunityUnitAmenities(CommunityUnitType.FloorPlan, list);
					break;
				case AmenityType.SpecHome:
					MSLivingChoices.Bcs.Admin.Components.ItemTypeBc.Instance.SaveDefaultCommunityUnitAmenities(CommunityUnitType.SpecHome, list);
					break;
				case AmenityType.House:
					MSLivingChoices.Bcs.Admin.Components.ItemTypeBc.Instance.SaveDefaultCommunityUnitAmenities(CommunityUnitType.House, list);
					break;
			}
		}

		public static OfficeHoursVm GetOfficeHoursVm()
		{
			return new OfficeHoursVm
			{
				StartTime = new DateTime(1, 1, 1, 9, 0, 0),
				EndTime = new DateTime(1, 1, 1, 18, 0, 0)
			};
		}

		public static NewCommunityVm GetNewCommunityVm()
		{
			NewCommunityVm newCommunityVm = new NewCommunityVm();
			newCommunityVm.Books = AccountBc.Instance.GetBooks().ToSelectListItemList();
			newCommunityVm.ListingTypes = ConverterHelpers.EnumToCheckBoxList<ListingType>();
			newCommunityVm.SeniorHousingAndCareCategories = ConverterHelpers.DictionaryToCheckBoxList(MSLivingChoices.Bcs.Admin.Components.ItemTypeBc.Instance.GetSHCCategoriesForCommunity());
			newCommunityVm.AgeRestrictions = ConverterHelpers.EnumToCheckBoxList<AgeRestriction>();
			newCommunityVm.Address = GetAddressVm();
			newCommunityVm.PhoneList = GetPhoneList(CommunityType.Community);
			newCommunityVm.PhoneList.AdditionalPhones.ForEach(delegate (PhoneVm ph)
			{
				ph.PhoneTypes.RemoveAll((SelectListItem pt) => pt.Text.Contains("Provision"));
			});
			newCommunityVm.EmailList = GetEmailListVm(CommunityType.Community);
			newCommunityVm.Contacts = new List<ContactVm>
		{
			GetContactVm(CommunityType.Community)
		};
			newCommunityVm.OfficeHours = new List<OfficeHoursVm>
		{
			GetOfficeHoursVm()
		};
			newCommunityVm.CommunityDetails = GetCommunityDetailsVm();
			newCommunityVm.ListingDetails = GetListingDetailsVm();
			return newCommunityVm;
		}

		public static CommunityDetailsVm GetCommunityDetailsVm()
		{
			CommunityDetailsVm obj = new CommunityDetailsVm
			{
				PaymentTypes = ConverterHelpers.DictionaryToCheckBoxList(MSLivingChoices.Bcs.Admin.Components.ItemTypeBc.Instance.GetPaymentTypes()),
				PriceRange = new MeasureBoundaryVm<decimal, MoneyType>(),
				Deposit = new MeasureBoundaryVm<decimal, MoneyType>(),
				ApplicationFee = new MeasureBoundaryVm<decimal, MoneyType>(),
				PetDeposit = new MeasureBoundaryVm<decimal, MoneyType>(),
				LivingSpace = new MeasureBoundaryVm<int, LivingSpaceMeasure>(),
				AvailableBedroomsFromQuantity = MSLivingChoices.Bcs.Components.ItemTypeBc.Instance.GetBedrooms().ToSelectListItemList()
			};
			obj.AvailableBedroomsToQuantity = obj.AvailableBedroomsFromQuantity;
			obj.AvailableBathroomsFromQuantity = MSLivingChoices.Bcs.Components.ItemTypeBc.Instance.GetBathrooms().ToSelectListItemList();
			obj.AvailableBathroomsToQuantity = obj.AvailableBathroomsFromQuantity;
			obj.DefaultAmenities = AmenityBc.Instance.GetDefaultAmenities(CommunityType.Community).ConvertAll((Amenity m) => new CheckBoxVm
			{
				Value = m.ClassId.ToString(),
				Text = m.Name
			});
			obj.CustomAmenities = new List<AmenityVm>
		{
			new AmenityVm()
		};
			obj.DefaultCommunityServices = CommunityServiceBc.Instance.GetDefaultCommunityServices().ConvertAll((CommunityService m) => new CheckBoxVm
			{
				Value = m.AdditionInfoTypeId.ToString(),
				Text = m.Name
			});
			obj.CustomCommunityServices = new List<CommunityServiceVm>
		{
			new CommunityServiceVm(),
			new CommunityServiceVm()
		};
			obj.CustomCommunityServices = new List<CommunityServiceVm>
		{
			new CommunityServiceVm()
		};
			obj.Coupon = new CouponVm();
			obj.FloorPlans = new List<FloorPlanVm>
		{
			GetCommunityUnit(CommunityUnitType.FloorPlan)
		};
			obj.SpecHomes = new List<SpecHomeVm>
		{
			GetCommunityUnit(CommunityUnitType.SpecHome)
		};
			obj.Houses = new List<HouseVm>
		{
			GetHouseUnit()
		};
			obj.Images = new ImageListVm(DisplayNames.CommunityImages);
			obj.LogoImages = new ImageListVm(DisplayNames.CommunityLogo);
			return obj;
		}

		public static ListingDetailsVm GetListingDetailsVm()
		{
			return new ListingDetailsVm
			{
				PropertyManager = GetOwnerVm(OwnerType.PropertyManager),
				Builder = GetOwnerVm(OwnerType.Builder),
				CallTrackingPhones = new List<CallTrackingPhoneVm>
			{
				new CallTrackingPhoneVm()
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
			EditCommunityVm editCommunityVm = new EditCommunityVm();
			editCommunityVm.Id = community.Id;
			editCommunityVm.MarchexAccountId = community.MarchexAccountId;
			editCommunityVm.BookId = community.Book.Id;
			editCommunityVm.Books = AccountBc.Instance.GetBooks().ToSelectListItemList();
			editCommunityVm.Package = community.Package;
			editCommunityVm.ListingTypes = ConverterHelpers.EnumToCheckBoxList(community.ListingTypes);
			editCommunityVm.SeniorHousingAndCareCategories = ConverterHelpers.DictionaryToCheckBoxList(MSLivingChoices.Bcs.Admin.Components.ItemTypeBc.Instance.GetSHCCategoriesForCommunity(), community.SeniorHousingAndCareCategoryIds);
			editCommunityVm.AgeRestrictions = ConverterHelpers.EnumToCheckBoxList(community.AgeRestrictions);
			editCommunityVm.Name = community.Name;
			editCommunityVm.Address = community.Address.MapToAddressVm();
			editCommunityVm.DoNotDisplayAddress = !community.DisplayAddress;
			editCommunityVm.PhoneList = community.Phones.MapToPhoneListVm(CommunityType.Community);
			editCommunityVm.PhoneList.AdditionalPhones.ForEach(delegate (PhoneVm ph)
			{
				ph.PhoneTypes.RemoveAll((SelectListItem pt) => pt.Text.Contains("Provision"));
			});
			editCommunityVm.EmailList = community.Emails.MapToEmailListVm(CommunityType.Community);
			List<KeyValuePair<int, string>> contactTypes = MSLivingChoices.Bcs.Admin.Components.ItemTypeBc.Instance.GetContactTypes(CommunityType.Community);
			editCommunityVm.Contacts = ((community.Contacts != null && community.Contacts.Any()) ? community.Contacts.ConvertAll((Contact m) => GetContactVm(m, contactTypes)) : new List<ContactVm>
		{
			GetContactVm(CommunityType.Community)
		});
			editCommunityVm.OfficeHours = ((community.OfficeHours != null && community.OfficeHours.Any()) ? community.OfficeHours.ConvertAll((OfficeHours m) => new OfficeHoursVm(m)) : new List<OfficeHoursVm>
		{
			GetOfficeHoursVm()
		});
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

		public static CommunityForGridVm GetLastCommunityForGrid(int? pageNumber, int? pageSize, CommunityGridSortByOption? sortBy, OrderBy? orderBy, CommunityGridFilter filter)
		{
			int totalCount;
			return CommunityBc.Instance.GetAll(pageNumber * pageSize, 1, sortBy, orderBy, filter, out totalCount).FirstOrDefault().MapToCommunityForGridVm();
		}

		public static SpecHomeVm GetCommunityUnit(CommunityUnitType communityUnitType)
		{
			SpecHomeVm obj = new SpecHomeVm
			{
				PriceRange = new MeasureBoundaryVm<decimal, MoneyType>(),
				LivingSpace = new MeasureBoundaryVm<int, LivingSpaceMeasure>(),
				Deposit = new MeasureBoundaryVm<decimal, MoneyType>(),
				ApplicationFee = new MeasureBoundaryVm<decimal, MoneyType>(),
				PetDeposit = new MeasureBoundaryVm<decimal, MoneyType>(),
				AvailableBedroomsFromQuantity = MSLivingChoices.Bcs.Components.ItemTypeBc.Instance.GetBedrooms().ToSelectListItemList()
			};
			obj.AvailableBedroomsToQuantity = obj.AvailableBedroomsFromQuantity;
			obj.AvailableBathroomsFromQuantity = MSLivingChoices.Bcs.Components.ItemTypeBc.Instance.GetBathrooms().ToSelectListItemList();
			obj.AvailableBathroomsToQuantity = obj.AvailableBathroomsFromQuantity;
			obj.CustomAmenities = new List<AmenityVm>
		{
			new AmenityVm()
		};
			obj.DefaultAmenities = AmenityBc.Instance.GetDefaultAmenities(communityUnitType).ConvertAll((Amenity m) => new CheckBoxVm
			{
				Value = m.ClassId.ToString(),
				Text = m.Name
			});
			obj.Images = new ImageListVm(DisplayHelpers.GetDisplayNameForCommunityUnitImages(communityUnitType));
			return obj;
		}

		public static HouseVm GetHouseUnit()
		{
			HouseVm obj = new HouseVm
			{
				PriceRange = new MeasureBoundaryVm<decimal, MoneyType>(),
				LivingSpace = new MeasureBoundaryVm<int, LivingSpaceMeasure>(),
				Deposit = new MeasureBoundaryVm<decimal, MoneyType>(),
				ApplicationFee = new MeasureBoundaryVm<decimal, MoneyType>(),
				PetDeposit = new MeasureBoundaryVm<decimal, MoneyType>(),
				AvailableBedroomsFromQuantity = MSLivingChoices.Bcs.Components.ItemTypeBc.Instance.GetBedrooms().ToSelectListItemList()
			};
			obj.AvailableBedroomsToQuantity = obj.AvailableBedroomsFromQuantity;
			obj.AvailableBathroomsFromQuantity = MSLivingChoices.Bcs.Components.ItemTypeBc.Instance.GetBathrooms().ToSelectListItemList();
			obj.AvailableBathroomsToQuantity = obj.AvailableBathroomsFromQuantity;
			obj.CustomAmenities = new List<AmenityVm>
		{
			new AmenityVm()
		};
			obj.DefaultAmenities = AmenityBc.Instance.GetDefaultAmenities(CommunityUnitType.House).ConvertAll((Amenity m) => new CheckBoxVm
			{
				Value = m.ClassId.ToString(),
				Text = m.Name
			});
			obj.Images = new ImageListVm(DisplayHelpers.GetDisplayNameForCommunityUnitImages(CommunityUnitType.House));
			obj.Address = GetAddressVm();
			return obj;
		}

		public static ContactVm GetContactVm(CommunityType communityType)
		{
			return new ContactVm
			{
				ContactTypes = MSLivingChoices.Bcs.Admin.Components.ItemTypeBc.Instance.GetContactTypes(communityType).ToSelectListItemList()
			};
		}

		public static ContactVm GetContactVm(OwnerType ownerType)
		{
			return new ContactVm
			{
				ContactTypes = MSLivingChoices.Bcs.Admin.Components.ItemTypeBc.Instance.GetContactTypes(ownerType).ToSelectListItemList()
			};
		}

		public static ContactVm GetContactVm(ServiceType serviceType)
		{
			return new ContactVm
			{
				ContactTypes = MSLivingChoices.Bcs.Admin.Components.ItemTypeBc.Instance.GetContactTypes(serviceType).ToSelectListItemList()
			};
		}

		public static ContactVm GetContactVm(Contact contact, List<KeyValuePair<int, string>> contactTypes)
		{
			ContactVm result = new ContactVm();
			result.Id = contact.Id;
			result.ContactTypeId = contact.ContactTypeId;
			result.FirstName = contact.FirstName;
			result.LastName = contact.LastName;
			result.ContactTypes = contactTypes.ToSelectListItemList(result.ContactTypeId);
			return result;
		}

		public static EmailListVm GetEmailListVm(CommunityType communityType)
		{
			return ((List<Entities.Admin.Email>)null).MapToEmailListVm(communityType);
		}

		public static EmailListVm GetEmailListVm(OwnerType ownerType)
		{
			return ((List<Entities.Admin.Email>)null).MapToEmailListVm(ownerType);
		}

		public static EmailListVm GetEmailListVm(ServiceType serviceType)
		{
			return ((List<Entities.Admin.Email>)null).MapToEmailListVm(serviceType);
		}

		public static CommunityGridVm GetCommunityGridVm(int? pageNumber, int? pageSize, CommunityGridSortByOption? sortBy, OrderBy? orderBy, CommunityGridFilter filter)
		{
			CommunityGridVm communityGrid = new CommunityGridVm();
			communityGrid.IsAdmin = true;
			int totalCount;
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
			communityGrid.GridUrl = MSLivingChoices.Mvc.Uipc.Legacy.MslcUrlBuilder.GetRouteUrl("iList", new
			{
				Controller = "Community",
				Action = "Grid"
			});
			communityGrid.JsonGridUrl = MSLivingChoices.Mvc.Uipc.Legacy.MslcUrlBuilder.GetRouteUrl("iList", new
			{
				Controller = "Community",
				Action = "JsonGrid"
			});
			communityGrid.ChangeListingTypeStateUrl = MSLivingChoices.Mvc.Uipc.Legacy.MslcUrlBuilder.GetRouteUrl("iList", new
			{
				Controller = "Community",
				Action = "ChangeListingTypeState"
			});
			communityGrid.ChangePackageTypeUrl = MSLivingChoices.Mvc.Uipc.Legacy.MslcUrlBuilder.GetRouteUrl("iList", new
			{
				Controller = "Community",
				Action = "ChangePackageType"
			});
			communityGrid.ChangeSeniorHousingAndCareCategoriesUrl = MSLivingChoices.Mvc.Uipc.Legacy.MslcUrlBuilder.GetRouteUrl("iList", new
			{
				Controller = "Community",
				Action = "ChangeSeniorHousingAndCareCategories"
			});
			communityGrid.ChangeShowcaseDatesUrl = MSLivingChoices.Mvc.Uipc.Legacy.MslcUrlBuilder.GetRouteUrl("iList", new
			{
				Controller = "Community",
				Action = "ChangeShowcaseDates"
			});
			communityGrid.ChangePublishDatesUrl = MSLivingChoices.Mvc.Uipc.Legacy.MslcUrlBuilder.GetRouteUrl("iList", new
			{
				Controller = "Community",
				Action = "ChangePublishDates"
			});
			communityGrid.DeleteCommunityUrl = MSLivingChoices.Mvc.Uipc.Legacy.MslcUrlBuilder.GetRouteUrl("iList", new
			{
				Controller = "Community",
				Action = "Delete"
			});
			communityGrid.Filter = filter.MapToFilterForCommunityGridVm();
			return communityGrid;
		}

		public static ServiceProviderGridVm GetServiceProviderGridVm(int? pageNumber, int? pageSize, ServiceProviderGridSortByOption? sortBy, OrderBy? orderBy, ServiceProviderGridFilter filter)
		{
			ServiceProviderGridVm serviceProviderGrid = new ServiceProviderGridVm();
			int totalCount;
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
			serviceProviderGrid.GridUrl = MSLivingChoices.Mvc.Uipc.Legacy.MslcUrlBuilder.GetRouteUrl("iList", new
			{
				Controller = "ServiceProvider",
				Action = "Grid"
			});
			serviceProviderGrid.JsonGridUrl = MSLivingChoices.Mvc.Uipc.Legacy.MslcUrlBuilder.GetRouteUrl("iList", new
			{
				Controller = "ServiceProvider",
				Action = "JsonGrid"
			});
			serviceProviderGrid.ChangePackageTypeUrl = MSLivingChoices.Mvc.Uipc.Legacy.MslcUrlBuilder.GetRouteUrl("iList", new
			{
				Controller = "ServiceProvider",
				Action = "ChangePackageType"
			});
			serviceProviderGrid.ChangeSeniorHousingAndCareCategoriesUrl = MSLivingChoices.Mvc.Uipc.Legacy.MslcUrlBuilder.GetRouteUrl("iList", new
			{
				Controller = "ServiceProvider",
				Action = "ChangeSeniorHousingAndCareCategories"
			});
			serviceProviderGrid.ChangeFeatureDatesUrl = MSLivingChoices.Mvc.Uipc.Legacy.MslcUrlBuilder.GetRouteUrl("iList", new
			{
				Controller = "ServiceProvider",
				Action = "ChangeFeatureDates"
			});
			serviceProviderGrid.ChangePublishDatesUrl = MSLivingChoices.Mvc.Uipc.Legacy.MslcUrlBuilder.GetRouteUrl("iList", new
			{
				Controller = "ServiceProvider",
				Action = "ChangePublishDates"
			});
			serviceProviderGrid.Filter = filter.MapToFilterForServiceProviderGridVm();
			return serviceProviderGrid;
		}

		public static OwnerGridVm<OwnerForGridVm> GetOwnerGridVm(OwnerType type, int? pageNumber, int? pageSize)
		{
			OwnerGridVm<OwnerForGridVm> ownerGrid = new OwnerGridVm<OwnerForGridVm>();
			int totalCount;
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
			ownerGrid.GridUrl = MSLivingChoices.Mvc.Uipc.Legacy.MslcUrlBuilder.GetRouteUrl("iList", new
			{
				Controller = "Owner",
				Action = "Grid"
			});
			ownerGrid.JsonGridUrl = MSLivingChoices.Mvc.Uipc.Legacy.MslcUrlBuilder.GetRouteUrl("iList", new
			{
				Controller = "Owner",
				Action = "JsonGrid"
			});
			return ownerGrid;
		}

		public static ImageVm UploadImage(UploadImageVm model)
		{
			byte[] data = Convert.FromBase64String(model.Base64Image.Substring(model.Base64Image.IndexOf(',') + 1));
			ImageVm imageVm = (model.IsCropImage ? ImageBc.CropAndSave(data, model.X, model.Y, model.Width, model.Height) : ImageBc.ResizeAndSave(data, model.X, model.Y, model.Width, model.Height)).MapToImageVm();
			imageVm.Url = MSLivingChoices.Mvc.Uipc.Admin.Helpers.MslcUrlBuilder.ImageHandlerUrl(imageVm);
			return imageVm;
		}

		public static OwnerVm GetOwnerVm(OwnerType ownerType)
		{
			return new OwnerVm
			{
				NewOwner = new NewOwnerVm
				{
					Address = GetAddressVm(),
					PhoneList = GetPhoneList(ownerType),
					EmailList = GetEmailListVm(ownerType),
					Contacts = new List<ContactVm>
				{
					GetContactVm(ownerType)
				},
					LogoImages = new ImageListVm(ownerType.MapToDisplayName()),
					OwnerType = ownerType
				},
				Owners = (from m in OwnerBc.Instance.GetAllByOwnerType(ownerType)
						  select new SelectListItem
						  {
							  Value = m.Id.ToString(),
							  Text = m.Name
						  }).ToList()
			};
		}

		public static NewOwnerVm GetNewOwnerVm(OwnerType ownerType)
		{
			return new NewOwnerVm
			{
				OwnerType = ownerType,
				Address = GetAddressVm(),
				PhoneList = GetPhoneList(ownerType),
				EmailList = GetEmailListVm(ownerType),
				Contacts = new List<ContactVm>
			{
				GetContactVm(ownerType)
			},
				LogoImages = new ImageListVm(ownerType.MapToDisplayName())
			};
		}

		public static NewOwnerVm GetNewOwnerVm(Owner owner)
		{
			return owner.MapToNewOwnerVm();
		}

		public static PhoneListVm GetPhoneList(CommunityType communityType)
		{
			return ((List<Entities.Admin.Phone>)null).MapToPhoneListVm(communityType);
		}

		public static PhoneListVm GetPhoneList(OwnerType ownerType)
		{
			return ((List<Entities.Admin.Phone>)null).MapToPhoneListVm(ownerType);
		}

		public static PhoneListVm GetPhoneList(ServiceType serviceType)
		{
			return ((List<Entities.Admin.Phone>)null).MapToPhoneListVm(serviceType);
		}

		public static SeoVm GetSeoMetadata(SeoVm model)
		{
			Seo seo = new Seo
			{
				SeoPage = model.SeoPage,
				SearchType = model.SearchType,
				CountryId = model.CountryId,
				StateId = model.StateId,
				CityId = model.CityId
			};
			Seo metaData = SeoBc.Instance.GetSeoMetaData(seo);
			return new SeoVm
			{
				SeoId = metaData.SeoId,
				SeoMetadata =
			{
				MetaDescription = metaData.MetaDescription,
				MetaKeywords = metaData.MetaKeyword,
				SeoCopyText = metaData.SeoCopyText
			}
			};
		}

		public static List<SelectListItem> GetCountriesForSeo()
		{
			return (from c in LocationBc.Instance.GetUsableCountries()
					select new SelectListItem
					{
						Text = c.Name,
						Value = c.Id.ToString()
					}).ToList();
		}

		public static List<SelectListItem> GetStatesForSeo(SearchType searchType, long? countryId)
		{
			return (from s in LocationBc.Instance.GetStates(countryId, searchType)
					select new SelectListItem
					{
						Text = s.Name,
						Value = s.Id.ToString()
					}).ToList();
		}

		public static List<SelectListItem> GetCitiesForSeo(SearchType searchType, long? stateId)
		{
			return (from c in LocationBc.Instance.GetCities(stateId, searchType)
					select new SelectListItem
					{
						Text = c.Name,
						Value = c.Id.ToString()
					}).ToList();
		}

		public static long? SaveSeoMetaData(SeoVm model)
		{
			Seo seo = new Seo
			{
				SeoId = model.SeoId,
				SeoPage = model.SeoPage,
				SearchType = model.SearchType,
				CountryId = model.CountryId,
				StateId = model.StateId,
				CityId = model.CityId,
				MetaKeyword = model.SeoMetadata.MetaKeywords,
				MetaDescription = model.SeoMetadata.MetaDescription,
				SeoCopyText = model.SeoMetadata.SeoCopyText
			};
			seo.UserId = AccountBc.Instance.GetCurrentUserId().Value;
			return SeoBc.Instance.SaveSeoMetaData(seo).SeoId;
		}

		public static NewServiceProviderVm GetNewServiceProviderVm()
		{
			NewServiceProviderVm newServiceProviderVm = new NewServiceProviderVm();
			newServiceProviderVm.Package = PackageType.Basic;
			newServiceProviderVm.Books = AccountBc.Instance.GetBooks().ToSelectListItemList();
			newServiceProviderVm.ServiceCategories = ConverterHelpers.DictionaryToCheckBoxList(MSLivingChoices.Bcs.Admin.Components.ItemTypeBc.Instance.GetSHCCategoriesForServiceProvider());
			newServiceProviderVm.AllCounties = GetCounties();
			newServiceProviderVm.CountiesServed = new List<County>();
			newServiceProviderVm.Address = GetAddressVm();
			newServiceProviderVm.PhoneList = GetPhoneList(ServiceType.ProductsAndServices);
			newServiceProviderVm.PhoneList.AdditionalPhones.ForEach(delegate (PhoneVm ph)
			{
				ph.PhoneTypes.RemoveAll((SelectListItem pt) => pt.Text.Contains("Provision"));
			});
			newServiceProviderVm.EmailList = GetEmailListVm(ServiceType.ProductsAndServices);
			newServiceProviderVm.Contacts = new List<ContactVm>
		{
			GetContactVm(ServiceType.ProductsAndServices)
		};
			newServiceProviderVm.OfficeHours = new List<OfficeHoursVm>
		{
			GetOfficeHoursVm()
		};
			newServiceProviderVm.PaymentTypes = ConverterHelpers.DictionaryToCheckBoxList(MSLivingChoices.Bcs.Admin.Components.ItemTypeBc.Instance.GetPaymentTypes());
			newServiceProviderVm.Coupon = new CouponVm();
			newServiceProviderVm.Images = new ImageListVm(DisplayNames.ServiceProviderImages);
			newServiceProviderVm.CallTrackingPhones = new List<CallTrackingPhoneVm>
		{
			new CallTrackingPhoneVm()
		};
			return newServiceProviderVm;
		}

		public static EditServiceProviderVm GetEditServiceProviderVm(long id)
		{
			if (!ServiceProviderBc.Instance.IsUsersService(id))
			{
				return null;
			}
			ServiceProvider serviceProvider = ServiceProviderBc.Instance.GetById(id);
			EditServiceProviderVm editServiceProviderVm = new EditServiceProviderVm();
			editServiceProviderVm.Id = serviceProvider.Id;
			editServiceProviderVm.MarchexAccountId = serviceProvider.MarchexAccountId;
			editServiceProviderVm.BookId = serviceProvider.Book.Id;
			editServiceProviderVm.Books = AccountBc.Instance.GetBooks().ToSelectListItemList();
			editServiceProviderVm.ServiceCategories = ConverterHelpers.DictionaryToCheckBoxList(MSLivingChoices.Bcs.Admin.Components.ItemTypeBc.Instance.GetSHCCategoriesForServiceProvider(), serviceProvider.ServiceCategories.Select((KeyValuePair<long, string> sc) => sc.Key).ToList());
			editServiceProviderVm.AllCounties = GetCounties();
			editServiceProviderVm.CountiesServed = ServiceProviderBc.Instance.GetCountiesServedById(id);
			editServiceProviderVm.PhoneList = serviceProvider.Phones.MapToPhoneListVm(ServiceType.ProductsAndServices);
			editServiceProviderVm.PhoneList.AdditionalPhones.ForEach(delegate (PhoneVm ph)
			{
				ph.PhoneTypes.RemoveAll((SelectListItem pt) => pt.Text.Contains("Provision"));
			});
			editServiceProviderVm.EmailList = serviceProvider.Emails.MapToEmailListVm(ServiceType.ProductsAndServices);
			List<KeyValuePair<int, string>> contactTypes = MSLivingChoices.Bcs.Admin.Components.ItemTypeBc.Instance.GetContactTypes(ServiceType.ProductsAndServices);
			editServiceProviderVm.Contacts = ((serviceProvider.Contacts != null && serviceProvider.Contacts.Any()) ? serviceProvider.Contacts.ConvertAll((Contact m) => GetContactVm(m, contactTypes)) : new List<ContactVm>
		{
			GetContactVm(ServiceType.ProductsAndServices)
		});
			editServiceProviderVm.OfficeHours = ((serviceProvider.OfficeHours != null && serviceProvider.OfficeHours.Any()) ? serviceProvider.OfficeHours.ConvertAll((OfficeHours m) => new OfficeHoursVm(m)) : new List<OfficeHoursVm>
		{
			GetOfficeHoursVm()
		});
			editServiceProviderVm.FeatureStartDate = serviceProvider.FeatureStartDate;
			editServiceProviderVm.FeatureEndDate = serviceProvider.FeatureEndDate;
			editServiceProviderVm.Description = serviceProvider.Description;
			editServiceProviderVm.WebsiteUrl = serviceProvider.WebsiteUrl;
			editServiceProviderVm.DisplayWebsiteUrl = serviceProvider.DisplayWebsiteUrl;
			editServiceProviderVm.Name = serviceProvider.Name;
			editServiceProviderVm.PublishEndDate = serviceProvider.PublishEndDate;
			editServiceProviderVm.PublishStartDate = serviceProvider.PublishStartDate;
			editServiceProviderVm.Package = serviceProvider.Package;
			editServiceProviderVm.Address = ((serviceProvider.Address == null) ? GetAddressVm() : serviceProvider.Address.MapToAddressVm());
			editServiceProviderVm.DoNotDisplayAddress = !serviceProvider.DisplayAddress;
			editServiceProviderVm.PaymentTypes = ConverterHelpers.DictionaryToCheckBoxList(MSLivingChoices.Bcs.Admin.Components.ItemTypeBc.Instance.GetPaymentTypes(), serviceProvider.PaymentTypeIds);
			editServiceProviderVm.Images = serviceProvider.Images.MapToImageListVm(DisplayNames.ServiceProviderImages);
			editServiceProviderVm.Coupon = ((serviceProvider.Coupon != null) ? serviceProvider.Coupon.MapToCouponVm() : new CouponVm());
			editServiceProviderVm.ProvisionCallTrackingNumbers = serviceProvider.CallTrackingPhones.Any();
			editServiceProviderVm.CallTrackingPhones = GetCallTrackingPhoneVmList(serviceProvider.CallTrackingPhones);
			return editServiceProviderVm;
		}
	}

}