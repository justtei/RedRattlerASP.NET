using MSLivingChoices.Entities.Admin;
using MSLivingChoices.SqlDacs.Admin.Helpers;
using MSLivingChoices.SqlDacs.SqlCommands;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace MSLivingChoices.SqlDacs.Admin.SqlCommands
{
	internal class GetCountiesServedByIdCommand : CachedBaseCommand<List<County>>
	{
		protected readonly long _id;

		private List<County> _result;

		public GetCountiesServedByIdCommand(long id)
		{
			base.StoredProcedureName = AdminStoredProcedures.SpGetCountiesServedForServices;
			this._id = id;
			base.CacheKey = CachedBaseCommand<List<County>>.GetCacheKey(new string[] { base.StoredProcedureName, this._id.ToString() });
		}

		protected override void CommandBody(SqlCommand command)
		{
			command.CommandText = base.StoredProcedureName;
			command.CommandType = CommandType.StoredProcedure;
			command.Parameters.Add("@ServiceId", SqlDbType.BigInt).Value = this._id;
			this._result = command.ExecuteReader().GetCounties();
		}

		protected override List<County> GetCommandResult(SqlCommand command)
		{
			return this._result;
		}
	}
}