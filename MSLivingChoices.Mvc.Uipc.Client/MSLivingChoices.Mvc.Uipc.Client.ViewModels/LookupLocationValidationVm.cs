using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Mvc.Uipc.Client.ViewModels
{
	public class LookupLocationValidationVm
	{
		public SearchCriteriaVm Criteria
		{
			get;
			set;
		}

		public bool IsValid
		{
			get;
			set;
		}

		public string SearchUrl
		{
			get;
			set;
		}

		public List<AutocompleteVm> Variants
		{
			get;
			set;
		}

		public LookupLocationValidationVm()
		{
			this.Variants = new List<AutocompleteVm>();
		}
	}
}