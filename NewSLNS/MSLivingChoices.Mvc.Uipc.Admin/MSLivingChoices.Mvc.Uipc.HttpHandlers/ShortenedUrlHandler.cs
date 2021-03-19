using MSLivingChoices.Bcs.Admin.Components;
using MSLivingChoices.Entities.Admin;
using MSLivingChoices.Entities.Admin.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MSLivingChoices.Mvc.Uipc.HttpHandlers
{
	public class ShortenedUrlHandler : IHttpHandler
	{
		bool System.Web.IHttpHandler.IsReusable
		{
			get
			{
				return true;
			}
		}

		public ShortenedUrlHandler()
		{
		}

		private string GetCommunityDetailsUrl(long id)
		{
			string url = null;
			Community model = CommunityBc.Instance.GetById(id);
			if (model != null)
			{
				if (!model.ListingTypes.Contains(ListingType.ActiveAdultCommunities) && !model.ListingTypes.Contains(ListingType.ActiveAdultHomes) && !model.ListingTypes.Contains(ListingType.SeniorHousingAndCare))
				{
					return null;
				}
				url = "";
			}
			return url;
		}

		private string GetServiceDetailsUrl(long id)
		{
			string url = null;
			if (ServiceProviderBc.Instance.GetById(id) != null)
			{
				url = "";
			}
			return url;
		}

		public void ProcessRequest(HttpContext context)
		{
			long id;
			string redirectUrl = null;
			if (long.TryParse(context.get_Request().get_Url().Segments.Last<string>(), out id))
			{
				if (context.get_Request().get_RawUrl().Contains("community"))
				{
					redirectUrl = this.GetCommunityDetailsUrl(id);
				}
				else if (!context.get_Request().get_RawUrl().Contains("service"))
				{
					redirectUrl = this.GetCommunityDetailsUrl(id);
					if (string.IsNullOrWhiteSpace(redirectUrl))
					{
						redirectUrl = this.GetServiceDetailsUrl(id);
					}
				}
				else
				{
					redirectUrl = this.GetServiceDetailsUrl(id);
				}
			}
			if (!string.IsNullOrWhiteSpace(redirectUrl))
			{
				context.get_Response().RedirectPermanent(redirectUrl);
				return;
			}
			IController controller = ControllerBuilder.Current.GetControllerFactory().CreateController(context.get_Request().get_RequestContext(), "Base");
			RouteData errorRoute = new RouteData();
			errorRoute.get_Values().Add("controller", "Base");
			errorRoute.get_Values().Add("action", "NotFound");
			controller.Execute(new RequestContext(context.get_Request().get_RequestContext().get_HttpContext(), errorRoute));
		}
	}
}