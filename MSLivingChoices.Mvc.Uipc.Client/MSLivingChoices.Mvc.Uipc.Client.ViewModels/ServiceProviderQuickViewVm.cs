using System;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Mvc.Uipc.Client.ViewModels
{
	public class ServiceProviderQuickViewVm : ServiceProviderBlockVm
	{
		public string Code { get; set; }

		public LeadFormVm LeadForm
		{
			get;
			set;
		}

		public ServiceProviderQuickViewVm()
		{
		}
	}
}