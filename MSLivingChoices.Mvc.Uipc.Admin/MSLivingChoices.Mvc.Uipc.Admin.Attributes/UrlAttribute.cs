using MSLivingChoices.Localization;
using System;
using System.ComponentModel.DataAnnotations;

namespace MSLivingChoices.Mvc.Uipc.Admin.Attributes
{
	public class UrlAttribute : ValidationAttribute
	{
		public UrlAttribute()
		{
			base.ErrorMessageResourceName = "InvalidUrl";
			base.ErrorMessageResourceType = typeof(ErrorMessages);
		}

		public override bool IsValid(object value)
		{
			if (value == null || value.ToString().Trim() == string.Empty)
			{
				return true;
			}
			return Uri.IsWellFormedUriString(value.ToString(), UriKind.RelativeOrAbsolute);
		}
	}
}