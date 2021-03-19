using MSLivingChoices.Localization;
using MSLivingChoices.Mvc.Uipc.Admin.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace MSLivingChoices.Mvc.Uipc.Admin.Attributes
{
	internal class OptionalSHCCategoriesAttribute : RequiredCheckBoxListAttribute
	{
		public OptionalSHCCategoriesAttribute()
		{
		}

		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			PropertyInfo listingTypesProperty = validationContext.ObjectType.GetProperty("ListingTypes");
			if (listingTypesProperty == null)
			{
				return new ValidationResult(string.Format(ErrorMessages.Required, "ListingTypes"));
			}
			List<CheckBoxVm> listingTypes = listingTypesProperty.GetValue(validationContext.ObjectInstance, null) as List<CheckBoxVm>;
			if (listingTypes == null)
			{
				return new ValidationResult(string.Format(ErrorMessages.Required, "ListingTypes"));
			}
			if (listingTypes.Count <= 2 || !listingTypes[2].IsChecked)
			{
				return ValidationResult.Success;
			}
			return base.IsValid(value, validationContext);
		}
	}
}