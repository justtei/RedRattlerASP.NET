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
			ValueProviderResult valueResult = bindingContext.get_ValueProvider().GetValue(bindingContext.get_ModelName());
			ModelState modelState1 = new ModelState();
			modelState1.set_Value(valueResult);
			ModelState modelState = modelState1;
			object actualValue = null;
			try
			{
				actualValue = Convert.ToDouble(valueResult.get_AttemptedValue(), CultureInfo.InvariantCulture);
			}
			catch (FormatException formatException)
			{
				modelState.get_Errors().Add(formatException);
			}
			bindingContext.get_ModelState().Add(bindingContext.get_ModelName(), modelState);
			return actualValue;
		}
	}
}