using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Web.Mvc;

namespace MSLivingChoices.Mvc.Uipc.Client.ViewModels
{
	public class ServiceProviderRefineVm
	{
		public IEnumerable<SelectListItem> ServiceCategories
		{
			get;
			set;
		}

		public IEnumerable<SelectListItem> SortTypes
		{
			get;
			set;
		}

		public ServiceProviderRefineVm()
		{
			this.SortTypes = new List<SelectListItem>();
			this.ServiceCategories = new List<SelectListItem>();
		}
	}
}