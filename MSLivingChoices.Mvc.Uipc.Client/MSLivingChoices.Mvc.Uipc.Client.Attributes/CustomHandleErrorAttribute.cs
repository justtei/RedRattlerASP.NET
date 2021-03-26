using MSLivingChoices.Configuration;
using MSLivingChoices.Localization;
using MSLivingChoices.Logging;
using MSLivingChoices.Logging.Messages;
using MSLivingChoices.Mvc.Uipc.Client.Enums;
using MSLivingChoices.Mvc.Uipc.Client.ViewModelsProviders;
using MSLivingChoices.Mvc.Uipc.Results;
using System;
using System.Web;
using System.Web.Mvc;

namespace MSLivingChoices.Mvc.Uipc.Client.Attributes
{
	public class CustomHandleErrorAttribute : HandleErrorAttribute
	{
		public override void OnException(ExceptionContext filterContext)
		{
			base.OnException(filterContext);
			Logger.Error(LogMessages.MvcUipcClient.Custom.ServerExceptionError, filterContext.Exception);
			if (ConfigurationManager.Instance.IsExceptionRewrite)
			{
				filterContext.HttpContext.Response.Clear();
				filterContext.HttpContext.Response.StatusCode = 500;
				filterContext.HttpContext.Response.TrySkipIisCustomErrors = true;
				filterContext.ExceptionHandled = true;
				if (filterContext.HttpContext.Request.IsAjaxRequest())
				{
					filterContext.Result = new AllowGetJsonResult(ErrorMessages.AjaxServerError);
					return;
				}
				filterContext.Result = new ViewResult
				{
					ViewName = "~/Views/Client/Error/Error.cshtml",
					ViewData = new ViewDataDictionary(ClientViewModelsProvider.GetStaticContent(PageType.Error500))
				};
			}
		}
	}
}