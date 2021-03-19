using System;

namespace MSLivingChoices.Entities.Admin
{
	[Serializable]
	public class DateTimeBoundary<T> : DateTimeBoundary
	{
		public T Status;

		public DateTimeBoundary()
		{
		}
	}
}