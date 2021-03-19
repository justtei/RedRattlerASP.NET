using MSLivingChoices.Entities.Admin;
using MSLivingChoices.Localization;
using MSLivingChoices.Mvc.Uipc.Admin.Helpers;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Web.Mvc;

namespace MSLivingChoices.Mvc.Uipc.Admin.ViewModels
{
	public class MeasureBoundaryVm<T, M> : MeasureBoundaryVm<T>
	where T : struct
	where M : struct
	{
		public List<SelectListItem> AvailableMeasures
		{
			get
			{
				return ConverterHelpers.EnumToKoSelectListItems<M>(this.Measure);
			}
		}

		public M Measure
		{
			get;
			set;
		}

		public MeasureBoundaryVm()
		{
			if (!typeof(M).IsEnum)
			{
				throw new ArgumentException(ErrorMessages.NotEnumType);
			}
			this.Measure = default(M);
		}

		public MeasureBoundary<T, M> ToEntity()
		{
			return new MeasureBoundary<T, M>()
			{
				Min = base.Min,
				Max = base.Max,
				Measure = this.Measure
			};
		}
	}
}