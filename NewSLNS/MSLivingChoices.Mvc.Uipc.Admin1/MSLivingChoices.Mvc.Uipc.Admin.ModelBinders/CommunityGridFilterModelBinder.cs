using MSLivingChoices.Bcs.Admin.Components;
using MSLivingChoices.Entities.Admin;
using MSLivingChoices.Entities.Admin.Enums;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MSLivingChoices.Mvc.Uipc.Admin.ModelBinders
{
	public class CommunityGridFilterModelBinder : IModelBinder
	{
		public CommunityGridFilterModelBinder()
		{
		}

		public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
		{
			CommunityGridFilter filter = new CommunityGridFilter()
			{
				Community = UtilsForBinding.GetStringValue(bindingContext.get_ValueProvider(), "community"),
				AAC = UtilsForBinding.GetBooleanValue(bindingContext.get_ValueProvider(), "aac"),
				AAH = UtilsForBinding.GetBooleanValue(bindingContext.get_ValueProvider(), "aah"),
				SHC = UtilsForBinding.GetBooleanValue(bindingContext.get_ValueProvider(), "shc"),
				Showcase = UtilsForBinding.GetBooleanValue(bindingContext.get_ValueProvider(), "showcase"),
				Publish = UtilsForBinding.GetBooleanValue(bindingContext.get_ValueProvider(), "publish"),
				ShowcaseStart = UtilsForBinding.GetStringValue(bindingContext.get_ValueProvider(), "showcaseStart"),
				ShowcaseEnd = UtilsForBinding.GetStringValue(bindingContext.get_ValueProvider(), "showcaseEnd"),
				PublishStart = UtilsForBinding.GetStringValue(bindingContext.get_ValueProvider(), "publishStart"),
				PublishEnd = UtilsForBinding.GetStringValue(bindingContext.get_ValueProvider(), "publishEnd")
			};
			string packages = UtilsForBinding.GetStringValue(bindingContext.get_ValueProvider(), "packages");
			List<long> checkedPackages = (packages != null ? (new List<string>(packages.Split(new char[] { ',' }))).ConvertAll<long>(new Converter<string, long>(long.Parse)) : new List<long>());
			filter.Packages = new List<KeyValuePair<int, string>>();
			foreach (KeyValuePair<int, string> package in ItemTypeBc.Instance.GetAdditionalInfo(AdditionalInfoClass.Package))
			{
				if (!checkedPackages.Contains((long)package.Key))
				{
					continue;
				}
				filter.Packages.Add(package);
			}
			string categories = UtilsForBinding.GetStringValue(bindingContext.get_ValueProvider(), "shcCategories");
			List<long> checkedCategories = (categories != null ? (new List<string>(categories.Split(new char[] { ',' }))).ConvertAll<long>(new Converter<string, long>(long.Parse)) : new List<long>());
			filter.Categories = new List<KeyValuePair<int, string>>();
			foreach (KeyValuePair<int, string> category in ItemTypeBc.Instance.GetSHCCategoriesForCommunity())
			{
				if (!checkedCategories.Contains((long)category.Key))
				{
					continue;
				}
				filter.Categories.Add(category);
			}
			return filter;
		}
	}
}