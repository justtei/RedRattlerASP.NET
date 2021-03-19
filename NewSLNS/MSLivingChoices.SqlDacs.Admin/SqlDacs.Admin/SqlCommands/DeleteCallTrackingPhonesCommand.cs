using MSLivingChoices.Entities.Admin;
using MSLivingChoices.SqlDacs.Admin.Helpers;
using MSLivingChoices.SqlDacs.SqlCommands;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace MSLivingChoices.SqlDacs.Admin.SqlCommands
{
	internal class DeleteCallTrackingPhonesCommand : FreeCacheBaseCommand<List<CallTrackingPhone>>
	{
		private readonly Guid _userId;

		private readonly List<CallTrackingPhone> _callTrackingPhones;

		public DeleteCallTrackingPhonesCommand(Guid userId, List<CallTrackingPhone> callTrackingPhones)
		{
			base.StoredProcedureName = AdminStoredProcedures.SpDeleteCallTrackingPhones;
			this._userId = userId;
			this._callTrackingPhones = callTrackingPhones;
		}

		protected override void CommandBody(SqlCommand command)
		{
			command.CommandText = base.StoredProcedureName;
			command.CommandType = CommandType.StoredProcedure;
			command.Parameters.Add("@UserId", SqlDbType.UniqueIdentifier).Value = this._userId;
			command.Parameters.Add("@PhoneIdTable", SqlDbType.Structured).Value = this._callTrackingPhones.GetPhoneIdTable();
			command.ExecuteNonQuery();
		}
	}
}