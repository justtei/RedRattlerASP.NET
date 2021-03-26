using MSLivingChoices.Entities.Client.DisplayOptions;
using System;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver
{
	public class ServiceProviderDisplayProperties
	{
		private bool _address;

		private bool _websiteUrl;

		private readonly ServiceDisplayOptions _displayOptions;

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

		public bool CountiesServed
		{
			get;
			set;
		}

		public bool Coupon
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

		public bool ServiceCategories
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

		public ServiceProviderDisplayProperties(ServiceDisplayOptions displayOptions)
		{
			this._displayOptions = displayOptions;
		}
	}
}