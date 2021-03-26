using System;
using System.Runtime.CompilerServices;
using System.Web.Mvc;

namespace MSLivingChoices.Mvc.Uipc.Client.ViewModels
{
	public class SearchBarSelectListItem : SelectListItem
	{
		public string UrlValue
		{
			get;
			set;
		}

		public SearchBarSelectListItem()
		{
		}
	}
}