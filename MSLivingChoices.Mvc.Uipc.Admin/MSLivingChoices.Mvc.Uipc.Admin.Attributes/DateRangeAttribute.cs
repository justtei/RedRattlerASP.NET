using MSLivingChoices.Localization;
using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace MSLivingChoices.Mvc.Uipc.Admin.Attributes
{
	public class DateRangeAttribute : ValidationAttribute
	{
		private readonly string _endDatePropertyName;

		private string _endDateDisplayName;

		public DateRangeAttribute(string endDatePropertyName)
		{
			this._endDatePropertyName = endDatePropertyName;
			base.ErrorMessageResourceName = "DateRange";
			base.ErrorMessageResourceType = typeof(ErrorMessages);
		}

		public override string FormatErrorMessage(string name)
		{
			return string.Format(base.ErrorMessageString, name, this._endDateDisplayName);
		}

		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			if (value == null)
			{
				return ValidationResult.Success;
			}
			PropertyInfo endDateProperyInfo = validationContext.ObjectType.GetProperty(this._endDatePropertyName);
			if (endDateProperyInfo == null)
			{
				return ValidationResult.Success;
			}
			object endDateProperyValue = endDateProperyInfo.GetValue(validationContext.ObjectInstance, null);
			if (endDateProperyValue == null)
			{
				return ValidationResult.Success;
			}
			this._endDateDisplayName = DisplayNameHelper.GetDisplayName(this._endDatePropertyName, endDateProperyInfo);
			if ((DateTime)value <= (DateTime)endDateProperyValue)
			{
				return ValidationResult.Success;
			}
			return new ValidationResult(base.ErrorMessage);
		}
	}
}