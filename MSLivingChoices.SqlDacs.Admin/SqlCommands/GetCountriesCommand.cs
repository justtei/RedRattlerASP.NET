using MSLivingChoices.Entities.Admin;
using MSLivingChoices.SqlDacs.Admin.Helpers;
using MSLivingChoices.SqlDacs.SqlCommands;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace MSLivingChoices.SqlDacs.Admin.SqlCommands
{
	internal class GetCountriesCommand : CachedBaseCommand<List<Country>>
	{
		private List<Country> _result;

		public GetCountriesCommand()
		{
			base.StoredProcedureName = AdminStoredProcedures.SpGetCountries;
			base.CacheKey = CachedBaseCommand<List<Country>>.GetCacheKey(new string[] { base.StoredProcedureName });
		}

		protected override void CommandBody(SqlCommand command)
		{
			command.CommandText = base.StoredProcedureName;
			command.CommandType = CommandType.StoredProcedure;
			this._result = command.ExecuteReader().GetCountries();
		}

		protected override List<Country> GetCommandResult(SqlCommand command)
		{
			return this._result;
		}
	}
}