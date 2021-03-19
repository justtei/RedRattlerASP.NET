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
			ModelStateDictionary modelState = filterContext.get_Controller().get_ViewData().get_ModelState();
			base.RemoveValidationIfNecessary(modelState, base.GetValue(filterContext, "ProvisionCallTrackingNumbers"), "CallTrackingPhones");
		}
	}
}