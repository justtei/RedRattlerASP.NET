using System;
using System.Web.Mvc;

namespace MSLivingChoices.Mvc.Uipc.Admin.Filters
{
	public class CallTrackingDetailsPartialValidation : PartialValidation
	{
		public CallTrackingDetailsPartialValidation()
		{
		}

		public override void OnActionExecuting(ActionExecutingContext filterContext)
		{
			ModelStateDictionary modelState = filterContext.Controller.ViewData.ModelState;
			base.RemoveValidationIfNecessary(modelState, base.GetValue(filterContext, "ProvisionCallTrackingNumbers"), "CallTrackingPhones");
		}
	}
}