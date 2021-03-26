using MSLivingChoices.Localization;
using MSLivingChoices.Mvc.Uipc.Client.ViewModels;
using MSLivingChoices.Utilities;
using System;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Mvc.Uipc.Client.Helpers
{
	public static class LeadFormMessageHelper
	{
		private const string ServiceProviderName = "{SERVICE_PROVIDER_NAME}";

		private const string CommunityName = "{COMMUNITY_NAME}";

		private const string CommunityUnitName = "{COMMUNITY_UNIT_NAME}";

		public static string GetLeadFormMessage(this CommunityShortVm community)
		{
			return LeadFormMessages.Community.Replace("{COMMUNITY_NAME}", !community.Name.IsNullOrWhitespace(), community.Name);
		}

		public static string GetLeadFormMessage(this ServiceProviderShortVm serviceProvider)
		{
			return LeadFormMessages.ServiceProvider.Replace("{SERVICE_PROVIDER_NAME}", !serviceProvider.Name.IsNullOrWhitespace(), serviceProvider.Name);
		}

		public static string GetLeadFormMessage(this CommunitiesSearchVm searchVm)
		{
			return LeadFormMessages.Community.Replace("{COMMUNITY_NAME}", string.Empty);
		}

		public static string GetLeadFormMessage(this ServiceProvidersSearchVm searchVm)
		{
			return LeadFormMessages.ServiceProvider.Replace("{SERVICE_PROVIDER_NAME}", string.Empty);
		}

		public static string GetLeadFormMessage(this FloorPlanQuickViewVm floorPlan)
		{
			return LeadFormMessages.FloorPlan.Replace("{COMMUNITY_UNIT_NAME}", !floorPlan.Name.IsNullOrWhitespace(), floorPlan.Name);
		}

		public static string GetLeadFormMessage(this SpecHomeQuickViewVm specHome)
		{
			return LeadFormMessages.SpecHome.Replace("{COMMUNITY_UNIT_NAME}", !specHome.Name.IsNullOrWhitespace(), specHome.Name);
		}

		public static string GetLeadFormMessage(this HomeQuickViewVm home)
		{
			return LeadFormMessages.FloorPlan.Replace("{COMMUNITY_UNIT_NAME}", !home.Name.IsNullOrWhitespace(), home.Name);
		}

		private static string Replace(this string input, string placehold, bool flag, string value)
		{
			value = (flag ? string.Format(" {0}", value) : string.Empty);
			return input.Replace(placehold, value);
		}
	}
}