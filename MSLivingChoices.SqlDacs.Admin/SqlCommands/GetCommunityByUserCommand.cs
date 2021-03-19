using MSLivingChoices.SqlDacs.SqlCommands;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace MSLivingChoices.SqlDacs.Admin.SqlCommands
{
	internal class GetCommunityByUserCommand : GetItemTypesCommand
	{
		private readonly int _bookId;

		public GetCommunityByUserCommand(int bookId)
		{
			base.StoredProcedureName = AdminStoredProcedures.SpGetCommunityByBook;
			this._bookId = bookId;
			base.CacheKey = CachedBaseCommand<List<KeyValuePair<int, string>>>.GetCacheKey(new string[] { base.StoredProcedureName, this._bookId.ToString() });
		}

		protected override void CommandBody(SqlCommand command)
		{
			command.CommandText = base.StoredProcedureName;
			command.CommandType = CommandType.StoredProcedure;
			command.Parameters.Add("@BookId", SqlDbType.Int).Value = this._bookId;
			SqlDataReader reader = command.ExecuteReader();
			this._result = new List<KeyValuePair<int, string>>();
			while (reader.Read())
			{
				int id = (int)reader["CommunityId"];
				string name = reader["Name"].ToString();
				this._result.Add(new KeyValuePair<int, string>(id, name));
			}
		}

		protected override List<KeyValuePair<int, string>> GetCommandResult(SqlCommand command)
		{
			return this._result;
		}
	}
}