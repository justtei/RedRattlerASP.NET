using MSLivingChoices.Entities.Admin;
using MSLivingChoices.Entities.Admin.Enums;
using MSLivingChoices.SqlDacs.SqlCommands;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace MSLivingChoices.SqlDacs.Admin.SqlCommands
{
	internal class GetUsableCitiesCommand : CachedBaseCommand<List<City>>
	{
		private readonly string _stateCode;

		private readonly SearchType _searchType;

		private List<City> _result;

		public GetUsableCitiesCommand(string stateCode, SearchType searchType)
		{
			base.StoredProcedureName = AdminStoredProcedures.SpGetUsableCities;
			this._stateCode = stateCode;
			this._searchType = searchType;
			base.CacheKey = CachedBaseCommand<List<City>>.GetCacheKey(new string[] { base.StoredProcedureName, this._stateCode, this._searchType.ToString() });
		}

		protected override void CommandBody(SqlCommand command)
		{
			object value;
			object obj;
			object value1;
			command.CommandText = base.StoredProcedureName;
			command.CommandType = CommandType.StoredProcedure;
			command.Parameters.Add("@StateCode", SqlDbType.VarChar, 3).Value = this._stateCode;
			SqlParameter sqlParameter = command.Parameters.Add("@HasAdultHomes", SqlDbType.Bit);
			if (this._searchType == SearchType.ActiveAdultHomes)
			{
				value = true;
			}
			else
			{
				value = DBNull.Value;
			}
			sqlParameter.Value = value;
			SqlParameter sqlParameter1 = command.Parameters.Add("@HasAdultApartments", SqlDbType.Bit);
			if (this._searchType == SearchType.ActiveAdultCommunities)
			{
				obj = true;
			}
			else
			{
				obj = DBNull.Value;
			}
			sqlParameter1.Value = obj;
			SqlParameter sqlParameter2 = command.Parameters.Add("@HasSeniorHousing", SqlDbType.Bit);
			if (this._searchType == SearchType.SeniorHousingAndCare)
			{
				value1 = true;
			}
			else
			{
				value1 = DBNull.Value;
			}
			sqlParameter2.Value = value1;
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