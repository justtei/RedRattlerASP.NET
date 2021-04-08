using MSLivingChoices.Entities.Client;
using MSLivingChoices.Entities.Client.DisplayOptions;
using MSLivingChoices.IDacs.Client.Components;
using MSLivingChoices.SqlDacs.Client.SqlCommands;
using MSLivingChoices.SqlDacs.SqlCommands;
using System;
using System.Collections.Generic;

namespace MSLivingChoices.SqlDacs.Client.Components
{
	public class SqlCommonDac : ICommonDac
	{
		public SqlCommonDac()
		{
		}

		public Dictionary<int, List<CompetitiveItem>> GetCompetitiveItems(bool takeActiveOnly)
		{
			GetCompetitiveItemsCommand getCompetitiveItemsCommand = new GetCompetitiveItemsCommand(takeActiveOnly);
			getCompetitiveItemsCommand.Execute();
			return getCompetitiveItemsCommand.CommandResult;
		}
		public bool SaveContact(Contact c)
        {
			SaveContactCommand sc = new SaveContactCommand(c);
			sc.Execute();
			return sc.CommandResult.Result;
        }

        public bool SaveEbookOrder(EbookOrder eb)
        {
            throw new NotImplementedException();
        }
    }
}