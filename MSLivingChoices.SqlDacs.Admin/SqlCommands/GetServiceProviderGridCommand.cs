using MSLivingChoices.Configuration;
using MSLivingChoices.Entities.Admin;
using MSLivingChoices.Entities.Admin.Enums;
using MSLivingChoices.SqlDacs.Admin.Helpers;
using MSLivingChoices.SqlDacs.Helpers;
using MSLivingChoices.SqlDacs.SqlCommands;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.SqlDacs.Admin.SqlCommands
{
	internal class GetServiceProviderGridCommand : BaseCommand<List<ServiceProvider>>
	{
		private readonly List<Book> _books;

		private readonly int? _pageNumber;

		private readonly int? _pageSize;

		private readonly ServiceProviderGridSortByOption? _sortBy;

		private readonly OrderBy? _orderBy;

		private readonly ServiceProviderGridFilter _filter;

		private int _totalCount;

		private List<ServiceProvider> _result;

		public GetServiceProviderGridCommand(List<Book> books, int? pageNumber, int? pageSize, ServiceProviderGridSortByOption? sortBy, OrderBy? orderBy, ServiceProviderGridFilter filter)
		{
			base.StoredProcedureName = AdminStoredProcedures.SpGetServiceGridWithPaging;
			this._books = books;
			int? nullable = pageNumber;
			this._pageNumber = new int?((nullable.HasValue ? nullable.GetValueOrDefault() : ConfigurationManager.Instance.DefaultGridPageNumber));
			nullable = pageSize;
			this._pageSize = new int?((nullable.HasValue ? nullable.GetValueOrDefault() : ConfigurationManager.Instance.DefaultGridPageSize));
			this._filter = filter;
			this._sortBy = sortBy;
			this._orderBy = orderBy;
		}

		protected override void CommandBody(SqlCommand command)
		{
			PackageType packageType;
			DateTime? nullable;
			DateTime? item;
			DateTime? item1;
			DateTime? nullable1;
			DateTime? item2;
			command.CommandText = base.StoredProcedureName;
			command.CommandType = CommandType.StoredProcedure;
			command.Parameters.Add("@PageNumber", SqlDbType.Int).Value = this._pageNumber;
			command.Parameters.Add("@Pagesize", SqlDbType.Int).Value = this._pageSize;
			command.Parameters.Add("@SortBy", SqlDbType.NVarChar).Value = this._sortBy.ValueOrDBNull<ServiceProviderGridSortByOption?>();
			command.Parameters.Add("@SortOrder", SqlDbType.NVarChar).Value = this._orderBy.ValueOrDBNull<OrderBy?>();
			command.Parameters.Add("@ServiceProviderName", SqlDbType.VarChar).Value = this._filter.ServiceProvider.ValueOrDBNull<string>();
			command.Parameters.Add("@HasFeature", SqlDbType.Bit).Value = this._filter.Feature.ValueOrDBNull<bool?>();
			command.Parameters.Add("@FeatureStartDate", SqlDbType.Date).Value = this._filter.FeatureStart.ValueOrDBNull<string>();
			command.Parameters.Add("@FeatureEndDate", SqlDbType.Date).Value = this._filter.FeatureEnd.ValueOrDBNull<string>();
			command.Parameters.Add("@IsPublish", SqlDbType.Bit).Value = this._filter.Publish.ValueOrDBNull<bool?>();
			command.Parameters.Add("@PublishStartDate", SqlDbType.Date).Value = this._filter.PublishStart.ValueOrDBNull<string>();
			command.Parameters.Add("@PublishEndDate", SqlDbType.Date).Value = this._filter.PublishEnd.ValueOrDBNull<string>();
			command.Parameters.Add("@CategoriesTable", SqlDbType.Structured).Value = this._filter.Categories.GetAdditionalInfoTable();
			command.Parameters.Add("@PackagesTable", SqlDbType.Structured).Value = this._filter.Packages.GetAdditionalInfoTable();
			command.Parameters.Add("@TotalCount", SqlDbType.Int).Direction = ParameterDirection.Output;
			command.Parameters.Add("@BookTable", SqlDbType.Structured).Value = this._books.GetBookTable();
			SqlDataReader dr = command.ExecuteReader();
			this._result = new List<ServiceProvider>();
			while (dr.Read())
			{
				ServiceProvider serviceProvider = new ServiceProvider()
				{
					Id = new long?(Convert.ToInt64(dr["ServiceId"])),
					Name = Convert.ToString(dr["Name"])
				};
				Enum.TryParse<PackageType>(Convert.ToString(dr["Package"]), out packageType);
				serviceProvider.Package = new PackageType?(((int)packageType == 0 ? PackageType.Basic : packageType));
				serviceProvider.ServiceCategories = new List<KeyValuePair<long, string>>();
				string[] separators = new string[] { ", " };
				string[] serviceCategoriesIds = dr["SHCSubcategories"].ToString().Split(separators, StringSplitOptions.RemoveEmptyEntries);
				serviceProvider.ServiceCategories = (
					from scId in serviceCategoriesIds
					select new KeyValuePair<long, string>(Convert.ToInt64(scId), string.Empty)).ToList<KeyValuePair<long, string>>();
				int featureStart = dr.GetOrdinal("FeatureStart");
				int featureEnd = dr.GetOrdinal("FeatureEnd");
				int publishStart = dr.GetOrdinal("PublishStart");
				int publishEnd = dr.GetOrdinal("PublishEnd");
				ServiceProvider serviceProvider1 = serviceProvider;
				if (!dr.IsDBNull(featureStart))
				{
					item = (DateTime?)dr["FeatureStart"];
				}
				else
				{
					nullable = null;
					item = nullable;
				}
				serviceProvider1.FeatureStartDate = item;
				ServiceProvider serviceProvider2 = serviceProvider;
				if (!dr.IsDBNull(featureEnd))
				{
					item1 = (DateTime?)dr["FeatureEnd"];
				}
				else
				{
					nullable = null;
					item1 = nullable;
				}
				serviceProvider2.FeatureEndDate = item1;
				ServiceProvider serviceProvider3 = serviceProvider;
				if (!dr.IsDBNull(publishStart))
				{
					nullable1 = (DateTime?)dr["PublishStart"];
				}
				else
				{
					nullable = null;
					nullable1 = nullable;
				}
				serviceProvider3.PublishStartDate = nullable1;
				ServiceProvider serviceProvider4 = serviceProvider;
				if (!dr.IsDBNull(publishEnd))
				{
					item2 = (DateTime?)dr["PublishEnd"];
				}
				else
				{
					nullable = null;
					item2 = nullable;
				}
				serviceProvider4.PublishEndDate = item2;
				this._result.Add(serviceProvider);
			}
		}

		protected override List<ServiceProvider> GetCommandResult(SqlCommand command)
		{
			this._totalCount = (int)command.Parameters["@TotalCount"].Value;
			return this._result;
		}

		public int GetTotalCount()
		{
			return this._totalCount;
		}
	}
}