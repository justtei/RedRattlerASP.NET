using MSLivingChoices.Entities.Admin;
using MSLivingChoices.Entities.Admin.Enums;
using MSLivingChoices.Mvc.Uipc.Admin.Attributes;
using MSLivingChoices.Mvc.Uipc.Admin.Attributes.RestrictCollectionLengthAttributes;
using MSLivingChoices.Mvc.Uipc.Admin.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web.Mvc;

namespace MSLivingChoices.Mvc.Uipc.Admin.ViewModels
{
	public class CommunityDetailsVm
	{
		public MeasureBoundaryVm<decimal, MoneyType> ApplicationFee
		{
			get;
			set;
		}

		public List<SelectListItem> AvailableBathroomsFromQuantity
		{
			get;
			set;
		}

		public List<SelectListItem> AvailableBathroomsToQuantity
		{
			get;
			set;
		}

		public List<SelectListItem> AvailableBedroomsFromQuantity
		{
			get;
			set;
		}

		public List<SelectListItem> AvailableBedroomsToQuantity
		{
			get;
			set;
		}

		public long? BathroomFromId
		{
			get;
			set;
		}

		public long? BathroomToId
		{
			get;
			set;
		}

		public long? BedroomFromId
		{
			get;
			set;
		}

		public long? BedroomToId
		{
			get;
			set;
		}

		public CouponVm Coupon
		{
			get;
			set;
		}

		public List<AmenityVm> CustomAmenities
		{
			get;
			set;
		}

		public List<CommunityServiceVm> CustomCommunityServices
		{
			get;
			set;
		}

		public List<CheckBoxVm> DefaultAmenities
		{
			get;
			set;
		}

		public List<CheckBoxVm> DefaultCommunityServices
		{
			get;
			set;
		}

		public MeasureBoundaryVm<decimal, MoneyType> Deposit
		{
			get;
			set;
		}

		[RestrictCommunityUnitCollectionLength]
		public List<FloorPlanVm> FloorPlans
		{
			get;
			set;
		}

		public bool HasFloorPlans
		{
			get;
			set;
		}

		public bool HasHouses
		{
			get;
			set;
		}

		public bool HasSpecHomes
		{
			get;
			set;
		}

		[RestrictCommunityUnitCollectionLength]
		public List<HouseVm> Houses
		{
			get;
			set;
		}

		[RestrictCommunityImageCollectionLength]
		public ImageListVm Images
		{
			get;
			set;
		}

		public MeasureBoundaryVm<int, LivingSpaceMeasure> LivingSpace
		{
			get;
			set;
		}

		[RestrictLogoImageCollectionLength]
		public ImageListVm LogoImages
		{
			get;
			set;
		}

		public List<CheckBoxVm> PaymentTypes
		{
			get;
			set;
		}

		public MeasureBoundaryVm<decimal, MoneyType> PetDeposit
		{
			get;
			set;
		}

		public MeasureBoundaryVm<decimal, MoneyType> PriceRange
		{
			get;
			set;
		}

		[RestrictCommunityUnitCollectionLength]
		public List<SpecHomeVm> SpecHomes
		{
			get;
			set;
		}

		[Range(0, 2147483647)]
		public int? UnitCount
		{
			get;
			set;
		}

		[CustomUrl]
		[StringLength(200)]
		public string VirtualTour
		{
			get;
			set;
		}

		public CommunityDetailsVm()
		{
			this.Images = new ImageListVm();
			this.LogoImages = new ImageListVm();
		}

		public Community ToEntity()
		{
			long id;
			Community community = new Community();
			List<long> paymentTypeIds = new List<long>();
			foreach (CheckBoxVm checkBoxVm in 
				from m in this.PaymentTypes
				where m.IsChecked
				select m)
			{
				if (!long.TryParse(checkBoxVm.Value, out id))
				{
					continue;
				}
				paymentTypeIds.Add(id);
			}
			community.PaymentTypeIds = paymentTypeIds;
			community.PriceRange = this.PriceRange.ToEntity();
			community.Deposit = this.Deposit.ToEntity();
			community.ApplicationFee = this.ApplicationFee.ToEntity();
			community.PetDeposit = this.PetDeposit.ToEntity();
			community.LivingSpace = this.LivingSpace.ToEntity();
			community.BedroomFromId = this.BedroomFromId;
			community.BedroomToId = this.BedroomToId;
			community.BathroomFromId = this.BathroomFromId;
			community.BathroomToId = this.BathroomToId;
			community.UnitCount = this.UnitCount;
			community.Amenities = AmenityVm.ToEntityList(this.DefaultAmenities, this.CustomAmenities);
			community.CommunityServices = CommunityServiceVm.ToEntityList(this.DefaultCommunityServices, this.CustomCommunityServices);
			community.FloorPlans = new List<FloorPlan>();
			community.SpecHomes = new List<SpecHome>();
			community.Houses = new List<House>();
			community.LogoImages = (this.LogoImages != null ? this.LogoImages.ToEntity(ImageType.Logo) : new List<Image>());
			community.Images = (this.Images != null ? this.Images.ToEntity(ImageType.Photo) : new List<Image>());
			community.VirtualTour = this.VirtualTour;
			community.Coupon = this.Coupon.ToEntity();
			if (this.HasFloorPlans)
			{
				community.FloorPlans = (
					from m in this.FloorPlans
					select m.ToEntity()).ToList<FloorPlan>();
				community.FloorPlans.ForEach((FloorPlan m) => m.Community = community);
			}
			if (this.HasSpecHomes)
			{
				community.SpecHomes = (
					from m in this.SpecHomes
					select m.ToEntity()).ToList<SpecHome>();
				community.SpecHomes.ForEach((SpecHome m) => m.Community = community);
			}
			if (this.HasHouses)
			{
				community.Houses = (
					from m in this.Houses
					select m.ToEntity()).ToList<House>();
				community.Houses.ForEach((House m) => m.Community = community);
			}
			return community;
		}
	}
}