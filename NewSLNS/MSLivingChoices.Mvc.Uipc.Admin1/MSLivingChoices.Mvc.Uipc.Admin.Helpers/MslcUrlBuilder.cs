using MSLivingChoices.Configuration;
using MSLivingChoices.Mvc.Uipc.Admin.ViewModels;
using System;
using System.Web;
using System.Web.Routing;

namespace MSLivingChoices.Mvc.Uipc.Admin.Helpers
{
	public static class MslcUrlBuilder
	{
		public static string BaseUrl
		{
			get
			{
				string rootUrl;
				if (HttpContext.Current != null)
				{
					Uri url = HttpContext.Current.Request.Url;
					string port = (url.IsDefaultPort ? string.Empty : string.Format(":{0}", url.Port));
					rootUrl = string.Format("{0}{1}{2}{3}", new object[] { url.Scheme, Uri.SchemeDelimiter, url.Host, port });
				}
				else
				{
					rootUrl = ConfigurationManager.Instance.SiteUrl;
				}
				return rootUrl;
			}
		}

		public static string ImageHandlerUrl(ImageVm image)
		{
			if (image == null)
			{
				return string.Empty;
			}
			return MslcUrlBuilder.RouteUrl("Images", new { name = image.Name });
		}

		public static string NormalizeUri(string url)
		{
			string result = null;
			if (url != null)
			{
				try
				{
					result = (new UriBuilder(url)).Uri.ToString();
				}
				catch (Exception exception)
				{
					result = string.Format("http://{0}", url);
				}
			}
			return result;
		}

		private static string RouteUrl(string routeName, object routeValues)
		{
			VirtualPathData virtualPathData = RouteTable.Routes.GetVirtualPath(null, routeName, new RouteValueDictionary(routeValues));
			return ((virtualPathData != null ? string.Concat(MslcUrlBuilder.BaseUrl, virtualPathData.VirtualPath) : string.Empty)).ToLower();
		}
	}
}