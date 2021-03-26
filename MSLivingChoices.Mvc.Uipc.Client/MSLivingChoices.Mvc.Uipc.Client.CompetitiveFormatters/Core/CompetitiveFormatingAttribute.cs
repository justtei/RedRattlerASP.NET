using MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters;
using MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver;
using MSLivingChoices.Mvc.Uipc.Client.Enums;
using MSLivingChoices.Mvc.Uipc.Client.ViewModels;
using System;
using System.Web.Mvc;

namespace MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.Core
{
	public class CompetitiveFormatingAttribute : ActionFilterAttribute
	{
		public CompetitiveFormatingAttribute()
		{
		}

		public override void OnActionExecuted(ActionExecutedContext filterContext)
		{
			object model;
			ViewResultBase result = filterContext.Result as ViewResultBase;
			if (result != null)
			{
				model = result.Model;
			}
			else
			{
				JsonResult jsonResult = filterContext.Result as JsonResult;
				if (jsonResult == null)
				{
					return;
				}
				model = jsonResult.Data;
			}
			if (model == null)
			{
				return;
			}
			PageVm pageVm = model as PageVm;
			if (pageVm == null)
			{
				FormatterResolver.ApplyFormatting<EntityLocation>(model, EntityLocation.Search);
				return;
			}
			FormatterResolver.ApplyFormatting<PageType>(model, pageVm.PageType);
		}
	}
}