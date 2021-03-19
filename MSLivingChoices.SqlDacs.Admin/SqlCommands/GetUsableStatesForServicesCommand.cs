using MSLivingChoices.Entities.Admin;
using MSLivingChoices.SqlDacs.SqlCommands;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace MSLivingChoices.SqlDacs.Admin.SqlCommands
{
	internal class GetUsableStatesForServicesCommand : CachedBaseCommand<List<State>>
	{
		protected readonly long? _countryId;

		private List<State> _result;

		public GetUsableStatesForServicesCommand(long? countryId)
		{
			base.StoredProcedureName = AdminStoredProcedures.SpGetUsableStatesForServices;
			this._countryId = countryId;
			base.CacheKey = CachedBaseCommand<List<State>>.GetCacheKey(new string[] { base.StoredProcedureName, this._countryId.ToString() });
		}

		protected override void CommandBody(SqlCommand command)
		{
			command.CommandText = base.StoredProcedureName;
			command.CommandType = CommandType.StoredProcedure;
			command.Parameters.Add("@CountryId", SqlDbType.Int).Value = this._countryId;
			SqlDataReader reader = command.ExecuteReader();
			this._result = new List<State>();
			while (reader.Read())
			{
				int id = (int)reader["StateId"];
				string name = reader["State"].ToString().Trim();
				string code = reader["StateCode"].ToString().Trim();
				if (id == 0)
				{
					continue;
				}
				this._result.Add(new State()
				{
					Id = new long?((long)id),
					Name = name,
					Code = code
				});
			}
		}

		protected override List<State> GetCommandResult(SqlCommand command)
		{
			return this._result;
		}
	}
}