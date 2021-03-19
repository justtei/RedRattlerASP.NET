using MSLivingChoices.Entities.Admin;
using MSLivingChoices.Entities.Admin.Enums;
using MSLivingChoices.SqlDacs.SqlCommands;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace MSLivingChoices.SqlDacs.Admin.SqlCommands
{
	internal class GetUsableStatesCommand : CachedBaseCommand<List<State>>
	{
		protected readonly long? CountryId;

		protected readonly MSLivingChoices.Entities.Admin.Enums.SearchType SearchType;

		private List<State> _result;

		public GetUsableStatesCommand(long? countryId, MSLivingChoices.Entities.Admin.Enums.SearchType searchType)
		{
			base.StoredProcedureName = AdminStoredProcedures.SpGetUsableStates;
			this.CountryId = countryId;
			this.SearchType = searchType;
			base.CacheKey = CachedBaseCommand<List<State>>.GetCacheKey(new string[] { base.StoredProcedureName, this.CountryId.ToString(), this.SearchType.ToString() });
		}

		protected override void CommandBody(SqlCommand command)
		{
			object value;
			object obj;
			object value1;
			command.CommandText = base.StoredProcedureName;
			command.CommandType = CommandType.StoredProcedure;
			command.Parameters.Add("@CountryId", SqlDbType.Int).Value = this.CountryId;
			SqlParameter sqlParameter = command.Parameters.Add("@HasAdultHomes", SqlDbType.Bit);
			if (this.SearchType == MSLivingChoices.Entities.Admin.Enums.SearchType.ActiveAdultHomes)
			{
				value = true;
			}
			else
			{
				value = DBNull.Value;
			}
			sqlParameter.Value = value;
			SqlParameter sqlParameter1 = command.Parameters.Add("@HasAdultApartments", SqlDbType.Bit);
			if (this.SearchType == MSLivingChoices.Entities.Admin.Enums.SearchType.ActiveAdultCommunities)
			{
				obj = true;
			}
			else
			{
				obj = DBNull.Value;
			}
			sqlParameter1.Value = obj;
			SqlParameter sqlParameter2 = command.Parameters.Add("@HasSeniorHousing", SqlDbType.Bit);
			if (this.SearchType == MSLivingChoices.Entities.Admin.Enums.SearchType.SeniorHousingAndCare)
			{
				value1 = true;
			}
			else
			{
				value1 = DBNull.Value;
			}
			sqlParameter2.Value = value1;
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