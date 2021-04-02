using MSLivingChoices.Entities.Client;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Mvc.Uipc.Client.ViewModels
{
	public class ServiceProviderBlockVm : ServiceProviderShortVm
	{
		public List<County> CountiesServed
		{
			get;
			set;
		}

		public List<ImageVm> Images
		{
			get;
			set;
		}
		
		public string Phone
		{
			get;
			set;
		}

		public string PrintDirectionBaseUrl
		{
			get;
			set;
		}

		public string PrintUrl
		{
			get;
			set;
		}

		public string SearchRadiusDesignation
		{
			get;
			set;
		}

		public List<string> ServiceCategories
		{
			get;
			set;
		}

		public ServiceProviderBlockVm()
		{
		}
	}
}