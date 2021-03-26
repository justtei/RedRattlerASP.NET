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
	public class CommunitiesSearchVmModelBinder : SearchVmBinder
	{
		protected override void BindProperty(ControllerContext controllerContext, ModelBindingContext bindingContext, PropertyDescriptor propertyDescriptor)
		{
			CommunitiesSearchVm communitiesSearchVm = bindingContext.Model as CommunitiesSearchVm;
			base.BindProperty(controllerContext, bindingContext, propertyDescriptor);
			if (communitiesSearchVm != null)
			{
				BindListingsSearchModel(communitiesSearchVm, controllerContext, propertyDescriptor);
			}
		}

		private void BindListingsSearchModel(CommunitiesSearchVm model, ControllerContext controllerContext, PropertyDescriptor propertyDescriptor)
		{
			if (string.Equals(propertyDescriptor.Name, "Amenities"))
			{
				string text = controllerContext.HttpContext.Request["amenities"] ?? controllerContext.HttpContext.Request["Amenities"];
				model.Amenities = new List<int>();
				if (!string.IsNullOrWhiteSpace(text))
				{
					model.Amenities = (from pair in text.Split('-', ',').Select(delegate (string str)
					{
						int result6;
						bool success2 = int.TryParse(str, out result6);
						return new
						{
							value = result6,
							success = success2
						};
					})
									   where pair.success
									   select pair.value).Distinct().ToList();
					return;
				}
			}
			if (string.Equals(propertyDescriptor.Name, "ShcCategories"))
			{
				string text2 = controllerContext.HttpContext.Request["shc-categories"] ?? controllerContext.HttpContext.Request["ShcCategories"];
				model.ShcCategories = new List<int>();
				if (!string.IsNullOrWhiteSpace(text2))
				{
					model.ShcCategories = (from pair in text2.Split('-', ',').Select(delegate (string str)
					{
						int result5;
						bool success = int.TryParse(str, out result5);
						return new
						{
							value = result5,
							success = success
						};
					})
										   where pair.success
										   select pair.value).Distinct().ToList();
					return;
				}
			}
			int result2;
			int result3;
			int result4;
			if (string.Equals(propertyDescriptor.Name, "MinPrice") && int.TryParse(controllerContext.HttpContext.Request["min-price"] ?? controllerContext.HttpContext.Request["MinPrice"], out var result))
			{
				model.MinPrice = result;
			}
			else if (string.Equals(propertyDescriptor.Name, "MaxPrice") && int.TryParse(controllerContext.HttpContext.Request["max-price"] ?? controllerContext.HttpContext.Request["MaxPrice"], out result2))
			{
				model.MaxPrice = result2;
			}
			else if (string.Equals(propertyDescriptor.Name, "Beds") && int.TryParse(controllerContext.HttpContext.Request["beds"] ?? controllerContext.HttpContext.Request["Beds"], out result3))
			{
				model.Beds = result3;
			}
			else if (string.Equals(propertyDescriptor.Name, "Bathes") && int.TryParse(controllerContext.HttpContext.Request["bathes"] ?? controllerContext.HttpContext.Request["Bathes"], out result4))
			{
				model.Bathes = result4;
			}
			else if (string.Equals(propertyDescriptor.Name, "SortType"))
			{
				string sortType = controllerContext.HttpContext.Request["sort-by"] ?? controllerContext.HttpContext.Request["SortType"];
				model.SortType = sortType.FromCommunitySortTypeUrlStr();
			}
		}
	}
}