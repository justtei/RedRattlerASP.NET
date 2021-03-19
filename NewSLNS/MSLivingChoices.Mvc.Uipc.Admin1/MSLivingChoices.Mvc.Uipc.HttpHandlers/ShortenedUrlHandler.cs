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
			if (long.TryParse(context.Request.Url.Segments.Last<string>(), out id))
			{
				if (context.Request.RawUrl.Contains("community"))
				{
					redirectUrl = this.GetCommunityDetailsUrl(id);
				}
				else if (context.Request.RawUrl.Contains("service"))
				{
					redirectUrl = this.GetServiceDetailsUrl(id);
				}
				else
				{
					redirectUrl = this.GetCommunityDetailsUrl(id);
					if (string.IsNullOrWhiteSpace(redirectUrl))
					{
						redirectUrl = this.GetServiceDetailsUrl(id);
					}
				}
			}
			if (!string.IsNullOrWhiteSpace(redirectUrl))
			{
				context.Response.RedirectPermanent(redirectUrl);
				return;
			}
			IController controller = ControllerBuilder.get_Current().GetControllerFactory().CreateController(context.Request.RequestContext, "Base");
			RouteData errorRoute = new RouteData();
			errorRoute.Values.Add("controller", "Base");
			errorRoute.Values.Add("action", "NotFound");
			controller.Execute(new RequestContext(context.Request.RequestContext.HttpContext, errorRoute));
		}
	}
}