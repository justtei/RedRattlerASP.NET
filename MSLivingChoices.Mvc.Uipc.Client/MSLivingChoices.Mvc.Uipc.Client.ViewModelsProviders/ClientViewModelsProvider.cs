using MSLivingChoices.Bcs.Client.Components;
using MSLivingChoices.Configuration;
using MSLivingChoices.Configuration.Entities.SearchTemplates;
using MSLivingChoices.Entities.Client;
using MSLivingChoices.Entities.Client.Enums;
using MSLivingChoices.Entities.Client.Search;
using MSLivingChoices.Entities.Client.Search.Criteria;
using MSLivingChoices.Localization;
using MSLivingChoices.Logging;
using MSLivingChoices.Logging.Messages;
using MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver;
using MSLivingChoices.Mvc.Uipc.Client.Enums;
using MSLivingChoices.Mvc.Uipc.Client.Helpers;
using MSLivingChoices.Mvc.Uipc.Client.MappingExtentions;
using MSLivingChoices.Mvc.Uipc.Client.MSLivingChoices.Mvc.Uipc.Client.ViewModels;
using MSLivingChoices.Mvc.Uipc.Client.ViewModels;
using MSLivingChoices.Mvc.Uipc.Enums;
using MSLivingChoices.Mvc.Uipc.Helpers;
using MSLivingChoices.Mvc.Utilities.Cookies;
using MSLivingChoices.Utilities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Mvc.Uipc.Client.ViewModelsProviders
{
	public static class ClientViewModelsProvider
	{
		public static LeadConfirmationVm ProcessLead(LeadFormVm leadForm)
		{
			LeadConfirmationVm leadConfirmationVm = new LeadConfirmationVm();
			try
			{
				LeadBc.Instance.ProcessLead(leadForm.ToEntity());
				SaveCustomerInfo(leadForm);
			}
			catch (Exception exception)
			{
				Logger.Error(LogMessages.MvcUipcClient.ViewModelsProviders.LeadProcessingError, exception);
				leadConfirmationVm.Success = false;
				leadConfirmationVm.Message = ErrorMessages.AjaxServerError;
				return leadConfirmationVm;
			}
			leadConfirmationVm.Success = true;
			leadConfirmationVm.Message = StaticContent.Txt_LeadConfirmationMessage;
			return leadConfirmationVm;
		}
		public static bool SaveContact(ContactUs con)
        {
			return CommonBc.Instance.SaveContact(con.MapToContact());
        }
		public static bool EBook(MSLivingChoices.Mvc.Uipc.Client.ViewModels.EbookOrder eb)
        {
			return CommonBc.Instance.SaveEBook(eb.MapToEBook());
        }
		public static LeadFormVm GetLeadFormVm(CommunityDetailsVm vm)
		{
			LeadFormVm leadFormVm = GetLeadFormVm();
			leadFormVm.ListingId = vm.Community.Id;
			leadFormVm.ListingName = vm.Community.Name;
			leadFormVm.Message = vm.Community.GetLeadFormMessage();
			leadFormVm.Brand = vm.PageType.ToSearchType().MapToBrandType();
			leadFormVm.Inquiry = InquiryType.Community;
			return leadFormVm;
		}

		public static LeadFormVm GetLeadFormVm(ServiceProviderDetailsVm vm)
		{
			LeadFormVm leadFormVm = GetLeadFormVm();
			leadFormVm.ListingId = vm.ServiceProvider.Id;
			leadFormVm.ListingName = vm.ServiceProvider.Name;
			leadFormVm.Message = vm.ServiceProvider.GetLeadFormMessage();
			leadFormVm.Brand = SearchType.ProductsAndServices.MapToBrandType();
			leadFormVm.Inquiry = InquiryType.ServiceProvider;
			leadFormVm.DisplayProperties.MoveInDate = false;
			return leadFormVm;
		}

		public static LeadFormVm GetLeadFormVm(CommunitiesSearchVm vm)
		{
			LeadFormVm leadFormVm = GetLeadFormVm();
			leadFormVm.Message = vm.GetLeadFormMessage();
			leadFormVm.Brand = vm.PageType.ToSearchType().MapToBrandType();
			leadFormVm.Inquiry = InquiryType.Community;
			return leadFormVm;
		}

		public static LeadFormVm GetLeadFormVm(ServiceProvidersSearchVm vm)
		{
			LeadFormVm leadFormVm = GetLeadFormVm();
			leadFormVm.Message = vm.GetLeadFormMessage();
			leadFormVm.Brand = vm.PageType.ToSearchType().MapToBrandType();
			leadFormVm.Inquiry = InquiryType.ServiceProvider;
			leadFormVm.DisplayProperties.MoveInDate = false;
			return leadFormVm;
		}

		public static LeadFormVm GetLeadFormVm(CommunityQuickViewVm vm, SearchType searchType)
		{
			LeadFormVm leadFormVm = GetLeadFormVm();
			leadFormVm.ListingId = vm.Id;
			leadFormVm.ListingName = vm.Name;
			leadFormVm.Message = vm.GetLeadFormMessage();
			leadFormVm.Brand = searchType.MapToBrandType();
			leadFormVm.Inquiry = InquiryType.Community;
			return leadFormVm;
		}

		public static LeadFormVm GetLeadFormVm(ServiceProviderQuickViewVm vm)
		{
			LeadFormVm leadFormVm = GetLeadFormVm();
			leadFormVm.ListingId = vm.Id;
			leadFormVm.ListingName = vm.Name;
			leadFormVm.Message = vm.GetLeadFormMessage();
			leadFormVm.Brand = SearchType.ProductsAndServices.MapToBrandType();
			leadFormVm.Inquiry = InquiryType.ServiceProvider;
			leadFormVm.DisplayProperties.MoveInDate = false;
			return leadFormVm;
		}

		public static LeadFormVm GetLeadFormVm(FloorPlanQuickViewVm vm, long communityId, SearchType searchType)
		{
			LeadFormVm leadFormVm = GetLeadFormVm();
			leadFormVm.ListingId = communityId;
			leadFormVm.CommunityUnitId = vm.Id;
			leadFormVm.ListingName = vm.Name;
			leadFormVm.Message = vm.GetLeadFormMessage();
			leadFormVm.Brand = searchType.MapToBrandType();
			leadFormVm.Inquiry = InquiryType.FloorPlan;
			return leadFormVm;
		}

		public static LeadFormVm GetLeadFormVm(SpecHomeQuickViewVm vm, long communityId, SearchType searchType)
		{
			LeadFormVm leadFormVm = GetLeadFormVm();
			leadFormVm.ListingId = communityId;
			leadFormVm.CommunityUnitId = vm.Id;
			leadFormVm.ListingName = vm.Name;
			leadFormVm.Message = vm.GetLeadFormMessage();
			leadFormVm.Brand = searchType.MapToBrandType();
			leadFormVm.Inquiry = InquiryType.SpecialHome;
			return leadFormVm;
		}

		public static LeadFormVm GetLeadFormVm(HomeQuickViewVm vm, long communityId, SearchType searchType)
		{
			LeadFormVm leadFormVm = GetLeadFormVm();
			leadFormVm.ListingId = communityId;
			leadFormVm.CommunityUnitId = vm.Id;
			leadFormVm.ListingName = vm.Name;
			leadFormVm.Message = vm.GetLeadFormMessage();
			leadFormVm.Brand = searchType.MapToBrandType();
			leadFormVm.Inquiry = InquiryType.Home;
			return leadFormVm;
		}

		private static LeadFormVm GetLeadFormVm()
		{
			return new LeadFormVm
			{
				Customer = GetCustomerInfo(),
				LookingFor = LookingForType.Myself,
				LookingForChoices = ConverterHelper.EnumToKoSelectListItems<LookingForType>(),
				DisplayProperties = new LeadFormDisplayProperties
				{
					MoveInDate = true
				}
			};
		}

		private static CustomerInfoVm GetCustomerInfo()
		{
			return CookieManager.GetCookie<CustomerInfoVm>(ConfigurationManager.Instance.UserInfoCookieName) ?? new CustomerInfoVm();
		}

		private static void SaveCustomerInfo(LeadFormVm leadForm)
		{
			try
			{
				CookieManager.SetCookie(ConfigurationManager.Instance.UserInfoCookieName, leadForm.Customer, DateTime.Now.AddDays(ConfigurationManager.Instance.UserInfoCookiesLifeSpanDays));
			}
			catch (Exception exception)
			{
				Logger.Error(LogMessages.MvcUipcClient.ViewModelsProviders.UnableSaveCustomerCookieError, exception);
			}
		}

		public static IndexVm GetIndexSearchVm()
		{
			IndexVm indexVm = new IndexVm();
			indexVm.PageType = PageType.Index;
			indexVm.Seo = SeoHelper.GetSeo(indexVm);
			indexVm.Criteria = GetInitSearchCriteriaVm();
			CountryStubSearchModel countryStubSearchModel = new CountryStubSearchModel();
			countryStubSearchModel.Criteria = indexVm.Criteria.ToSearchCriteria();
			countryStubSearchModel.MaxCount = ConfigurationManager.Instance.IndexStubCitiesMaxCount;
			countryStubSearchModel.IsMarketAreaOnly = true;
			List<CityListingsInfo> result = SearchBc.Instance.SearchStubCities(countryStubSearchModel).Result;
			indexVm.Result.Add(SearchType.ActiveAdultCommunities, result.OrderByDescending((CityListingsInfo li) => li.AdultCommunitiesCount).Take(countryStubSearchModel.MaxCount).MapToCitiesLinks(SearchType.ActiveAdultCommunities, addCounting: false));
			indexVm.Result.Add(SearchType.ActiveAdultHomes, result.OrderByDescending((CityListingsInfo li) => li.AdultHomesCount).Take(countryStubSearchModel.MaxCount).MapToCitiesLinks(SearchType.ActiveAdultHomes, addCounting: false));
			indexVm.Result.Add(SearchType.SeniorHousingAndCare, result.OrderByDescending((CityListingsInfo li) => li.SeniorHousingCount).Take(countryStubSearchModel.MaxCount).MapToCitiesLinks(SearchType.SeniorHousingAndCare, addCounting: false));
			indexVm.Result.Add(SearchType.ProductsAndServices, result.OrderByDescending((CityListingsInfo li) => li.ServicesCount).Take(countryStubSearchModel.MaxCount).MapToCitiesLinks(SearchType.ProductsAndServices, addCounting: false));
			return indexVm;
		}

		public static SearchTypeStubSearchVm GetSearchTypeSearchVm(SearchTypeStubSearchVm searchVm)
		{
			List<CityListingsInfo> result;
			if (searchVm.PageType == PageType.ServiceProvidersByType)
			{
				CountryStubSearchModel countryStubSearchModel = new CountryStubSearchModel();
				countryStubSearchModel.Criteria = searchVm.Criteria.ToSearchCriteria();
				countryStubSearchModel.MaxCount = ConfigurationManager.Instance.SearchTypeStubCitiesMaxCount;
				result = SearchBc.Instance.SearchServiceProvidersStubCities(countryStubSearchModel).Result;
			}
			else
			{
				CommunityCountryStubSearchModel communityCountryStubSearchModel = new CommunityCountryStubSearchModel();
				communityCountryStubSearchModel.Criteria = searchVm.Criteria.ToSearchCriteria();
				communityCountryStubSearchModel.ListingType = searchVm.PageType.ToSearchType().ToListingType();
				communityCountryStubSearchModel.MaxCount = ConfigurationManager.Instance.SearchTypeStubCitiesMaxCount;
				result = SearchBc.Instance.SearchCommunitiesStubCities(communityCountryStubSearchModel).Result;
			}
			searchVm.Result = result.MapToCitiesTabs(searchVm.PageType.ToSearchType());
			searchVm.Seo = SeoHelper.GetSeo(searchVm);
			searchVm.SearchBar = GetSearchBarVm(searchVm);
			searchVm.Breadcrumbs = GetBreadcrumbs(searchVm);
			return searchVm;
		}
		public static List<CommunityBlockVm> GetNewSmililarCommunity(CommunitiesSearchVm searchVm,long CommunityId)
		{
            Entities.Client.Search.FeaturedCommunitySearchModel searchModel2 = searchVm.ToFeaturedCommunitySearchModel();
			searchModel2 = SearchBc.Instance.SearchFeaturedCommunities(searchModel2, CommunityId);
			return searchModel2.Result.MapToCommunityBlockVmList(searchVm.Criteria.SearchType());
		}
		public static CommunitiesSearchVm GetCommunitiesSearchVm(CommunitiesSearchVm searchVm)
		{
			if (!ValidatePageNumber(searchVm.PageNumber))
			{
				return null;
			}
			searchVm.ValidationResult = GetLookupLocationValidationVm(searchVm.SearchBar);
			if (!searchVm.ValidationResult.IsValid)
			{
				return searchVm;
			}
			searchVm.Criteria = searchVm.ValidationResult.Criteria;
			searchVm.SearchBar = GetSearchBarVm(searchVm);
			CommunitySearchModel searchModel = searchVm.ToCommunitySearchModel();
			FeaturedCommunitySearchModel searchModel2 = searchVm.ToFeaturedCommunitySearchModel();
			searchModel = SearchBc.Instance.SearchCommunities(searchModel);
			searchModel2 = SearchBc.Instance.SearchFeaturedCommunities(searchModel2);
			searchVm.PageSize = searchModel.PageSize;
			searchVm.TotalCount = searchModel.Result.TotalCount;
			searchVm.Paging = searchVm.MapToPagingVm();
			searchVm.Refine = searchVm.MapToCommunityRefineVm();
			searchVm.Result = searchModel.Result.Results.MapToCommunityBlockVmList(searchVm.Criteria.SearchType());
			searchVm.FeaturedCommunities = searchModel2.Result.MapToCommunityShortVmList(searchVm.Criteria.SearchType());
			PopulateFeaturedServices(searchVm);
			searchVm.Breadcrumbs = GetBreadcrumbs(searchVm);
			searchVm.LeadForm = GetLeadFormVm(searchVm);
			searchVm.Seo = SeoHelper.GetSeo(searchVm);
			return searchVm;
		}
		public static List<ServiceProviderBlockVm> GetNewSmililarServiceProvider(ServiceProvidersSearchVm searchVm, long CommunityId)
		{
			Entities.Client.Search.FeaturedServiceProviderSearchModel searchModel2 = searchVm.ToFeaturedServiceProviderSearchModel();
			return SearchBc.Instance.SearchFeaturedServiceProviders(searchModel2, CommunityId).Result.MapToServiceProviderBlockVmList();
		}
		public static ServiceProvidersSearchVm GetServiceProvidersSearchVm(ServiceProvidersSearchVm searchVm)
		{
			if (!ValidatePageNumber(searchVm.PageNumber))
			{
				return null;
			}
			searchVm.ValidationResult = GetLookupLocationValidationVm(searchVm.SearchBar);
			if (!searchVm.ValidationResult.IsValid)
			{
				return searchVm;
			}
			searchVm.Criteria = searchVm.ValidationResult.Criteria;
			searchVm.SearchBar = GetSearchBarVm(searchVm);
			ServiceProviderSearchModel searchModel = searchVm.ToServiceProviderSearchModel();
			searchModel = SearchBc.Instance.SearchServiceProviders(searchModel);
			searchVm.PageSize = searchModel.PageSize;
			searchVm.TotalCount = searchModel.Result.TotalCount;
			searchVm.Paging = searchVm.MapToPagingVm();
			searchVm.Refine = searchVm.MapToServiceProviderRefineVm();
			searchVm.Result = searchModel.Result.Results.MapToServiceProviderBlockVmList();
			PopulateFeaturedServices(searchVm);
			searchVm.Breadcrumbs = GetBreadcrumbs(searchVm);
			searchVm.LeadForm = GetLeadFormVm(searchVm);
			searchVm.DisplayProperties = new SearchDisplayProperties();
			searchVm.Seo = SeoHelper.GetSeo(searchVm);
			return searchVm;
		}

		public static CommunityDetailsVm GetCommunityDetailsVm(long communityId, PageType pageType)
		{
			CommunityDetailsVm result = null;
			Community community = SearchBc.Instance.GetCommunity(communityId);
			if (community != null)
			{
				result = community.MapToCommunityDetailsVm(pageType);
				result.Breadcrumbs = GetBreadcrumbs(result);
				result.Seo = SeoHelper.GetSeo(result);
				PopulateFeaturedServices(result, communityId);
				foreach (FloorPlanVm floorPlan in result.FloorPlans)
				{
					floorPlan.LeadForm = GetLeadFormVm(floorPlan, communityId, pageType.ToSearchType());
				}
				foreach (SpecHomeVm specHome in result.SpecHomes)
				{
					specHome.LeadForm = GetLeadFormVm(specHome, communityId, pageType.ToSearchType());
				}
				{
					foreach (HomeVm home in result.Homes)
					{
						home.LeadForm = GetLeadFormVm(home, communityId, pageType.ToSearchType());
					}
					return result;
				}
			}
			return result;
		}

		public static CommunityDetailsVm GetCommunityDetailsVmForPrint(long communityId, PageType pageType)
		{
			CommunityDetailsVm communityDetailsVm = null;
			Community community = SearchBc.Instance.GetCommunity(communityId);
			if (community != null)
			{
				communityDetailsVm = community.MapToCommunityDetailsVm(pageType);
				communityDetailsVm.Seo = SeoHelper.GetSeo(communityDetailsVm);
			}
			return communityDetailsVm;
		}

		public static CommunityPrintDirectionVm GetCommunityPrintDirectionVm(long communityId, PageType pageType, double latitude, double longitude)
		{
			CommunityPrintDirectionVm communityPrintDirectionVm = null;
			Community community = SearchBc.Instance.GetCommunity(communityId);
			if (community != null)
			{
				communityPrintDirectionVm = community.MapToCommunityPrintDirectionVm(pageType, latitude, longitude);
				communityPrintDirectionVm.Seo = SeoHelper.GetSeo(communityPrintDirectionVm);
			}
			return communityPrintDirectionVm;
		}

		public static ServiceProviderDetailsVm GetServiceProviderDetailsVm(long serviceProviderId)
		{
			ServiceProviderDetailsVm serviceProviderDetailsVm = null;
			ServiceProvider serviceProvider = SearchBc.Instance.GetServiceProvider(serviceProviderId);
			if (serviceProvider != null)
			{
				serviceProviderDetailsVm = serviceProvider.MapToServiceProviderDetailsVm();
				serviceProviderDetailsVm.Breadcrumbs = GetBreadcrumbs(serviceProviderDetailsVm);
				serviceProviderDetailsVm.Seo = SeoHelper.GetSeo(serviceProviderDetailsVm);
				PopulateFeaturedServices(serviceProviderDetailsVm, null, serviceProviderId);
			}
			return serviceProviderDetailsVm;
		}

		public static ServiceProviderDetailsVm GetServiceProviderDetailsVmForPrint(long serviceProviderId)
		{
			ServiceProviderDetailsVm serviceProviderDetailsVm = null;
			ServiceProvider serviceProvider = SearchBc.Instance.GetServiceProvider(serviceProviderId);
			if (serviceProvider != null)
			{
				serviceProviderDetailsVm = serviceProvider.MapToServiceProviderDetailsVm();
				serviceProviderDetailsVm.Seo = SeoHelper.GetSeo(serviceProviderDetailsVm);
			}
			return serviceProviderDetailsVm;
		}

		public static ServiceProviderPrintDirectionVm GetServiceProviderPrintDirectionVm(long serviceProviderId, double latitude, double longitude)
		{
			ServiceProviderPrintDirectionVm serviceProviderPrintDirectionVm = null;
			ServiceProvider serviceProvider = SearchBc.Instance.GetServiceProvider(serviceProviderId);
			if (serviceProvider != null)
			{
				serviceProviderPrintDirectionVm = serviceProvider.MapToServiceProviderPrintDirectionVm(latitude, longitude);
				serviceProviderPrintDirectionVm.Seo = SeoHelper.GetSeo(serviceProviderPrintDirectionVm);
			}
			return serviceProviderPrintDirectionVm;
		}

		public static List<AutocompleteVm> GetAutocompleteVmList(LookupLocationVm lookupLocation)
		{
			return LocationBc.Instance.GetAutocomplete(lookupLocation.LookupLocation).MapToAutocompleteVmList(lookupLocation.SearchType, lookupLocation.LookupLocation);
		}

		public static LookupLocationValidationVm GetLookupLocationValidationVm(LookupLocationVm lookupLocation)
		{
			return LocationBc.Instance.ValidateLookupLocation(lookupLocation.LookupLocation).MapToLookupLocationValidationVm(lookupLocation.SearchType);
		}

		public static ServiceProviderQuickViewVm GetServiceProviderQuickViewVm(long serviceProviderId)
		{
			ServiceProviderQuickViewVm serviceProviderQuickViewVm = null;
			ServiceProvider serviceProvider = SearchBc.Instance.GetServiceProvider(serviceProviderId);
			if (serviceProvider != null)
			{
				serviceProviderQuickViewVm = serviceProvider.MapToServiceProviderQuickViewVm();
				serviceProviderQuickViewVm.LeadForm = GetLeadFormVm(serviceProviderQuickViewVm);
			}
			return serviceProviderQuickViewVm;
		}

		public static List<SpecHomeQuickViewVm> GetSpecHomeQuickViewVmList(long communityId, SearchType searchType)
		{
			List<SpecHomeQuickViewVm> list = SearchBc.Instance.GetSpecHomes(communityId).MapToSpecHomeQuickViewVmList();
			foreach (SpecHomeQuickViewVm item in list)
			{
				item.LeadForm = GetLeadFormVm(item, communityId, searchType);
			}
			return list;
		}

		public static List<HomeQuickViewVm> GetHomeQuickViewVmList(long communityId, SearchType searchType)
		{
			List<HomeQuickViewVm> list = SearchBc.Instance.GetHomes(communityId).MapToHomeQuickViewVmList();
			foreach (HomeQuickViewVm item in list)
			{
				item.LeadForm = GetLeadFormVm(item, communityId, searchType);
			}
			return list;
		}

		public static CommunityQuickViewVm GetCommunityQuickViewVm(long communityId, SearchType searchType)
		{
			CommunityQuickViewVm communityQuickViewVm = null;
			Community community = SearchBc.Instance.GetCommunity(communityId);
			if (community != null)
			{
				communityQuickViewVm = community.MapToCommunityQuickViewVm(searchType);
				communityQuickViewVm.LeadForm = GetLeadFormVm(communityQuickViewVm, searchType);
			}
			return communityQuickViewVm;
		}

		public static IEnumerable<FloorPlanQuickViewVm> GetFloorPlanQuickViewVmList(long communityId, SearchType searchType)
		{
			List<FloorPlanQuickViewVm> list = SearchBc.Instance.GetFloorPlans(communityId).MapToFloorPlanQuickViewVmList();
			foreach (FloorPlanQuickViewVm item in list)
			{
				item.LeadForm = GetLeadFormVm(item, communityId, searchType);
			}
			return list;
		}

		public static SearchVm GetStaticContent(PageType type)
		{
			SearchVm obj = new SearchVm
			{
				PageType = type,
				Seo = SeoHelper.GetSeo(type),
				Criteria = GetInitSearchCriteriaVm()
			};
			obj.Breadcrumbs = GetBreadcrumbs(obj);
			return obj;
		}

		internal static SearchBarVm GetSearchBarVm(SearchVm searchVm)
		{
			SearchBarVm searchBarVm = FillSearchTemplates(FillSearchTypeList(new SearchBarVm
			{
				SearchType = searchVm.Criteria.SearchType()
			}, searchVm));
			searchBarVm.LookupLocation = GetLookupLocation(searchVm.Criteria);
			return searchBarVm;
		}

		internal static string GetLookupLocation(ISearchCriteria criteria)
		{
			string result = string.Empty;
			switch (criteria.Depth)
			{
				case SearchDepth.State:
					result = $"{criteria.StateCode()}";
					break;
				case SearchDepth.City:
					result = $"{criteria.City()}, {criteria.StateCode()}";
					break;
				case SearchDepth.Zip:
					result = $"{criteria.Zip()}, {criteria.StateCode()}";
					break;
			}
			return result;
		}

		private static bool ValidatePageNumber(int? pageNumber)
		{
			if (pageNumber.HasValue)
			{
				return pageNumber < (int)Math.Ceiling(2147483647.0 / (double)ConfigurationManager.Instance.DefaultPageSize);
			}
			return false;
		}

		private static SearchCriteriaVm GetInitSearchCriteriaVm()
		{
			SearchCriteriaVm searchCriteriaVm = new SearchCriteriaVm();
			searchCriteriaVm.SearchType(SearchType.SeniorHousingAndCare);
			searchCriteriaVm.CountryCode("USA");
			return searchCriteriaVm;
		}

		private static SearchBarVm FillSearchTemplates(SearchBarVm searchBar)
		{
			List<SearchTemplates> searchTemplates = ConfigurationManager.Instance.SearchTemplates;
			if (searchTemplates.Any((SearchTemplates t) => t.CountryCode.Equals("USA", StringComparison.InvariantCultureIgnoreCase)))
			{
				SearchTemplates searchTemplates2 = searchTemplates.First((SearchTemplates t) => t.CountryCode.Equals("USA", StringComparison.InvariantCultureIgnoreCase));
				searchBar.Placeholder = searchTemplates2.Placeholder;
				searchBar.Templates = new Dictionary<SearchType, List<AutocompleteVm>>();
				SearchType[] array = (SearchType[])Enum.GetValues(typeof(SearchType));
				foreach (SearchType searchType in array)
				{
					List<AutocompleteVm> list = new List<AutocompleteVm>();
					foreach (QueryTemplate template in searchTemplates2.Templates)
					{
						AutocompleteVm autocompleteVm = new AutocompleteVm();
						autocompleteVm.Start = template.LookupLocation;
						autocompleteVm.Template = template.Template;
						autocompleteVm.Url = MslcUrlBuilder.AbsoluteUrl($"/{searchType.UrlPrefix()}{template.Url}");
						list.Add(autocompleteVm);
					}
					searchBar.Templates.Add(searchType, list);
				}
			}
			return searchBar;
		}

		private static SearchBarVm FillSearchTypeList(SearchBarVm searchBar, SearchVm searchVm)
		{
			List<SearchType> list = ConverterHelper.EnumToList<SearchType>();
			SearchType searchType = searchVm.Criteria.SearchType();
			searchBar.SearchTypeList = new List<SearchBarSelectListItem>();
			NearbySearchResult nearbySearchResult = GetNearbySearchResult(searchVm);
			if (nearbySearchResult != null)
			{
				searchBar.Crosslinks = nearbySearchResult.MapToCrosslinksVm(searchVm.Criteria);
			}
			foreach (SearchType item in list)
			{
				SearchBarSelectListItem searchBarSelectListItem = new SearchBarSelectListItem();
				searchBarSelectListItem.Text = item.GetEnumLocalizedValue();
				int num = (int)item;
				searchBarSelectListItem.Value = num.ToString(CultureInfo.InvariantCulture);
				searchBarSelectListItem.Selected = item == searchType;
				ListingType type;
				if (nearbySearchResult == null)
				{
					searchBarSelectListItem.UrlValue = MslcUrlBuilder.SearchUrl(searchVm.Criteria, item);
				}
				else if (item.TryToListingType(out type))
				{
					searchBarSelectListItem.UrlValue = MslcUrlBuilder.SearchUrl(nearbySearchResult.AvailableListingTypes.Contains(type) ? searchVm.Criteria : searchVm.Criteria.CloneLowerDepth(), item);
				}
				else
				{
					searchBarSelectListItem.UrlValue = MslcUrlBuilder.SearchUrl(nearbySearchResult.IsServiceProvidersAvailable ? searchVm.Criteria : searchVm.Criteria.CloneLowerDepth(), item);
				}
				searchBar.SearchTypeList.Add(searchBarSelectListItem);
			}
			return searchBar;
		}

		private static NearbySearchResult GetNearbySearchResult(SearchVm searchVm)
		{
			NearbySearchResult result = null;
			if (searchVm.PageType.ToSearchType() != SearchType.ProductsAndServices)
			{
				CommunitiesSearchVm communitiesSearchVm = searchVm as CommunitiesSearchVm;
				if (communitiesSearchVm != null)
				{
					CommunityNearbySearchModel searchModel = communitiesSearchVm.ToCommunityNearbySearchModel();
					searchModel = SearchBc.Instance.SearchNearbyCommunities(searchModel);
					result = searchModel.Result;
				}
			}
			else
			{
				ServiceProvidersSearchVm serviceProvidersSearchVm = searchVm as ServiceProvidersSearchVm;
				if (serviceProvidersSearchVm != null)
				{
					NearbySearchModel searchModel2 = serviceProvidersSearchVm.ToNearbySearchModel();
					searchModel2 = SearchBc.Instance.SearchNearbyServiceProviders(searchModel2);
					result = searchModel2.Result;
				}
			}
			return result;
		}

		private static List<LinkVm> GetBreadcrumbs(SearchVm searchVm)
		{
			List<LinkVm> list = new List<LinkVm>();
			list.Add(new LinkVm("Home", MslcUrlBuilder.BaseUrl));
			if (searchVm.PageType.IsStaticPage())
			{

				if (searchVm.Seo != null)
				{
					list.Add(new LinkVm(searchVm.Seo.Header, searchVm.Seo.CanonicalUrl));
				}
				return list;
			}
			if (searchVm.Criteria.Validate())
			{
				SearchCriteriaVm criteria = new SearchCriteriaVm();
				criteria.SearchType(searchVm.Criteria.SearchType());
				list.Add(new LinkVm(criteria.SearchType().GetEnumLocalizedValue(), MslcUrlBuilder.SearchUrl(criteria, criteria.SearchType())));
				if (!searchVm.Criteria.StateCode().IsNullOrEmpty())
				{
					criteria.StateCode(searchVm.Criteria.StateCode());
					list.Add(new LinkVm(LocationBc.Instance.GetStateName(criteria.StateCode()), MslcUrlBuilder.SearchUrl(criteria, criteria.SearchType())));
				}
				if (!searchVm.Criteria.City().IsNullOrEmpty())
				{
					criteria.City(searchVm.Criteria.City());
					list.Add(new LinkVm(criteria.City(), MslcUrlBuilder.SearchUrl(criteria, criteria.SearchType())));
				}
				else if (!searchVm.Criteria.Zip().IsNullOrEmpty())
				{
					criteria.Zip(searchVm.Criteria.Zip());
					list.Add(new LinkVm(criteria.Zip(), MslcUrlBuilder.SearchUrl(criteria, criteria.SearchType())));
				}
			}
			return list;
		}

		private static List<LinkVm> GetBreadcrumbs(CommunityDetailsVm communityDetails)
		{
			List<LinkVm> breadcrumbs = GetBreadcrumbs((SearchVm)communityDetails);
			breadcrumbs.Add(new LinkVm(communityDetails.Community.Name, MslcUrlBuilder.DetailsUrl(communityDetails.Community, communityDetails.Criteria.SearchType())));
			return breadcrumbs;
		}

		private static List<LinkVm> GetBreadcrumbs(ServiceProviderDetailsVm serviceProviderDetails)
		{
			List<LinkVm> breadcrumbs = GetBreadcrumbs((SearchVm)serviceProviderDetails);
			breadcrumbs.Add(new LinkVm(serviceProviderDetails.ServiceProvider.Name, MslcUrlBuilder.DetailsUrl(serviceProviderDetails.ServiceProvider)));
			return breadcrumbs;
		}

		private static void PopulateFeaturedServices(this SearchWithServicesVm searchVm, long? communityId = null, long? serviceId = null)
		{
			FeaturedServiceProviderSearchModel searchModel = searchVm.ToFeaturedServiceProviderSearchModel(communityId, serviceId);
			searchModel = SearchBc.Instance.SearchFeaturedServiceProviders(searchModel);
			searchVm.FeaturedServices = new FeaturedServicesVm();
			searchVm.FeaturedServices.AreaName = searchVm.SearchBar.LookupLocation;
			searchVm.FeaturedServices.Items = searchModel.Result.MapToServiceProviderShortVmList();
			searchVm.FeaturedServices.AreaServicesLink = MslcUrlBuilder.SearchUrl(searchVm.Criteria, SearchType.ProductsAndServices);
		}
	}

}