using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Mvc.Uipc.Client.ViewModels
{
	public class CommunityQuickViewVm : CommunityBlockVm
	{
		public List<string> CommunityServices
		{
			get;
			set;
		}

		public string Description
		{
			get;
			set;
		}

		public LeadFormVm LeadForm
		{
			get;
			set;
		}

		public CommunityQuickViewVm()
		{
		}
	}
}