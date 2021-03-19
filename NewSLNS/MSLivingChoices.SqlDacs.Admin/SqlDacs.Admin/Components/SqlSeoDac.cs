using MSLivingChoices.Entities.Admin;
using MSLivingChoices.IDacs.Admin.Components;
using MSLivingChoices.SqlDacs.Admin.SqlCommands;
using MSLivingChoices.SqlDacs.SqlCommands;
using System;

namespace MSLivingChoices.SqlDacs.Admin.Components
{
	public class SqlSeoDac : ISeoDac
	{
		public SqlSeoDac()
		{
		}

		public Seo GetSeoMetaData(Seo seo)
		{
			GetSeoMetaDataCommand getSeoMetaDataCommand = new GetSeoMetaDataCommand(seo);
			getSeoMetaDataCommand.Execute();
			return getSeoMetaDataCommand.CommandResult;
		}

		public Seo SaveSeoMetaData(Seo seo)
		{
			SaveSeoMetaDataCommand saveSeoMetaDataCommand = new SaveSeoMetaDataCommand(seo);
			saveSeoMetaDataCommand.Execute();
			return saveSeoMetaDataCommand.CommandResult;
		}
	}
}