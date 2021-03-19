using MSLivingChoices.SqlDacs.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace MSLivingChoices.SqlDacs.SqlCommands
{
	internal class GetCommunityDefaultAmenitiesCommand : CachedBaseCommand<List<KeyValuePair<int, string>>>
	{
		private List<KeyValuePair<int, string>> _result;

		protected int? SpParameter;

		protected readonly string ParameterName;

		public GetCommunityDefaultAmenitiesCommand()
		{
			base.StoredProcedureName = CommonStoredProcedures.SpGetCommunityAmenityType;
			this.ParameterName = "@CommunityClassId";
			this.SpParameter = new int?(1);
			base.CacheKey = CachedBaseCommand<List<KeyValuePair<int, string>>>.GetCacheKey(new string[] { base.StoredProcedureName, "common", this.ParameterName, this.SpParameter.ToString() });
		}

		protected override void CommandBody(SqlCommand command)
		{
			command.CommandType = CommandType.StoredProcedure;
			command.CommandText = base.StoredProcedureName;
			if (this.SpParameter.HasValue)
			{
				command.Parameters.Add(this.ParameterName, SqlDbType.Int).Value = this.SpParameter;
			}
			SqlDataReader sqlDataReader = command.ExecuteReader();
			this._result = new List<KeyValuePair<int, string>>();
			while (sqlDataReader.Read())
			{
				int? nullableValue = sqlDataReader.GetNullableValue<int>("AmenityTypeId");
				string str = sqlDataReader["Description"].ToString();
				if (!nullableValue.HasValue)
				{
					continue;
				}
				this._result.Add(new KeyValuePair<int, string>(nullableValue.Value, str));
			}
		}

		protected override List<KeyValuePair<int, string>> GetCommandResult(SqlCommand command)
		{
			return this._result;
		}
	}
}