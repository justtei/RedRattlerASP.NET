using System;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Entities.Client
{
	[Serializable]
	public class MeasureBoundary<TValue, TMeasure> : Boundary<TValue>
	where TValue : struct
	{
		public TMeasure Measure
		{
			get;
			set;
		}

		public MeasureBoundary()
		{
		}

		public override string ToString()
		{
			return string.Format("From {0} {1} to {2} {1}", base.Min, this.Measure, base.Max);
		}
	}
}