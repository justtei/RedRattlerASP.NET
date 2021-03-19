using MSLivingChoices.Entities.Admin;
using MSLivingChoices.SqlDacs.SqlCommands;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace MSLivingChoices.SqlDacs.Admin.SqlCommands
{
	internal class GetUsableCitiesForServicesCommand : CachedBaseCommand<List<City>>
	{
		private readonly string _stateCode;

		private List<City> _result;

		public GetUsableCitiesForServicesCommand(string stateCode)
		{
			base.StoredProcedureName = AdminStoredProcedures.SpGetUsableCitiesForServices;
			this._stateCode = stateCode;
			base.CacheKey = CachedBaseCommand<List<City>>.GetCacheKey(new string[] { base.StoredProcedureName, this._stateCode });
		}

		protected override void CommandBody(SqlCommand command)
		{
			command.CommandText = base.StoredProcedureName;
			command.CommandType = CommandType.StoredProcedure;
			command.Parameters.Add("@StateCode", SqlDbType.VarChar, 3).Value = this._stateCode;
			SqlDataReader reader = command.ExecuteReader();
			this._result = new List<City>();
			while (reader.Read())
			{
				int id = (int)reader["CityId"];
				string name = reader["City"].ToString();
				if (id == 0)
				{
					continue;
				}
				this._result.Add(new City(new long?((long)id), name));
			}
		}

		protected override List<City> GetCommandResult(SqlCommand command)
		{
			return this._result;
		}
	}
}