using System;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Entities.Client
{
	[Serializable]
	public class Coupon
	{
		public string Description
		{
			get;
			set;
		}

		public DateTime? ExpirationDate
		{
			get;
			set;
		}

		public string Title
		{
			get;
			set;
		}

		public Coupon()
		{
		}
	}
}