using MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Mvc.Uipc.Client.ViewModels
{
	public class ServiceProviderDetailsVm : SearchWithServicesVm
	{
		public CouponVm Coupon
		{
			get;
			set;
		}

		public DetailsDisplayProperties DisplayProperties
		{
			get;
			set;
		}

		public List<string> OfficeHours
		{
			get;
			set;
		}

		public List<string> PaymentsAccepted
		{
			get;
			set;
		}

		public ServiceProviderQuickViewVm ServiceProvider
		{
			get;
			set;
		}

		public string WebsiteUrl
		{
			get;
			set;
		}

		public ServiceProviderDetailsVm()
		{
		}
	}
}