using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web.Mvc;

namespace MSLivingChoices.Mvc.Uipc.Admin.Filters
{
	public abstract class PartialValidation : ActionFilterAttribute
	{
		protected bool? GetValue(ActionExecutingContext filterContext, string valueName)
		{
			ValueProviderResult result = filterContext.Controller.ValueProvider.GetValue(valueName);
			if (result == null)
			{
				return null;
			}
			if (!bool.TryParse(result.AttemptedValue, out var value))
			{
				return null;
			}
			return value;
		}

		protected void RemoveValidationIfNecessary(ModelStateDictionary modelState, bool? boolValue, string patternForRemoval)
		{
			if (!boolValue.HasValue || boolValue.Value)
			{
				return;
			}
			foreach (string s in modelState.Keys.Where((string x) => x.Contains(patternForRemoval)))
			{
				modelState[s].Errors.Clear();
			}
		}
	}

}