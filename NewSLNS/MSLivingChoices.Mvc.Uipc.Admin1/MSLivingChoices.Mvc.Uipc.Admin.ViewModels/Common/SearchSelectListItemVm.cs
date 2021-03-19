using System;
using System.Runtime.CompilerServices;
using System.Web.Mvc;

namespace MSLivingChoices.Mvc.Uipc.Admin.ViewModels.Common
{
	public class SearchSelectListItemVm : SelectListItem
	{
		public string UrlValue
		{
			get;
			set;
		}

		public SearchSelectListItemVm()
		{
		}
	}
}