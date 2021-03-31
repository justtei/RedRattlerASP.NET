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
using System.Linq;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.SqlDacs.Client.SqlCommands
{
	internal class SearchServiceProvidersCommand : CachedBaseCommand<ServiceProviderSearchModel>
	{
		private readonly ServiceProviderSearchModel _searchModel;

		public SearchServiceProvidersCommand(ServiceProviderSearchModel searchModel)
		{
			base.StoredProcedureName = ClientStoredProcedures.SpSearchServicesMap;
			this._searchModel = searchModel;
			this._searchModel.Result = new ServiceProviderSearchResult();
			base.CacheKey = CachedBaseCommand<ServiceProviderSearchModel>.GetCacheKey(new string[] { base.StoredProcedureName, this._searchModel.ToString() });
		}

		protected override void CommandBody(SqlCommand command)
		{
			command.CommandText = base.StoredProcedureName;
			command.CommandType = CommandType.StoredProcedure;
			command.Parameters.Add("@CountryCode", SqlDbType.VarChar, 5).Value = this._searchModel.Criteria.CountryCode().ValueOrDBNull<string>();
			command.Parameters.Add("@StateCode", SqlDbType.VarChar, 3).Value = this._searchModel.Criteria.StateCode().ValueOrDBNull<string>();
			command.Parameters.Add("@City", SqlDbType.VarChar, 50).Value = this._searchModel.Criteria.City().ValueOrDBNull<string>();
			command.Parameters.Add("@PostalCode", SqlDbType.VarChar, 10).Value = this._searchModel.Criteria.Zip().ValueOrDBNull<string>();
			command.Parameters.Add("@ServiceCategoriesIdTable", SqlDbType.Structured).Value = this._searchModel.ServiceCategoriesIds.GetIdsTable();
			command.Parameters.Add("@Sort", SqlDbType.Int).Value = this._searchModel.SortType;
			command.Parameters.Add("@PageNumber", SqlDbType.Int).Value = this._searchModel.PageNumber;
			command.Parameters.Add("@Pagesize", SqlDbType.Int).Value = this._searchModel.PageSize;
			command.Parameters.Add("@TotalCount", SqlDbType.Int).Direction = ParameterDirection.Output;
			SqlDataReader sqlDataReader = command.ExecuteReader();
			while (sqlDataReader.Read())
			{
				ServiceProvider searchService = sqlDataReader.GetSearchService();
				this._searchModel.Result.Results.Add(searchService);
			}
			if (!this._searchModel.Result.Results.Any<ServiceProvider>())
			{
				return;
			}
			if (sqlDataReader.NextResult())
			{
				while (sqlDataReader.Read())
				{
					long value = sqlDataReader.GetValue<long>("ServiceId");
					Image image = sqlDataReader.GetImage();
					this._searchModel.Result.Results.First<ServiceProvider>((ServiceProvider x) => x.Id == value).Images.Add(image);
				}
			}
			if (sqlDataReader.NextResult())
			{
				while (sqlDataReader.Read())
				{
					long num = sqlDataReader.GetValue<long>("ServiceId");
					string shortAdditionalInfo = sqlDataReader.GetShortAdditionalInfo();
					this._searchModel.Result.Results.First<ServiceProvider>((ServiceProvider x) => x.Id == num).ServiceCategories.Add(shortAdditionalInfo);
				}
			}
		}

		protected override ServiceProviderSearchModel GetCommandResult(SqlCommand command)
		{
			this._searchModel.Result.TotalCount = (int)command.Parameters["@TotalCount"].Value;
			return this._searchModel;
		}
	}
}