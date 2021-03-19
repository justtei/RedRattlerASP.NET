using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace MSLivingChoices.SqlDacs.SqlCommands
{
	public class GetItemTypesCommand : CachedBaseCommand<List<KeyValuePair<int, string>>>
	{
		protected string IdColumnName;

		protected string DescriptionColumnName;

		protected int? SpParameter;

		protected string ParameterName;

		protected List<KeyValuePair<int, string>> _result;

		public GetItemTypesCommand()
		{
		}

		protected override void CommandBody(SqlCommand command)
		{
			command.CommandText = base.StoredProcedureName;
			command.CommandType = CommandType.StoredProcedure;
			if (this.SpParameter.HasValue)
			{
				command.Parameters.Add(this.ParameterName, SqlDbType.Int).Value = this.SpParameter;
			}
			SqlDataReader sqlDataReader = command.ExecuteReader();
			this._result = new List<KeyValuePair<int, string>>();
			while (sqlDataReader.Read())
			{
				int item = (int)sqlDataReader[this.IdColumnName];
				string str = sqlDataReader[this.DescriptionColumnName].ToString();
				this._result.Add(new KeyValuePair<int, string>(item, str));
			}
		}

		protected override List<KeyValuePair<int, string>> GetCommandResult(SqlCommand command)
		{
			return this._result;
		}
	}
}