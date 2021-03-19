using MSLivingChoices.Configuration;
using MSLivingChoices.Entities.Admin;
using MSLivingChoices.Entities.Admin.Enums;
using MSLivingChoices.SqlDacs.Admin.Helpers;
using MSLivingChoices.SqlDacs.SqlCommands;
using System;
using System.Data;
using System.Data.SqlClient;

namespace MSLivingChoices.SqlDacs.Admin.SqlCommands
{
	internal class ChangePublishDatesForCommunityCommand : FreeCacheBaseCommand<Community>
	{
		private readonly long _communityId;

		private readonly DateTime? _startDate;

		private readonly DateTime? _endDate;

		private readonly int _publishTypeId;

		public ChangePublishDatesForCommunityCommand(long communityId, DateTime? startDate, DateTime? endDate, int publishTypeId)
		{
			base.StoredProcedureName = AdminStoredProcedures.SpPutAdditionalInformation;
			this._communityId = communityId;
			this._startDate = startDate;
			this._endDate = endDate;
			this._publishTypeId = publishTypeId;
		}

		protected override void CommandBody(SqlCommand command)
		{
			command.CommandText = base.StoredProcedureName;
			command.CommandType = CommandType.StoredProcedure;
			command.Parameters.Add("@UserId", SqlDbType.UniqueIdentifier).Value = ConfigurationManager.Instance.CurrentUserId;
			command.Parameters.Add("@DateTimeStamp", SqlDbType.DateTime).Value = DateTime.Now;
			command.Parameters.Add("@CommunityId", SqlDbType.BigInt).Value = this._communityId;
			command.Parameters.Add("@CommunityUnitId", SqlDbType.BigInt).Value = DBNull.Value;
			command.Parameters.Add("@ServiceId", SqlDbType.BigInt).Value = DBNull.Value;
			command.Parameters.Add("@AdditionalInformationClassId", SqlDbType.Int).Value = 4;
			SqlParameter sqlParameter = command.Parameters.Add("@AdditionalInformationTable", SqlDbType.Structured);
			DataTable additionalInfoTableValue = TableParamsExtensions.GetDateTable(this._startDate, this._endDate, new AdditionalInfoClass?(AdditionalInfoClass.Publish), this._publishTypeId);
			sqlParameter.Value = additionalInfoTableValue;
			command.ExecuteNonQuery();
		}
	}
}