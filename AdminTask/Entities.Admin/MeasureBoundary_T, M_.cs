using System;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Entities.Admin
{
	[Serializable]
	public class MeasureBoundary<T, M>
	where T : struct
	where M : struct
	{
		public Nullable<T> Max
		{
			get;
			set;
		}

		public M Measure
		{
			get;
			set;
		}

		public Nullable<T> Min
		{
			get;
			set;
		}

		public MeasureBoundary()
		{
			if (!typeof(M).IsEnum)
			{
				throw new ArgumentException("Not enum type");
			}
			this.Measure = default(M);
		}
	}
}