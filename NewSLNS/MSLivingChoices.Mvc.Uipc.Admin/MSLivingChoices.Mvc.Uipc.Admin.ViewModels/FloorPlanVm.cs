using MSLivingChoices.Entities.Admin;
using MSLivingChoices.Entities.Admin.Enums;
using MSLivingChoices.Mvc.Uipc.Admin.Attributes.RestrictCollectionLengthAttributes;
using MSLivingChoices.Mvc.Uipc.Admin.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Web.Mvc;

namespace MSLivingChoices.Mvc.Uipc.Admin.ViewModels
{
	public class FloorPlanVm
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

		public List<AmenityVm> CustomAmenities
		{
			get;
			set;
		}

		public List<CheckBoxVm> DefaultAmenities
		{
			get;
			set;
		}

		public MeasureBoundaryVm<decimal, MoneyType> Deposit
		{
			get;
			set;
		}

		public long? Id
		{
			get;
			set;
		}

		[RestricCommunityUnitImageCollectionLength]
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

		[AllowHtml]
		[StringLength(50)]
		public virtual string Name
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

		public FloorPlanVm()
		{
			this.Images = new ImageListVm();
		}

		public FloorPlan ToEntity()
		{
			return new FloorPlan()
			{
				Id = this.Id,
				Name = this.Name,
				BedroomFromId = this.BedroomFromId,
				BedroomToId = this.BedroomToId,
				BathroomFromId = this.BathroomFromId,
				BathroomToId = this.BathroomToId,
				PriceRange = this.PriceRange.ToEntity(),
				LivingSpace = this.LivingSpace.ToEntity(),
				Deposit = this.Deposit.ToEntity(),
				ApplicationFee = this.ApplicationFee.ToEntity(),
				PetDeposit = this.PetDeposit.ToEntity(),
				Amenities = AmenityVm.ToEntityList(this.DefaultAmenities, this.CustomAmenities),
				DateAdded = DateTime.Now,
				Images = (this.Images == null ? new List<Image>() : this.Images.ToEntity(ImageType.Photo))
			};
		}
	}
}