using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Mvc.Uipc.Client.ViewModels
{
	public class SpecHomeVm : SpecHomeQuickViewVm
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

		public string Description
		{
			get;
			set;
		}

		public string PetDeposit
		{
			get;
			set;
		}

		public SpecHomeVm()
		{
		}
	}
}