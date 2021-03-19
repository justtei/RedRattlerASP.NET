using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace MSLivingChoices.Mvc.Uipc.Admin.Attributes
{
	public class RequiredOnDemand : RequiredAttribute
	{
		private readonly string _propertyName;

		public RequiredOnDemand(string propertyName)
		{
			this._propertyName = propertyName;
		}

		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			PropertyInfo property = validationContext.ObjectType.GetProperty(this._propertyName);
			if (property != null)
			{
				object propertyValue = property.GetValue(validationContext.ObjectInstance, null);
				if (propertyValue != null && propertyValue is bool && (bool)propertyValue)
				{
					return base.IsValid(value, validationContext);
				}
			}
			return ValidationResult.Success;
		}
	}
}