using MSLivingChoices.Mvc.Uipc.Admin.Attributes;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Mvc.Uipc.Admin.ViewModels
{
	public class MeasureBoundaryVm<T>
	where T : struct
	{
		[Range(0, 7.92281625142643E+28)]
		public Nullable<T> Max
		{
			get;
			set;
		}

		[NumberNotGreaterThan("Max")]
		[Range(0, 7.92281625142643E+28)]
		public Nullable<T> Min
		{
			get;
			set;
		}

		public MeasureBoundaryVm()
		{
		}
	}
}