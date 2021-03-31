using MSLivingChoices.Entities.Client.Search.Criteria;
using MSLivingChoices.SqlDacs.Client.Helpers;
using MSLivingChoices.SqlDacs.Helpers;
using MSLivingChoices.SqlDacs.SqlCommands;
using System;
using System.Data;
using System.Data.SqlClient;

namespace MSLivingChoices.SqlDacs.Client.SqlCommands
{
	internal class ValidateAddressCommand : CachedBaseCommand<SearchCriteria>
	{
		private readonly SearchCriteria _searchModel;

		private SearchCriteria _result;

		public ValidateAddressCommand(SearchCriteria searchModel)
		{
			this._searchModel = searchModel;
			base.StoredProcedureName = ClientStoredProcedures.SpValidateAddress;
			base.CacheKey = CachedBaseCommand<SearchCriteria>.GetCacheKey(new string[] { base.StoredProcedureName, this._searchModel.ToString() });
		}

		protected override void CommandBody(SqlCommand cmd)
		{
			SearchCriteria addressCriteria;
			cmd.CommandText = base.StoredProcedureName;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Parameters.Add("@Country", SqlDbType.VarChar, 5).Value = this._searchModel.CountryCode().ValueOrDBNull<string>();
			cmd.Parameters.Add("@State", SqlDbType.VarChar, 20).Value = this._searchModel.StateCode().ValueOrDBNull<string>();
			cmd.Parameters.Add("@City", SqlDbType.VarChar, 50).Value = this._searchModel.City().ValueOrDBNull<string>();
			using (SqlDataReader sqlDataReader = cmd.ExecuteReader())
			{
				if (sqlDataReader.Read())
				{
					if (sqlDataReader.GetValue<bool>("IsValid"))
					{
						addressCriteria = sqlDataReader.GetAddressCriteria();
					}
					else
					{
						addressCriteria = null;
					}
					this._result = addressCriteria;
				}
			}
		}

		protected override SearchCriteria GetCommandResult(SqlCommand command)
		{
			return this._result;
		}
	}
}