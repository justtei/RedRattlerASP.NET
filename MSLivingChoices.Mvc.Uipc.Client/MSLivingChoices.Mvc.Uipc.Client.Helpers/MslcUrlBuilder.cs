using MSLivingChoices.Configuration;
using MSLivingChoices.Entities.Client;
using MSLivingChoices.Entities.Client.Enums;
using MSLivingChoices.Entities.Client.Search.Criteria;
using MSLivingChoices.Mvc.Uipc.Client.Enums;
using MSLivingChoices.Mvc.Uipc.Client.Helpers.Core;
using MSLivingChoices.Mvc.Uipc.Client.ViewModels;
using MSLivingChoices.Mvc.Uipc.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MSLivingChoices.Mvc.Uipc.Client.Helpers
{
	public static class MslcUrlBuilder
	{
		public static string BaseUrl
		{
			get
			{
				if (HttpContext.Current != null)
				{
					Uri url = HttpContext.Current.Request.Url;
					string text = (url.IsDefaultPort ? string.Empty : $":{url.Port}");
					return $"{ConfigurationManager.Instance.UrlScheme}{Uri.SchemeDelimiter}{url.Host}{text}";
				}
				return ConfigurationManager.Instance.SiteUrl;
			}
		}

		public static string AbsoluteUrl(string url)
		{
			return BaseUrl + url;
		}

		public static string SearchUrl(ISearchCriteria criteria, SearchType searchtype)
		{
			return searchtype.FluentUrl().State(criteria.StateCode()).Zip(criteria.Zip())
				.City(criteria.City())
				.Url();
		}

		public static string DetailsUrl(ICommunity community, SearchType searchtype)
		{
			return searchtype.FluentUrl().State(community.Address.StateCode).City(community.Address.City)
				.Name(community.Name)
				.DetailsId(community.Id)
				.Url();
		}

		public static string DetailsUrl(IProvider serviceProvider)
		{
			return PageType.ServiceProviderDetails.FluentUrl().State(serviceProvider.Address.StateCode).City(serviceProvider.Address.City)
				.Name(serviceProvider.Name)
				.DetailsId(serviceProvider.Id)
				.Url();
		}

		public static string PagingUrl(SearchVm model, int pageNumber)
		{
			return model.PageType.FluentUrl().State(model.Criteria.StateCode()).Zip(model.Criteria.Zip())
				.City(model.Criteria.City())
				.WithPaging(pageNumber)
				.Url();
		}

		public static string PagingUrl(CommunitiesSearchVm model, int pageNumber)
		{
			return model.PageType.FluentUrl().State(model.Criteria.StateCode()).Zip(model.Criteria.Zip())
				.City(model.Criteria.City())
				.Refined(RefinedParameters(model))
				.WithPaging(pageNumber)
				.Url();
		}

		public static string PagingUrl(ServiceProvidersSearchVm model, int pageNumber)
		{
			return model.PageType.FluentUrl().State(model.Criteria.StateCode()).Zip(model.Criteria.Zip())
				.City(model.Criteria.City())
				.Refined(RefinedParameters(model))
				.WithPaging(pageNumber)
				.Url();
		}

		public static string PrintUrl(ICommunity community, SearchType searchType)
		{
			return searchType.FluentUrl().State(community.Address.StateCode).City(community.Address.City)
				.Name(community.Name)
				.DetailsId(community.Id)
				.Print()
				.Url();
		}

		public static string PrintUrl(IProvider serviceProvider)
		{
			return SearchType.ProductsAndServices.FluentUrl().State(serviceProvider.Address.StateCode).City(serviceProvider.Address.City)
				.Name(serviceProvider.Name)
				.DetailsId(serviceProvider.Id)
				.Print()
				.Url();
		}

		public static string PrintCouponUrl(ICommunity community, SearchType searchType)
		{
			return searchType.FluentUrl().State(community.Address.StateCode).City(community.Address.City)
				.Name(community.Name)
				.DetailsId(community.Id)
				.PrintCoupon()
				.Url();
		}

		public static string PrintCouponUrl(IProvider serviceProvider)
		{
			return SearchType.ProductsAndServices.FluentUrl().State(serviceProvider.Address.StateCode).City(serviceProvider.Address.City)
				.Name(serviceProvider.Name)
				.DetailsId(serviceProvider.Id)
				.PrintCoupon()
				.Url();
		}

		public static string PrintDirectionBaseUrl(Community community, SearchType searchType)
		{
			return searchType.FluentUrl().State(community.Address.StateCode).City(community.Address.City)
				.Name(community.Name)
				.DetailsId(community.Id)
				.PrintDirection()
				.Url();
		}

		public static string PrintDirectionBaseUrl(ServiceProvider serviceProvider)
		{
			return SearchType.ProductsAndServices.FluentUrl().State(serviceProvider.Address.StateCode).City(serviceProvider.Address.City)
				.Name(serviceProvider.Name)
				.DetailsId(serviceProvider.Id)
				.PrintDirection()
				.Url();
		}

		public static string StaticPageUrl(PageType page)
		{
			UrlHelper urlHelper = new UrlHelper(HttpContext.Current.Request.RequestContext);
			string text = (((uint)(page - 22) > 1u) ? string.Empty : urlHelper.RouteUrl(page.ToString()));
			if (!text.StartsWith("/api"))
			{
				return AbsoluteUrl(text);
			}
			return null;
		}

		private static string ActionUrl(string action, string controller)
		{
			return new UrlHelper(HttpContext.Current.Request.RequestContext).Action(action, controller);
		}

		private static IEnumerable<KeyValuePair<string, object>> RefinedParameters(ServiceProvidersSearchVm model)
		{
			RouteValueDictionary routeValueDictionary = new RouteValueDictionary();
			if (model.ServiceCategories != null && model.ServiceCategories.Any())
			{
				routeValueDictionary.Add("service-categories", string.Join("-", model.ServiceCategories));
			}
			if (model.SortType != ServiceProviderSortType.Featured && model.SortType != 0)
			{
				routeValueDictionary.Add("sort-by", model.SortType.ToSortTypeUrlStr());
			}
			return routeValueDictionary;
		}

		private static IEnumerable<KeyValuePair<string, object>> RefinedParameters(CommunitiesSearchVm model)
		{
			RouteValueDictionary routeValueDictionary = new RouteValueDictionary();
			if (model.Beds.HasValue)
			{
				routeValueDictionary.Add("beds", model.Beds);
			}
			if (model.Bathes.HasValue)
			{
				routeValueDictionary.Add("bathes", model.Bathes);
			}
			if (model.MinPrice.HasValue)
			{
				routeValueDictionary.Add("min-price", model.MinPrice);
			}
			if (model.MaxPrice.HasValue)
			{
				routeValueDictionary.Add("max-price", model.MaxPrice);
			}
			if (model.Amenities != null && model.Amenities.Any())
			{
				routeValueDictionary.Add("amenities", string.Join("-", model.Amenities));
			}
			if (model.ShcCategories != null && model.ShcCategories.Any())
			{
				routeValueDictionary.Add("shc-categories", string.Join("-", model.ShcCategories));
			}
			if (model.SortType != CommunitySortType.Featured && model.SortType != 0)
			{
				routeValueDictionary.Add("sort-by", model.SortType.ToSortTypeUrlStr());
			}
			return routeValueDictionary;
		}
	}
}