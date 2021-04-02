using MSLivingChoices.Bcs.Client;
using MSLivingChoices.Entities.Client;
using MSLivingChoices.Entities.Client.Enums;
using MSLivingChoices.Entities.Client.Search;
using MSLivingChoices.Entities.Client.Search.Criteria;
using MSLivingChoices.Entities.Client.Utils;
using MSLivingChoices.IDacs.Client;
using MSLivingChoices.IDacs.Client.Components;
using MSLivingChoices.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Bcs.Client.Components
{
	public class SearchBc
	{
		private readonly ISearchDac _searchDac;

		private static SearchBc _searchBc;

		private readonly static object Locker;

		public static SearchBc Instance
		{
			get
			{
				if (SearchBc._searchBc == null)
				{
					lock (SearchBc.Locker)
					{
						if (SearchBc._searchBc == null)
						{
							SearchBc._searchBc = new SearchBc();
						}
					}
				}
				return SearchBc._searchBc;
			}
		}

		static SearchBc()
		{
			SearchBc.Locker = new object();
		}

		private SearchBc()
		{
			this._searchDac = ClientDacFactoryClient.GetConcreteFactory().GetSearchDac();
		}

		public Community GetCommunity(long communityId)
		{
			return this._searchDac.GetCommunityById(communityId);
		}

		public List<FloorPlan> GetFloorPlans(long communityId)
		{
			return this._searchDac.GetFloorPlans(communityId);
		}

		public List<Home> GetHomes(long communityId)
		{
			return this._searchDac.GetHomes(communityId);
		}

		public ServiceProvider GetServiceProvider(long serviceProviderId)
		{
			return this._searchDac.GetServiceById(serviceProviderId);
		}

		public List<SpecHome> GetSpecHomes(long communityId)
		{
			return this._searchDac.GetSpecHomes(communityId);
		}

		public CommunitySearchModel SearchCommunities(CommunitySearchModel searchModel)
		{
			SearchCriteria criteria = searchModel.Criteria;
			searchModel.Criteria = searchModel.Criteria.ToSearchableCriteria();
			searchModel = this._searchDac.SearchCommunities(searchModel);
			searchModel.Criteria = criteria;
			return searchModel;
		}

		public CommunityCountryStubSearchModel SearchCommunitiesStubCities(CommunityCountryStubSearchModel searchModel)
		{
			SearchCriteria criteria = searchModel.Criteria;
			searchModel.Criteria = searchModel.Criteria.ToSearchableCriteria();
			searchModel = this._searchDac.SearchCountryStubCitiesWithCommunities(searchModel);
			searchModel.Criteria = criteria;
			return searchModel;
		}
		public FeaturedCommunitySearchModel SearchFeaturedCommunities(FeaturedCommunitySearchModel searchModel)
		{
			SearchCriteria criteria = searchModel.Criteria;
			searchModel.Criteria = searchModel.Criteria.ToSearchableCriteria();
			searchModel = this._searchDac.SearchFeaturedCommunities(searchModel);
			searchModel.Criteria = criteria;
			return searchModel;
		}
		public FeaturedCommunitySearchModel SearchFeaturedCommunities(FeaturedCommunitySearchModel searchModel,long SimilarId)
		{
			SearchCriteria criteria = searchModel.Criteria;
			searchModel.Criteria = searchModel.Criteria.ToSearchableCriteria();
			searchModel = this._searchDac.SearchFeaturedCommunities(searchModel,SimilarId);
			searchModel.Criteria = criteria;
			return searchModel;
		}

		public FeaturedServiceProviderSearchModel SearchFeaturedServiceProviders(FeaturedServiceProviderSearchModel searchModel)
		{
			SearchCriteria criteria = searchModel.Criteria;
			searchModel.Criteria = searchModel.Criteria.ToSearchableCriteria();
			searchModel = this._searchDac.SearchFeaturedServiceProviders(searchModel);
			searchModel.Criteria = criteria;
			return searchModel;
		}
		public FeaturedServiceProviderSearchModel SearchFeaturedServiceProviders(FeaturedServiceProviderSearchModel searchModel,long SimilarId)
		{
			SearchCriteria criteria = searchModel.Criteria;
			searchModel.Criteria = searchModel.Criteria.ToSearchableCriteria();
			searchModel = this._searchDac.SearchFeaturedServiceProviders(searchModel,SimilarId);
			searchModel.Criteria = criteria;
			return searchModel;
		}

		public CommunityNearbySearchModel SearchNearbyCommunities(CommunityNearbySearchModel searchModel)
		{
			SearchCriteria criteria = searchModel.Criteria;
			searchModel.Criteria = searchModel.Criteria.ToSearchableCriteria();
			searchModel = this._searchDac.SearchNearbyCommunities(searchModel);
			searchModel.Criteria = criteria;
			return searchModel;
		}

		public NearbySearchModel SearchNearbyServiceProviders(NearbySearchModel searchModel)
		{
			SearchCriteria criteria = searchModel.Criteria;
			searchModel.Criteria = searchModel.Criteria.ToSearchableCriteria();
			searchModel = this._searchDac.SearchNearbyServiceProviders(searchModel);
			searchModel.Criteria = criteria;
			return searchModel;
		}

		public ServiceProviderSearchModel SearchServiceProviders(ServiceProviderSearchModel searchModel)
		{
			SearchCriteria criteria = searchModel.Criteria;
			searchModel.Criteria = searchModel.Criteria.ToSearchableCriteria();
			searchModel = this._searchDac.SearchServiceProviders(searchModel);
			searchModel.Criteria = criteria;
			return searchModel;
		}

		public CountryStubSearchModel SearchServiceProvidersStubCities(CountryStubSearchModel searchModel)
		{
			SearchCriteria criteria = searchModel.Criteria;
			searchModel.Criteria = searchModel.Criteria.ToSearchableCriteria();
			searchModel = this._searchDac.SearchCountryStubCitiesWithServices(searchModel);
			searchModel.Criteria = criteria;
			return searchModel;
		}

		public CountryStubSearchModel SearchStubCities(CountryStubSearchModel searchModel)
		{
			SearchCriteria criteria = searchModel.Criteria;
			searchModel.Criteria = searchModel.Criteria.ToSearchableCriteria();
			searchModel = this._searchDac.SearchCountryStubCitiesWithServices(searchModel);
			searchModel.Criteria = criteria;
			CommunityCountryStubSearchModel communityCountryStubSearchModel = new CommunityCountryStubSearchModel()
			{
				Criteria = searchModel.Criteria,
				ListingType = ListingType.ActiveAdultCommunities,
				MaxCount = searchModel.MaxCount,
				IsMarketAreaOnly = searchModel.IsMarketAreaOnly
			};
			searchModel.Result.AddRange(this.SearchCommunitiesStubCities(communityCountryStubSearchModel).Result);
			communityCountryStubSearchModel.ListingType = ListingType.ActiveAdultHomes;
			searchModel.Result.AddRange(this.SearchCommunitiesStubCities(communityCountryStubSearchModel).Result);
			communityCountryStubSearchModel.ListingType = ListingType.SeniorHousingAndCare;
			searchModel.Result.AddRange(this.SearchCommunitiesStubCities(communityCountryStubSearchModel).Result);
			searchModel.Result = searchModel.Result.DistinctBy<CityListingsInfo, ISearchCriteria>((CityListingsInfo i) => i.SearchCriteria, new SearchCriteriaComparer()).ToList<CityListingsInfo>();
			return searchModel;
		}
	}
}