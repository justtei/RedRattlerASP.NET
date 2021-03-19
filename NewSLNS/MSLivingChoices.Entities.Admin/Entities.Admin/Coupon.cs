using System;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Entities.Admin
{
	[Serializable]
	public class Coupon
	{
		public long? CommunityId
		{
			get;
			set;
		}

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

		public long? Id
		{
			get;
			set;
		}

		public string Name
		{
			get;
			set;
		}

		public DateTime? PublishDate
		{
			get;
			set;
		}

		public Coupon()
		{
		}
	}
}