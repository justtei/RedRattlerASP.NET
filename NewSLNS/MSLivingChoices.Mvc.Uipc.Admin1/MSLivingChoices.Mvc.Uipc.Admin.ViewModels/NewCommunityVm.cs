using MSLivingChoices.Entities.Admin;
using MSLivingChoices.Entities.Admin.Enums;
using MSLivingChoices.Mvc.Uipc.Admin.Attributes;
using MSLivingChoices.Mvc.Uipc.Admin.Helpers;
using MSLivingChoices.Mvc.Uipc.Admin.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web.Mvc;

namespace MSLivingChoices.Mvc.Uipc.Admin.ViewModels
{
	public class NewCommunityVm
	{
		[Required]
		public AddressVm Address
		{
			get;
			set;
		}

		public AddressValidationVm AddressValidation
		{
			get;
			set;
		}

		public List<CheckBoxVm> AgeRestrictions
		{
			get;
			set;
		}

		[Required]
		public long? BookId
		{
			get;
			set;
		}

		public List<SelectListItem> Books
		{
			get;
			set;
		}

		public CommunityDetailsVm CommunityDetails
		{
			get;
			set;
		}

		[Required]
		public List<ContactVm> Contacts
		{
			get;
			set;
		}

		[AllowHtml]
		[UIHint("RichTextEditor")]
		public string Description
		{
			get;
			set;
		}

		public bool DisplayWebsiteUrl
		{
			get;
			set;
		}

		public bool DoNotDisplayAddress
		{
			get;
			set;
		}

		[Required]
		public EmailListVm EmailList
		{
			get;
			set;
		}

		public ListingDetailsVm ListingDetails
		{
			get;
			set;
		}

		[RequiredCheckBoxList]
		public List<CheckBoxVm> ListingTypes
		{
			get;
			set;
		}

		[AllowHtml]
		[Required]
		[StringLength(50)]
		public string Name
		{
			get;
			set;
		}

		public List<OfficeHoursVm> OfficeHours
		{
			get;
			set;
		}

		[Required]
		public PackageType? Package
		{
			get;
			set;
		}

		public List<SelectListItem> Packages
		{
			get
			{
				if (!this.Package.HasValue)
				{
					return ConverterHelpers.EnumToKoSelectListItems<PackageType>();
				}
				return ConverterHelpers.EnumToKoSelectListItems<PackageType>(this.Package.Value);
			}
		}

		[Required]
		public PhoneListVm PhoneList
		{
			get;
			set;
		}

		public DateTime? PublishEnd
		{
			get;
			set;
		}

		[DateRange("PublishEnd")]
		public DateTime? PublishStart
		{
			get;
			set;
		}

		[OptionalSHCCategories]
		public List<CheckBoxVm> SeniorHousingAndCareCategories
		{
			get;
			set;
		}

		public DateTime? ShowcaseEnd
		{
			get;
			set;
		}

		[DateRange("ShowcaseEnd")]
		public DateTime? ShowcaseStart
		{
			get;
			set;
		}

		[AllowHtml]
		[CustomUrl]
		[StringLength(200)]
		public string WebsiteUrl
		{
			get;
			set;
		}

		public NewCommunityVm()
		{
		}

