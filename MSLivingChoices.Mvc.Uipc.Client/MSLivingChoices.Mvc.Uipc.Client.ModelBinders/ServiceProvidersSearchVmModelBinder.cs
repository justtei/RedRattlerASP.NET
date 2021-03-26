using MSLivingChoices.Mvc.Uipc.Client.Helpers;
using MSLivingChoices.Mvc.Uipc.Client.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Mvc;

namespace MSLivingChoices.Mvc.Uipc.Client.ModelBinders
{
	public class ServiceProvidersSearchVmModelBinder : SearchVmBinder
	{
		protected override void BindProperty(ControllerContext controllerContext, ModelBindingContext bindingContext, PropertyDescriptor propertyDescriptor)
		{
			ServiceProvidersSearchVm serviceProvidersSearchVm = bindingContext.Model as ServiceProvidersSearchVm;
			base.BindProperty(controllerContext, bindingContext, propertyDescriptor);
			if (serviceProvidersSearchVm != null)
			{
				BindListingsSearchModel(serviceProvidersSearchVm, controllerContext, propertyDescriptor);
			}
		}

		private void BindListingsSearchModel(ServiceProvidersSearchVm model, ControllerContext controllerContext, PropertyDescriptor propertyDescriptor)
		{
			if (string.Equals(propertyDescriptor.Name, "ServiceCategories"))
			{
				string text = controllerContext.HttpContext.Request["service-categories"] ?? controllerContext.HttpContext.Request["ServiceCategories"];
				model.ServiceCategories = new List<int>();
				if (!string.IsNullOrWhiteSpace(text))
				{
					model.ServiceCategories = (from pair in text.Split('-', ',').Select(delegate (string str)
					{
						int result;
						bool success = int.TryParse(str, out result);
						return new
						{
							value = result,
							success = success
						};
					})
											   where pair.success
											   select pair.value).Distinct().ToList();
					return;
				}
			}
			if (string.Equals(propertyDescriptor.Name, "SortType"))
			{
				string sortType = controllerContext.HttpContext.Request["sort-by"] ?? controllerContext.HttpContext.Request["SortType"];
				model.SortType = sortType.FromServiceProviderSortTypeUrlStr();
			}
		}
	}
}