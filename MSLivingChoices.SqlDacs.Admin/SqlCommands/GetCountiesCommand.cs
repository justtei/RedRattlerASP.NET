using MSLivingChoices.Entities.Admin;
using MSLivingChoices.SqlDacs.Admin.Helpers;
using MSLivingChoices.SqlDacs.SqlCommands;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace MSLivingChoices.SqlDacs.Admin.SqlCommands
{
	internal class GetCountiesCommand : CachedBaseCommand<List<County>>
	{
		private List<County> _result;

		public GetCountiesCommand()
		{
			base.StoredProcedureName = AdminStoredProcedures.SpGetCounties;
			base.CacheKey = CachedBaseCommand<List<County>>.GetCacheKey(new string[] { base.StoredProcedureName });
		}

		protected override void CommandBody(SqlCommand command)
		{
			command.CommandText = base.StoredProcedureName;
			command.CommandType = CommandType.StoredProcedure;
			this._result = command.ExecuteReader().GetCounties();
		}

		protected override List<County> GetCommandResult(SqlCommand command)
		{
			return this._result;
		}
	}
}