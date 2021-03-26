using MSLivingChoices.Entities.Client.Search.Criteria;
using MSLivingChoices.Mvc.Uipc.Client.Helpers;
using MSLivingChoices.Mvc.Uipc.Client.ViewModels;
using System;
using System.ComponentModel;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MSLivingChoices.Mvc.Uipc.Client.ModelBinders
{
	public class SearchVmBinder : DefaultModelBinder
	{
		protected override void BindProperty(ControllerContext controllerContext, ModelBindingContext bindingContext, PropertyDescriptor propertyDescriptor)
		{
			SearchVm searchVm = bindingContext.Model as SearchVm;
			base.BindProperty(controllerContext, bindingContext, propertyDescriptor);
			if (searchVm != null)
			{
				BindSearchModel(searchVm, controllerContext, bindingContext, propertyDescriptor);
			}
		}

		protected void BindSearchModel(SearchVm model, ControllerContext controllerContext, ModelBindingContext bindingContext, PropertyDescriptor propertyDescriptor)
		{
			if (string.Equals(propertyDescriptor.Name, "Criteria"))
			{
				model.Criteria.CountryCode("USA");
				string text = ((string)controllerContext.RouteData.Values["stateCode"]) ?? controllerContext.HttpContext.Request["StateCode"];
				if (!string.IsNullOrWhiteSpace(text))
				{
					model.Criteria.StateCode(text.FromUrlSectionString());
				}
				string text2 = ((string)controllerContext.RouteData.Values["cityName"]) ?? controllerContext.HttpContext.Request["City"];
				if (!string.IsNullOrWhiteSpace(text2))
				{
					model.Criteria.City(text2.FromUrlSectionString());
				}
				string text3 = ((string)controllerContext.RouteData.Values["Zip"]) ?? controllerContext.HttpContext.Request["zip"];
				if (!string.IsNullOrWhiteSpace(text3))
				{
					model.Criteria.Zip(text3);
				}
			}
			if (string.Equals(propertyDescriptor.Name, "PageType"))
			{
				base.BindProperty(controllerContext, bindingContext, propertyDescriptor);
				model.Criteria.SearchType(model.PageType.ToSearchType());
			}
		}
	}
}