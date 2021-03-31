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
	internal class GetCountrySearchStubCommand : CachedBaseCommand<List<CityListingsInfo>>
	{
		private readonly CountryStubSearchModel _searchModel;

		private readonly List<CityListingsInfo> _searchResult;

		private readonly ListingType? _listingType;

		public GetCountrySearchStubCommand(CountryStubSearchModel searchModel, ListingType? listingType = null)
		{
			this._searchModel = searchModel;
			this._listingType = listingType;
			this._searchResult = new List<CityListingsInfo>();
			base.StoredProcedureName = ClientStoredProcedures.SpGetCountryStubCities;
			base.CacheKey = CachedBaseCommand<List<CityListingsInfo>>.GetCacheKey(new string[] { base.StoredProcedureName, this._searchModel.ToString(), this._listingType.ToString() });
		}

		protected override void CommandBody(SqlCommand cmd)
		{
			cmd.CommandText = base.StoredProcedureName;
			cmd.CommandType = CommandType.StoredProcedure;
			string searchTypeParamName = this._listingType.GetSearchTypeParamName();
			cmd.Parameters.Add(searchTypeParamName, SqlDbType.Bit).Value = true;
			cmd.Parameters.Add("@Country", SqlDbType.VarChar, 3).Value = this._searchModel.Criteria.CountryCode().ValueOrDBNull<string>();
			cmd.Parameters.Add("@MaxCount", SqlDbType.Int).Value = this._searchModel.MaxCount;
			cmd.Parameters.Add("@OnlyPaidMarkets", SqlDbType.Bit).Value = this._searchModel.IsMarketAreaOnly;
			using (SqlDataReader sqlDataReader = cmd.ExecuteReader())
			{
				while (sqlDataReader.Read())
				{
					CityListingsInfo cityListingsInfo = new CityListingsInfo()
					{
						SearchCriteria = sqlDataReader.GetAddressCriteria(),
						AdultHomesCount = sqlDataReader.GetValueOrDefault<int>("AahCount"),
						AdultCommunitiesCount = sqlDataReader.GetValueOrDefault<int>("AacCount"),
						SeniorHousingCount = sqlDataReader.GetValueOrDefault<int>("ShcCount"),
						ServicesCount = sqlDataReader.GetValueOrDefault<int>("PsCount")
					};
					this._searchResult.Add(cityListingsInfo);
				}
			}
		}

		protected override List<CityListingsInfo> GetCommandResult(SqlCommand command)
		{
			return this._searchResult;
		}
	}
}