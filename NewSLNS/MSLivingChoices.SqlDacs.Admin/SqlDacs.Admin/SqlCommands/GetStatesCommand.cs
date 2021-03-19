using MSLivingChoices.Entities.Admin;
using MSLivingChoices.SqlDacs.SqlCommands;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace MSLivingChoices.SqlDacs.Admin.SqlCommands
{
	internal class GetStatesCommand : CachedBaseCommand<List<State>>
	{
		protected readonly long? CountryId;

		private List<State> _result;

		public GetStatesCommand(long? countryId)
		{
			base.StoredProcedureName = CommonStoredProcedures.SpGetStates;
			this.CountryId = countryId;
			base.CacheKey = CachedBaseCommand<List<State>>.GetCacheKey(new string[] { base.StoredProcedureName, "admin", this.CountryId.ToString() });
		}

		protected override void CommandBody(SqlCommand command)
		{
			command.CommandText = base.StoredProcedureName;
			command.CommandType = CommandType.StoredProcedure;
			command.Parameters.Add("@CountryId", SqlDbType.Int).Value = this.CountryId;
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