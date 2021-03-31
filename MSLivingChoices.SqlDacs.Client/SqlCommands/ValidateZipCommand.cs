using MSLivingChoices.Entities.Client.Search.Criteria;
using MSLivingChoices.SqlDacs.Client.Helpers;
using MSLivingChoices.SqlDacs.Helpers;
using MSLivingChoices.SqlDacs.SqlCommands;
using System;
using System.Data;
using System.Data.SqlClient;

namespace MSLivingChoices.SqlDacs.Client.SqlCommands
{
	internal class ValidateZipCommand : CachedBaseCommand<SearchCriteria>
	{
		private readonly SearchCriteria _searchModel;

		private SearchCriteria _result;

		public ValidateZipCommand(SearchCriteria searchModel)
		{
			this._searchModel = searchModel;
			base.StoredProcedureName = ClientStoredProcedures.SpValidateZip;
			base.CacheKey = CachedBaseCommand<SearchCriteria>.GetCacheKey(new string[] { base.StoredProcedureName, this._searchModel.ToString() });
		}

		protected override void CommandBody(SqlCommand cmd)
		{
			SearchCriteria zipCriteria;
			cmd.CommandText = base.StoredProcedureName;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Parameters.Add("@Country", SqlDbType.VarChar, 5).Value = this._searchModel.CountryCode().ValueOrDBNull<string>();
			cmd.Parameters.Add("@State", SqlDbType.VarChar, 20).Value = this._searchModel.StateCode().ValueOrDBNull<string>();
			cmd.Parameters.Add("@Zip", SqlDbType.VarChar, 10).Value = this._searchModel.Zip().ValueOrDBNull<string>();
			using (SqlDataReader sqlDataReader = cmd.ExecuteReader())
			{
				if (sqlDataReader.Read())
				{
					if (sqlDataReader.GetValue<bool>("IsValid"))
					{
						zipCriteria = sqlDataReader.GetZipCriteria();
					}
					else
					{
						zipCriteria = null;
					}
					this._result = zipCriteria;
				}
			}
		}

		protected override SearchCriteria GetCommandResult(SqlCommand command)
		{
			return this._result;
		}
	}
}