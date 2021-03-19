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
		public SqlCommunityDac()
		{
		}

		public void ChangeListingTypeState(long communityId, ListingType listingType, bool value)
		{
			(new ChangeListingTypeStateCommand(communityId, listingType, value)).Execute();
		}

		public void ChangePackageType(long communityId, PackageType packageType)
		{
			(new ChangePackageTypeForCommunityCommand(communityId, packageType)).Execute();
		}

		public void ChangePublishDates(long communityId, DateTime? startDate, DateTime? endDate, int publishTypeId)
		{
			(new ChangePublishDatesForCommunityCommand(communityId, startDate, endDate, publishTypeId)).Execute();
		}

		public void ChangeSeniorHousingAndCareCategories(long communityId, List<long> seniorHousingAndCareCategoryIds)
		{
			(new ChangeSeniorHousingAndCareCategoriesForCommunityCommand(communityId, seniorHousingAndCareCategoryIds)).Execute();
		}

		public void ChangeShowcaseDates(long communityId, DateTime? startDate, DateTime? endDate, int showcaseTypeId)
		{
			(new ChangeShowcaseDatesCommand(communityId, startDate, endDate, showcaseTypeId)).Execute();
		}

		public void Delete(long id)
		{
			(new DeleteCommunityByIdCommand(id)).Execute();
		}

		public List<Community> GetAll(List<Book> books, int? pageNumber, int? pageSize, CommunityGridSortByOption? sortBy, OrderBy? orderBy, CommunityGridFilter filter, out int totalCount)
		{
			// 
			// Current member / type: System.Collections.Generic.List`1<MSLivingChoices.Entities.Admin.Community> MSLivingChoices.SqlDacs.Admin.Components.SqlCommunityDac::GetAll(System.Collections.Generic.List`1<MSLivingChoices.Entities.Admin.Book>,System.Nullable`1<System.Int32>,System.Nullable`1<System.Int32>,System.Nullable`1<MSLivingChoices.Entities.Admin.Enums.CommunityGridSortByOption>,System.Nullable`1<MSLivingChoices.Entities.Admin.Enums.OrderBy>,MSLivingChoices.Entities.Admin.CommunityGridFilter,System.Int32&)
			// File path: C:\Users\sra_r\Desktop\SeniorLiving1\Main\bin\MSLivingChoices.SqlDacs.Admin.dll
			// 
			// Product version: 2019.1.118.0
			// Exception in: System.Collections.Generic.List<MSLivingChoices.Entities.Admin.Community> GetAll(System.Collections.Generic.List<MSLivingChoices.Entities.Admin.Book>,System.Nullable<System.Int32>,System.Nullable<System.Int32>,System.Nullable<MSLivingChoices.Entities.Admin.Enums.CommunityGridSortByOption>,System.Nullable<MSLivingChoices.Entities.Admin.Enums.OrderBy>,MSLivingChoices.Entities.Admin.CommunityGridFilter,System.Int32&)
			// 
			// Specified argument was out of the range of valid values.
			// Parameter name: Expression is not evaluated to any type.
			//    at ..(Expression , VariableReference ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\TypeInference\UsedAsTypeHelper.cs:line 102
			//    at ..(Expression , VariableReference ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\TypeInference\UsedAsTypeHelper.cs:line 94
			//    at ..(Expression , VariableReference ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\TypeInference\UsedAsTypeHelper.cs:line 94
			//    at ..(BinaryExpression , VariableReference ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\TypeInference\UsedAsTypeHelper.cs:line 182
			//    at ..(Expression , VariableReference ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\TypeInference\UsedAsTypeHelper.cs:line 75
			//    at ..(Instruction , Expression , VariableReference ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\TypeInference\UsedAsTypeHelper.cs:line 45
			//    at ..(VariableReference , TypeReference& ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\TypeInference\GreedyTypeInferer.cs:line 60
			//    at ..() in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\TypeInference\GreedyTypeInferer.cs:line 35
			//    at Telerik.JustDecompiler.Decompiler.TypeInference.TypeInferer.() in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\TypeInference\TypeInferer.cs:line 300
			//    at Telerik.JustDecompiler.Decompiler.ExpressionDecompilerStep.(DecompilationContext ,  ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\ExpressionDecompilerStep.cs:line 86
			//    at ..(MethodBody ,  , ILanguage ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\DecompilationPipeline.cs:line 88
			//    at ..(MethodBody , ILanguage ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\DecompilationPipeline.cs:line 70
			//    at Telerik.JustDecompiler.Decompiler.Extensions.( , ILanguage , MethodBody , DecompilationContext& ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\Extensions.cs:line 95
			//    at Telerik.JustDecompiler.Decompiler.Extensions.(MethodBody , ILanguage , DecompilationContext& ,  ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\Extensions.cs:line 58
			//    at ..(ILanguage , MethodDefinition ,  ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\WriterContextServices\BaseWriterContextService.cs:line 117
			// 
			// mailto: JustDecompilePublicFeedback@telerik.com

		}

		public Community GetById(long id)
		{
			GetCommunityByIdCommand getCommunityByIdCommand = new GetCommunityByIdCommand(id);
			getCommunityByIdCommand.Execute();
			return getCommunityByIdCommand.CommandResult;
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

		public Community SaveEditedCommunity(Community community, int publishTypeId, int showcaseTypeId, int couponTypeId, int customCommunityServiceTypeId)
		{
			if (community.Builder != null && !community.Builder.Id.HasValue)
			{
				community.Builder = this.SaveOwner(community.Builder);
			}
			if (community.PropertyManager != null && !community.PropertyManager.Id.HasValue)
			{
				community.PropertyManager = this.SaveOwner(community.PropertyManager);
			}
			if (community.FloorPlans != null)
			{
				for (int i = 0; i < community.FloorPlans.Count; i++)
				{
					community.FloorPlans[i] = this.SaveFloorPlan(community.FloorPlans[i], i + 1, couponTypeId);
				}
			}
			if (community.SpecHomes != null)
			{
				for (int i = 0; i < community.SpecHomes.Count; i++)
				{
					community.SpecHomes[i] = this.SaveSpecHome(community.SpecHomes[i], i + 1, couponTypeId);
				}
			}
			if (community.Houses != null)
			{
				for (int i = 0; i < community.Houses.Count; i++)
				{
					community.Houses[i] = this.SaveHouse(community.Houses[i], i + 1, couponTypeId);
				}
			}
			SaveCommunityCommand saveCommunityCommand = new SaveCommunityCommand(community, publishTypeId, showcaseTypeId, couponTypeId, customCommunityServiceTypeId);
			saveCommunityCommand.Execute();
			return saveCommunityCommand.CommandResult;
		}

		public FloorPlan SaveFloorPlan(FloorPlan floorPlan, int sequence, int couponTypeId)
		{
			SaveFloorPlanCommand saveFloorPlanCommand = new SaveFloorPlanCommand(floorPlan, sequence, couponTypeId);
			saveFloorPlanCommand.Execute();
			return saveFloorPlanCommand.CommandResult;
		}

		public House SaveHouse(House house, int sequence, int couponTypeId)
		{
			SaveHouseCommand saveHouseCommand = new SaveHouseCommand(house, sequence, couponTypeId);
			saveHouseCommand.Execute();
			return saveHouseCommand.CommandResult;
		}

		public Community SaveNewCommunity(Community community, int publishTypeId, int showcaseTypeId, int couponTypeId, int customCommunityServiceTypeId)
		{
			if (community.Builder != null && !community.Builder.Id.HasValue)
			{
				community.Builder = this.SaveOwner(community.Builder);
			}
			if (community.PropertyManager != null && !community.PropertyManager.Id.HasValue)
			{
				community.PropertyManager = this.SaveOwner(community.PropertyManager);
			}
			SaveNewCommunityCommand saveNewCommunityCommand = new SaveNewCommunityCommand(community, publishTypeId, showcaseTypeId, couponTypeId, customCommunityServiceTypeId);
			saveNewCommunityCommand.Execute();
			community = saveNewCommunityCommand.CommandResult;
			int floorPlanCount = community.FloorPlans.Count;
			for (int i = 0; i < floorPlanCount; i++)
			{
				community.FloorPlans[i] = this.SaveFloorPlan(community.FloorPlans[i], i + 1, couponTypeId);
			}
			int specHomeCount = community.SpecHomes.Count;
			for (int i = 0; i < specHomeCount; i++)
			{
				community.SpecHomes[i] = this.SaveSpecHome(community.SpecHomes[i], i + 1, couponTypeId);
			}
			int housesCount = community.Houses.Count;
			for (int i = 0; i < housesCount; i++)
			{
				community.Houses[i] = this.SaveHouse(community.Houses[i], i + 1, couponTypeId);
			}
			return community;
		}

		public Owner SaveOwner(Owner owner)
		{
			SaveOwnerCommand saveOwnerCommand = new SaveOwnerCommand(owner);
			saveOwnerCommand.Execute();
			return saveOwnerCommand.CommandResult;
		}

		public SpecHome SaveSpecHome(SpecHome specHome, int sequence, int couponTypeId)
		{
			SaveSpecHomeCommand saveSpecHomeCommand = new SaveSpecHomeCommand(specHome, sequence, couponTypeId);
			saveSpecHomeCommand.Execute();
			return saveSpecHomeCommand.CommandResult;
		}
	}
}