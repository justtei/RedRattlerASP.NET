using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Mvc.Uipc.Client.ViewModels
{
	public class FloorPlanVm : FloorPlanQuickViewVm
	{
		public List<string> Amenities
		{
			get;
			set;
		}

		public string ApplicationFee
		{
			get;
			set;
		}

		public string Deposit
		{
			get;
			set;
		}

		public string PetDeposit
		{
			get;
			set;
		}

		public FloorPlanVm()
		{
		}
	}
}