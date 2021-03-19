using MSLivingChoices.Entities.Admin;
using MSLivingChoices.SqlDacs.Admin.Helpers;
using MSLivingChoices.SqlDacs.SqlCommands;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace MSLivingChoices.SqlDacs.Admin.SqlCommands
{
	internal class GetUsableCountriesCommand : CachedBaseCommand<List<Country>>
	{
		private List<Country> _result;

		public GetUsableCountriesCommand()
		{
			base.StoredProcedureName = AdminStoredProcedures.SpGetUsableCountries;
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