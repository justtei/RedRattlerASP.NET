using MSLivingChoices.Entities.Client.Enums;
using MSLivingChoices.Entities.Client.Search;
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
	internal class GetNearbyCitiesCommand : CachedBaseCommand<NearbySearchResult>
	{
		private readonly NearbySearchModel _searchModel;

		private readonly NearbySearchResult _searchResult;

		private readonly ListingType? _listingType;

		public GetNearbyCitiesCommand(NearbySearchModel searchModel, ListingType? listingType)
		{
			this._searchModel = searchModel;
			this._listingType = listingType;
			this._searchResult = new NearbySearchResult();
			base.StoredProcedureName = ClientStoredProcedures.SpGetCrosslinkCities;
			base.CacheKey = CachedBaseCommand<NearbySearchResult>.GetCacheKey(new string[] { base.StoredProcedureName, this._searchModel.ToString(), this._listingType.ToString() });
		}

		protected override void CommandBody(SqlCommand cmd)
		{
			cmd.CommandText = base.StoredProcedureName;
			cmd.CommandType = CommandType.StoredProcedure;
			string searchTypeParamName = this._listingType.GetSearchTypeParamName();
			cmd.Parameters.Add(searchTypeParamName, SqlDbType.Bit).Value = true;
			cmd.Parameters.Add("@Country", SqlDbType.VarChar, 5).Value = this._searchModel.Criteria.CountryCode().ValueOrDBNull<string>();
			cmd.Parameters.Add("@State", SqlDbType.VarChar, 5).Value = this._searchModel.Criteria.StateCode().ValueOrDBNull<string>();
			cmd.Parameters.Add("@City", SqlDbType.VarChar, 60).Value = this._searchModel.Criteria.City().ValueOrDBNull<string>();
			cmd.Parameters.Add("@MaxCount", SqlDbType.Int).Value = this._searchModel.MaxCount;
			using (SqlDataReader sqlDataReader = cmd.ExecuteReader())
			{
				this._searchResult.AvailableListingTypes = new List<ListingType>();
				this._searchResult.NearbyCities = new List<SearchCriteria>();
				while (sqlDataReader.Read())
				{
					SearchCriteria addressCriteria = sqlDataReader.GetAddressCriteria();
					this._searchResult.NearbyCities.Add(addressCriteria);
				}
				if (sqlDataReader.NextResult() && sqlDataReader.Read())
				{
					int value = sqlDataReader.GetValue<int>("AahCount");
					int num = sqlDataReader.GetValue<int>("AacCount");
					int value1 = sqlDataReader.GetValue<int>("ShcCount");
					int num1 = sqlDataReader.GetValue<int>("PsCount");
					if (value > 0)
					{
						this._searchResult.AvailableListingTypes.Add(ListingType.ActiveAdultHomes);
					}
					if (num > 0)
					{
						this._searchResult.AvailableListingTypes.Add(ListingType.ActiveAdultCommunities);
					}
					if (value1 > 0)
					{
						this._searchResult.AvailableListingTypes.Add(ListingType.SeniorHousingAndCare);
					}
					this._searchResult.IsServiceProvidersAvailable = num1 > 0;
				}
			}
		}

		protected override NearbySearchResult GetCommandResult(SqlCommand command)
		{
			return this._searchResult;
		}
	}
}