using MSLivingChoices.Entities.Admin;
using MSLivingChoices.SqlDacs.Admin.Helpers;
using MSLivingChoices.SqlDacs.Helpers;
using MSLivingChoices.SqlDacs.SqlCommands;
using System;
using System.Data;
using System.Data.SqlClient;

namespace MSLivingChoices.SqlDacs.Admin.SqlCommands
{
	internal class GetSeoMetaDataCommand : BaseCommand<Seo>
	{
		private readonly Seo _seo;

		private Seo _result;

		public GetSeoMetaDataCommand(Seo seo)
		{
			base.StoredProcedureName = AdminStoredProcedures.SpGetSEOData;
			this._seo = seo;
		}

		protected override void CommandBody(SqlCommand command)
		{
			command.CommandText = base.StoredProcedureName;
			command.CommandType = CommandType.StoredProcedure;
			command.Parameters.Add("PageTypeId", SqlDbType.Int).Value = (int)this._seo.SeoPage;
			command.Parameters.Add("SearchTypeId", SqlDbType.Int).Value = this._seo.SearchType.ValueOrDBNull<SearchType?>();
			command.Parameters.Add("CountryId", SqlDbType.BigInt).Value = this._seo.CountryId.ValueOrDBNull<long?>();
			command.Parameters.Add("StateId", SqlDbType.BigInt).Value = this._seo.StateId.ValueOrDBNull<long?>();
			command.Parameters.Add("CityId", SqlDbType.BigInt).Value = this._seo.CityId.ValueOrDBNull<long?>();
			using (SqlDataReader reader = command.ExecuteReader())
			{
				this._result = reader.GetSeo();
			}
		}

		protected override Seo GetCommandResult(SqlCommand command)
		{
			return this._result;
		}
	}
}