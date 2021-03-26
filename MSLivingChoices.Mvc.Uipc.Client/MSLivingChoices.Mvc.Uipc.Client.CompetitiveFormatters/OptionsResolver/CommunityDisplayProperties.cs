using MSLivingChoices.Entities.Client.DisplayOptions;
using System;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver
{
	public class CommunityDisplayProperties
	{
		private bool _address;

		private bool _websiteUrl;

		private bool _floorPlan;

		private bool _home;

		private bool _specHome;

		private readonly CommunityDisplayOptions _displayOptions;

		public bool AdditionalImages
		{
			get;
			set;
		}

		public bool Address
		{
			get
			{
				if (!this._displayOptions.Address)
				{
					return false;
				}
				return this._address;
			}
			set
			{
				this._address = value;
			}
		}

		public bool AgeRestrictions
		{
			get;
			set;
		}

		public bool Amenities
		{
			get;
			set;
		}

		public bool ApplicationFee
		{
			get;
			set;
		}

		public bool Area
		{
			get;
			set;
		}

		public bool Bathes
		{
			get;
			set;
		}

		public bool Beds
		{
			get;
			set;
		}

		public bool CommunityServices
		{
			get;
			set;
		}

		public bool Coupon
		{
			get;
			set;
		}

		public bool Deposit
		{
			get;
			set;
		}

		public bool Description
		{
			get;
			set;
		}

		public bool Featured
		{
			get;
			set;
		}

		public bool FloorPlans
		{
			get
			{
				if (!this._floorPlan)
				{
					return false;
				}
				return this._displayOptions.FloorPlans;
			}
			set
			{
				this._floorPlan = value;
			}
		}

		public bool Homes
		{
			get
			{
				if (!this._home)
				{
					return false;
				}
				return this._displayOptions.Homes;
			}
			set
			{
				this._home = value;
			}
		}

		public bool Image
		{
			get;
			set;
		}

		public bool LeadForm
		{
			get;
			set;
		}

		public bool Logo
		{
			get;
			set;
		}

		public bool Map
		{
			get;
			set;
		}

		public bool Name
		{
			get;
			set;
		}

		public bool OfficeHours
		{
			get;
			set;
		}

		public bool PaymentsAccepted
		{
			get;
			set;
		}

		public bool PetDeposit
		{
			get;
			set;
		}

		public bool Phone
		{
			get;
			set;
		}

		public bool PhotoCount
		{
			get;
			set;
		}

		public bool PhotoTour
		{
			get;
			set;
		}

		public bool Pmc
		{
			get;
			set;
		}

		public bool Price
		{
			get;
			set;
		}

		public bool QuickView
		{
			get;
			set;
		}

		public bool RadiusDesignation
		{
			get;
			set;
		}

		public bool ShcCategories
		{
			get;
			set;
		}

		public bool SpecHomes
		{
			get
			{
				if (!this._specHome)
				{
					return false;
				}
				return this._displayOptions.SpecHomes;
			}
			set
			{
				this._specHome = value;
			}
		}

		public bool VirtualTourUrl
		{
			get;
			set;
		}

		public bool WebsiteUrl
		{
			get
			{
				if (!this._displayOptions.Website)
				{
					return false;
				}
				return this._websiteUrl;
			}
			set
			{
				this._websiteUrl = value;
			}
		}

		public CommunityDisplayProperties(CommunityDisplayOptions displayOptions)
		{
			this._displayOptions = displayOptions;
		}
	}
}