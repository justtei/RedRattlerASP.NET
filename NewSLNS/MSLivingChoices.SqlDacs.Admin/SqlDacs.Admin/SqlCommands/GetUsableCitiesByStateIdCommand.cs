using MSLivingChoices.Entities.Admin;
using MSLivingChoices.Entities.Admin.Enums;
using MSLivingChoices.SqlDacs.SqlCommands;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace MSLivingChoices.SqlDacs.Admin.SqlCommands
{
	internal class GetUsableCitiesByStateIdCommand : CachedBaseCommand<List<City>>
	{
		private readonly long? _stateId;

		private readonly SearchType _searchType;

		private List<City> _result;

		public GetUsableCitiesByStateIdCommand(long? stateId, SearchType searchType)
		{
			base.StoredProcedureName = AdminStoredProcedures.SpGetUsableCitiesByStateId;
			this._stateId = stateId;
			this._searchType = searchType;
			base.CacheKey = CachedBaseCommand<List<City>>.GetCacheKey(new string[] { base.StoredProcedureName, this._stateId.ToString(), searchType.ToString() });
		}

		protected override void CommandBody(SqlCommand command)
		{
			object value;
			object obj;
			object value1;
			command.CommandText = base.StoredProcedureName;
			command.CommandType = CommandType.StoredProcedure;
			command.Parameters.Add("@StateId", SqlDbType.BigInt).Value = this._stateId;
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