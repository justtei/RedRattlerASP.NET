using System;
using System.Web;
using System.Web.Routing;

namespace MSLivingChoices.Mvc.Uipc.HttpHandlers
{
	public class ShortenedRouteHandler : IRouteHandler
	{
		public ShortenedRouteHandler()
		{
		}

		public IHttpHandler GetHttpHandler(RequestContext requestContext)
		{
			return new ShortenedUrlHandler();
		}
	}
}