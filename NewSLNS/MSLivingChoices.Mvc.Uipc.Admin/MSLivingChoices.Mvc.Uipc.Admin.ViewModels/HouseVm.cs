using MSLivingChoices.Entities.Admin;
using MSLivingChoices.Entities.Admin.Enums;
using MSLivingChoices.Mvc.Uipc.Admin.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Web.Mvc;

namespace MSLivingChoices.Mvc.Uipc.Admin.ViewModels
{
	public class HouseVm : FloorPlanVm
	{
		public AddressVm Address
		{
			get;
			set;
		}

		public string Description
		{
			get;
			set;
		}

		[AllowHtml]
		[StringLength(50)]
		public override string Name
		{
			get;
			set;
		}

		public HomeSaleType SaleType
		{
			get;
			set;
		}

		public List<SelectListItem> SaleTypes
		{
			get
			{
				return ConverterHelpers.EnumToKoSelectListItems<HomeSaleType>(this.SaleType);
			}
		}

		public int? YearBuilt
		{
			get;
			set;
		}

		public HouseVm()
		{
		}

		public new House ToEntity()
		{
			return new House()
			{
				Id = base.Id,
				Name = this.Name,
				BedroomFromId = base.BedroomFromId,
				BedroomToId = base.BedroomToId,
				BathroomFromId = base.BathroomFromId,
				BathroomToId = base.BathroomToId,
				PriceRange = base.PriceRange.ToEntity(),
				LivingSpace = base.LivingSpace.ToEntity(),
				Deposit = base.Deposit.ToEntity(),
				ApplicationFee = base.ApplicationFee.ToEntity(),
				PetDeposit = base.PetDeposit.ToEntity(),
				Amenities = AmenityVm.ToEntityList(base.DefaultAmenities, base.CustomAmenities),
				DateAdded = DateTime.Now,
				Images = (base.Images == null ? new List<Image>() : base.Images.ToEntity(ImageType.Photo)),
				SaleType = this.SaleType,
				Description = this.Description,
				YearBuilt = this.YearBuilt,
				Address = this.Address.ToEntity()
			};
		}
	}
}