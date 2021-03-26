using System;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Mvc.Uipc.Client.ViewModels
{
	public class ServiceProviderPrintDirectionVm : ServiceProviderDetailsVm
	{
		public double StartLatitude
		{
			get;
			set;
		}

		public double StartLongitude
		{
			get;
			set;
		}

		public ServiceProviderPrintDirectionVm()
		{
		}
	}
}