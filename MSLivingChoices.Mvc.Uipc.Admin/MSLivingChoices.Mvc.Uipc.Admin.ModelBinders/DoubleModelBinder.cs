using System;
using System.Globalization;
using System.Web.Mvc;

namespace MSLivingChoices.Mvc.Uipc.Admin.ModelBinders
{
	public class DoubleModelBinder : IModelBinder
	{
		public DoubleModelBinder()
		{
		}

		public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
		{
			ValueProviderResult valueResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
			ModelState modelState = new ModelState()
			{
				Value = valueResult
			};
			object actualValue = null;
			try
			{
				actualValue = Convert.ToDouble(valueResult.AttemptedValue, CultureInfo.InvariantCulture);
			}
			catch (FormatException formatException)
			{
				modelState.Errors.Add(formatException);
			}
			bindingContext.ModelState.Add(bindingContext.ModelName, modelState);
			return actualValue;
		}
	}
}