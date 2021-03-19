using MSLivingChoices.Entities.Admin;
using MSLivingChoices.SqlDacs.SqlCommands;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace MSLivingChoices.SqlDacs.Admin.SqlCommands
{
	internal class GetCitiesCommand : CachedBaseCommand<List<City>>
	{
		protected readonly long? StateId;

		private List<City> _result;

		public GetCitiesCommand(long? stateId)
		{
			base.StoredProcedureName = AdminStoredProcedures.SpGetCities;
			this.StateId = stateId;
			base.CacheKey = CachedBaseCommand<List<City>>.GetCacheKey(new string[] { base.StoredProcedureName, this.StateId.ToString() });
		}

		protected override void CommandBody(SqlCommand command)
		{
			command.CommandText = base.StoredProcedureName;
			command.CommandType = CommandType.StoredProcedure;
			command.Parameters.Add("@StateId", SqlDbType.Int).Value = this.StateId;
			SqlDataReader reader = command.ExecuteReader();
			this._result = new List<City>();
			while (reader.Read())
			{
				int id = (int)reader["CityId"];
				string name = reader["City"].ToString().Trim();
				if (id == 0)
				{
					continue;
				}
				this._result.Add(new City()
				{
					Id = new long?((long)id),
					Name = name
				});
			}
		}

		protected override List<City> GetCommandResult(SqlCommand command)
		{
			return this._result;
		}
	}
}