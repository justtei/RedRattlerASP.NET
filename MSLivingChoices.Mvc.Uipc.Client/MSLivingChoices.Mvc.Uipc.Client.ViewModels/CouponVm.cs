using System;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Mvc.Uipc.Client.ViewModels
{
	public class CouponVm
	{
		public string Description
		{
			get;
			set;
		}

		public string ExpirationDate
		{
			get;
			set;
		}

		public string PrintUrl
		{
			get;
			set;
		}

		public string Title
		{
			get;
			set;
		}

		public CouponVm()
		{
		}
	}
}