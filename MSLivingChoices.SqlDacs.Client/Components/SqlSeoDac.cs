using MSLivingChoices.Entities.Client.Enums;
using MSLivingChoices.Entities.Client.Search.Criteria;
using MSLivingChoices.IDacs.Client.Components;
using MSLivingChoices.SqlDacs.Client.SqlCommands;
using MSLivingChoices.SqlDacs.SqlCommands;
using System;

namespace MSLivingChoices.SqlDacs.Client.Components
{
	public class SqlSeoDac : ISeoDac
	{
		public SqlSeoDac()
		{
		}

		public string GetCommunitiesMarketCopy(SearchCriteria criteria, ListingType listingType)
		{
			GetMarketCopyCommand getMarketCopyCommand = new GetMarketCopyCommand(criteria, new ListingType?(listingType));
			getMarketCopyCommand.Execute();
			return getMarketCopyCommand.CommandResult;
		}

		public string GetServiceProvidersMarketCopy(SearchCriteria criteria)
		{
			GetMarketCopyCommand getMarketCopyCommand = new GetMarketCopyCommand(criteria, null);
			getMarketCopyCommand.Execute();
			return getMarketCopyCommand.CommandResult;
		}
	}
}