using System;
using System.Web.Mvc;

namespace MSLivingChoices.Mvc.Uipc.Admin.Filters
{
	public class EditCommunityPartialValidation : PartialValidation
	{
		public EditCommunityPartialValidation()
		{
		}

		public override void OnActionExecuting(ActionExecutingContext filterContext)
		{
			ModelStateDictionary modelState = filterContext.Controller.ViewData.ModelState;
			base.RemoveValidationIfNecessary(modelState, base.GetValue(filterContext, "CommunityDetails.HasFloorPlans"), "CommunityDetails.FloorPlans");
			base.RemoveValidationIfNecessary(modelState, base.GetValue(filterContext, "CommunityDetails.HasSpecHomes"), "CommunityDetails.SpecHomes");
			base.RemoveValidationIfNecessary(modelState, base.GetValue(filterContext, "CommunityDetails.HasHouses"), "CommunityDetails.Houses");
			base.RemoveValidationIfNecessary(modelState, base.GetValue(filterContext, "ListingDetails.PropertyManager.HasNewOwner"), "ListingDetails.PropertyManager.NewOwner");
			base.RemoveValidationIfNecessary(modelState, base.GetValue(filterContext, "ListingDetails.Builder.HasNewOwner"), "ListingDetails.Builder.NewOwner");
			base.RemoveValidationIfNecessary(modelState, base.GetValue(filterContext, "ListingDetails.ProvisionCallTrackingNumbers"), "ListingDetails.CallTrackingPhones");
		}
	}
}