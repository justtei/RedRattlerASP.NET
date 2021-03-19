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
			_seo = seo;
		}

		protected override void CommandBody(SqlCommand command)
		{
			command.CommandText = base.StoredProcedureName;
			command.CommandType = CommandType.StoredProcedure;
			command.Parameters.Add("PageTypeId", SqlDbType.Int).Value = (int)_seo.SeoPage;
			command.Parameters.Add("SearchTypeId", SqlDbType.Int).Value = _seo.SearchType.ValueOrDBNull();
			command.Parameters.Add("CountryId", SqlDbType.BigInt).Value = _seo.CountryId.ValueOrDBNull();
			command.Parameters.Add("StateId", SqlDbType.BigInt).Value = _seo.StateId.ValueOrDBNull();
			command.Parameters.Add("CityId", SqlDbType.BigInt).Value = _seo.CityId.ValueOrDBNull();
			SqlDataReader reader = command.ExecuteReader();
			_result = reader.GetSeo();
		}

		protected override Seo GetCommandResult(SqlCommand command)
		{
			return _result;
		}
	}

}