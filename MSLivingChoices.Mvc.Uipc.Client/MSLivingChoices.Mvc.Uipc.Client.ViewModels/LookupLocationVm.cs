using MSLivingChoices.Mvc.Uipc.Enums;
using System;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Mvc.Uipc.Client.ViewModels
{
	public class LookupLocationVm
	{
		public string LookupLocation
		{
			get;
			set;
		}

		public SearchType SearchType
		{
			get;
			set;
		}

		public LookupLocationVm()
		{
			this.SearchType = SearchType.SeniorHousingAndCare;
			this.LookupLocation = string.Empty;
		}

		public override string ToString()
		{
			return string.Format("{0} in {1}", this.SearchType, this.LookupLocation);
		}
	}
}