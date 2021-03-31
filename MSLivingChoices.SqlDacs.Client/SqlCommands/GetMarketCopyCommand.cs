using MSLivingChoices.Entities.Client.Enums;
using MSLivingChoices.Entities.Client.Search.Criteria;
using MSLivingChoices.SqlDacs.Client.Helpers;
using MSLivingChoices.SqlDacs.Helpers;
using MSLivingChoices.SqlDacs.SqlCommands;
using MSLivingChoices.Utilities;
using System;
using System.Data;
using System.Data.SqlClient;

namespace MSLivingChoices.SqlDacs.Client.SqlCommands
{
	internal class GetMarketCopyCommand : CachedBaseCommand<string>
	{
		private readonly SearchCriteria _criteria;

		private readonly ListingType? _listingType;

		private string _result;

		public GetMarketCopyCommand(SearchCriteria criteria, ListingType? listingType)
		{
			base.StoredProcedureName = ClientStoredProcedures.SpGetMarketCopy;
			this._criteria = criteria;
			this._listingType = listingType;
			base.CacheKey = CachedBaseCommand<string>.GetCacheKey(new string[] { base.StoredProcedureName, this._criteria.ToString(), listingType.ToString() });
		}

		protected override void CommandBody(SqlCommand command)
		{
			command.CommandText = base.StoredProcedureName;
			command.CommandType = CommandType.StoredProcedure;
			int searchTypeId = this._listingType.GetSearchTypeId();
			command.Parameters.Add("@Country", SqlDbType.VarChar, 5).Value = this._criteria.CountryCode().ValueOrDBNull<string>();
			command.Parameters.Add("@State", SqlDbType.VarChar, 5).Value = this._criteria.StateCode().ValueOrDBNull<string>();
			command.Parameters.Add("@City", SqlDbType.VarChar, 60).Value = this._criteria.City().ValueOrDBNull<string>();
			command.Parameters.Add("@SearchTypeId", SqlDbType.Int).Value = searchTypeId;
			SqlDataReader sqlDataReader = command.ExecuteReader();
			if (sqlDataReader.Read())
			{
				this._result = sqlDataReader["MarketCopy"].ToString().SafeTrim();
			}
		}

		protected override string GetCommandResult(SqlCommand command)
		{
			return this._result;
		}
	}
}