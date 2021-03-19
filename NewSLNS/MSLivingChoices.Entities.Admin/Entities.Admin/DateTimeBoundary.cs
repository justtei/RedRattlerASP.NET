using System;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Entities.Admin
{
	[Serializable]
	public class DateTimeBoundary
	{
		public long? Id;

		public DateTime? StartDate;

		public DateTime? EndDate;

		public long? CommunityId
		{
			get;
			set;
		}

		public DateTimeBoundary()
		{
		}
	}
}