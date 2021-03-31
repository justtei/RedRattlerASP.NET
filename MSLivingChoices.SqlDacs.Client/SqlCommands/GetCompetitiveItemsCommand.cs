using MSLivingChoices.Entities.Client.DisplayOptions;
using MSLivingChoices.SqlDacs.Client.Helpers;
using MSLivingChoices.SqlDacs.SqlCommands;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace MSLivingChoices.SqlDacs.Client.SqlCommands
{
	internal class GetCompetitiveItemsCommand : CachedBaseCommand<Dictionary<int, List<CompetitiveItem>>>
	{
		private Dictionary<int, List<CompetitiveItem>> _result;

		private readonly bool _takeActiveOnly;

		public GetCompetitiveItemsCommand(bool takeActiveOnly)
		{
			this._takeActiveOnly = takeActiveOnly;
			base.StoredProcedureName = ClientStoredProcedures.SpGetCompetitiveItems;
			base.CacheKey = CachedBaseCommand<Dictionary<int, List<CompetitiveItem>>>.GetCacheKey(new string[] { base.StoredProcedureName, this._takeActiveOnly.ToString() });
		}

		protected override void CommandBody(SqlCommand cmd)
		{
			cmd.CommandText = base.StoredProcedureName;
			cmd.CommandType = CommandType.StoredProcedure;
			using (SqlDataReader sqlDataReader = cmd.ExecuteReader())
			{
				this._result = sqlDataReader.GetTrebClassesWithItems(this._takeActiveOnly);
			}
		}

		protected override Dictionary<int, List<CompetitiveItem>> GetCommandResult(SqlCommand command)
		{
			return this._result;
		}
	}
}