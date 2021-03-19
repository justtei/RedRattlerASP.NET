using System;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Mvc;

namespace MSLivingChoices.Mvc.Uipc.Admin.Helpers
{
	public static class RenderHelper
	{
		public static IHtmlString Json(this HtmlHelper helper, object data)
		{
			return helper.Raw(JsHelper.MapToJson(data));
		}
	}
}