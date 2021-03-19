using MSLivingChoices.Entities.Admin;
using MSLivingChoices.SqlDacs.SqlCommands;
using System;
using System.Data;
using System.Data.SqlClient;

namespace MSLivingChoices.SqlDacs.Admin.SqlCommands
{
	internal class GetCountryByIdCommand : CachedBaseCommand<Country>
	{
		protected long? CountryId;

		private Country _result;

		public GetCountryByIdCommand(long? countryId)
		{
			base.StoredProcedureName = AdminStoredProcedures.SpGetCountryById;
			this.CountryId = countryId;
			base.CacheKey = CachedBaseCommand<Country>.GetCacheKey(new string[] { base.StoredProcedureName, this.CountryId.ToString() });
		}

		protected override void CommandBody(SqlCommand command)
		{
			command.CommandText = base.StoredProcedureName;
			command.CommandType = CommandType.StoredProcedure;
			command.Parameters.Add("@CountryId", SqlDbType.Int).Value = this.CountryId;
			SqlDataReader reader = command.ExecuteReader();
			this._result = new Country();
			if (reader.Read())
			{
				int id = (int)reader["CountryId"];
				string name = reader["Country"].ToString().Trim();
				string code = reader["CountryCode"].ToString().Trim();
				if (id != 0)
				{
					this._result = new Country()
					{
						Id = new long?((long)id),
						Name = name,
						Code = code
					};
				}
			}
		}

		protected override Country GetCommandResult(SqlCommand command)
		{
			return this._result;
		}
	}
}