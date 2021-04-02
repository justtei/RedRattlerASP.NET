using MSLivingChoices.Entities.Client;
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
	internal class SearchFeaturedServicesCommand : BaseCommand<FeaturedServiceProviderSearchModel>
	{
		private readonly FeaturedServiceProviderSearchModel _searchModel;
		private readonly long id = -1;
		public SearchFeaturedServicesCommand(FeaturedServiceProviderSearchModel searchModel)
		{
			base.StoredProcedureName = ClientStoredProcedures.SpGetFeaturedServices;
			this._searchModel = searchModel;
		}
		public SearchFeaturedServicesCommand(FeaturedServiceProviderSearchModel searchModel,long SimilarId)
		{
			base.StoredProcedureName = "spGetSimilarServices";
			this._searchModel = searchModel;
			this.id = SimilarId;
		}
		protected override void CommandBody(SqlCommand command)
		{
			command.CommandText = base.StoredProcedureName;
			command.CommandType = CommandType.StoredProcedure;
			command.Parameters.Add("@CountryCode", SqlDbType.VarChar, 5).Value = this._searchModel.Criteria.CountryCode().ValueOrDBNull<string>();
			command.Parameters.Add("@StateCode", SqlDbType.VarChar, 3).Value = this._searchModel.Criteria.StateCode().ValueOrDBNull<string>();
			command.Parameters.Add("@City", SqlDbType.VarChar, 50).Value = this._searchModel.Criteria.City().ValueOrDBNull<string>();
			command.Parameters.Add("@CommunityId", SqlDbType.BigInt).Value = this._searchModel.CommunityId.ValueOrDBNull<long?>();
			command.Parameters.Add("@ServiceId", SqlDbType.BigInt).Value = this._searchModel.ServiceId.ValueOrDBNull<long?>();
			command.Parameters.Add("@MaxCount", SqlDbType.Int).Value = this._searchModel.MaxCount;
			if(id != -1)
				command.Parameters.Add("@Id", SqlDbType.BigInt).Value = this.id;
			SqlDataReader sqlDataReader = command.ExecuteReader();
			this._searchModel.Result = new List<ServiceProvider>();
			while (sqlDataReader.Read())
			{
				ServiceProvider featuredService;
				if (id != -1)
					featuredService = sqlDataReader.GetFeaturedService(true);
				else
					featuredService = sqlDataReader.GetFeaturedService();
				this._searchModel.Result.Add(featuredService);
			}
		}

		protected override FeaturedServiceProviderSearchModel GetCommandResult(SqlCommand command)
		{
			return this._searchModel;
		}
	}
}