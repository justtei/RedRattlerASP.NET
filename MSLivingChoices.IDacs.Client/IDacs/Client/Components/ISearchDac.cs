using MSLivingChoices.Entities.Client;
using MSLivingChoices.Entities.Client.Search;
using System;
using System.Collections.Generic;

namespace MSLivingChoices.IDacs.Client.Components
{
	public interface ISearchDac
	{
		Community GetCommunityById(long id);

		List<FloorPlan> GetFloorPlans(long communityId);

		List<Home> GetHomes(long communityId);

		ServiceProvider GetServiceById(long id);

		List<SpecHome> GetSpecHomes(long communityId);

		CommunitySearchModel SearchCommunities(CommunitySearchModel searchModel);

		CommunityCountryStubSearchModel SearchCountryStubCitiesWithCommunities(CommunityCountryStubSearchModel searchModel);

		CountryStubSearchModel SearchCountryStubCitiesWithServices(CountryStubSearchModel searchModel);

		FeaturedCommunitySearchModel SearchFeaturedCommunities(FeaturedCommunitySearchModel searchModel);
		FeaturedCommunitySearchModel SearchFeaturedCommunities(FeaturedCommunitySearchModel searchModel,long SimilarCommunityId);

		FeaturedServiceProviderSearchModel SearchFeaturedServiceProviders(FeaturedServiceProviderSearchModel searchModel);
		FeaturedServiceProviderSearchModel SearchFeaturedServiceProviders(FeaturedServiceProviderSearchModel searchModel,long SimilarId);

		CommunityNearbySearchModel SearchNearbyCommunities(CommunityNearbySearchModel searchModel);

		NearbySearchModel SearchNearbyServiceProviders(NearbySearchModel searchModel);

		ServiceProviderSearchModel SearchServiceProviders(ServiceProviderSearchModel searchModel);
	}
}