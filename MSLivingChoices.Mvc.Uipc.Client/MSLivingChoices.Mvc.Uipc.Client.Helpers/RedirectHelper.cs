using MSLivingChoices.Configuration;
using MSLivingChoices.Entities.Client.Enums;
using MSLivingChoices.Mvc.Uipc.Client.ViewModels;
using MSLivingChoices.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Web;

namespace MSLivingChoices.Mvc.Uipc.Client.Helpers
{

	public static class RedirectHelper
	{
		private static readonly Regex IgnoreSearchType = new Regex(ConfigurationManager.Instance.IgnoreSearchTypePattern, RegexOptions.IgnoreCase);

		private static string CurrentUrl => HttpContext.Current.Request.Url.AbsoluteUri;

		public static bool ShouldRedirect(this SearchVm vm)
		{
			if (vm.Seo != null)
			{
				return ShouldRedirect(vm.Seo.CanonicalUrl);
			}
			return false;
		}

		public static bool ShouldRedirect(this SearchVm vm, List<ListingType> listingTypes)
		{
			if (vm.Seo != null)
			{
				return ShouldRedirect(vm.Seo.CanonicalUrl, listingTypes);
			}
			return false;
		}

		private static bool ShouldRedirect(string canonicalUrl)
		{
			return !canonicalUrl.IsEqualUrlWithoutQuery(CurrentUrl);
		}

		private static bool ShouldRedirect(string canonicalUrl, List<ListingType> listingTypes)
		{
			Match match = IgnoreSearchType.Match(CurrentUrl);
			Match match2 = IgnoreSearchType.Match(canonicalUrl);
			string searchTypePrefix = match.Groups["searchType"].Value;
			string value = match.Groups["path"].Value;
			string value2 = match2.Groups["path"].Value;
			if (string.Equals(value, value2))
			{
				return listingTypes.All((ListingType t) => t.ToSearchType().UrlPrefix() != searchTypePrefix);
			}
			return true;
		}
	}

}