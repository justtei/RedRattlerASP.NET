using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Mvc.Uipc.Client.ViewModels
{
	public class FeaturedServicesVm
	{
		public string AreaName
		{
			get;
			set;
		}

		public string AreaServicesLink
		{
			get;
			set;
		}

		public List<ServiceProviderShortVm> Items
		{
			get;
			set;
		}

		public FeaturedServicesVm()
		{
		}
	}
}