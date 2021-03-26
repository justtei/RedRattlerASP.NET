using MSLivingChoices.Entities.Client.Enums;
using MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Mvc.Uipc.Client.ViewModels
{
	public class ServiceProvidersSearchVm : ResultSetSearchVm<ServiceProviderBlockVm, ServiceProviderSortType>
	{
		public SearchDisplayProperties DisplayProperties
		{
			get;
			set;
		}

		public ServiceProviderRefineVm Refine
		{
			get;
			set;
		}

		public List<int> ServiceCategories
		{
			get;
			set;
		}

		public ServiceProvidersSearchVm()
		{
		}
	}
}