using MSLivingChoices.Bcs.Client.Components;
using MSLivingChoices.Entities.Client.Enums;
using MSLivingChoices.Entities.Client.Search.Criteria;
using MSLivingChoices.Localization.Seo;
using MSLivingChoices.Mvc.Uipc.Client.Enums;
using MSLivingChoices.Mvc.Uipc.Client.ViewModels;
using MSLivingChoices.Utilities;
using System;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace MSLivingChoices.Mvc.Uipc.Client.Helpers
{
	public static class SeoHelper
	{
		private const string ServiceName = "{SERVICE_NAME}";

		private const string CommunityName = "{COMMUNITY_NAME}";

		private const string CommunityDescription = "{COMMUNITY_DESCRIPTION}";

		private const string State = "{STATE}";

		private const string StateCode = "{STATE_CODE}";

		private const string City = "{CITY}";

		private const string CityStateCode = "{CITY_STATE_CODE}";

		private const string PageNumber = "{PAGE_NUMBER}";

		private readonly static Regex WithPage;

		private readonly static Regex WithoutPage;

		static SeoHelper()
		{
			SeoHelper.WithPage = new Regex("(?<pattern>\\[IFPAGE:(?<replace>[^\\]]*)\\])", RegexOptions.Singleline);
			SeoHelper.WithoutPage = new Regex("(?<pattern>\\[IFNOTPAGE:(?<replace>[^\\]]*)\\])", RegexOptions.Singleline);
		}

		private static string FormPageLink<TResult, TSort>(ResultSetSearchVm<TResult, TSort> searchResultVm, PageDirection direction)
		{
			string empty = string.Empty;
			if (searchResultVm.PageSize == 0 || searchResultVm.PageNumber == 0)
			{
				return empty;
			}
			if (direction == PageDirection.Next)
			{
				if ((float)searchResultVm.PageNumber < (float)searchResultVm.TotalCount / (float)searchResultVm.PageSize)
				{
					empty = MslcUrlBuilder.PagingUrl(searchResultVm, searchResultVm.PageNumber + 1);
				}
			}
			else if (searchResultVm.PageNumber > 1)
			{
				empty = MslcUrlBuilder.PagingUrl(searchResultVm, searchResultVm.PageNumber - 1);
			}
			return empty;
		}

		public static SeoVm GetSeo(CommunityDetailsVm communityDetails)
		{
			return new SeoVm()
			{
				PageType = communityDetails.PageType,
				Description = Description.CommunityDetails.Replace(communityDetails),
				Title = Title.CommunityDetails.Replace(communityDetails),
				Header = Header.CommunityDetails.Replace(communityDetails),
				CanonicalUrl = MslcUrlBuilder.DetailsUrl(communityDetails.Community, communityDetails.Community.ListingTypes.ToSearchType())
			};
		}

		public static SeoVm GetSeo(ServiceProviderDetailsVm serviceProviderDetails)
		{
			return new SeoVm()
			{
				PageType = serviceProviderDetails.PageType,
				Title = Title.ServiceDetails.Replace(serviceProviderDetails),
				Description = Description.ServiceDetails.Replace(serviceProviderDetails),
				Header = Header.ServiceDetails.Replace(serviceProviderDetails),
				CanonicalUrl = MslcUrlBuilder.DetailsUrl(serviceProviderDetails.ServiceProvider)
			};
		}

		public static SeoVm GetSeo(CommunitiesSearchVm result)
		{
			SeoVm seoVm = new SeoVm()
			{
				PageType = result.PageType,
				CanonicalUrl = MslcUrlBuilder.PagingUrl((SearchVm)result, result.PageNumber),
				LinkPrev = SeoHelper.FormPageLink<CommunityBlockVm, CommunitySortType>(result, PageDirection.Previous),
				LinkNext = SeoHelper.FormPageLink<CommunityBlockVm, CommunitySortType>(result, PageDirection.Next),
				MarketCopy = SeoBc.Instance.GetCommunityMarketCopy(result.Criteria.ToSearchCriteria(), result.Criteria.SearchType().ToListingType())
			};
			switch (seoVm.PageType)
			{
				case PageType.ShcByState:
				{
					seoVm.Title = Title.SearchSHCByState;
					seoVm.Description = Description.SearchSHCByState;
					seoVm.Header = Header.SearchSHCByState;
					seoVm.Title = seoVm.Title.Replace<CommunityBlockVm, CommunitySortType>(result);
					seoVm.Description = seoVm.Description.Replace<CommunityBlockVm, CommunitySortType>(result);
					seoVm.Header = seoVm.Header.Replace<CommunityBlockVm, CommunitySortType>(result);
					seoVm.MarketCopy = seoVm.MarketCopy.Replace<CommunityBlockVm, CommunitySortType>(result);
					return seoVm;
				}
				case PageType.ShcByCity:
				{
					seoVm.Title = Title.SearchSHCByCity;
					seoVm.Description = Description.SearchSHCByCity;
					seoVm.Header = Header.SearchSHCByCity;
					seoVm.Title = seoVm.Title.Replace<CommunityBlockVm, CommunitySortType>(result);
					seoVm.Description = seoVm.Description.Replace<CommunityBlockVm, CommunitySortType>(result);
					seoVm.Header = seoVm.Header.Replace<CommunityBlockVm, CommunitySortType>(result);
					seoVm.MarketCopy = seoVm.MarketCopy.Replace<CommunityBlockVm, CommunitySortType>(result);
					return seoVm;
				}
				case PageType.ShcByZip:
				case PageType.AacByType:
				case PageType.AacByZip:
				case PageType.AahByType:
				{
					seoVm.Title = seoVm.Title.Replace<CommunityBlockVm, CommunitySortType>(result);
					seoVm.Description = seoVm.Description.Replace<CommunityBlockVm, CommunitySortType>(result);
					seoVm.Header = seoVm.Header.Replace<CommunityBlockVm, CommunitySortType>(result);
					seoVm.MarketCopy = seoVm.MarketCopy.Replace<CommunityBlockVm, CommunitySortType>(result);
					return seoVm;
				}
				case PageType.AacByState:
				{
					seoVm.Title = Title.SearchAACByState;
					seoVm.Description = Description.SearchAACByState;
					seoVm.Header = Header.SearchAACByState;
					seoVm.Title = seoVm.Title.Replace<CommunityBlockVm, CommunitySortType>(result);
					seoVm.Description = seoVm.Description.Replace<CommunityBlockVm, CommunitySortType>(result);
					seoVm.Header = seoVm.Header.Replace<CommunityBlockVm, CommunitySortType>(result);
					seoVm.MarketCopy = seoVm.MarketCopy.Replace<CommunityBlockVm, CommunitySortType>(result);
					return seoVm;
				}
				case PageType.AacByCity:
				{
					seoVm.Title = Title.SearchAACByCity;
					seoVm.Description = Description.SearchAACByCity;
					seoVm.Header = Header.SearchAACByCity;
					seoVm.Title = seoVm.Title.Replace<CommunityBlockVm, CommunitySortType>(result);
					seoVm.Description = seoVm.Description.Replace<CommunityBlockVm, CommunitySortType>(result);
					seoVm.Header = seoVm.Header.Replace<CommunityBlockVm, CommunitySortType>(result);
					seoVm.MarketCopy = seoVm.MarketCopy.Replace<CommunityBlockVm, CommunitySortType>(result);
					return seoVm;
				}
				case PageType.AahByState:
				{
					seoVm.Title = Title.SearchAAHByState;
					seoVm.Description = Description.SearchAAHByState;
					seoVm.Header = Header.SearchAAHByState;
					seoVm.Title = seoVm.Title.Replace<CommunityBlockVm, CommunitySortType>(result);
					seoVm.Description = seoVm.Description.Replace<CommunityBlockVm, CommunitySortType>(result);
					seoVm.Header = seoVm.Header.Replace<CommunityBlockVm, CommunitySortType>(result);
					seoVm.MarketCopy = seoVm.MarketCopy.Replace<CommunityBlockVm, CommunitySortType>(result);
					return seoVm;
				}
				case PageType.AahByCity:
				{
					seoVm.Title = Title.SearchAAHByCity;
					seoVm.Description = Description.SearchAAHByCity;
					seoVm.Header = Header.SearchAAHByCity;
					seoVm.Title = seoVm.Title.Replace<CommunityBlockVm, CommunitySortType>(result);
					seoVm.Description = seoVm.Description.Replace<CommunityBlockVm, CommunitySortType>(result);
					seoVm.Header = seoVm.Header.Replace<CommunityBlockVm, CommunitySortType>(result);
					seoVm.MarketCopy = seoVm.MarketCopy.Replace<CommunityBlockVm, CommunitySortType>(result);
					return seoVm;
				}
				default:
				{
					seoVm.Title = seoVm.Title.Replace<CommunityBlockVm, CommunitySortType>(result);
					seoVm.Description = seoVm.Description.Replace<CommunityBlockVm, CommunitySortType>(result);
					seoVm.Header = seoVm.Header.Replace<CommunityBlockVm, CommunitySortType>(result);
					seoVm.MarketCopy = seoVm.MarketCopy.Replace<CommunityBlockVm, CommunitySortType>(result);
					return seoVm;
				}
			}
		}

		public static SeoVm GetSeo(ServiceProvidersSearchVm result)
		{
			SeoVm seoVm = new SeoVm()
			{
				PageType = result.PageType,
				CanonicalUrl = MslcUrlBuilder.PagingUrl(result, result.PageNumber),
				LinkPrev = SeoHelper.FormPageLink<ServiceProviderBlockVm, ServiceProviderSortType>(result, PageDirection.Previous),
				LinkNext = SeoHelper.FormPageLink<ServiceProviderBlockVm, ServiceProviderSortType>(result, PageDirection.Next),
				MarketCopy = SeoBc.Instance.GetServiceProvidersMarketCopy(result.Criteria.ToSearchCriteria())
			};
			PageType pageType = seoVm.PageType;
			if (pageType == PageType.ServiceProvidersByState)
			{
				seoVm.Title = Title.SearchServicesByState;
				seoVm.Description = Description.SearchServicesByState;
				seoVm.Header = Header.SearchServicesByState;
			}
			else if (pageType == PageType.ServiceProvidersByCity)
			{
				seoVm.Title = Title.SearchServicesByCity;
				seoVm.Description = Description.SearchServicesByCity;
				seoVm.Header = Header.SearchServicesByCity;
			}
			seoVm.Title = seoVm.Title.Replace<ServiceProviderBlockVm, ServiceProviderSortType>(result);
			seoVm.Description = seoVm.Description.Replace<ServiceProviderBlockVm, ServiceProviderSortType>(result);
			seoVm.Header = seoVm.Header.Replace<ServiceProviderBlockVm, ServiceProviderSortType>(result);
			seoVm.MarketCopy = seoVm.MarketCopy.Replace<ServiceProviderBlockVm, ServiceProviderSortType>(result);
			return seoVm;
		}

		public static SeoVm GetSeo(SearchVm result)
		{
			SeoVm seoVm = new SeoVm()
			{
				PageType = result.PageType,
				CanonicalUrl = MslcUrlBuilder.SearchUrl(result.Criteria, result.PageType.ToSearchType())
			};
			PageType pageType = seoVm.PageType;
			if (pageType <= PageType.ShcByType)
			{
				if (pageType == PageType.Index)
				{
					seoVm.Title = Title.Index;
					seoVm.Header = Header.Index;
					seoVm.Description = Description.Index;
					seoVm.CanonicalUrl = MslcUrlBuilder.BaseUrl;
				}
				else if (pageType == PageType.ShcByType)
				{
					seoVm.Title = Title.SearchSHC;
					seoVm.Description = Description.SearchSHC;
					seoVm.Header = Header.SearchSHC;
					seoVm.MarketCopy = MarketCopy.SearchSHC;
				}
			}
			else if (pageType == PageType.AacByType)
			{
				seoVm.Title = Title.SearchAAC;
				seoVm.Description = Description.SearchAAC;
				seoVm.Header = Header.SearchAAC;
				seoVm.MarketCopy = MarketCopy.SearchAAC;
			}
			else if (pageType == PageType.AahByType)
			{
				seoVm.Title = Title.SearchAAH;
				seoVm.Description = Description.SearchAAH;
				seoVm.Header = Header.SearchAAH;
				seoVm.MarketCopy = MarketCopy.SearchAAH;
			}
			else if (pageType == PageType.ServiceProvidersByType)
			{
				seoVm.Title = Title.SearchServices;
				seoVm.Description = Description.SearchServices;
				seoVm.Header = Header.SearchServices;
				seoVm.MarketCopy = MarketCopy.SearchServices;
			}
			seoVm.Title = seoVm.Title.Replace(result);
			seoVm.Description = seoVm.Description.Replace(result);
			seoVm.Header = seoVm.Header.Replace(result);
			return seoVm;
		}

		public static SeoVm GetSeo(PageType staticPage)
		{
			SeoVm seoVm = new SeoVm()
			{
				CanonicalUrl = MslcUrlBuilder.StaticPageUrl(staticPage)
			};
			switch (staticPage)
			{
				case PageType.PrivacyPolicy:
				{
					seoVm.Title = Title.PrivacyPolicy;
					seoVm.Header = Header.PrivacyPolicy;
					seoVm.Description = Description.PrivacyPolicy;
					break;
				}
				case PageType.TermsOfUse:
				{
					seoVm.Title = Title.TermsOfUse;
					seoVm.Header = Header.TermsOfUse;
					seoVm.Description = Description.TermsOfUse;
					break;
				}
				case PageType.Error404:
				{
					seoVm.Title = Title.Error404;
					seoVm.Header = Header.Error404;
					seoVm.MarketCopy = MarketCopy.Error404;
					break;
				}
				case PageType.Error500:
				{
					seoVm.Title = Title.Error500;
					seoVm.Header = Header.Error500;
					seoVm.MarketCopy = MarketCopy.Error500;
					break;
				}
				case PageType.Ebook:
				{
					seoVm.Title = "Book edit tool";
					seoVm.Header = "Book edit tool";
					seoVm.MarketCopy = string.Empty;
					break;
				}
			}
			return seoVm;
		}

		private static string Replace(this string input, ServiceProviderDetailsVm data)
		{
			return input.Replace("{SERVICE_NAME}", data.ServiceProvider.Name).Replace("{CITY_STATE_CODE}", string.Format("{0}, {1}", data.ServiceProvider.Address.City, data.ServiceProvider.Address.StateCode));
		}

		private static string Replace(this string input, CommunityDetailsVm data)
		{
			return input.ReplaceWithDescription("{COMMUNITY_DESCRIPTION}", data.Community.Description).Replace("{COMMUNITY_NAME}", data.Community.Name).Replace("{CITY_STATE_CODE}", string.Format("{0}, {1}", data.Community.Address.City, data.Community.Address.StateCode));
		}

		private static string Replace<TResult, TSort>(this string input, ResultSetSearchVm<TResult, TSort> data)
		{
			return input.ReplaceWithPageNumber<TResult, TSort>(data).ReplaceWithLocationData(data.Criteria);
		}

		private static string Replace(this string input, SearchVm data)
		{
			return input.ReplaceWithLocationData(data.Criteria);
		}

		private static string Replace(this string input, string placehold, bool flag, string provider, params object[] values)
		{
			return input.Replace(placehold, flag.ResolveReplace(provider, values));
		}

		private static string ReplaceWithDescription(this string input, string placeholder, string description)
		{
			if (input.IsNullOrEmpty())
			{
				return string.Empty;
			}
			if (description.Length > 150)
			{
				description = string.Format("{0}...", description.Substring(0, 147));
			}
			return input.Replace(placeholder, description);
		}

		private static string ReplaceWithLocationData(this string input, ISearchCriteria data)
		{
			if (input.IsNullOrEmpty())
			{
				return string.Empty;
			}
			return input.Replace("{STATE}", LocationBc.Instance.GetStateName(data.StateCode())).Replace("{STATE_CODE}", data.StateCode()).Replace("{CITY}", data.City());
		}

		private static string ReplaceWithPageNumber<TResult, TSort>(this string input, ResultSetSearchVm<TResult, TSort> data)
		{
			Regex regex;
			if (input.IsNullOrEmpty())
			{
				return string.Empty;
			}
			bool pageNumber = data.PageNumber > 1;
			regex = (pageNumber ? SeoHelper.WithPage : SeoHelper.WithoutPage);
			Regex regex1 = (pageNumber ? SeoHelper.WithoutPage : SeoHelper.WithPage);
			foreach (Match match in regex.Matches(input))
			{
				input = input.Replace(match.Groups["pattern"].Value, match.Groups["replace"].Value);
			}
			input = regex1.Replace(input, string.Empty);
			return input.Replace("{PAGE_NUMBER}", pageNumber, "Page {0} - ", new object[] { data.PageNumber });
		}

		private static string ResolveReplace(this bool flag, string provider, params object[] values)
		{
			if (!flag)
			{
				return string.Empty;
			}
			return string.Format(provider, values);
		}
	}
}