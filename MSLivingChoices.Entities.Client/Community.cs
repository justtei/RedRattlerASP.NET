using MSLivingChoices.Entities.Client.DisplayOptions;
using MSLivingChoices.Entities.Client.Enums;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Entities.Client
{
	[Serializable]
	public class Community : ICommunity
	{
		public List<string> AcceptedPayments
		{
			get;
			set;
		}

		public MSLivingChoices.Entities.Client.Address Address
		{
			get;
			set;
		}

		public List<AgeRestriction> AgeRestrictions
		{
			get;
			set;
		}

		public List<string> Amenities
		{
			get;
			set;
		}

		public MeasureBoundary<decimal, MSLivingChoices.Entities.Client.Enums.Currency> ApplicationFee
		{
			get;
			set;
		}

		public Boundary<long> Bathes
		{
			get;
			set;
		}

		public Boundary<long> Beds
		{
			get;
			set;
		}

		public string BookNumber
		{
			get;
			set;
		}

		public Owner Builder
		{
			get;
			set;
		}

		public MSLivingChoices.Entities.Client.Coupon Coupon
		{
			get;
			set;
		}

		public MeasureBoundary<decimal, MSLivingChoices.Entities.Client.Enums.Currency> Deposit
		{
			get;
			set;
		}

		public string Description
		{
			get;
			set;
		}

		public CommunityDisplayOptions DisplayOptions
		{
			get;
			set;
		}

		public List<FloorPlan> FloorPlans
		{
			get;
			set;
		}

		public List<Home> Homes
		{
			get;
			set;
		}

		public long Id
		{
			get;
			set;
		}

		public List<Image> Images
		{
			get;
			set;
		}

		public List<ListingType> ListingTypes
		{
			get;
			set;
		}

		public MeasureBoundary<int, Area> LivingSpace
		{
			get;
			set;
		}

		IAddress MSLivingChoices.Entities.Client.ICommunity.Address
		{
			get
			{
				return this.Address;
			}
			set
			{
				this.Address = value as MSLivingChoices.Entities.Client.Address;
			}
		}

		public string Name
		{
			get;
			set;
		}

		public List<MSLivingChoices.Entities.Client.OfficeHours> OfficeHours
		{
			get;
			set;
		}

		public long PackageId
		{
			get;
			set;
		}

		public MeasureBoundary<decimal, MSLivingChoices.Entities.Client.Enums.Currency> PetDeposit
		{
			get;
			set;
		}

		public string Phone
		{
			get;
			set;
		}

		public Owner Pmc
		{
			get;
			set;
		}

		public MeasureBoundary<decimal, MSLivingChoices.Entities.Client.Enums.Currency> Price
		{
			get;
			set;
		}

		public int SearchResultRadius
		{
			get;
			set;
		}

		public List<string> Services
		{
			get;
			set;
		}

		public List<string> ShcCategories
		{
			get;
			set;
		}

		public List<SpecHome> SpecHomes
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
			this.DisplayOptions = new CommunityDisplayOptions();
			this.Amenities = new List<string>();
			this.Services = new List<string>();
			this.AcceptedPayments = new List<string>();
			this.ShcCategories = new List<string>();
			this.AgeRestrictions = new List<AgeRestriction>();
			this.ListingTypes = new List<ListingType>();
			this.Images = new List<Image>();
			this.FloorPlans = new List<FloorPlan>();
			this.SpecHomes = new List<SpecHome>();
			this.Homes = new List<Home>();
			this.OfficeHours = new List<MSLivingChoices.Entities.Client.OfficeHours>();
		}

		public override string ToString()
		{
			return this.Name;
		}
	}
}