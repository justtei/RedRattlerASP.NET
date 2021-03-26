using MSLivingChoices.Mvc.Uipc.Enums;
using System;
using System.Collections.Generic;

namespace MSLivingChoices.Mvc.Uipc.Client.ViewModels
{
	public class IndexVm : SearchVm<Dictionary<SearchType, List<LinkVm>>>
	{
		public IndexVm()
		{
			base.Result = new Dictionary<SearchType, List<LinkVm>>();
		}
	}
}