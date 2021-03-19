using MSLivingChoices.Entities.Admin;
using MSLivingChoices.SqlDacs.SqlCommands;
using System;
using System.Data;
using System.Data.SqlClient;

namespace MSLivingChoices.SqlDacs.Admin.SqlCommands
{
	internal class GetCityByIdCommand : CachedBaseCommand<City>
	{
		protected long? CityId;

		private City _result;

		public GetCityByIdCommand(long? cityId)
		{
			base.StoredProcedureName = AdminStoredProcedures.SpGetCityById;
			this.CityId = cityId;
			base.CacheKey = CachedBaseCommand<City>.GetCacheKey(new string[] { base.StoredProcedureName, this.CityId.ToString() });
		}

		protected override void CommandBody(SqlCommand command)
		{
			command.CommandText = base.StoredProcedureName;
			command.CommandType = CommandType.StoredProcedure;
			command.Parameters.Add("@CityId", SqlDbType.Int).Value = this.CityId;
			SqlDataReader reader = command.ExecuteReader();
			this._result = new City();
			if (reader.Read())
			{
				int id = (int)reader["CityId"];
				string name = reader["City"].ToString().Trim();
				if (id != 0)
				{
					this._result = new City()
					{
						Id = new long?((long)id),
						Name = name
					};
				}
			}
		}

		protected override City GetCommandResult(SqlCommand command)
		{
			return this._result;
		}
	}
}