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
		protected PartialValidation()
		{
		}

		protected bool? GetValue(ActionExecutingContext filterContext, string valueName)
		{
			bool value;
			bool? nullable;
			ValueProviderResult result = filterContext.get_Controller().get_ValueProvider().GetValue(valueName);
			if (result == null)
			{
				nullable = null;
				return nullable;
			}
			if (bool.TryParse(result.get_AttemptedValue(), out value))
			{
				return new bool?(value);
			}
			nullable = null;
			return nullable;
		}

		protected void RemoveValidationIfNecessary(ModelStateDictionary modelState, bool? boolValue, string patternForRemoval)
		{
			Func<string, bool> func = null;
			if (!boolValue.HasValue || boolValue.Value)
			{
				return;
			}
			ICollection<string> keys = modelState.get_Keys();
			Func<string, bool> func1 = func;
			if (func1 == null)
			{
				Func<string, bool> func2 = (string x) => x.Contains(patternForRemoval);
				Func<string, bool> func3 = func2;
				func = func2;
				func1 = func3;
			}
			foreach (string s in keys.Where<string>(func1))
			{
				modelState.get_Item(s).get_Errors().Clear();
			}
		}
	}
}