using MSLivingChoices.Entities.Client;
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
using System.Linq;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.SqlDacs.Client.SqlCommands
{
	internal class SearchCommunitiesCommand : CachedBaseCommand<CommunitySearchModel>
	{
		private readonly CommunitySearchModel _searchModel;

		public SearchCommunitiesCommand(CommunitySearchModel searchModel)
		{
			base.StoredProcedureName = ClientStoredProcedures.SpSearchCommunitiesMap;
			this._searchModel = searchModel;
			this._searchModel.Result = new CommunitySearchResult()
			{
				Results = new List<Community>()
			};
			base.CacheKey = CachedBaseCommand<CommunitySearchModel>.GetCacheKey(new string[] { base.StoredProcedureName, this._searchModel.ToString() });
		}

		protected override void CommandBody(SqlCommand command)
		{
			object value;
			object obj;
			object value1;
			command.CommandText = base.StoredProcedureName;
			command.CommandType = CommandType.StoredProcedure;
			SqlParameter sqlParameter = command.Parameters.Add("@HasAdultHomes", SqlDbType.Bit);
			if (this._searchModel.ListingType == ListingType.ActiveAdultHomes)
			{
				value = true;
			}
			else
			{
				value = DBNull.Value;
			}
			sqlParameter.Value = value;
			SqlParameter sqlParameter1 = command.Parameters.Add("@HasAdultApartments", SqlDbType.Bit);
			if (this._searchModel.ListingType == ListingType.ActiveAdultCommunities)
			{
				obj = true;
			}
			else
			{
				obj = DBNull.Value;
			}
			sqlParameter1.Value = obj;
			SqlParameter sqlParameter2 = command.Parameters.Add("@HasSeniorHousing", SqlDbType.Bit);
			if (this._searchModel.ListingType == ListingType.SeniorHousingAndCare)
			{
				value1 = true;
			}
			else
			{
				value1 = DBNull.Value;
			}
			sqlParameter2.Value = value1;
			command.Parameters.Add("@CountryCode", SqlDbType.VarChar, 5).Value = this._searchModel.Criteria.CountryCode().ValueOrDBNull<string>();
			command.Parameters.Add("@StateCode", SqlDbType.VarChar, 3).Value = this._searchModel.Criteria.StateCode().ValueOrDBNull<string>();
			command.Parameters.Add("@City", SqlDbType.VarChar, 50).Value = this._searchModel.Criteria.City().ValueOrDBNull<string>();
			command.Parameters.Add("@PostalCode", SqlDbType.VarChar, 10).Value = this._searchModel.Criteria.Zip().ValueOrDBNull<string>();
			command.Parameters.Add("@PriceFrom", SqlDbType.Money).Value = this._searchModel.MinPrice.ValueOrDBNull<decimal?>();
			command.Parameters.Add("@PriceTo", SqlDbType.Money).Value = this._searchModel.MaxPrice.ValueOrDBNull<decimal?>();
			command.Parameters.Add("@BathroomFromId", SqlDbType.Int).Value = this._searchModel.BathroomFromId.ValueOrDBNull<long?>();
			command.Parameters.Add("@BedroomFromId", SqlDbType.Int).Value = this._searchModel.BedroomFromId.ValueOrDBNull<long?>();
			command.Parameters.Add("@AmenityTypeIdTable", SqlDbType.Structured).Value = this._searchModel.AmenitiesIds.GetIdsTable();
			command.Parameters.Add("@SeniorCareIdTable", SqlDbType.Structured).Value = this._searchModel.ShcCategoriesIds.GetIdsTable();
			command.Parameters.Add("@Sort", SqlDbType.Int).Value = this._searchModel.SortType;
			command.Parameters.Add("@PageNumber", SqlDbType.Int).Value = this._searchModel.PageNumber;
			command.Parameters.Add("@Pagesize", SqlDbType.Int).Value = this._searchModel.PageSize;
			command.Parameters.Add("@TotalCount", SqlDbType.Int).Direction = ParameterDirection.Output;
			SqlDataReader sqlDataReader = command.ExecuteReader();
			while (sqlDataReader.Read())
			{
				Community searchCommunity = sqlDataReader.GetSearchCommunity();
				this._searchModel.Result.Results.Add(searchCommunity);
			}
			if (!this._searchModel.Result.Results.Any<Community>())
			{
				return;
			}
			if (sqlDataReader.NextResult())
			{
				while (sqlDataReader.Read())
				{
					long num = sqlDataReader.GetValue<long>("CommunityId");
					Image image = sqlDataReader.GetImage();
					this._searchModel.Result.Results.First<Community>((Community x) => x.Id == num).Images.Add(image);
				}
			}
			if (sqlDataReader.NextResult())
			{
				while (sqlDataReader.Read())
				{
					long num1 = sqlDataReader.GetValue<long>("CommunityId");
					string valueOrDefault = sqlDataReader.GetValueOrDefault<string>("Amenity");
					this._searchModel.Result.Results.First<Community>((Community x) => x.Id == num1).Amenities.Add(valueOrDefault);
				}
			}
		}

		protected override CommunitySearchModel GetCommandResult(SqlCommand command)
		{
			this._searchModel.Result.TotalCount = (int)command.Parameters["@TotalCount"].Value;
			return this._searchModel;
		}
	}
}