		public virtual Community ToEntity()
		{
			long id;
			Community community = new Community()
			{
				Book = new Book()
				{
					Id = this.BookId
				},
				Package = this.Package,
				ListingTypes = ConverterHelpers.CheckBoxListToEnumList<ListingType>(this.ListingTypes),
				SeniorHousingAndCareCategoryIds = ConverterHelpers.CheckBoxListToLongArray(this.SeniorHousingAndCareCategories),
				AgeRestrictions = ConverterHelpers.CheckBoxListToEnumList<AgeRestriction>(this.AgeRestrictions),
				Name = this.Name,
				Address = (this.AddressValidation.ValidationItems == null ? this.Address.ToEntity() : this.AddressValidation.ToEntity()),
				DisplayAddress = !this.DoNotDisplayAddress,
				Phones = this.PhoneList.ToEntityList(),
				Emails = this.EmailList.ToEntity(),
				Contacts = this.Contacts.ConvertAll<Contact>((ContactVm m) => m.ToEntity()).Where<Contact>((Contact x) => {
					if (!string.IsNullOrWhiteSpace(x.FirstName))
					{
						return true;
					}
					return !string.IsNullOrWhiteSpace(x.LastName);
				}).ToList<Contact>(),
				OfficeHours = (
					from m in this.OfficeHours
					select m.ToEntity()).ToList<MSLivingChoices.Entities.Admin.OfficeHours>(),
				Description = this.Description,
				WebsiteUrl = MslcUrlBuilder.NormalizeUri(this.WebsiteUrl),
				DisplayWebsiteUrl = this.DisplayWebsiteUrl
			};
			List<long> paymentTypeIds = new List<long>();
			foreach (CheckBoxVm checkBoxVm in 
				from m in this.CommunityDetails.PaymentTypes
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
			community.PriceRange = this.CommunityDetails.PriceRange.ToEntity();
			community.Deposit = this.CommunityDetails.Deposit.ToEntity();
			community.ApplicationFee = this.CommunityDetails.ApplicationFee.ToEntity();
			community.PetDeposit = this.CommunityDetails.PetDeposit.ToEntity();
			community.BedroomFromId = this.CommunityDetails.BedroomFromId;
			community.BedroomToId = this.CommunityDetails.BedroomToId;
			community.BathroomFromId = this.CommunityDetails.BathroomFromId;
			community.BathroomToId = this.CommunityDetails.BathroomToId;
			community.LivingSpace = this.CommunityDetails.LivingSpace.ToEntity();
			community.UnitCount = this.CommunityDetails.UnitCount;
			community.Amenities = AmenityVm.ToEntityList(this.CommunityDetails.DefaultAmenities, this.CommunityDetails.CustomAmenities);
			community.CommunityServices = CommunityServiceVm.ToEntityList(this.CommunityDetails.DefaultCommunityServices, this.CommunityDetails.CustomCommunityServices);
			community.FloorPlans = new List<FloorPlan>();
			community.SpecHomes = new List<SpecHome>();
			community.Houses = new List<House>();
			community.VirtualTour = MslcUrlBuilder.NormalizeUri(this.CommunityDetails.VirtualTour);
			community.Coupon = this.CommunityDetails.Coupon.ToEntity();
			community.Images = (this.CommunityDetails.Images == null ? new List<Image>() : this.CommunityDetails.Images.ToEntity(ImageType.Photo));
			community.LogoImages = (this.CommunityDetails.LogoImages == null ? new List<Image>() : this.CommunityDetails.LogoImages.ToEntity(ImageType.Logo));
			if (this.CommunityDetails.HasFloorPlans)
			{
				community.FloorPlans = (
					from m in this.CommunityDetails.FloorPlans
					select m.ToEntity()).ToList<FloorPlan>();
				community.FloorPlans.ForEach((FloorPlan m) => m.Community = community);
			}
			if (this.CommunityDetails.HasSpecHomes)
			{
				community.SpecHomes = (
					from m in this.CommunityDetails.SpecHomes
					select m.ToEntity()).ToList<SpecHome>();
				community.SpecHomes.ForEach((SpecHome m) => m.Community = community);
			}
			if (this.CommunityDetails.HasHouses)
			{
				community.Houses = (
					from m in this.CommunityDetails.Houses
					select m.ToEntity()).ToList<House>();
				community.Houses.ForEach((House m) => m.Community = community);
			}
			community.PropertyManager = this.ListingDetails.PropertyManager.ToEntity(OwnerType.PropertyManager);
			community.Builder = this.ListingDetails.Builder.ToEntity(OwnerType.Builder);
			community.CallTrackingPhones = new List<CallTrackingPhone>();
			if (this.ListingDetails.CallTrackingPhones != null)
			{
				if (!this.ListingDetails.ProvisionCallTrackingNumbers)
				{
					this.ListingDetails.CallTrackingPhones.ForEach((CallTrackingPhoneVm c) => c.IsDisconnected = true);
				}
				community.CallTrackingPhones = (
					from p in this.ListingDetails.CallTrackingPhones.ConvertAll<CallTrackingPhone>((CallTrackingPhoneVm x) => x.ToEntity())
					where !string.IsNullOrEmpty(p.Phone)
					select p).ToList<CallTrackingPhone>();
			}
			community.Publishing.StartDate = this.PublishStart;
			community.Publishing.EndDate = this.PublishEnd;
			community.Showcase.StartDate = this.ShowcaseStart;
			community.Showcase.EndDate = this.ShowcaseEnd;
			return community;
		}
	}
}