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
	internal class ChangeShowcaseDatesCommand : FreeCacheBaseCommand<Community>
	{
		private readonly long _communityId;

		private readonly DateTime? _startDate;

		private readonly DateTime? _endDate;

		private readonly int _showcaseTypeId;

		public ChangeShowcaseDatesCommand(long communityId, DateTime? startDate, DateTime? endDate, int showcaseTypeId)
		{
			base.StoredProcedureName = AdminStoredProcedures.SpPutAdditionalInformation;
			this._communityId = communityId;
			this._startDate = startDate;
			this._endDate = endDate;
			this._showcaseTypeId = showcaseTypeId;
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
			command.Parameters.Add("@AdditionalInformationClassId", SqlDbType.Int).Value = 7;
			SqlParameter sqlParameter = command.Parameters.Add("@AdditionalInformationTable", SqlDbType.Structured);
			DataTable additionalInfoTableValue = TableParamsExtensions.GetDateTable(this._startDate, this._endDate, new AdditionalInfoClass?(AdditionalInfoClass.Showcase), this._showcaseTypeId);
			sqlParameter.Value = additionalInfoTableValue;
			command.ExecuteNonQuery();
		}
	}
}