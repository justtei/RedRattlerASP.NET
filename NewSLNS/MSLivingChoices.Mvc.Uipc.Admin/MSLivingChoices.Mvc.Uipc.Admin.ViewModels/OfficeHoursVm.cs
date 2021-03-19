using MSLivingChoices.Entities.Admin;
using MSLivingChoices.Entities.Admin.Enums;
using MSLivingChoices.Mvc.Uipc.Admin.Attributes;
using MSLivingChoices.Mvc.Uipc.Admin.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Web.Mvc;

namespace MSLivingChoices.Mvc.Uipc.Admin.ViewModels
{
	public class OfficeHoursVm
	{
		public EuropeanDayOfWeek? EndDay
		{
			get;
			set;
		}

		public List<SelectListItem> EndDays
		{
			get
			{
				if (!this.EndDay.HasValue)
				{
					return ConverterHelpers.EnumToKoSelectListItems<EuropeanDayOfWeek>();
				}
				return ConverterHelpers.EnumToKoSelectListItems<EuropeanDayOfWeek>(this.EndDay.Value);
			}
		}

		public DateTime? EndTime
		{
			get;
			set;
		}

		public long? Id
		{
			get;
			set;
		}

		[AllowHtml]
		[StringLength(100)]
		public string Note
		{
			get;
			set;
		}

		[WeekRange("EndDay")]
		public EuropeanDayOfWeek? StartDay
		{
			get;
			set;
		}

		public List<SelectListItem> StartDays
		{
			get
			{
				if (!this.StartDay.HasValue)
				{
					return ConverterHelpers.EnumToKoSelectListItems<EuropeanDayOfWeek>();
				}
				return ConverterHelpers.EnumToKoSelectListItems<EuropeanDayOfWeek>(this.StartDay.Value);
			}
		}

		public DateTime? StartTime
		{
			get;
			set;
		}

		public OfficeHoursVm()
		{
		}

		public OfficeHoursVm(OfficeHours officeHours)
		{
			this.Id = officeHours.Id;
			this.StartDay = officeHours.StartDay;
			this.EndDay = officeHours.EndDay;
			this.StartTime = officeHours.StartTime;
			this.EndTime = officeHours.EndTime;
			this.Note = officeHours.Note;
		}

		public OfficeHours ToEntity()
		{
			if (!this.StartTime.HasValue || !this.EndTime.HasValue || !this.StartDay.HasValue && !this.EndDay.HasValue)
			{
				return null;
			}
			return new OfficeHours()
			{
				Id = this.Id,
				StartDay = this.StartDay,
				EndDay = this.EndDay,
				StartTime = this.StartTime,
				EndTime = this.EndTime,
				Note = this.Note
			};
		}
	}
}