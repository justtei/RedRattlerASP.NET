using MSLivingChoices.Configuration;
using MSLivingChoices.Entities.Admin;
using MSLivingChoices.Entities.Admin.Enums;
using MSLivingChoices.IDacs.Admin.Components;
using MSLivingChoices.SqlDacs.Admin;
using MSLivingChoices.SqlDacs.Admin.SqlCommands;
using MSLivingChoices.SqlDacs.SqlCommands;
using System;
using System.Collections.Generic;

namespace MSLivingChoices.SqlDacs.Admin.Components
{
	public class SqlCommunityDac : ICommunityDac
	{
		public List<Community> GetAll(List<Book> books, int? pageNumber, int? pageSize, CommunityGridSortByOption? sortBy, OrderBy? orderBy, CommunityGridFilter filter, out int totalCount)
		{
			pageNumber = pageNumber ?? ConfigurationManager.Instance.DefaultGridPageNumber;
			pageSize = pageSize ?? ConfigurationManager.Instance.DefaultGridPageSize;
			GetCommunityGridCommand command = new GetCommunityGridCommand(books, pageNumber.Value, pageSize.Value, sortBy, orderBy, filter);
			command.Execute();
			totalCount = command.GetTotalCount();
			return command.CommandResult;
		}

		public void Delete(long id)
		{
			new DeleteCommunityByIdCommand(id).Execute();
		}

		public Community GetById(long id)
		{
			GetCommunityByIdCommand getCommunityByIdCommand = new GetCommunityByIdCommand(id);
			getCommunityByIdCommand.Execute();
			return getCommunityByIdCommand.CommandResult;
		}

		public Community SaveNewCommunity(Community community, int publishTypeId, int showcaseTypeId, int couponTypeId, int customCommunityServiceTypeId)
		{
			if (community.Builder != null && !community.Builder.Id.HasValue)
			{
				community.Builder = SaveOwner(community.Builder);
			}
			if (community.PropertyManager != null && !community.PropertyManager.Id.HasValue)
			{
				community.PropertyManager = SaveOwner(community.PropertyManager);
			}
			SaveNewCommunityCommand saveNewCommunityCommand = new SaveNewCommunityCommand(community, publishTypeId, showcaseTypeId, couponTypeId, customCommunityServiceTypeId);
			saveNewCommunityCommand.Execute();
			community = saveNewCommunityCommand.CommandResult;
			int floorPlanCount = community.FloorPlans.Count;
			for (int k = 0; k < floorPlanCount; k++)
			{
				community.FloorPlans[k] = SaveFloorPlan(community.FloorPlans[k], k + 1, couponTypeId);
			}
			int specHomeCount = community.SpecHomes.Count;
			for (int j = 0; j < specHomeCount; j++)
			{
				community.SpecHomes[j] = SaveSpecHome(community.SpecHomes[j], j + 1, couponTypeId);
			}
			int housesCount = community.Houses.Count;
			for (int i = 0; i < housesCount; i++)
			{
				community.Houses[i] = SaveHouse(community.Houses[i], i + 1, couponTypeId);
			}
			return community;
		}

		public FloorPlan SaveFloorPlan(FloorPlan floorPlan, int sequence, int couponTypeId)
		{
			SaveFloorPlanCommand saveFloorPlanCommand = new SaveFloorPlanCommand(floorPlan, sequence, couponTypeId);
			saveFloorPlanCommand.Execute();
			return saveFloorPlanCommand.CommandResult;
		}

		public SpecHome SaveSpecHome(SpecHome specHome, int sequence, int couponTypeId)
		{
			SaveSpecHomeCommand saveSpecHomeCommand = new SaveSpecHomeCommand(specHome, sequence, couponTypeId);
			saveSpecHomeCommand.Execute();
			return saveSpecHomeCommand.CommandResult;
		}

		public House SaveHouse(House house, int sequence, int couponTypeId)
		{
			SaveHouseCommand saveHouseCommand = new SaveHouseCommand(house, sequence, couponTypeId);
			saveHouseCommand.Execute();
			return saveHouseCommand.CommandResult;
		}

		public Owner SaveOwner(Owner owner)
		{
			SaveOwnerCommand saveOwnerCommand = new SaveOwnerCommand(owner);
			saveOwnerCommand.Execute();
			return saveOwnerCommand.CommandResult;
		}

		public Community SaveEditedCommunity(Community community, int publishTypeId, int showcaseTypeId, int couponTypeId, int customCommunityServiceTypeId)
		{
			if (community.Builder != null && !community.Builder.Id.HasValue)
			{
				community.Builder = SaveOwner(community.Builder);
			}
			if (community.PropertyManager != null && !community.PropertyManager.Id.HasValue)
			{
				community.PropertyManager = SaveOwner(community.PropertyManager);
			}
			if (community.FloorPlans != null)
			{
				for (int k = 0; k < community.FloorPlans.Count; k++)
				{
					community.FloorPlans[k] = SaveFloorPlan(community.FloorPlans[k], k + 1, couponTypeId);
				}
			}
			if (community.SpecHomes != null)
			{
				for (int j = 0; j < community.SpecHomes.Count; j++)
				{
					community.SpecHomes[j] = SaveSpecHome(community.SpecHomes[j], j + 1, couponTypeId);
				}
			}
			if (community.Houses != null)
			{
				for (int i = 0; i < community.Houses.Count; i++)
				{
					community.Houses[i] = SaveHouse(community.Houses[i], i + 1, couponTypeId);
				}
			}
			SaveCommunityCommand saveCommunityCommand = new SaveCommunityCommand(community, publishTypeId, showcaseTypeId, couponTypeId, customCommunityServiceTypeId);
			saveCommunityCommand.Execute();
			return saveCommunityCommand.CommandResult;
		}

		public void ChangeListingTypeState(long communityId, ListingType listingType, bool value)
		{
			new ChangeListingTypeStateCommand(communityId, listingType, value).Execute();
		}

		public void ChangePackageType(long communityId, PackageType packageType)
		{
			new ChangePackageTypeForCommunityCommand(communityId, packageType).Execute();
		}

		public void ChangeSeniorHousingAndCareCategories(long communityId, List<long> seniorHousingAndCareCategoryIds)
		{
			new ChangeSeniorHousingAndCareCategoriesForCommunityCommand(communityId, seniorHousingAndCareCategoryIds).Execute();
		}

		public void ChangeShowcaseDates(long communityId, DateTime? startDate, DateTime? endDate, int showcaseTypeId)
		{
			new ChangeShowcaseDatesCommand(communityId, startDate, endDate, showcaseTypeId).Execute();
		}

		public void ChangePublishDates(long communityId, DateTime? startDate, DateTime? endDate, int publishTypeId)
		{
			new ChangePublishDatesForCommunityCommand(communityId, startDate, endDate, publishTypeId).Execute();
		}

		public Tuple<List<Phone>, List<CallTrackingPhone>> GetCommunityPhones(long communityId)
		{
			GetCommunityPhonesCommand getCommunityPhonesCommand = new GetCommunityPhonesCommand(communityId);
			getCommunityPhonesCommand.Execute();
			return getCommunityPhonesCommand.CommandResult;
		}

		public bool IsUsersCommunity(List<Book> books, long communityId)
		{
			IsUserCommunityCommand isUserCommunityCommand = new IsUserCommunityCommand(books, communityId);
			isUserCommunityCommand.Execute();
			return isUserCommunityCommand.CommandResult.Value;
		}
	}

}