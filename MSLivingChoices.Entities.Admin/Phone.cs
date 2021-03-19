using System;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Entities.Admin
{
	[Serializable]
	public class Phone
	{
		public long? CommunityId
		{
			get;
			set;
		}

		public long? Id
		{
			get;
			set;
		}

		public string Number
		{
			get;
			set;
		}

		public long? PhoneTypeId
		{
			get;
			set;
		}

		public int Sequence
		{
			get;
			set;
		}

		public long? ServiceId
		{
			get;
			set;
		}

		public Phone()
		{
		}
	}
}