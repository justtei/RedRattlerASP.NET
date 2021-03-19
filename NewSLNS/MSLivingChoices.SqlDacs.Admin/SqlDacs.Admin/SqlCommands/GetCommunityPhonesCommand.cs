using MSLivingChoices.Entities.Admin;
using MSLivingChoices.SqlDacs.Admin.Helpers;
using MSLivingChoices.SqlDacs.SqlCommands;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace MSLivingChoices.SqlDacs.Admin.SqlCommands
{
	internal class GetCommunityPhonesCommand : BaseCommand<Tuple<List<Phone>, List<CallTrackingPhone>>>
	{
		private readonly long _communityId;

		private Tuple<List<Phone>, List<CallTrackingPhone>> _result;

		public GetCommunityPhonesCommand(long communityId)
		{
			base.StoredProcedureName = AdminStoredProcedures.SpGetPhone;
			this._communityId = communityId;
		}

		protected override void CommandBody(SqlCommand command)
		{
			command.CommandText = base.StoredProcedureName;
			command.CommandType = CommandType.StoredProcedure;
			command.Parameters.Add("@OwnerId", SqlDbType.BigInt).Value = DBNull.Value;
			command.Parameters.Add("@CommunityId", SqlDbType.BigInt).Value = this._communityId;
			command.Parameters.Add("@ContactId", SqlDbType.BigInt).Value = DBNull.Value;
			command.Parameters.Add("@ServiceId", SqlDbType.BigInt).Value = DBNull.Value;
			command.Parameters.Add("@WhichPhones", SqlDbType.Int).Value = 3;
			this._result = command.ExecuteReader().GetPhones();
		}

		protected override Tuple<List<Phone>, List<CallTrackingPhone>> GetCommandResult(SqlCommand command)
		{
			return this._result;
		}
	}
}