using MSLivingChoices.Entities.Client.Search.Criteria;
using MSLivingChoices.SqlDacs.Client.Helpers;
using MSLivingChoices.SqlDacs.Helpers;
using MSLivingChoices.SqlDacs.SqlCommands;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace MSLivingChoices.SqlDacs.Client.SqlCommands
{
	internal class GetZipAutocompleteCommand : CachedBaseCommand<List<SearchCriteria>>
	{
		private readonly SearchCriteria _searchModel;

		private List<SearchCriteria> _results;

		private readonly int _maxCount;

		public GetZipAutocompleteCommand(SearchCriteria searchModel, int maxCount)
		{
			this._searchModel = searchModel;
			this._maxCount = maxCount;
			base.StoredProcedureName = ClientStoredProcedures.GetSearchAutocompleteVariantsForZip;
			base.CacheKey = CachedBaseCommand<List<SearchCriteria>>.GetCacheKey(new string[] { base.StoredProcedureName, this._searchModel.ToString(), this._maxCount.ToString() });
		}

		protected override void CommandBody(SqlCommand cmd)
		{
			cmd.CommandText = base.StoredProcedureName;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Parameters.Add("@Country", SqlDbType.VarChar, 5).Value = this._searchModel.CountryCode().ValueOrDBNull<string>();
			cmd.Parameters.Add("@State", SqlDbType.VarChar, 5).Value = this._searchModel.StateCode().ValueOrDBNull<string>();
			cmd.Parameters.Add("@Zip", SqlDbType.VarChar, 10).Value = this._searchModel.Zip().ValueOrDBNull<string>();
			cmd.Parameters.Add("@MaxVariantsCount", SqlDbType.Int).Value = this._maxCount;
			using (SqlDataReader sqlDataReader = cmd.ExecuteReader())
			{
				this._results = sqlDataReader.GetZipAutoCompleteVariants();
			}
		}

		protected override List<SearchCriteria> GetCommandResult(SqlCommand command)
		{
			return this._results;
		}
	}
}