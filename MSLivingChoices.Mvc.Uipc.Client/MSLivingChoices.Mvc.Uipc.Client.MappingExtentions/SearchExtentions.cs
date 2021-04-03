using MSLivingChoices.Bcs.Components;
using MSLivingChoices.Configuration;
using MSLivingChoices.Entities.Client;
using MSLivingChoices.Entities.Client.Enums;
using MSLivingChoices.Entities.Client.Search;
using MSLivingChoices.Entities.Client.Search.Criteria;
using MSLivingChoices.Localization;
using MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver;
using MSLivingChoices.Mvc.Uipc.Client.Enums;
using MSLivingChoices.Mvc.Uipc.Client.Helpers;
using MSLivingChoices.Mvc.Uipc.Client.ViewModels;
using MSLivingChoices.Mvc.Uipc.Client.ViewModelsProviders;
using MSLivingChoices.Mvc.Uipc.Enums;
using MSLivingChoices.Mvc.Uipc.Helpers;
using MSLivingChoices.Utilities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Mvc.Uipc.Client.MappingExtentions
{
	internal static class SearchExtentions
	{
		private readonly static ConfigurationManager Config;

		static SearchExtentions()
		{
			SearchExtentions.Config = ConfigurationManager.Instance;
		}

		private static List<TUnit> FillUnitNames<TUnit>(this List<TUnit> units, string unitName)
		where TUnit : class, ICommunityUnit
		{
			if (units == null || !SearchExtentions.Config.EnableCommunityUnitsAutoNaming)
			{
				return units;
			}
			int num = 1;
			foreach (TUnit unit in units)
			{
				if (((ICommunityUnit)(object)unit).Name.IsNullOrEmpty())
				{
					((ICommunityUnit)(object)unit).Name = string.Format("{0} #{1}", unitName, num);
				}
				num++;
			}
			return units;
		}

		private static int GetListingsCount(CityListingsInfo cityInfo, SearchType searchType)
		{
			switch (searchType)
			{
				case SearchType.SeniorHousingAndCare:
				{
					return cityInfo.SeniorHousingCount;
				}
				case SearchType.ActiveAdultCommunities:
				{
					return cityInfo.AdultCommunitiesCount;
				}
				case SearchType.ActiveAdultHomes:
				{
					return cityInfo.AdultHomesCount;
				}
				case SearchType.ProductsAndServices:
				{
					return cityInfo.ServicesCount;
				}
			}
			throw new ArgumentOutOfRangeException("searchType");
		}

		internal static List<AutocompleteVm> MapToAutocompleteVmList(this IEnumerable<SearchCriteria> criterias, SearchType searchType, string lookupString)
		{
			List<AutocompleteVm> autocompleteVms = new List<AutocompleteVm>();
			foreach (SearchCriteria criteria in criterias)
			{
				AutocompleteVm autocompleteVm = new AutocompleteVm();
				string lookupLocation = ClientViewModelsProvider.GetLookupLocation(criteria);
				if (lookupString.IsNullOrEmpty() || !lookupLocation.StartsWith(lookupString, StringComparison.InvariantCultureIgnoreCase))
				{
					autocompleteVm.Start = lookupLocation;
				}
				else
				{
					autocompleteVm.Start = new string(lookupLocation.Take<char>(lookupString.Count<char>()).ToArray<char>());
					autocompleteVm.End = new string(lookupLocation.Skip<char>(lookupString.Count<char>()).ToArray<char>());
				}
				if (string.IsNullOrEmpty(autocompleteVm.LookupLocation))
				{
					continue;
				}
				autocompleteVm.Url = MslcUrlBuilder.SearchUrl(criteria, searchType);
				SearchDepth depth = criteria.Depth;
				switch (depth)
				{
					case SearchDepth.State:
					{
						autocompleteVm.Template = "State";
						break;
					}
					case SearchDepth.City:
					{
						autocompleteVm.Template = "City";
						break;
					}
					case SearchDepth.Zip:
					{
						autocompleteVm.Template = "Zip";
						break;
					}
					default:
					{
						depth = SearchDepth.Invalid;
						break;
					}
				}
				if (depth == SearchDepth.Invalid)
				{
					continue;
				}
				autocompleteVms.Add(autocompleteVm);
			}
			return autocompleteVms;
		}

		internal static List<LinkVm> MapToCitiesLinks(this IEnumerable<CityListingsInfo> cities, SearchType searchType)
		{
			return cities.MapToCitiesLinks(searchType, true);
		}

		internal static List<LinkVm> MapToCitiesLinks(this IEnumerable<CityListingsInfo> cities, SearchType searchType, bool addCounting)
		{
			string str = (addCounting ? "{0}, {1} ({2})" : "{0}, {1}");
			return cities.Select<CityListingsInfo, LinkVm>((CityListingsInfo cityInfo) => {
				LinkVm linkVm = new LinkVm();
				int listingsCount = SearchExtentions.GetListingsCount(cityInfo, searchType);
				linkVm.Href = MslcUrlBuilder.SearchUrl(cityInfo.SearchCriteria, searchType);
				linkVm.InnerText = string.Format(str, cityInfo.SearchCriteria.City(), cityInfo.SearchCriteria.StateCode(), listingsCount);
				return linkVm;
			}).ToList<LinkVm>();
		}

		internal static Dictionary<string, List<LinkVm>> MapToCitiesTabs(this IEnumerable<CityListingsInfo> cities, SearchType searchType)
		{
			Dictionary<string, List<LinkVm>> strs = new Dictionary<string, List<LinkVm>>();
			List<LinkVm> citiesLinks = cities.MapToCitiesLinks(searchType);
			strs.Add("Featured", (
				from x in citiesLinks.Take<LinkVm>(SearchExtentions.Config.SearchTypeStubFeaturedCitiesCount)
				orderby x.InnerText
				select x).ToList<LinkVm>());
			foreach (IGrouping<string, LinkVm> strs1 in 
				from x in citiesLinks
				group x by x.InnerText[0].ToString(CultureInfo.InvariantCulture).ToUpper() into x
				orderby x.Key
				select x)
			{
				strs.Add(strs1.Key, (
					from x in strs1
					orderby x.InnerText
					select x).ToList<LinkVm>());
			}
			return strs;
		}

		internal static CommunityBlockVm MapToCommunityBlockVm(this Community community, SearchType searchType)
		{
			CommunityBlockVm communityBlockVm = community.MapToCommunityBlockVm(searchType, null);
			communityBlockVm.Amenities = communityBlockVm.Amenities.Take<string>(SearchExtentions.Config.SearchAmenitiesListMaxCount).ToList<string>();
			communityBlockVm.Images = communityBlockVm.Images.TakeExceptFirst<ImageVm>(SearchExtentions.Config.AdditionalImagesMaxCount).ToList<ImageVm>();
			return communityBlockVm;
		}

		private static CommunityBlockVm MapToCommunityBlockVm(this Community community, SearchType searchType, CommunityBlockVm viewModel)
		{
			CommunityBlockVm communityShortVm = community.MapToCommunityShortVm(searchType, viewModel ?? new CommunityBlockVm()) as CommunityBlockVm;
			if (communityShortVm != null)
			{
				communityShortVm.Description = community.Description;
				communityShortVm.ListingTypes = community.ListingTypes;
				communityShortVm.Bathes = community.Bathes.BathesCaption();
				communityShortVm.Beds = community.Beds.BedsCaption();
				communityShortVm.Area = community.LivingSpace.AreaCaption();
				communityShortVm.Amenities = community.Amenities;
				communityShortVm.Images = (community.Images.Any<Image>((Image i) => i.Type == ImageType.Image) ? (
					from i in community.Images
					where i.Type == ImageType.Image
					select i).ToList<Image>().ConvertAll<ImageVm>((Image i) => i.MapToImageVm(ImageOwner.Community, communityShortVm.Name)) : new List<ImageVm>());
				communityShortVm.Phone = community.Phone;
				communityShortVm.SearchRadiusDesignation = (community.SearchResultRadius > 0 ? string.Format(StaticContent.Txt_SearchRadiusDesignation, community.SearchResultRadius) : string.Empty);
				communityShortVm.PrintUrl = MslcUrlBuilder.PrintUrl(community, searchType);
				communityShortVm.PrintDirectionBaseUrl = MslcUrlBuilder.PrintDirectionBaseUrl(community, searchType);
			}
			return communityShortVm;
		}

		internal static List<CommunityBlockVm> MapToCommunityBlockVmList(this List<Community> communities, SearchType searchType)
		{
			return communities.ConvertAll<CommunityBlockVm>((Community c) => c.MapToCommunityBlockVm(searchType));
		}

		internal static CommunityDetailsVm MapToCommunityDetailsVm(this Community community, PageType pageType)
		{
			return community.MapToCommunityDetailsVm(pageType, null);
		}

		private static CommunityDetailsVm MapToCommunityDetailsVm(this Community community, PageType pageType, CommunityDetailsVm viewModel)
		{
			ImageVm imageVm;
			CommunityDetailsVm communityQuickViewVm = viewModel ?? new CommunityDetailsVm();
			communityQuickViewVm.PageType = pageType;
			communityQuickViewVm.Community = community.MapToCommunityQuickViewVm(pageType.ToSearchType());
			communityQuickViewVm.Criteria = communityQuickViewVm.Community.Address.MapToSearchCriteriaVm(pageType.ToSearchType());
			communityQuickViewVm.Deposit = community.Deposit.PriceCaption();
			communityQuickViewVm.ApplicationFee = community.ApplicationFee.PriceCaption();
			communityQuickViewVm.PetDeposit = community.PetDeposit.PriceCaption();
			communityQuickViewVm.VirtualTourUrl = community.VirtualTour.ExternalUrl();
			communityQuickViewVm.WebsiteUrl = community.WebsiteUrl.ExternalUrl();
			CommunityDetailsVm communityDetailsVm = communityQuickViewVm;
			if (community.Images.Any<Image>((Image i) => i.Type == ImageType.Logo))
			{
				imageVm = community.Images.First<Image>((Image i) => i.Type == ImageType.Logo).MapToImageVm(ImageOwner.Community, string.Format("{0} Logo", communityQuickViewVm.Community.Name));
			}
			else
			{
				imageVm = null;
			}
			communityDetailsVm.Logo = imageVm;
			communityQuickViewVm.AgeRestrictions = community.AgeRestrictions.Select<AgeRestriction, string>(new Func<AgeRestriction, string>(LocalizationExtensions.GetEnumLocalizedValue<AgeRestriction>)).ToList<string>();
			communityQuickViewVm.ShcCategories = community.ShcCategories;
			communityQuickViewVm.PaymentsAccepted = community.AcceptedPayments;
			communityQuickViewVm.FloorPlans = community.FloorPlans.MapToFloorPlanVmList();
			communityQuickViewVm.SpecHomes = community.SpecHomes.MapToSpecHomeVmList();
			communityQuickViewVm.Homes = community.Homes.MapToHomeVmList();
			communityQuickViewVm.Coupon = community.Coupon.MapToCouponVm(MslcUrlBuilder.PrintCouponUrl(community, communityQuickViewVm.Criteria.SearchType()));
			communityQuickViewVm.Pmc = community.Pmc.MapToOwnerVm(communityQuickViewVm.Community.Package);
			communityQuickViewVm.OfficeHours = (
				from oh in community.OfficeHours
				select oh.ToString()).ToList<string>();
			communityQuickViewVm.DisplayProperties = new DetailsDisplayProperties();
			return communityQuickViewVm;
		}

		internal static CommunityPrintDirectionVm MapToCommunityPrintDirectionVm(this Community community, PageType pageType, double latitude, double longitude)
		{
			CommunityPrintDirectionVm communityDetailsVm = community.MapToCommunityDetailsVm(pageType, new CommunityPrintDirectionVm()) as CommunityPrintDirectionVm;
			if (communityDetailsVm != null)
			{
				communityDetailsVm.StartLatitude = latitude;
				communityDetailsVm.StartLongitude = longitude;
			}
			return communityDetailsVm;
		}

		internal static CommunityQuickViewVm MapToCommunityQuickViewVm(this Community community, SearchType searchType)
		{
			CommunityQuickViewVm communityBlockVm = community.MapToCommunityBlockVm(searchType, new CommunityQuickViewVm()) as CommunityQuickViewVm;
			if (communityBlockVm != null)
			{
				communityBlockVm.Description = community.Description;
				communityBlockVm.CommunityServices = community.Services;
			}
			return communityBlockVm;
		}

		internal static CommunityRefineVm MapToCommunityRefineVm(this CommunitiesSearchVm searchVm)
		{
			long? nullable;
			long? nullable1;
			long? nullable2;
			CommunityRefineVm communityRefineVm = new CommunityRefineVm();
			List<KeyValuePair<int, string>> communityDefaultAmenities = ItemTypeBc.Instance.GetCommunityDefaultAmenities();
			List<KeyValuePair<int, string>> shcCategoriesForCommunity = ItemTypeBc.Instance.GetShcCategoriesForCommunity();
			List<KeyValuePair<int, string>> list = ItemTypeBc.Instance.GetBedrooms().Take<KeyValuePair<int, string>>(6).ToList<KeyValuePair<int, string>>();
			List<KeyValuePair<int, string>> keyValuePairs = (
				from pair in ItemTypeBc.Instance.GetBathrooms()
				where !pair.Value.Contains(".")
				select pair).Take<KeyValuePair<int, string>>(6).ToList<KeyValuePair<int, string>>();
			communityRefineVm.Amenities = communityDefaultAmenities.MapToSelectListItemList(searchVm.Amenities);
			communityRefineVm.ShcCategories = shcCategoriesForCommunity.MapToSelectListItemList(searchVm.ShcCategories);
			List<KeyValuePair<int, string>> keyValuePairs1 = keyValuePairs;
			int? bathes = searchVm.Bathes;
			if (bathes.HasValue)
			{
				nullable1 = new long?((long)bathes.GetValueOrDefault());
			}
			else
			{
				nullable = null;
				nullable1 = nullable;
			}
			communityRefineVm.Bathes = keyValuePairs1.ToSelectListItemList(nullable1);
			List<KeyValuePair<int, string>> keyValuePairs2 = list;
			bathes = searchVm.Beds;
			if (bathes.HasValue)
			{
				nullable2 = new long?((long)bathes.GetValueOrDefault());
			}
			else
			{
				nullable = null;
				nullable2 = nullable;
			}
			communityRefineVm.Beds = keyValuePairs2.ToSelectListItemList(nullable2);
			communityRefineVm.SortTypes = ConverterHelper.EnumToKoSelectListItems<CommunitySortType>(searchVm.SortType);
			return communityRefineVm;
		}

		internal static CommunityShortVm MapToCommunityShortVm(this Community community, SearchType searchType)
		{
			return community.MapToCommunityShortVm(searchType, null);
		}

		private static CommunityShortVm MapToCommunityShortVm(this Community community, SearchType searchType, CommunityShortVm viewModel)
		{
			CommunityShortVm id = viewModel ?? new CommunityShortVm();
			id.Id = community.Id;
			id.BookNumber = community.BookNumber;
			id.Name = community.Name;
			id.Price = community.Price.PriceCaption(id.Name);
			id.PhotoCount = community.Images.Count<Image>((Image i) => i.Type == ImageType.Image);
			id.Image = community.Images.FirstOrDefault<Image>((Image i) => i.Type == ImageType.Image).MapToImageVm(ImageOwner.Community, id.Name);
			id.Address = community.Address.MapToAddressVm();
			id.DetailsUrl = MslcUrlBuilder.DetailsUrl(id, searchType);
			id.DisplayProperties = new CommunityDisplayProperties(community.DisplayOptions);
			id.Package = (int)community.PackageId;
			return id;
		}

		internal static List<CommunityShortVm> MapToCommunityShortVmList(this List<Community> communities, SearchType searchType)
		{
			return communities.ConvertAll<CommunityShortVm>((Community c) => c.MapToCommunityShortVm(searchType));
		}

		internal static CrosslinksVm MapToCrosslinksVm(this NearbySearchResult searchResult, ISearchCriteria sourceCriteria)
		{
			CrosslinksVm crosslinksVm = new CrosslinksVm();
			foreach (SearchCriteria nearbyCity in searchResult.NearbyCities)
			{
				if (!nearbyCity.MapToSearchCriteriaVm().Validate())
				{
					continue;
				}
				LinkVm linkVm = new LinkVm()
				{
					InnerText = ClientViewModelsProvider.GetLookupLocation(nearbyCity),
					Href = MslcUrlBuilder.SearchUrl(nearbyCity, sourceCriteria.SearchType())
				};
				crosslinksVm.Cities.Add(linkVm);
			}
			foreach (ListingType availableListingType in searchResult.AvailableListingTypes)
			{
				LinkVm linkVm1 = new LinkVm()
				{
					InnerText = availableListingType.GetEnumLocalizedValue<ListingType>(),
					Href = MslcUrlBuilder.SearchUrl(sourceCriteria, availableListingType.ToSearchType())
				};
				crosslinksVm.Categories.Add(linkVm1);
			}
			if (searchResult.IsServiceProvidersAvailable)
			{
				LinkVm linkVm2 = new LinkVm()
				{
					InnerText = "Products & Services",
					Href = MslcUrlBuilder.SearchUrl(sourceCriteria, SearchType.ProductsAndServices)
				};
				crosslinksVm.Categories.Add(linkVm2);
			}
			return crosslinksVm;
		}

		internal static FloorPlanQuickViewVm MapToFloorPlanQuickViewVm(this FloorPlan floorPlan)
		{
			return floorPlan.MapToFloorPlanQuickViewVm(null);
		}

		private static FloorPlanQuickViewVm MapToFloorPlanQuickViewVm(this FloorPlan floorPlan, FloorPlanQuickViewVm viewModel)
		{
			ImageVm imageVm;
			FloorPlanQuickViewVm id = viewModel ?? new FloorPlanQuickViewVm();
			id.Id = floorPlan.Id;
			id.Name = floorPlan.Name;
			id.Price = floorPlan.Price.PriceCaption();
			FloorPlanQuickViewVm floorPlanQuickViewVm = id;
			if (floorPlan.Images.Any<Image>())
			{
				imageVm = floorPlan.Images.First<Image>().MapToImageVm(ImageOwner.CommunityUnit, id.Name);
			}
			else
			{
				imageVm = null;
			}
			floorPlanQuickViewVm.Image = imageVm;
			id.Images = (
				from i in floorPlan.Images
				select i.MapToImageVm(ImageOwner.CommunityUnit, id.Name)).ToList<ImageVm>();
			id.Bathes = floorPlan.Bathes.BathesCaption();
			id.Beds = floorPlan.Beds.BedsCaption();
			id.Area = floorPlan.LivingSpace.AreaCaption();
			id.DisplayProperties = new FloorPlanDisplayProperties();
			id.Package = (int)floorPlan.PackageId;
			return id;
		}

		internal static List<FloorPlanQuickViewVm> MapToFloorPlanQuickViewVmList(this IEnumerable<FloorPlan> floorPlans)
		{
			return floorPlans.Select<FloorPlan, FloorPlanQuickViewVm>(new Func<FloorPlan, FloorPlanQuickViewVm>(SearchExtentions.MapToFloorPlanQuickViewVm)).ToList<FloorPlanQuickViewVm>().FillUnitNames<FloorPlanQuickViewVm>(DisplayNames.FloorPlan);
		}

		internal static FloorPlanVm MapToFloorPlanVm(this FloorPlan floorPlan)
		{
			FloorPlanVm floorPlanQuickViewVm = floorPlan.MapToFloorPlanQuickViewVm(new FloorPlanVm()) as FloorPlanVm;
			if (floorPlanQuickViewVm != null)
			{
				floorPlanQuickViewVm.Deposit = floorPlan.Deposit.PriceCaption();
				floorPlanQuickViewVm.ApplicationFee = floorPlan.ApplicationFee.PriceCaption();
				floorPlanQuickViewVm.PetDeposit = floorPlan.PetDeposit.PriceCaption();
				floorPlanQuickViewVm.Amenities = floorPlan.Amenities;
			}
			return floorPlanQuickViewVm;
		}

		internal static List<FloorPlanVm> MapToFloorPlanVmList(this IEnumerable<FloorPlan> floorPlans)
		{
			return floorPlans.Select<FloorPlan, FloorPlanVm>(new Func<FloorPlan, FloorPlanVm>(SearchExtentions.MapToFloorPlanVm)).ToList<FloorPlanVm>().FillUnitNames<FloorPlanVm>(DisplayNames.FloorPlan);
		}

		internal static HomeQuickViewVm MapToHomeQuickViewVm(this Home home)
		{
			return home.MapToHomeQuickViewVm(null);
		}

		private static HomeQuickViewVm MapToHomeQuickViewVm(this Home home, HomeQuickViewVm viewModel)
		{
			ImageVm imageVm;
			HomeQuickViewVm id = viewModel ?? new HomeQuickViewVm();
			id.Id = home.Id;
			id.Name = home.Name;
			id.Price = home.Price.PriceCaption();
			HomeQuickViewVm homeQuickViewVm = id;
			if (home.Images.Any<Image>())
			{
				imageVm = home.Images.First<Image>().MapToImageVm(ImageOwner.CommunityUnit, id.Name);
			}
			else
			{
				imageVm = null;
			}
			homeQuickViewVm.Image = imageVm;
			id.Images = (
				from i in home.Images
				select i.MapToImageVm(ImageOwner.CommunityUnit, id.Name)).ToList<ImageVm>();
			id.Bathes = home.Bathes.BathesCaption();
			id.Beds = home.Beds.BedsCaption();
			id.Area = home.LivingSpace.AreaCaption();
			id.SaleType = home.SaleType.GetEnumLocalizedValue<SaleType>();
			id.Address = home.Address.MapToAddressVm();
			id.YearBuilt = (home.YearBuilt.HasValue ? home.YearBuilt.Value.ToString(CultureInfo.InvariantCulture) : string.Empty);
			id.DisplayProperties = new HomeDisplayProperties();
			id.Package = (int)home.PackageId;
			return id;
		}

		internal static List<HomeQuickViewVm> MapToHomeQuickViewVmList(this List<Home> homes)
		{
			return homes.Select<Home, HomeQuickViewVm>(new Func<Home, HomeQuickViewVm>(SearchExtentions.MapToHomeQuickViewVm)).ToList<HomeQuickViewVm>().FillUnitNames<HomeQuickViewVm>(DisplayNames.Home);
		}

		internal static HomeVm MapToHomeVm(this Home home)
		{
			HomeVm homeQuickViewVm = home.MapToHomeQuickViewVm(new HomeVm()) as HomeVm;
			if (homeQuickViewVm != null)
			{
				homeQuickViewVm.Description = home.Description;
				homeQuickViewVm.Deposit = home.Deposit.PriceCaption();
				homeQuickViewVm.ApplicationFee = home.ApplicationFee.PriceCaption();
				homeQuickViewVm.PetDeposit = home.PetDeposit.PriceCaption();
				homeQuickViewVm.Amenities = home.Amenities;
			}
			return homeQuickViewVm;
		}

		internal static List<HomeVm> MapToHomeVmList(this List<Home> homes)
		{
			return homes.Select<Home, HomeVm>(new Func<Home, HomeVm>(SearchExtentions.MapToHomeVm)).ToList<HomeVm>().FillUnitNames<HomeVm>(DisplayNames.Home);
		}

		internal static LookupLocationValidationVm MapToLookupLocationValidationVm(this LookupLocationValidationResult validationResult, SearchType searchType)
		{
			LookupLocationValidationVm lookupLocationValidationVm = new LookupLocationValidationVm();
			if (validationResult.IsValid && validationResult.Criteria.Depth == SearchDepth.Zip)
			{
				SearchCriteria searchCriterium = new SearchCriteria();
				searchCriterium.CountryCode(validationResult.Criteria.CountryCode());
				searchCriterium.StateCode(validationResult.Criteria.StateCode());
				if (!validationResult.Criteria.City().IsNullOrEmpty())
				{
					searchCriterium.City(validationResult.Criteria.City());
				}
				validationResult.Criteria = searchCriterium;
			}
			lookupLocationValidationVm.IsValid = validationResult.IsValid;
			lookupLocationValidationVm.Criteria = (lookupLocationValidationVm.IsValid ? validationResult.Criteria.MapToSearchCriteriaVm(searchType) : new SearchCriteriaVm());
			lookupLocationValidationVm.Variants = (lookupLocationValidationVm.IsValid ? new List<AutocompleteVm>() : validationResult.Variants.MapToAutocompleteVmList(searchType, string.Empty));
			lookupLocationValidationVm.SearchUrl = (lookupLocationValidationVm.IsValid ? MslcUrlBuilder.SearchUrl(validationResult.Criteria, searchType) : string.Empty);
			return lookupLocationValidationVm;
		}

		internal static SearchCriteriaVm MapToSearchCriteriaVm(this SearchCriteria criteria)
		{
			return new SearchCriteriaVm(criteria.Components, new SearchDepth?(criteria.Depth));
		}

		internal static SearchCriteriaVm MapToSearchCriteriaVm(this SearchCriteria criteria, SearchType searchType)
		{
			SearchCriteriaVm searchCriteriaVm = criteria.MapToSearchCriteriaVm();
			searchCriteriaVm.SearchType(searchType);
			return searchCriteriaVm;
		}

		internal static SearchCriteriaVm MapToSearchCriteriaVm(this AddressVm addressVm, SearchType searchType)
		{
			SearchCriteriaVm searchCriteriaVm = new SearchCriteriaVm();
			searchCriteriaVm.SearchType(searchType);
			searchCriteriaVm.CountryCode(addressVm.CountryCode);
			searchCriteriaVm.StateCode(addressVm.StateCode);
			searchCriteriaVm.City(addressVm.City);
			return searchCriteriaVm;
		}

		internal static ServiceProviderBlockVm MapToServiceProviderBlockVm(this ServiceProvider serviceProvider)
		{
			ServiceProviderBlockVm serviceProviderBlockVm = serviceProvider.MapToServiceProviderBlockVm(null);
			if(serviceProviderBlockVm.ServiceCategories != null)
				serviceProviderBlockVm.ServiceCategories = serviceProviderBlockVm.ServiceCategories.Take<string>(SearchExtentions.Config.SearchAmenitiesListMaxCount).ToList<string>();
			serviceProviderBlockVm.Images = serviceProviderBlockVm.Images.TakeExceptFirst<ImageVm>(SearchExtentions.Config.AdditionalImagesMaxCount).ToList<ImageVm>();
			return serviceProviderBlockVm;
		}

		private static ServiceProviderBlockVm MapToServiceProviderBlockVm(this ServiceProvider serviceProvider, ServiceProviderBlockVm viewModel)
		{
			ServiceProviderBlockVm serviceProviderShortVm = serviceProvider.MapToServiceProviderShortVm(viewModel ?? new ServiceProviderBlockVm()) as ServiceProviderBlockVm;
			if (serviceProviderShortVm != null)
			{
				serviceProviderShortVm.Description = serviceProvider.Description;
				serviceProviderShortVm.CountiesServed = serviceProvider.CountiesServed;
				serviceProviderShortVm.ServiceCategories = serviceProvider.ServiceCategories;
				serviceProviderShortVm.Images = (serviceProvider.Images.Any<Image>((Image i) => i.Type == ImageType.Image) ? (
					from i in serviceProvider.Images
					where i.Type == ImageType.Image
					select i).ToList<Image>().ConvertAll<ImageVm>((Image i) => i.MapToImageVm(ImageOwner.Service, serviceProviderShortVm.Name)) : new List<ImageVm>());
				serviceProviderShortVm.Phone = serviceProvider.Phone;
				serviceProviderShortVm.SearchRadiusDesignation = (serviceProvider.SearchResultRadius > 0 ? string.Format(StaticContent.Txt_SearchRadiusDesignation, serviceProvider.SearchResultRadius) : string.Empty);
				serviceProviderShortVm.PrintUrl = MslcUrlBuilder.PrintUrl(serviceProvider);
				serviceProviderShortVm.PrintDirectionBaseUrl = MslcUrlBuilder.PrintDirectionBaseUrl(serviceProvider);
			}
			return serviceProviderShortVm;
		}

		internal static List<ServiceProviderBlockVm> MapToServiceProviderBlockVmList(this List<ServiceProvider> serviceProviders)
		{
			return serviceProviders.ConvertAll<ServiceProviderBlockVm>((ServiceProvider c) => c.MapToServiceProviderBlockVm());
		}

		internal static ServiceProviderDetailsVm MapToServiceProviderDetailsVm(this ServiceProvider serviceProvider)
		{
			return serviceProvider.MapToServiceProviderDetailsVm(null);
		}

		private static ServiceProviderDetailsVm MapToServiceProviderDetailsVm(this ServiceProvider serviceProvider, ServiceProviderDetailsVm viewModel)
		{
			ServiceProviderDetailsVm serviceProviderQuickViewVm = viewModel ?? new ServiceProviderDetailsVm();
			serviceProviderQuickViewVm.PageType = PageType.ServiceProviderDetails;
			serviceProviderQuickViewVm.ServiceProvider = serviceProvider.MapToServiceProviderQuickViewVm();
			serviceProviderQuickViewVm.Criteria = serviceProviderQuickViewVm.ServiceProvider.Address.MapToSearchCriteriaVm(SearchType.ProductsAndServices);
			serviceProviderQuickViewVm.Coupon = serviceProvider.Coupon.MapToCouponVm(MslcUrlBuilder.PrintCouponUrl(serviceProvider));
			serviceProviderQuickViewVm.OfficeHours = (
				from oh in serviceProvider.OfficeHours
				select oh.ToString()).ToList<string>();
			serviceProviderQuickViewVm.WebsiteUrl = serviceProvider.WebsiteUrl.ExternalUrl();
			serviceProviderQuickViewVm.PaymentsAccepted = serviceProvider.AcceptedPayments;
			serviceProviderQuickViewVm.DisplayProperties = new DetailsDisplayProperties();
			return serviceProviderQuickViewVm;
		}

		internal static ServiceProviderPrintDirectionVm MapToServiceProviderPrintDirectionVm(this ServiceProvider serviceProvider, double latitude, double longitude)
		{
			ServiceProviderPrintDirectionVm serviceProviderDetailsVm = serviceProvider.MapToServiceProviderDetailsVm(new ServiceProviderPrintDirectionVm()) as ServiceProviderPrintDirectionVm;
			if (serviceProviderDetailsVm != null)
			{
				serviceProviderDetailsVm.StartLatitude = latitude;
				serviceProviderDetailsVm.StartLongitude = longitude;
			}
			return serviceProviderDetailsVm;
		}

		internal static ServiceProviderQuickViewVm MapToServiceProviderQuickViewVm(this ServiceProvider serviceProvider)
		{
			ServiceProviderQuickViewVm serviceProviderBlockVm = serviceProvider.MapToServiceProviderBlockVm(new ServiceProviderQuickViewVm()) as ServiceProviderQuickViewVm;
			if (serviceProviderBlockVm != null)
			{
				serviceProviderBlockVm.Description = serviceProvider.Description;
			}
			return serviceProviderBlockVm;
		}

		internal static ServiceProviderRefineVm MapToServiceProviderRefineVm(this ServiceProvidersSearchVm searchVm)
		{
			ServiceProviderRefineVm serviceProviderRefineVm = new ServiceProviderRefineVm();
			List<KeyValuePair<int, string>> shcCategoriesForServiceProvider = ItemTypeBc.Instance.GetShcCategoriesForServiceProvider();
			serviceProviderRefineVm.ServiceCategories = shcCategoriesForServiceProvider.MapToSelectListItemList(searchVm.ServiceCategories);
			serviceProviderRefineVm.SortTypes = ConverterHelper.EnumToKoSelectListItems<ServiceProviderSortType>(searchVm.SortType);
			return serviceProviderRefineVm;
		}

		internal static ServiceProviderShortVm MapToServiceProviderShortVm(this ServiceProvider serviceProvider)
		{
			return serviceProvider.MapToServiceProviderShortVm(null);
		}

		private static ServiceProviderShortVm MapToServiceProviderShortVm(this ServiceProvider serviceProvider, ServiceProviderShortVm viewModel)
		{
			ServiceProviderShortVm id = viewModel ?? new ServiceProviderShortVm();
			id.Id = serviceProvider.Id;
			id.BookNumber = serviceProvider.BookNumber;
			id.Name = serviceProvider.Name;
			id.PhotoCount = serviceProvider.Images.Count<Image>((Image i) => i.Type == ImageType.Image);
			id.Image = serviceProvider.Images.FirstOrDefault<Image>((Image i) => i.Type == ImageType.Image).MapToImageVm(ImageOwner.Service, id.Name);
			id.Address = serviceProvider.Address.MapToAddressVm();
			id.DetailsUrl = MslcUrlBuilder.DetailsUrl(id);
			id.DisplayProperties = new ServiceProviderDisplayProperties(serviceProvider.DisplayOptions);
			id.Package = (int)serviceProvider.PackageId;
			return id;
		}

		internal static List<ServiceProviderShortVm> MapToServiceProviderShortVmList(this List<ServiceProvider> serviceProviders)
		{
			return serviceProviders.ConvertAll<ServiceProviderShortVm>(new Converter<ServiceProvider, ServiceProviderShortVm>(SearchExtentions.MapToServiceProviderShortVm));
		}

		internal static SpecHomeQuickViewVm MapToSpecHomeQuickViewVm(this SpecHome specHome)
		{
			return specHome.MapToSpecHomeQuickViewVm(null);
		}

		private static SpecHomeQuickViewVm MapToSpecHomeQuickViewVm(this SpecHome specHome, SpecHomeQuickViewVm viewModel)
		{
			ImageVm imageVm;
			SpecHomeQuickViewVm id = viewModel ?? new SpecHomeQuickViewVm();
			id.Id = specHome.Id;
			id.Name = specHome.Name;
			id.Price = specHome.Price.PriceCaption();
			SpecHomeQuickViewVm specHomeQuickViewVm = id;
			if (specHome.Images.Any<Image>())
			{
				imageVm = specHome.Images.First<Image>().MapToImageVm(ImageOwner.CommunityUnit, id.Name);
			}
			else
			{
				imageVm = null;
			}
			specHomeQuickViewVm.Image = imageVm;
			id.Images = (
				from i in specHome.Images
				select i.MapToImageVm(ImageOwner.CommunityUnit, id.Name)).ToList<ImageVm>();
			id.Bathes = specHome.Bathes.BathesCaption();
			id.Beds = specHome.Beds.BedsCaption();
			id.Area = specHome.LivingSpace.AreaCaption();
			id.SaleType = specHome.SaleType.GetEnumLocalizedValue<SaleType>();
			id.Status = specHome.Status.GetEnumLocalizedValue<BuildStatus>();
			id.DisplayProperties = new SpecHomeDisplayProperties();
			id.Package = (int)specHome.PackageId;
			return id;
		}

		internal static List<SpecHomeQuickViewVm> MapToSpecHomeQuickViewVmList(this List<SpecHome> specHomes)
		{
			return specHomes.Select<SpecHome, SpecHomeQuickViewVm>(new Func<SpecHome, SpecHomeQuickViewVm>(SearchExtentions.MapToSpecHomeQuickViewVm)).ToList<SpecHomeQuickViewVm>().FillUnitNames<SpecHomeQuickViewVm>(DisplayNames.SpecHome);
		}

		internal static SpecHomeVm MapToSpecHomeVm(this SpecHome specHome)
		{
			SpecHomeVm specHomeQuickViewVm = specHome.MapToSpecHomeQuickViewVm(new SpecHomeVm()) as SpecHomeVm;
			if (specHomeQuickViewVm != null)
			{
				specHomeQuickViewVm.Deposit = specHome.Deposit.PriceCaption();
				specHomeQuickViewVm.ApplicationFee = specHome.ApplicationFee.PriceCaption();
				specHomeQuickViewVm.PetDeposit = specHome.PetDeposit.PriceCaption();
				specHomeQuickViewVm.Amenities = specHome.Amenities;
				specHomeQuickViewVm.Description = specHome.Description;
			}
			return specHomeQuickViewVm;
		}

		internal static List<SpecHomeVm> MapToSpecHomeVmList(this List<SpecHome> specHomes)
		{
			return specHomes.Select<SpecHome, SpecHomeVm>(new Func<SpecHome, SpecHomeVm>(SearchExtentions.MapToSpecHomeVm)).ToList<SpecHomeVm>().FillUnitNames<SpecHomeVm>(DisplayNames.SpecHome);
		}

		internal static CommunityNearbySearchModel ToCommunityNearbySearchModel(this CommunitiesSearchVm searchVm)
		{
			return new CommunityNearbySearchModel()
			{
				Criteria = searchVm.Criteria.ToSearchCriteria(),
				ListingType = searchVm.Criteria.SearchType().ToListingType(),
				MaxCount = SearchExtentions.Config.NearbyCitiesMaxCount
			};
		}

		internal static CommunitySearchModel ToCommunitySearchModel(this CommunitiesSearchVm searchVm)
		{
			long? nullable;
			long? nullable1;
			long? nullable2;
			CommunitySearchModel communitySearchModel = new CommunitySearchModel()
			{
				Criteria = searchVm.Criteria.ToSearchCriteria(),
				PageNumber = searchVm.PageNumber,
				PageSize = SearchExtentions.Config.DefaultPageSize,
				SortType = searchVm.SortType,
				ListingType = searchVm.Criteria.SearchType().ToListingType(),
				MaxPrice = searchVm.MaxPrice,
				MinPrice = searchVm.MinPrice
			};
			int? bathes = searchVm.Bathes;
			if (bathes.HasValue)
			{
				nullable1 = new long?((long)bathes.GetValueOrDefault());
			}
			else
			{
				nullable = null;
				nullable1 = nullable;
			}
			communitySearchModel.BathroomFromId = nullable1;
			bathes = searchVm.Beds;
			if (bathes.HasValue)
			{
				nullable2 = new long?((long)bathes.GetValueOrDefault());
			}
			else
			{
				nullable = null;
				nullable2 = nullable;
			}
			communitySearchModel.BedroomFromId = nullable2;
			communitySearchModel.AmenitiesIds = (
				from a in searchVm.Amenities
				select (long)a).ToList<long>();
			communitySearchModel.ShcCategoriesIds = (
				from a in searchVm.ShcCategories
				select (long)a).ToList<long>();
			return communitySearchModel;
		}

		internal static FeaturedCommunitySearchModel ToFeaturedCommunitySearchModel(this CommunitiesSearchVm searchVm)
		{
			return new FeaturedCommunitySearchModel()
			{
				Criteria = searchVm.Criteria.ToSearchCriteria(),
				MaxCount = SearchExtentions.Config.FeaturedCommunitiesMaxCount,
				ListingType = searchVm.Criteria.SearchType().ToListingType()
			};
		}

		internal static FeaturedServiceProviderSearchModel ToFeaturedServiceProviderSearchModel(this SearchVm searchVm, long? communityId = null, long? serviceId = null)
		{
			return new FeaturedServiceProviderSearchModel()
			{
				Criteria = searchVm.Criteria.ToSearchCriteria(),
				MaxCount = SearchExtentions.Config.FeaturedProvidersMaxCount,
				CommunityId = communityId,
				ServiceId = serviceId
			};
		}

		internal static NearbySearchModel ToNearbySearchModel(this ServiceProvidersSearchVm searchVm)
		{
			return new NearbySearchModel()
			{
				Criteria = searchVm.Criteria.ToSearchCriteria(),
				MaxCount = SearchExtentions.Config.NearbyCitiesMaxCount
			};
		}

		internal static ServiceProviderSearchModel ToServiceProviderSearchModel(this ServiceProvidersSearchVm searchVm)
		{
			return new ServiceProviderSearchModel()
			{
				Criteria = searchVm.Criteria.ToSearchCriteria(),
				PageNumber = searchVm.PageNumber,
				PageSize = SearchExtentions.Config.DefaultPageSize,
				ServiceCategoriesIds = (
					from a in searchVm.ServiceCategories
					select (long)a).ToList<long>(),
				SortType = searchVm.SortType
			};
		}
	}
}