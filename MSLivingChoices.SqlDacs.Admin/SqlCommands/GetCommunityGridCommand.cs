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
	internal class GetCommunityGridCommand : BaseCommand<List<Community>>
	{
		private readonly List<Book> _books;

		private readonly int _pageNumber;

		private readonly int _pageSize;

		private readonly CommunityGridSortByOption? _sortBy;

		private readonly OrderBy? _orderBy;

		private readonly CommunityGridFilter _filter;

		private int _totalCount;

		private List<Community> _result;

		public GetCommunityGridCommand(List<Book> books, int pageNumber, int pageSize, CommunityGridSortByOption? sortBy, OrderBy? orderBy, CommunityGridFilter filter)
		{
			base.StoredProcedureName = AdminStoredProcedures.SpGetCommunityGridWithPaging;
			this._books = books;
			this._pageNumber = pageNumber;
			this._pageSize = pageSize;
			this._sortBy = sortBy;
			this._orderBy = orderBy;
			this._filter = filter;
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
			command.Parameters.Add("@PageSize", SqlDbType.Int).Value = this._pageSize;
			command.Parameters.Add("@SortBy", SqlDbType.NVarChar).Value = this._sortBy.ValueOrDBNull<CommunityGridSortByOption?>();
			command.Parameters.Add("@SortOrder", SqlDbType.NVarChar).Value = this._orderBy.ValueOrDBNull<OrderBy?>();
			command.Parameters.Add("@CommunityName", SqlDbType.VarChar).Value = this._filter.Community.ValueOrDBNull<string>();
			command.Parameters.Add("@HasAdultApartments", SqlDbType.Bit).Value = this._filter.AAC.ValueOrDBNull<bool?>();
			command.Parameters.Add("@ShowcaseStartDate", SqlDbType.Date).Value = this._filter.ShowcaseStart.ValueOrDBNull<string>();
			command.Parameters.Add("@ShowcaseEndDate", SqlDbType.Date).Value = this._filter.ShowcaseEnd.ValueOrDBNull<string>();
			command.Parameters.Add("@PublishStartDate", SqlDbType.Date).Value = this._filter.PublishStart.ValueOrDBNull<string>();
			command.Parameters.Add("@PublishEndDate", SqlDbType.Date).Value = this._filter.PublishEnd.ValueOrDBNull<string>();
			command.Parameters.Add("@HasAdultHomes", SqlDbType.Bit).Value = this._filter.AAH.ValueOrDBNull<bool?>();
			command.Parameters.Add("@HasSeniorHousing", SqlDbType.Bit).Value = this._filter.SHC.ValueOrDBNull<bool?>();
			command.Parameters.Add("@IsShowcase", SqlDbType.Bit).Value = this._filter.Showcase.ValueOrDBNull<bool?>();
			command.Parameters.Add("@IsPublish", SqlDbType.Bit).Value = this._filter.Publish.ValueOrDBNull<bool?>();
			command.Parameters.Add("@CategoriesTable", SqlDbType.Structured).Value = this._filter.Categories.GetAdditionalInfoTable();
			command.Parameters.Add("@PackagesTable", SqlDbType.Structured).Value = this._filter.Packages.GetAdditionalInfoTable();
			command.Parameters.Add("@TotalCount", SqlDbType.Int).Direction = ParameterDirection.Output;
			command.Parameters.Add("@BookTable", SqlDbType.Structured).Value = this._books.GetBookTable();
			StaticDebugger.CommandText = command.CommandText;
			DataTable dt = new DataTable();
			new SqlDataAdapter(command).Fill(dt);
			SqlDataReader dr1 = command.ExecuteReader();
			DataSet ds = new DataSet();
			ds.Tables.Add(dt);
			StaticDebugger.DataTable = ds.GetXml();
			this._result = new List<Community>();
			foreach(DataRow dr in dt.Rows)
            {

				Community community = new Community()
				{
					Id = new long?(Convert.ToInt64(dr["CommunityId"])),
					Name = Convert.ToString(dr["Name"]),
					CreateUserId =(Guid) dr[("CreateUserId")]
				};
				string bookNumber = (String)dr["BookNumber"];
				community.Book = new Book()
				{
					Number = bookNumber
				};
				Enum.TryParse<PackageType>(Convert.ToString(dr["Package"]), out packageType);
				community.Package = new PackageType?(((int)packageType == 0 ? PackageType.Basic : packageType));
				community.ListingTypes = new List<ListingType>();
				if (!dr.IsNull("HasAdultApartments") && (bool)dr["HasAdultApartments"])
				{
					community.ListingTypes.Add(ListingType.ActiveAdultCommunities);
				}
				if (!dr.IsNull("HasAdultHomes") && (bool)dr["HasAdultHomes"])
				{
					community.ListingTypes.Add(ListingType.ActiveAdultHomes);
				}
				community.SeniorHousingAndCareCategoryIds = new List<long>();
				if (!dr.IsNull("HasSeniorHousing") && (bool)dr["HasSeniorHousing"])
				{
					community.ListingTypes.Add(ListingType.SeniorHousingAndCare);
					string[] shacCategoriesIds = dr["SHCSubcategories"].ToString().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
					community.SeniorHousingAndCareCategoryIds = (
						from strId in shacCategoriesIds
						select Convert.ToInt64(strId)).ToList<long>();
				}
				DateTimeBoundary showcase = community.Showcase;
				if (!dr.IsNull("ShowcaseStart"))
				{
					item = (DateTime?)dr["ShowcaseStart"];
				}
				else
				{
					nullable = null;
					item = nullable;
				}
				showcase.StartDate = item;
				DateTimeBoundary dateTimeBoundary = community.Showcase;
				if (!dr.IsNull("ShowcaseEnd"))
				{
					item1 = (DateTime?)dr["ShowcaseEnd"];
				}
				else
				{
					nullable = null;
					item1 = nullable;
				}
				dateTimeBoundary.EndDate = item1;
				DateTimeBoundary<PublishingStatus> publishing = community.Publishing;
				if (!dr.IsNull("PublishStart"))
				{
					nullable1 = (DateTime?)dr["PublishStart"];
				}
				else
				{
					nullable = null;
					nullable1 = nullable;
				}
				publishing.StartDate = nullable1;
				DateTimeBoundary<PublishingStatus> publishing1 = community.Publishing;
				if (!dr.IsNull("PublishEnd"))
				{
					item2 = (DateTime?)dr["PublishEnd"];
				}
				else
				{
					nullable = null;
					item2 = nullable;
				}
				publishing1.EndDate = item2;
				this._result.Add(community);
			}
		}

		protected override List<Community> GetCommandResult(SqlCommand command)
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