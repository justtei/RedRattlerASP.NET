using MSLivingChoices.Entities.Admin;
using MSLivingChoices.Entities.Admin.Enums;
using MSLivingChoices.SqlDacs.Helpers;
using MSLivingChoices.SqlDacs.SqlCommands;
using System;
using System.Data;
using System.Data.SqlClient;

namespace MSLivingChoices.SqlDacs.Admin.SqlCommands
{
	internal class SaveSeoMetaDataCommand : FreeCacheBaseCommand<Seo>
	{
		private readonly Seo _seo;

		private readonly Seo _result;

		public SaveSeoMetaDataCommand(Seo seo)
		{
			base.StoredProcedureName = AdminStoredProcedures.SpPutSEOData;
			this._seo = seo;
			this._result = new Seo();
		}

		protected override void CommandBody(SqlCommand command)
		{
			command.CommandText = base.StoredProcedureName;
			command.CommandType = CommandType.StoredProcedure;
			command.Parameters.Add("SEODataId", SqlDbType.BigInt).Value = this._seo.SeoId.ValueOrDBNull<int?>();
			command.Parameters.Add("UserId", SqlDbType.UniqueIdentifier).Value = this._seo.UserId;
			command.Parameters.Add("PageTypeId", SqlDbType.Int).Value = (int)this._seo.SeoPage;
			command.Parameters.Add("SearchTypeId", SqlDbType.Int).Value = this._seo.SearchType.ValueOrDBNull<SearchType?>();
			command.Parameters.Add("CountryId", SqlDbType.BigInt).Value = this._seo.CountryId.ValueOrDBNull<long?>();
			command.Parameters.Add("StateId", SqlDbType.BigInt).Value = this._seo.StateId.ValueOrDBNull<long?>();
			command.Parameters.Add("CityId", SqlDbType.BigInt).Value = this._seo.CityId.ValueOrDBNull<long?>();
			command.Parameters.Add("MetaDescription", SqlDbType.VarChar).Value = this._seo.MetaDescription.ValueOrDBNull<string>();
			command.Parameters.Add("SEOCopy", SqlDbType.VarChar).Value = this._seo.SeoCopyText.ValueOrDBNull<string>();
			command.Parameters.Add("MetaKeywords", SqlDbType.VarChar).Value = this._seo.MetaKeyword.ValueOrDBNull<string>();
			SqlParameter outputSeoId = new SqlParameter("@ScopeSEODataId", SqlDbType.Int)
			{
				Direction = ParameterDirection.Output
			};
			command.Parameters.Add(outputSeoId);
			command.ExecuteNonQuery();
			this._result.SeoId = new int?((int)outputSeoId.Value);
		}

		protected override Seo GetCommandResult(SqlCommand command)
		{
			return this._result;
		}
	}
}