using MSLivingChoices.Bcs.Client.Components;
using MSLivingChoices.Configuration;
using MSLivingChoices.Configuration.ConfigurationSections.UrlRedirects;
using MSLivingChoices.Entities.Client;
using MSLivingChoices.Entities.Client.Search.Criteria;
using MSLivingChoices.Logging;
using MSLivingChoices.Logging.Messages;
using MSLivingChoices.Mvc.Uipc.Client.Helpers;
using MSLivingChoices.Mvc.Uipc.Client.ViewModels;
using MSLivingChoices.Mvc.Uipc.Enums;
using MSLivingChoices.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MSLivingChoices.Mvc.Uipc.Client.HttpModules
{
	public class UrlModule : IHttpModule
	{
		private delegate UrlProcessingResult UrlProcessingAction(string url, out string newUrl);

		private static readonly ConfigurationManager Config = ConfigurationManager.Instance;

		private readonly UrlProcessingAction[] _urlHandlers;

		private static readonly Regex WhiteList = new Regex(Config.WhiteListPattern, RegexOptions.IgnoreCase);

		private static readonly Regex OldDetails = new Regex(Config.OldDetailsPattern, RegexOptions.IgnoreCase);

		private static readonly Regex OldSearch = new Regex(Config.OldSearchPattern, RegexOptions.IgnoreCase);

		private static readonly Regex Technical = new Regex(Config.TechnicalPattern, RegexOptions.IgnoreCase);

		private static readonly Regex TrailingSlash = new Regex(Config.TrailingSlashPattern, RegexOptions.IgnoreCase);

		private static readonly Regex UpperCase = new Regex(Config.UpperCasePattern);

		private static readonly Regex Spaces = new Regex(Config.SpacesPattern);

		private static readonly Regex Canonical = new Regex(Config.CanonicalPattern, RegexOptions.IgnoreCase);

		private static readonly Regex SpaceFind = new Regex(Config.SpaceFindPatter);

		private static readonly string SpaceReplace = Config.SpacesReplace;

		private static readonly Regex DomainFind = new Regex(Config.DomainFindPatter, RegexOptions.IgnoreCase);

		private static readonly string DomainReplace = Config.DomainReplace;

		public UrlModule()
		{
			_urlHandlers = new UrlProcessingAction[5]
			{
			CheckForWhiteList,
			CheckForTechnicalUrl,
			CheckForOldUrl,
			CheckForSimpleRedirect,
			CheckUrlFormating
			};
		}

		public void Init(HttpApplication application)
		{
			application.BeginRequest += ProcessUrl;
		}

		public void Dispose()
		{
		}

		private void ProcessUrl(object sender, EventArgs e)
		{
			try
			{
				HttpContext context = ((HttpApplication)sender).Context;
				string absoluteUri = context.Request.Url.AbsoluteUri;
				UrlProcessingAction[] urlHandlers = _urlHandlers;
				for (int i = 0; i < urlHandlers.Length; i++)
				{
					string newUrl;
					switch (urlHandlers[i](absoluteUri, out newUrl))
					{
						case UrlProcessingResult.Stop:
							return;
						case UrlProcessingResult.RedirectPermanent:
							RedirectPermanent(context, newUrl);
							return;
						case UrlProcessingResult.NotFound:
							NotFound(context);
							return;
						case UrlProcessingResult.Redirect:
							Redirect(context, newUrl);
							return;
						case UrlProcessingResult.RedirectPermanentIfExist:
							if (IsUnknownUrl(context))
							{
								NotFound(context);
							}
							else
							{
								RedirectPermanent(context, newUrl);
							}
							return;
					}
				}
			}
			catch (Exception exception)
			{
				Logger.ErrorFormat(LogMessages.MvcUipcClient.Custom.UrlProcessingError, exception);
			}
		}

		private static UrlProcessingResult CheckForWhiteList(string url, out string newUrl)
		{
			newUrl = null;
			if (!WhiteList.IsMatch(url))
			{
				return UrlProcessingResult.Continue;
			}
			return UrlProcessingResult.Stop;
		}

		private static UrlProcessingResult CheckUrlFormating(string url, out string newUrl)
		{
			newUrl = url;
			Match match = TrailingSlash.Match(newUrl);
			if (match.Success)
			{
				newUrl = match.Groups["url"].Value;
			}
			Match match2 = UpperCase.Match(newUrl);
			if (match2.Success)
			{
				newUrl = newUrl.ToLower();
			}
			Match match3 = Spaces.Match(newUrl);
			if (match3.Success)
			{
				newUrl = SpaceFind.Replace(newUrl, SpaceReplace);
			}
			Match match4 = Canonical.Match(newUrl);
			if (match4.Success)
			{
				newUrl = DomainFind.Replace(newUrl, DomainReplace);
			}
			if (!match.Success && !match2.Success && !match3.Success && !match4.Success)
			{
				return UrlProcessingResult.Continue;
			}
			return UrlProcessingResult.RedirectPermanentIfExist;
		}

		private static UrlProcessingResult CheckForOldUrl(string url, out string newUrl)
		{
			newUrl = null;
			Match match = OldDetails.Match(url);
			if (match.Success)
			{
				if (TryParseToPropertyType(match.Groups["searchType"].Value, out var type))
				{
					if (type == SearchType.ProductsAndServices)
					{
						ServiceProviderShortVm serviceProviderShortVm = new ServiceProviderShortVm();
						serviceProviderShortVm.Id = Convert.ToInt64(match.Groups["listingId"].Value);
						serviceProviderShortVm.Name = match.Groups["listingName"].Value;
						serviceProviderShortVm.Address = new AddressVm();
						serviceProviderShortVm.Address.StateCode = match.Groups["stateCode"].Value;
						serviceProviderShortVm.Address.City = match.Groups["city"].Value;
						newUrl = MslcUrlBuilder.DetailsUrl(serviceProviderShortVm);
					}
					else
					{
						CommunityShortVm communityShortVm = new CommunityShortVm();
						communityShortVm.Id = Convert.ToInt64(match.Groups["listingId"].Value);
						communityShortVm.Name = match.Groups["listingName"].Value;
						communityShortVm.Address = new AddressVm();
						communityShortVm.Address.StateCode = match.Groups["stateCode"].Value;
						communityShortVm.Address.City = match.Groups["city"].Value;
						newUrl = MslcUrlBuilder.DetailsUrl(communityShortVm, type);
					}
					if (!newUrl.IsNullOrEmpty())
					{
						return UrlProcessingResult.RedirectPermanent;
					}
					return UrlProcessingResult.NotFound;
				}
				return UrlProcessingResult.NotFound;
			}
			Match match2 = OldSearch.Match(url);
			if (match2.Success)
			{
				if (TryParseToPropertyType(match2.Groups["searchType"].Value, out var type2))
				{
					SearchCriteria criteria = new SearchCriteria();
					criteria.StateCode(match2.Groups["stateCode"].Value);
					criteria.City(match2.Groups["city"].Value);
					newUrl = MslcUrlBuilder.SearchUrl(criteria, type2);
					if (!newUrl.IsNullOrEmpty())
					{
						return UrlProcessingResult.RedirectPermanent;
					}
					return UrlProcessingResult.NotFound;
				}
				return UrlProcessingResult.NotFound;
			}
			return UrlProcessingResult.Continue;
		}

		private static UrlProcessingResult CheckForTechnicalUrl(string url, out string newUrl)
		{
			newUrl = null;
			Match match = Technical.Match(url);
			if (match.Success)
			{
				if (!long.TryParse(match.Groups["listingId"].Value, out var result))
				{
					return UrlProcessingResult.NotFound;
				}
				Group group = match.Groups["listingType"];
				if (group.Success)
				{
					bool flag = group.Value.SafeEquals("community", StringComparison.InvariantCultureIgnoreCase);
					newUrl = (flag ? GetCommunityDetailsUrl(result) : GetServiceDetailsUrl(result));
				}
				else
				{
					newUrl = GetCommunityDetailsUrl(result);
					if (newUrl.IsNullOrEmpty())
					{
						newUrl = GetServiceDetailsUrl(result);
					}
				}
				if (!newUrl.IsNullOrEmpty())
				{
					return UrlProcessingResult.RedirectPermanent;
				}
				return UrlProcessingResult.NotFound;
			}
			return UrlProcessingResult.Continue;
		}

		private static UrlProcessingResult CheckForSimpleRedirect(string url, out string newUrl)
		{
			newUrl = null;
			foreach (RedirectElement redirectRule in Config.RedirectRules)
			{
				if (url.IndexOf(redirectRule.From, StringComparison.OrdinalIgnoreCase) >= 0)
				{
					newUrl = ((CheckUrlFormating(url, out newUrl) != UrlProcessingResult.Continue) ? newUrl.Replace(redirectRule.From, redirectRule.To) : url.Replace(redirectRule.From, redirectRule.To));
					return UrlProcessingResult.RedirectPermanent;
				}
			}
			return UrlProcessingResult.Continue;
		}

		private static bool TryParseToPropertyType(string name, out SearchType type)
		{
			if (name.IsNullOrEmpty())
			{
				type = (SearchType)0;
				return false;
			}
			name = name.Replace("-", string.Empty).SafeToLower();
			return Enum.TryParse<SearchType>(name, ignoreCase: true, out type);
		}

		private static string GetCommunityDetailsUrl(long id)
		{
			string result = null;
			Community community = SearchBc.Instance.GetCommunity(id);
			if (community != null && community.ListingTypes.Any())
			{
				result = MslcUrlBuilder.DetailsUrl(community, community.ListingTypes.ToSearchType());
			}
			return result;
		}

		private static string GetServiceDetailsUrl(long id)
		{
			ServiceProvider serviceProvider = SearchBc.Instance.GetServiceProvider(id);
			if (serviceProvider == null)
			{
				return null;
			}
			return MslcUrlBuilder.DetailsUrl(serviceProvider);
		}

		private static bool IsUnknownUrl(HttpContext context)
		{
			RouteData routeData = RouteTable.Routes.GetRouteData(new HttpContextWrapper(context));
			if (routeData != null)
			{
				return "NotFound".SafeEquals(routeData.Values["action"].ToString());
			}
			return true;
		}

		private static void RedirectPermanent(HttpContext context, string url)
		{
			context.Response.RedirectPermanent(url, endResponse: false);
			context.ApplicationInstance.CompleteRequest();
		}

		private static void Redirect(HttpContext context, string url)
		{
			context.Response.Redirect(url, endResponse: false);
			context.ApplicationInstance.CompleteRequest();
		}

		private static void NotFound(HttpContext context)
		{
			ControllerBuilder.Current.GetControllerFactory().CreateController(context.Request.RequestContext, "Error").Execute(new RequestContext(routeData: new RouteData
			{
				Values =
			{
				{
					"controller",
					(object)"Client"
				},
				{
					"action",
					(object)"NotFound"
				}
			}
			}, httpContext: context.Request.RequestContext.HttpContext));
		}
	}

}