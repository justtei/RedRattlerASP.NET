using System;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Entities.Client
{
	[Serializable]
	public class Boundary<TValue>
	where TValue : struct
	{
		public Nullable<TValue> Max
		{
			get;
			set;
		}

		public Nullable<TValue> Min
		{
			get;
			set;
		}

		public Boundary()
		{
		}

		public override string ToString()
		{
			return string.Format("From {0} to {1}", this.Min, this.Max);
		}
	}
}