using MSLivingChoices.Localization;
using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace MSLivingChoices.Mvc.Uipc.Admin.Attributes
{
	public class NumberNotGreaterThanAttribute : ValidationAttribute
	{
		private readonly string _propertyToCompareName;

		public NumberNotGreaterThanAttribute(string propertyToCompareName)
		{
			this._propertyToCompareName = propertyToCompareName;
			base.ErrorMessageResourceType = typeof(ErrorMessages);
			base.ErrorMessageResourceName = "InvalidMinValue";
		}

		public override string FormatErrorMessage(string name)
		{
			return string.Format(base.ErrorMessageString, name, this._propertyToCompareName);
		}

		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			double propertyDoubleValue;
			double propertyToCompareDoubleValue;
			if (value == null)
			{
				return ValidationResult.Success;
			}
			string propertyStringValue = value.ToString();
			if (propertyStringValue == string.Empty)
			{
				return ValidationResult.Success;
			}
			if (double.TryParse(propertyStringValue, out propertyDoubleValue))
			{
				PropertyInfo propertyToCompare = validationContext.ObjectType.GetProperty(this._propertyToCompareName);
				if (propertyToCompare == null)
				{
					return ValidationResult.Success;
				}
				object propertyToCompareValue = propertyToCompare.GetValue(validationContext.ObjectInstance, null);
				if (propertyToCompareValue == null)
				{
					return ValidationResult.Success;
				}
				string propertyToCompareStringValue = propertyToCompareValue.ToString();
				if (propertyToCompareStringValue == string.Empty)
				{
					return ValidationResult.Success;
				}
				if (double.TryParse(propertyToCompareStringValue, out propertyToCompareDoubleValue) && propertyDoubleValue <= propertyToCompareDoubleValue)
				{
					return ValidationResult.Success;
				}
			}
			return new ValidationResult(base.ErrorMessage);
		}
	}
}