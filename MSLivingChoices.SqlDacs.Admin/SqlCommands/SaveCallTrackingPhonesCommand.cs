using MSLivingChoices.Configuration;
using MSLivingChoices.Entities.Admin;
using MSLivingChoices.SqlDacs.Admin.Helpers;
using MSLivingChoices.SqlDacs.Helpers;
using MSLivingChoices.SqlDacs.SqlCommands;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace MSLivingChoices.SqlDacs.Admin.SqlCommands
{
	internal class SaveCallTrackingPhonesCommand : FreeCacheBaseCommand<List<CallTrackingPhone>>
	{
		private readonly long? _communityId;

		private readonly long? _serviceId;

		private readonly string _marchexAccountId;

		private List<CallTrackingPhone> _callTrackingPhones;

		public SaveCallTrackingPhonesCommand(long communityId, List<CallTrackingPhone> callTrackingPhones)
		{
			this._communityId = new long?(communityId);
			this.InitCommand(callTrackingPhones);
		}

		public SaveCallTrackingPhonesCommand(Community community)
		{
			this._communityId = community.Id;
			this._marchexAccountId = community.MarchexAccountId;
			this.InitCommand(community.CallTrackingPhones);
		}

		public SaveCallTrackingPhonesCommand(ServiceProvider serviceProvider)
		{
			this._serviceId = serviceProvider.Id;
			this._marchexAccountId = serviceProvider.MarchexAccountId;
			this.InitCommand(serviceProvider.CallTrackingPhones);
		}

		protected override void CommandBody(SqlCommand command)
		{
			command.CommandText = base.StoredProcedureName;
			command.CommandType = CommandType.StoredProcedure;
			command.Parameters.Add("@UserId", SqlDbType.UniqueIdentifier).Value = ConfigurationManager.Instance.CurrentUserId;
			command.Parameters.Add("@DateTimeStamp", SqlDbType.DateTime).Value = DateTime.Now;
			command.Parameters.Add("@OwnerId", SqlDbType.BigInt).Value = DBNull.Value;
			command.Parameters.Add("@CommunityId", SqlDbType.BigInt).Value = this._communityId.ValueOrDBNull<long?>();
			command.Parameters.Add("@ContactId", SqlDbType.BigInt).Value = DBNull.Value;
			command.Parameters.Add("@ServiceId", SqlDbType.BigInt).Value = this._serviceId.ValueOrDBNull<long?>();
			command.Parameters.Add("@WhichPhones", SqlDbType.Int).Value = 2;
			command.Parameters.Add("@MARCHEX_AccountId", SqlDbType.VarChar, 24).Value = this._marchexAccountId;
			command.Parameters.Add("@PhoneTable", SqlDbType.Structured).Value = this._callTrackingPhones.GetPhonesTable();
			command.ExecuteNonQuery();
		}

		private void InitCommand(List<CallTrackingPhone> callTrackingPhones)
		{
			base.StoredProcedureName = AdminStoredProcedures.SpPutPhone;
			this._callTrackingPhones = callTrackingPhones;
		}
	}
}