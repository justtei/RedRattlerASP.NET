using MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Mvc.Uipc.Client.ViewModels
{
	public class SearchTypeStubSearchVm : SearchVm<Dictionary<string, List<LinkVm>>>
	{
		public SearchDisplayProperties DisplayProperties
		{
			get;
			set;
		}

		public SearchTypeStubSearchVm()
		{
		}
	}
}