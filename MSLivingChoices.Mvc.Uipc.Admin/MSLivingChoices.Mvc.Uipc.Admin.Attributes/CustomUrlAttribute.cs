using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace MSLivingChoices.Mvc.Uipc.Admin.Attributes
{
	public class CustomUrlAttribute : ValidationAttribute
	{
		private const string Pattern = "((([A-Za-z]{3,9}:(?:\\/\\/)?)(?:[-;:&=\\+\\$,\\w]+@)?[A-Za-z0-9.-]+|(?:www.|[-;:&=\\+\\$,\\w]+@)[A-Za-z0-9.-]+)((?:\\/[\\+~%\\/.\\w-_]*)?\\??(?:[-\\+=&;%@.\\w_]*)#?(?:[\\w]*))?)";

		public CustomUrlAttribute()
		{
		}

		public override bool IsValid(object value)
		{
			if (value == null || value.ToString().Trim() == string.Empty)
			{
				return true;
			}
			return Regex.IsMatch(value.ToString(), "((([A-Za-z]{3,9}:(?:\\/\\/)?)(?:[-;:&=\\+\\$,\\w]+@)?[A-Za-z0-9.-]+|(?:www.|[-;:&=\\+\\$,\\w]+@)[A-Za-z0-9.-]+)((?:\\/[\\+~%\\/.\\w-_]*)?\\??(?:[-\\+=&;%@.\\w_]*)#?(?:[\\w]*))?)");
		}
	}
}