using MSLivingChoices.IDacs.Components;
using MSLivingChoices.SqlDacs.SqlCommands;
using System;
using System.Collections.Generic;

namespace MSLivingChoices.SqlDacs.Components
{
	public class SqlItemTypeDac : IItemTypeDac
	{
		public SqlItemTypeDac()
		{
		}

		public List<KeyValuePair<int, string>> GetBathrooms()
		{
			GetBathroomsCommand getBathroomsCommand = new GetBathroomsCommand();
			getBathroomsCommand.Execute();
			return getBathroomsCommand.CommandResult;
		}

		public List<KeyValuePair<int, string>> GetBedrooms()
		{
			GetBedroomsCommand getBedroomsCommand = new GetBedroomsCommand();
			getBedroomsCommand.Execute();
			return getBedroomsCommand.CommandResult;
		}

		public List<KeyValuePair<int, string>> GetCommunityDefaultAmenities()
		{
			GetCommunityDefaultAmenitiesCommand getCommunityDefaultAmenitiesCommand = new GetCommunityDefaultAmenitiesCommand();
			getCommunityDefaultAmenitiesCommand.Execute();
			return getCommunityDefaultAmenitiesCommand.CommandResult;
		}

		public List<KeyValuePair<int, string>> GetShcCategoriesForCommunity()
		{
			GetShcCategoriesForCommunityCommand getShcCategoriesForCommunityCommand = new GetShcCategoriesForCommunityCommand();
			getShcCategoriesForCommunityCommand.Execute();
			return getShcCategoriesForCommunityCommand.CommandResult;
		}

		public List<KeyValuePair<int, string>> GetShcCategoriesForServiceProvider()
		{
			GetShcCategoriesForServiceProviderCommand getShcCategoriesForServiceProviderCommand = new GetShcCategoriesForServiceProviderCommand();
			getShcCategoriesForServiceProviderCommand.Execute();
			return getShcCategoriesForServiceProviderCommand.CommandResult;
		}
	}
}