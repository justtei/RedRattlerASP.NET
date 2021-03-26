using System;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Mvc.Uipc.Client.ViewModels
{
	public class SearchWithServicesVm : SearchVm
	{
		public FeaturedServicesVm FeaturedServices
		{
			get;
			set;
		}

		public SearchWithServicesVm()
		{
		}
	}
}