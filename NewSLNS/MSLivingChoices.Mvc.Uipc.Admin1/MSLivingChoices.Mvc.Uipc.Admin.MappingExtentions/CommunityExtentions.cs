using MSLivingChoices.Bcs.Admin.Components;
using MSLivingChoices.Bcs.Components;
using MSLivingChoices.Entities.Admin;
using MSLivingChoices.Entities.Admin.Enums;
using MSLivingChoices.Localization;
using MSLivingChoices.Mvc.Uipc.Admin.Helpers;
using MSLivingChoices.Mvc.Uipc.Admin.ViewModels;
using MSLivingChoices.Mvc.Uipc.Admin.ViewModels.Common;
using MSLivingChoices.Mvc.Uipc.Admin.ViewModelsProviders;
using MSLivingChoices.Mvc.Uipc.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Mvc.Uipc.Admin.MappingExtentions
{
	internal static class CommunityExtentions
	{
		private static List<CommunityServiceVm> GetCustomCommunityServices(IEnumerable<CommunityService> allCommunityServices, List<CommunityService> defaultCommunityServices)
		{
			List<CommunityServiceVm> customCommunityServices = new List<CommunityServiceVm>();
			foreach (CommunityService allCommunityService in allCommunityServices)
			{
				if (!defaultCommunityServices.All<CommunityService>((CommunityService c) => {
					int? additionInfoTypeId = c.AdditionInfoTypeId;
					int? nullable = allCommunityService.AdditionInfoTypeId;
					return !(additionInfoTypeId.GetValueOrDefault() == nullable.GetValueOrDefault() & additionInfoTypeId.HasValue == nullable.HasValue);
				}))
				{
					continue;
				}
				customCommunityServices.Add(new CommunityServiceVm()
				{
					AdditionInfoTypeId = allCommunityService.AdditionInfoTypeId,
					Name = allCommunityService.Name
				});
			}
			if (!customCommunityServices.Any<CommunityServiceVm>())
			{
				customCommunityServices.Add(new CommunityServiceVm());
			}
			return customCommunityServices;
		}

		private static List<CheckBoxVm> GetDefaultCommunityServices(IEnumerable<CommunityService> allCommunityServices, List<CommunityService> defaultCommunityServices)
		{
			return defaultCommunityServices.ConvertAll<CheckBoxVm>((CommunityService m) => new CheckBoxVm()
			{
				Value = m.AdditionInfoTypeId.ToString(),
				Text = m.Name,
				IsChecked = allCommunityServices.Any<CommunityService>((CommunityService communitySevice) => {
					int? additionInfoTypeId = communitySevice.AdditionInfoTypeId;
					int? nullable = m.AdditionInfoTypeId;
					return additionInfoTypeId.GetValueOrDefault() == nullable.GetValueOrDefault() & additionInfoTypeId.HasValue == nullable.HasValue;
				})
			});
		}

		internal static CommunityDetailsVm MapToCommunityDetailsVm(this Community community)
		{
			CommunityDetailsVm communityDetails = new CommunityDetailsVm()
			{
				PaymentTypes = ConverterHelpers.DictionaryToCheckBoxList(MSLivingChoices.Bcs.Admin.Components.ItemTypeBc.Instance.GetPaymentTypes(), community.PaymentTypeIds),
				PriceRange = community.PriceRange.MapToMeasureBoundaryVm<decimal, MoneyType>(),
				Deposit = community.Deposit.MapToMeasureBoundaryVm<decimal, MoneyType>(),
				ApplicationFee = community.ApplicationFee.MapToMeasureBoundaryVm<decimal, MoneyType>(),
				PetDeposit = community.PetDeposit.MapToMeasureBoundaryVm<decimal, MoneyType>(),
				LivingSpace = community.LivingSpace.MapToMeasureBoundaryVm<int, LivingSpaceMeasure>(),
				BathroomFromId = community.BathroomFromId,
				BathroomToId = community.BathroomToId
			};
			List<KeyValuePair<int, string>> bedrooms = MSLivingChoices.Bcs.Components.ItemTypeBc.Instance.GetBedrooms();
			communityDetails.AvailableBedroomsFromQuantity = bedrooms.ToSelectListItemList(community.BedroomFromId);
			communityDetails.AvailableBedroomsToQuantity = bedrooms.ToSelectListItemList(community.BedroomToId);
			communityDetails.BedroomFromId = community.BedroomFromId;
			communityDetails.BedroomToId = community.BedroomToId;
			List<KeyValuePair<int, string>> bathrooms = MSLivingChoices.Bcs.Components.ItemTypeBc.Instance.GetBathrooms();
			communityDetails.AvailableBathroomsFromQuantity = bathrooms.ToSelectListItemList(community.BathroomFromId);
			communityDetails.AvailableBathroomsToQuantity = bathrooms.ToSelectListItemList(community.BathroomToId);
			communityDetails.UnitCount = community.UnitCount;
			List<Amenity> defaultCommunityAmenities = AmenityBc.Instance.GetDefaultAmenities(CommunityType.Community);
			communityDetails.DefaultAmenities = community.Amenities.MapToCheckBoxVmList(defaultCommunityAmenities);
			communityDetails.CustomAmenities = community.Amenities.MapToAmenityVmList(defaultCommunityAmenities);
			List<CommunityService> defaultCommunityServices = CommunityServiceBc.Instance.GetDefaultCommunityServices();
			communityDetails.DefaultCommunityServices = CommunityExtentions.GetDefaultCommunityServices(community.CommunityServices, defaultCommunityServices);
			communityDetails.CustomCommunityServices = CommunityExtentions.GetCustomCommunityServices(community.CommunityServices, defaultCommunityServices);
			communityDetails.Images = community.Images.MapToImageListVm(DisplayNames.CommunityImages);
			communityDetails.LogoImages = community.LogoImages.MapToImageListVm(DisplayNames.CommunityLogo);
			communityDetails.VirtualTour = community.VirtualTour;
			communityDetails.Coupon = (community.Coupon != null ? community.Coupon.MapToCouponVm() : new CouponVm());
			if (community.FloorPlans == null || !community.FloorPlans.Any<FloorPlan>())
			{
				communityDetails.HasFloorPlans = false;
				communityDetails.FloorPlans = new List<FloorPlanVm>()
				{
					AdminViewModelsProvider.GetCommunityUnit(CommunityUnitType.FloorPlan)
				};
			}
			else
			{
				communityDetails.HasFloorPlans = community.FloorPlans.Any<FloorPlan>();
				communityDetails.FloorPlans = community.FloorPlans.MapToFloorPlanVmList();
			}
			if (community.SpecHomes == null || !community.SpecHomes.Any<SpecHome>())
			{
				communityDetails.HasSpecHomes = false;
				communityDetails.SpecHomes = new List<SpecHomeVm>()
				{
					AdminViewModelsProvider.GetCommunityUnit(CommunityUnitType.SpecHome)
				};
			}
			else
			{
				communityDetails.HasSpecHomes = community.SpecHomes.Any<SpecHome>();
				communityDetails.SpecHomes = community.SpecHomes.MapToSpecHomeVmList();
			}
			if (community.Houses == null || !community.Houses.Any<House>())
			{
				communityDetails.HasHouses = false;
				communityDetails.Houses = new List<HouseVm>()
				{
					AdminViewModelsProvider.GetHouseUnit()
				};
			}
			else
			{
				communityDetails.HasHouses = community.Houses.Any<House>();
				communityDetails.Houses = community.Houses.MapToHouseVmList();
			}
			return communityDetails;
		}

		internal static FloorPlanVm MapToFloorPlanVm(this FloorPlan floorPlan)
		{
			FloorPlanVm floorPlanVm = new FloorPlanVm();
			List<KeyValuePair<int, string>> bedrooms = MSLivingChoices.Bcs.Components.ItemTypeBc.Instance.GetBedrooms();
			List<KeyValuePair<int, string>> bathrooms = MSLivingChoices.Bcs.Components.ItemTypeBc.Instance.GetBathrooms();
			List<Amenity> defaultAmenities = AmenityBc.Instance.GetDefaultAmenities(CommunityUnitType.FloorPlan);
			floorPlanVm.Id = floorPlan.Id;
			floorPlanVm.Name = floorPlan.Name;
			floorPlanVm.BedroomFromId = floorPlan.BedroomFromId;
			floorPlanVm.BedroomToId = floorPlan.BedroomToId;
			floorPlanVm.AvailableBedroomsFromQuantity = bedrooms.ToSelectListItemList(floorPlan.BedroomFromId);
			floorPlanVm.AvailableBedroomsToQuantity = bedrooms.ToSelectListItemList(floorPlan.BedroomToId);
			floorPlanVm.BathroomFromId = floorPlan.BathroomFromId;
			floorPlanVm.BathroomToId = floorPlan.BathroomToId;
			floorPlanVm.AvailableBathroomsFromQuantity = bathrooms.ToSelectListItemList(floorPlan.BathroomFromId);
			floorPlanVm.AvailableBathroomsToQuantity = bathrooms.ToSelectListItemList(floorPlan.BathroomToId);
			floorPlanVm.PriceRange = floorPlan.PriceRange.MapToMeasureBoundaryVm<decimal, MoneyType>();
			floorPlanVm.Deposit = floorPlan.Deposit.MapToMeasureBoundaryVm<decimal, MoneyType>();
			floorPlanVm.PetDeposit = floorPlan.PetDeposit.MapToMeasureBoundaryVm<decimal, MoneyType>();
			floorPlanVm.ApplicationFee = floorPlan.ApplicationFee.MapToMeasureBoundaryVm<decimal, MoneyType>();
			floorPlanVm.LivingSpace = floorPlan.LivingSpace.MapToMeasureBoundaryVm<int, LivingSpaceMeasure>();
			floorPlanVm.DefaultAmenities = floorPlan.Amenities.MapToCheckBoxVmList(defaultAmenities);
			floorPlanVm.CustomAmenities = floorPlan.Amenities.MapToAmenityVmList(defaultAmenities);
			floorPlanVm.Images = floorPlan.Images.MapToImageListVm(DisplayNames.FloorPlanImages);
			return floorPlanVm;
		}

		internal static List<FloorPlanVm> MapToFloorPlanVmList(this List<FloorPlan> floorPlans)
		{
			return floorPlans.ConvertAll<FloorPlanVm>(new Converter<FloorPlan, FloorPlanVm>(CommunityExtentions.MapToFloorPlanVm));
		}

		internal static HouseVm MapToHouseVm(this House house)
		{
			HouseVm houseVm = new HouseVm();
			List<KeyValuePair<int, string>> bedrooms = MSLivingChoices.Bcs.Components.ItemTypeBc.Instance.GetBedrooms();
			List<KeyValuePair<int, string>> bathrooms = MSLivingChoices.Bcs.Components.ItemTypeBc.Instance.GetBathrooms();
			List<Amenity> defaultAmenities = AmenityBc.Instance.GetDefaultAmenities(CommunityUnitType.House);
			houseVm.Id = house.Id;
			houseVm.Name = house.Name;
			houseVm.BedroomFromId = house.BedroomFromId;
			houseVm.BedroomToId = house.BedroomToId;
			houseVm.AvailableBedroomsFromQuantity = bedrooms.ToSelectListItemList(house.BedroomFromId);
			houseVm.AvailableBedroomsToQuantity = bedrooms.ToSelectListItemList(house.BedroomToId);
			houseVm.BathroomFromId = house.BathroomFromId;
			houseVm.BathroomToId = house.BathroomToId;
			houseVm.AvailableBathroomsFromQuantity = bathrooms.ToSelectListItemList(house.BathroomFromId);
			houseVm.AvailableBathroomsToQuantity = bathrooms.ToSelectListItemList(house.BathroomToId);
			houseVm.PriceRange = house.PriceRange.MapToMeasureBoundaryVm<decimal, MoneyType>();
			houseVm.Deposit = house.Deposit.MapToMeasureBoundaryVm<decimal, MoneyType>();
			houseVm.PetDeposit = house.PetDeposit.MapToMeasureBoundaryVm<decimal, MoneyType>();
			houseVm.ApplicationFee = house.ApplicationFee.MapToMeasureBoundaryVm<decimal, MoneyType>();
			houseVm.LivingSpace = house.LivingSpace.MapToMeasureBoundaryVm<int, LivingSpaceMeasure>();
			houseVm.DefaultAmenities = house.Amenities.MapToCheckBoxVmList(defaultAmenities);
			houseVm.CustomAmenities = house.Amenities.MapToAmenityVmList(defaultAmenities);
			houseVm.Images = house.Images.MapToImageListVm(DisplayNames.HouseImages);
			houseVm.SaleType = house.SaleType;
			houseVm.Description = house.Description;
			houseVm.YearBuilt = house.YearBuilt;
			houseVm.Address = house.Address.MapToAddressVm();
			return houseVm;
		}

		internal static List<HouseVm> MapToHouseVmList(this List<House> houses)
		{
			return houses.ConvertAll<HouseVm>(new Converter<House, HouseVm>(CommunityExtentions.MapToHouseVm));
		}

		internal static ImageListVm MapToImageListVm(this List<Image> images, string displayName)
		{
			return new ImageListVm()
			{
				Images = images.ConvertAll<ImageVm>((Image i) => i.MapToImageVm()).ToList<ImageVm>(),
				DisplayName = displayName
			};
		}

		internal static ListingDetailsVm MapToListingDetailsVm(this Community community)
		{
			return new ListingDetailsVm()
			{
				PropertyManager = (community.PropertyManager == null ? AdminViewModelsProvider.GetOwnerVm(OwnerType.PropertyManager) : community.PropertyManager.MapToOwnerVm(OwnerType.PropertyManager)),
				Builder = (community.Builder == null ? AdminViewModelsProvider.GetOwnerVm(OwnerType.Builder) : community.Builder.MapToOwnerVm(OwnerType.Builder)),
				ProvisionCallTrackingNumbers = community.CallTrackingPhones.Any<CallTrackingPhone>(),
				CallTrackingPhones = AdminViewModelsProvider.GetCallTrackingPhoneVmList(community.CallTrackingPhones)
			};
		}

		internal static SpecHomeVm MapToSpecHomeVm(this SpecHome specHome)
		{
			SpecHomeVm specHomeVm = new SpecHomeVm();
			List<KeyValuePair<int, string>> bedrooms = MSLivingChoices.Bcs.Components.ItemTypeBc.Instance.GetBedrooms();
			List<KeyValuePair<int, string>> bathrooms = MSLivingChoices.Bcs.Components.ItemTypeBc.Instance.GetBathrooms();
			List<Amenity> defaultAmenities = AmenityBc.Instance.GetDefaultAmenities(CommunityUnitType.SpecHome);
			specHomeVm.Id = specHome.Id;
			specHomeVm.Name = specHome.Name;
			specHomeVm.BedroomFromId = specHome.BedroomFromId;
			specHomeVm.BedroomToId = specHome.BedroomToId;
			specHomeVm.AvailableBedroomsFromQuantity = bedrooms.ToSelectListItemList(specHome.BedroomFromId);
			specHomeVm.AvailableBedroomsToQuantity = bedrooms.ToSelectListItemList(specHome.BedroomToId);
			specHomeVm.BathroomFromId = specHome.BathroomFromId;
			specHomeVm.BathroomToId = specHome.BathroomToId;
			specHomeVm.AvailableBathroomsFromQuantity = bathrooms.ToSelectListItemList(specHome.BathroomFromId);
			specHomeVm.AvailableBathroomsToQuantity = bathrooms.ToSelectListItemList(specHome.BathroomToId);
			specHomeVm.PriceRange = specHome.PriceRange.MapToMeasureBoundaryVm<decimal, MoneyType>();
			specHomeVm.Deposit = specHome.Deposit.MapToMeasureBoundaryVm<decimal, MoneyType>();
			specHomeVm.PetDeposit = specHome.PetDeposit.MapToMeasureBoundaryVm<decimal, MoneyType>();
			specHomeVm.ApplicationFee = specHome.ApplicationFee.MapToMeasureBoundaryVm<decimal, MoneyType>();
			specHomeVm.LivingSpace = specHome.LivingSpace.MapToMeasureBoundaryVm<int, LivingSpaceMeasure>();
			specHomeVm.DefaultAmenities = specHome.Amenities.MapToCheckBoxVmList(defaultAmenities);
			specHomeVm.CustomAmenities = specHome.Amenities.MapToAmenityVmList(defaultAmenities);
			specHomeVm.Images = specHome.Images.MapToImageListVm(DisplayNames.SpecHomeImages);
			specHomeVm.SaleType = specHome.SaleType;
			specHomeVm.Status = specHome.Status;
			specHomeVm.Description = specHome.Description;
			return specHomeVm;
		}

		internal static List<SpecHomeVm> MapToSpecHomeVmList(this List<SpecHome> specHomes)
		{
			return specHomes.ConvertAll<SpecHomeVm>(new Converter<SpecHome, SpecHomeVm>(CommunityExtentions.MapToSpecHomeVm));
		}
	}
}