using MSLivingChoices.Localization;
using MSLivingChoices.Mvc.Uipc.Admin.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Mvc.Uipc.Admin.Attributes
{
	internal class RequiredCheckBoxListAttribute : ValidationAttribute
	{
		public RequiredCheckBoxListAttribute()
		{
			base.ErrorMessageResourceType = typeof(ErrorMessages);
			base.ErrorMessageResourceName = "RequiredCheckboxList";
		}

		public override bool IsValid(object value)
		{
			List<CheckBoxVm> checkBoxList = value as List<CheckBoxVm>;
			if (checkBoxList == null)
			{
				return false;
			}
			return checkBoxList.Any<CheckBoxVm>((CheckBoxVm m) => m.IsChecked);
		}
	}
}