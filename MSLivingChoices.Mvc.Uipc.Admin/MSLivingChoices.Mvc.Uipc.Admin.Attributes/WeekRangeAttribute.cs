using MSLivingChoices.Entities.Admin.Enums;
using MSLivingChoices.Localization;
using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace MSLivingChoices.Mvc.Uipc.Admin.Attributes
{
	public class WeekRangeAttribute : ValidationAttribute
	{
		private readonly string _endDayPropertyName;

		private string _endDayDisplayName;

		public WeekRangeAttribute(string endDayPropertyName)
		{
			this._endDayPropertyName = endDayPropertyName;
			base.ErrorMessageResourceName = "WeekRange";
			base.ErrorMessageResourceType = typeof(ErrorMessages);
		}

		public override string FormatErrorMessage(string name)
		{
			return string.Format(base.ErrorMessageString, name, this._endDayDisplayName);
		}

		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			if (value == null)
			{
				return ValidationResult.Success;
			}
			PropertyInfo endDayPropertyInfo = validationContext.ObjectType.GetProperty(this._endDayPropertyName);
			if (endDayPropertyInfo == null)
			{
				return ValidationResult.Success;
			}
			object endDayPropertyValue = endDayPropertyInfo.GetValue(validationContext.ObjectInstance, null);
			if (endDayPropertyValue == null)
			{
				return ValidationResult.Success;
			}
			this._endDayDisplayName = DisplayNameHelper.GetDisplayName(this._endDayPropertyName, endDayPropertyInfo);
			if ((EuropeanDayOfWeek)value <= (EuropeanDayOfWeek)endDayPropertyValue)
			{
				return ValidationResult.Success;
			}
			return new ValidationResult(base.ErrorMessage);
		}
	}
}