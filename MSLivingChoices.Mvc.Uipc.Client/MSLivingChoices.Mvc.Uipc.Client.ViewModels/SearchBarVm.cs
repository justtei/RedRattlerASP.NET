using MSLivingChoices.Mvc.Uipc.Enums;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Web.Mvc;

namespace MSLivingChoices.Mvc.Uipc.Client.ViewModels
{
	public class SearchBarVm : LookupLocationVm
	{
		public List<SelectListItem> SHCategories { get; set; }
		public CrosslinksVm Crosslinks
		{
			get;
			set;
		}

		public string Placeholder
		{
			get;
			set;
		}

		public List<SearchBarSelectListItem> SearchTypeList
		{
			get;
			set;
		}

		public Dictionary<SearchType, List<AutocompleteVm>> Templates
		{
			get;
			set;
		}

		public SearchBarVm()
		{
			this.SearchTypeList = new List<SearchBarSelectListItem>();
			this.Templates = new Dictionary<SearchType, List<AutocompleteVm>>();
		}
	}
}