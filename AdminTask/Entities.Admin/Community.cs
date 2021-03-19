using MSLivingChoices.Entities.Admin.Enums;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Entities.Admin
{
	[Serializable]
	public class Community
	{
		public MSLivingChoices.Entities.Admin.Address Address
		{
			get;
			set;
		}

		public SaleType AdSaleType
		{
			get;
			set;
		}

		public Owner Advertiser
		{
			get;
			set;
		}

		public List<AgeRestriction> AgeRestrictions
		{
			get;
			set;
		}

		public List<Amenity> Amenities
		{
			get;
			set;
		}

		public MeasureBoundary<decimal, MoneyType> ApplicationFee
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

		public MSLivingChoices.Entities.Admin.Book Book
		{
			get;
			set;
		}

		public Owner Builder
		{
			get;
			set;
		}

		public List<CallTrackingPhone> CallTrackingPhones
		{
			get;
			set;
		}

		public List<CommunityService> CommunityServices
		{
			get;
			set;
		}

		public List<Contact> Contacts
		{
			get;
			set;
		}

		public MSLivingChoices.Entities.Admin.Coupon Coupon
		{
			get;
			set;
		}

		public DateTime DateAdded
		{
			get;
			set;
		}

		public MeasureBoundary<decimal, MoneyType> Deposit
		{
			get;
			set;
		}

		public string Description
		{
			get;
			set;
		}

		public bool DisplayAddress
		{
			get;
			set;
		}

		public bool DisplayWebsiteUrl
		{
			get;
			set;
		}

		public List<Email> Emails
		{
			get;
			set;
		}

		public DateTimeBoundary<bool> Feature
		{
			get;
			set;
		}

		public List<FloorPlan> FloorPlans
		{
			get;
			set;
		}

		public bool HasFloorPlan
		{
			get;
			set;
		}

		public List<House> Houses
		{
			get;
			set;
		}

		public long? Id
		{
			get;
			set;
		}

		public List<Image> Images
		{
			get;
			set;
		}

		public bool IsFeatured
		{
			get;
			set;
		}

		public List<ListingType> ListingTypes
		{
			get;
			set;
		}

		public MeasureBoundary<int, LivingSpaceMeasure> LivingSpace
		{
			get;
			set;
		}

		public List<Image> LogoImages
		{
			get;
			set;
		}

		public string MarchexAccountId
		{
			get;
			set;
		}

		public string Name
		{
			get;
			set;
		}

		public List<MSLivingChoices.Entities.Admin.OfficeHours> OfficeHours
		{
			get;
			set;
		}

		public PackageType? Package
		{
			get;
			set;
		}

		public List<long> PaymentTypeIds
		{
			get;
			set;
		}

		public MSLivingChoices.Entities.Admin.PdfBrochure PdfBrochure
		{
			get;
			set;
		}

		public MeasureBoundary<decimal, MoneyType> PetDeposit
		{
			get;
			set;
		}

		public List<Phone> Phones
		{
			get;
			set;
		}

		public MeasureBoundary<decimal, MoneyType> PriceRange
		{
			get;
			set;
		}

		public Owner PropertyManager
		{
			get;
			set;
		}

		public DateTimeBoundary<PublishingStatus> Publishing
		{
			get;
			set;
		}

		public List<long> SeniorHousingAndCareCategoryIds
		{
			get;
			set;
		}

		public int Sequence
		{
			get;
			set;
		}

		public DateTimeBoundary Showcase
		{
			get;
			set;
		}

		public List<SpecHome> SpecHomes
		{
			get;
			set;
		}

		public int? UnitCount
		{
			get;
			set;
		}

		public Guid? UserId
		{
			get;
			set;
		}

		public string VirtualTour
		{
			get;
			set;
		}

		public string WebsiteUrl
		{
			get;
			set;
		}

		public Community()
		{
			this.Images = new List<Image>();
			this.LogoImages = new List<Image>();
			this.Address = new MSLivingChoices.Entities.Admin.Address();
			this.Phones = new List<Phone>();
			this.CallTrackingPhones = new List<CallTrackingPhone>();
			this.Emails = new List<Email>();
			this.Contacts = new List<Contact>();
			this.Showcase = new DateTimeBoundary();
			this.Feature = new DateTimeBoundary<bool>();
			this.Publishing = new DateTimeBoundary<PublishingStatus>();
			this.CommunityServices = new List<CommunityService>();
			this.Houses = new List<House>();
		}
	}
}