using MSLivingChoices.SqlDacs.SqlCommands;
using System;
using System.Data;
using System.Data.SqlClient;

namespace MSLivingChoices.SqlDacs.Admin.SqlCommands
{
	internal class DeleteCommunityByIdCommand : FreeCacheBaseCommand
	{
		private readonly long _communityId;

		public DeleteCommunityByIdCommand(long communityId)
		{
			base.StoredProcedureName = AdminStoredProcedures.SpDeleteCommunity;
			this._communityId = communityId;
		}

		protected override void CommandBody(SqlCommand command)
		{
			command.CommandText = base.StoredProcedureName;
			command.CommandType = CommandType.StoredProcedure;
			command.Parameters.Add("@CommunityId", SqlDbType.BigInt).Value = this._communityId;
			command.ExecuteNonQuery();
		}
	}
}