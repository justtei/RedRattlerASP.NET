using MSLivingChoices.Entities.Admin;
using MSLivingChoices.SqlDacs.SqlCommands;
using System;
using System.Data;
using System.Data.SqlClient;

namespace MSLivingChoices.SqlDacs.Admin.SqlCommands
{
	internal class GetStateByIdCommand : CachedBaseCommand<State>
	{
		protected long? StateId;

		private State _result;

		public GetStateByIdCommand(long? stateId)
		{
			base.StoredProcedureName = AdminStoredProcedures.SpGetStateById;
			this.StateId = stateId;
			base.CacheKey = CachedBaseCommand<State>.GetCacheKey(new string[] { base.StoredProcedureName, this.StateId.ToString() });
		}

		protected override void CommandBody(SqlCommand command)
		{
			command.CommandText = base.StoredProcedureName;
			command.CommandType = CommandType.StoredProcedure;
			command.Parameters.Add("@StateId", SqlDbType.Int).Value = this.StateId;
			SqlDataReader reader = command.ExecuteReader();
			this._result = new State();
			if (reader.Read())
			{
				int id = (int)reader["StateId"];
				string name = reader["State"].ToString().Trim();
				string code = reader["StateCode"].ToString().Trim();
				if (id != 0)
				{
					this._result = new State()
					{
						Id = new long?((long)id),
						Name = name,
						Code = code
					};
				}
			}
		}

		protected override State GetCommandResult(SqlCommand command)
		{
			return this._result;
		}
	}
}