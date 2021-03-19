using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Web.Mvc;

namespace MSLivingChoices.Mvc.Uipc.Admin.Filters
{
	public abstract class PartialValidation : ActionFilterAttribute
	{
		protected PartialValidation()
		{
		}

		protected bool? GetValue(ActionExecutingContext filterContext, string valueName)
		{
			bool value;
			bool? nullable;
			ValueProviderResult result = filterContext.Controller.ValueProvider.GetValue(valueName);
			if (result == null)
			{
				nullable = null;
				return nullable;
			}
			if (bool.TryParse(result.AttemptedValue, out value))
			{
				return new bool?(value);
			}
			nullable = null;
			return nullable;
		}

		protected void RemoveValidationIfNecessary(ModelStateDictionary modelState, bool? boolValue, string patternForRemoval)
		{
			if (!boolValue.HasValue || boolValue.Value)
			{
				return;
			}
			foreach (string s in 
				from x in modelState.Keys
				where x.Contains(patternForRemoval)
				select x)
			{
				modelState[s].Errors.Clear();
			}
		}
	}
}