using MSLivingChoices.Entities.Client;
using MSLivingChoices.Entities.Client.Enums;
using MSLivingChoices.Entities.Client.Search;
using MSLivingChoices.IDacs.Client.Components;
using MSLivingChoices.SqlDacs.Client.SqlCommands;
using MSLivingChoices.SqlDacs.SqlCommands;
using System;
using System.Collections.Generic;

namespace MSLivingChoices.SqlDacs.Client.Components
{
	public class SqlSearchDac : ISearchDac
	{
		public SqlSearchDac()
		{
		}

		public Community GetCommunityById(long id)
		{
			GetCommunityByIdCommand getCommunityByIdCommand = new GetCommunityByIdCommand(id);
			getCommunityByIdCommand.Execute();
			return getCommunityByIdCommand.CommandResult;
		}

		public List<FloorPlan> GetFloorPlans(long communityId)
		{
			GetFloorPlansByCommunityIdCommand getFloorPlansByCommunityIdCommand = new GetFloorPlansByCommunityIdCommand(communityId);
			getFloorPlansByCommunityIdCommand.Execute();
			return getFloorPlansByCommunityIdCommand.CommandResult;
		}

		public List<Home> GetHomes(long communityId)
		{
			GetHomesByCommunityIdCommand getHomesByCommunityIdCommand = new GetHomesByCommunityIdCommand(communityId);
			getHomesByCommunityIdCommand.Execute();
			return getHomesByCommunityIdCommand.CommandResult;
		}

		public ServiceProvider GetServiceById(long id)
		{
			GetServiceByIdCommand getServiceByIdCommand = new GetServiceByIdCommand(id);
			getServiceByIdCommand.Execute();
			return getServiceByIdCommand.CommandResult;
		}

		public List<SpecHome> GetSpecHomes(long communityId)
		{
			GetSpecHomesByCommunityIdCommand getSpecHomesByCommunityIdCommand = new GetSpecHomesByCommunityIdCommand(communityId);
			getSpecHomesByCommunityIdCommand.Execute();
			return getSpecHomesByCommunityIdCommand.CommandResult;
		}

		public CommunitySearchModel SearchCommunities(CommunitySearchModel searchModel)
		{
			SearchCommunitiesCommand searchCommunitiesCommand = new SearchCommunitiesCommand(searchModel);
			searchCommunitiesCommand.Execute();
			return searchCommunitiesCommand.CommandResult;
		}

		public CommunityCountryStubSearchModel SearchCountryStubCitiesWithCommunities(CommunityCountryStubSearchModel searchModel)
		{
			GetCountrySearchStubCommand getCountrySearchStubCommand = new GetCountrySearchStubCommand(searchModel, new ListingType?(searchModel.ListingType));
			getCountrySearchStubCommand.Execute();
			searchModel.Result = getCountrySearchStubCommand.CommandResult;
			return searchModel;
		}

		public CountryStubSearchModel SearchCountryStubCitiesWithServices(CountryStubSearchModel searchModel)
		{
			GetCountrySearchStubCommand getCountrySearchStubCommand = new GetCountrySearchStubCommand(searchModel, null);
			getCountrySearchStubCommand.Execute();
			searchModel.Result = getCountrySearchStubCommand.CommandResult;
			return searchModel;
		}

		public FeaturedCommunitySearchModel SearchFeaturedCommunities(FeaturedCommunitySearchModel searchModel)
		{
			SearchFeaturedCommunitiesCommand searchFeaturedCommunitiesCommand = new SearchFeaturedCommunitiesCommand(searchModel);
			searchFeaturedCommunitiesCommand.Execute();
			return searchFeaturedCommunitiesCommand.CommandResult;
		}
		public FeaturedCommunitySearchModel SearchFeaturedCommunities(FeaturedCommunitySearchModel searchModel,long CommunityID)
		{
			SearchFeaturedCommunitiesCommand searchFeaturedCommunitiesCommand = new SearchFeaturedCommunitiesCommand(searchModel, CommunityID);
			searchFeaturedCommunitiesCommand.Execute();
			return searchFeaturedCommunitiesCommand.CommandResult;
		}
		public FeaturedServiceProviderSearchModel SearchFeaturedServiceProviders(FeaturedServiceProviderSearchModel searchModel)
		{
			SearchFeaturedServicesCommand searchFeaturedServicesCommand = new SearchFeaturedServicesCommand(searchModel);
			searchFeaturedServicesCommand.Execute();
			return searchFeaturedServicesCommand.CommandResult;
		}
		public FeaturedServiceProviderSearchModel SearchFeaturedServiceProviders(FeaturedServiceProviderSearchModel searchModel,long SimilarId)
		{
			SearchFeaturedServicesCommand searchFeaturedServicesCommand = new SearchFeaturedServicesCommand(searchModel, SimilarId);
			searchFeaturedServicesCommand.Execute();
			return searchFeaturedServicesCommand.CommandResult;
		}

		public CommunityNearbySearchModel SearchNearbyCommunities(CommunityNearbySearchModel searchModel)
		{
			GetNearbyCitiesCommand getNearbyCitiesCommand = new GetNearbyCitiesCommand(searchModel, new ListingType?(searchModel.ListingType));
			getNearbyCitiesCommand.Execute();
			searchModel.Result = getNearbyCitiesCommand.CommandResult;
			return searchModel;
		}

		public NearbySearchModel SearchNearbyServiceProviders(NearbySearchModel searchModel)
		{
			GetNearbyCitiesCommand getNearbyCitiesCommand = new GetNearbyCitiesCommand(searchModel, null);
			getNearbyCitiesCommand.Execute();
			searchModel.Result = getNearbyCitiesCommand.CommandResult;
			return searchModel;
		}

		public ServiceProviderSearchModel SearchServiceProviders(ServiceProviderSearchModel searchModel)
		{
			SearchServiceProvidersCommand searchServiceProvidersCommand = new SearchServiceProvidersCommand(searchModel);
			searchServiceProvidersCommand.Execute();
			return searchServiceProvidersCommand.CommandResult;
		}
	}
}