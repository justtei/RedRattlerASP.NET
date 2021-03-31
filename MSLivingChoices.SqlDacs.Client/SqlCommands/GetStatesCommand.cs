using MSLivingChoices.SqlDacs.SqlCommands;
using MSLivingChoices.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace MSLivingChoices.SqlDacs.Client.SqlCommands
{
	internal class GetStatesCommand : CachedBaseCommand<Dictionary<string, string>>
	{
		private readonly long? _countryId;

		private Dictionary<string, string> _result;

		public GetStatesCommand(long? countryId)
		{
			base.StoredProcedureName = CommonStoredProcedures.SpGetStates;
			this._countryId = countryId;
			base.CacheKey = CachedBaseCommand<Dictionary<string, string>>.GetCacheKey(new string[] { base.StoredProcedureName, "client", this._countryId.ToString() });
		}

		protected override void CommandBody(SqlCommand command)
		{
			command.CommandText = base.StoredProcedureName;
			command.CommandType = CommandType.StoredProcedure;
			command.Parameters.Add("@CountryId", SqlDbType.Int).Value = this._countryId;
			SqlDataReader sqlDataReader = command.ExecuteReader();
			this._result = new Dictionary<string, string>();
			while (sqlDataReader.Read())
			{
				string str = sqlDataReader["State"].ToString().SafeTrim();
				string str1 = sqlDataReader["StateCode"].ToString().SafeTrim();
				if (str.IsNullOrEmpty() || str1.IsNullOrEmpty())
				{
					continue;
				}
				this._result.Add(str1, str);
			}
		}

		protected override Dictionary<string, string> GetCommandResult(SqlCommand command)
		{
			return this._result;
		}
	}
}