using MSLivingChoices.SqlDacs.SqlCommands;
using System;
using System.Data;
using System.Data.SqlClient;

namespace MSLivingChoices.SqlDacs.Admin.SqlCommands
{
	internal class ValidateCallTrackingPhonesCommand : FreeCacheBaseCommand
	{
		private readonly Guid _userId;

		public ValidateCallTrackingPhonesCommand(Guid userId)
		{
			base.StoredProcedureName = AdminStoredProcedures.SpValidateCallTrackingPhones;
			this._userId = userId;
		}

		protected override void CommandBody(SqlCommand command)
		{
			command.CommandText = base.StoredProcedureName;
			command.CommandType = CommandType.StoredProcedure;
			command.Parameters.Add("@UserId", SqlDbType.UniqueIdentifier).Value = this._userId;
			command.ExecuteNonQuery();
		}
	}
}