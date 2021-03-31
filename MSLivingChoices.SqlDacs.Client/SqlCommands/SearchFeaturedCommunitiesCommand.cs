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

namespace MSLivingChoices.SqlDacs.Client.SqlCommands
{
	internal class SearchFeaturedCommunitiesCommand : BaseCommand<FeaturedCommunitySearchModel>
	{
		private readonly FeaturedCommunitySearchModel _searchModel;

		public SearchFeaturedCommunitiesCommand(FeaturedCommunitySearchModel searchModel)
		{
			base.StoredProcedureName = ClientStoredProcedures.SpGetFeaturedCommunities;
			this._searchModel = searchModel;
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
			command.Parameters.Add("@MaxCount", SqlDbType.Int).Value = this._searchModel.MaxCount;
			SqlDataReader sqlDataReader = command.ExecuteReader();
			this._searchModel.Result = new List<Community>();
			while (sqlDataReader.Read())
			{
				Community featuredCommunity = sqlDataReader.GetFeaturedCommunity();
				this._searchModel.Result.Add(featuredCommunity);
			}
		}

		protected override FeaturedCommunitySearchModel GetCommandResult(SqlCommand command)
		{
			return this._searchModel;
		}
	}
}