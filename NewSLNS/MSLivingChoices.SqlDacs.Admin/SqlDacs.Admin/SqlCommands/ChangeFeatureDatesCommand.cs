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
	internal class ChangeFeatureDatesCommand : FreeCacheBaseCommand<ServiceProvider>
	{
		private readonly long _serviceProviderId;

		private readonly DateTime? _startDate;

		private readonly DateTime? _endDate;

		private readonly int _featureTypeId;

		public ChangeFeatureDatesCommand(long serviceProviderId, DateTime? startDate, DateTime? endDate, int featureTypeId)
		{
			base.StoredProcedureName = AdminStoredProcedures.SpPutAdditionalInformation;
			this._serviceProviderId = serviceProviderId;
			this._startDate = startDate;
			this._endDate = endDate;
			this._featureTypeId = featureTypeId;
		}

		protected override void CommandBody(SqlCommand command)
		{
			command.CommandText = base.StoredProcedureName;
			command.CommandType = CommandType.StoredProcedure;
			command.Parameters.Add("@UserId", SqlDbType.UniqueIdentifier).Value = ConfigurationManager.Instance.CurrentUserId;
			command.Parameters.Add("@DateTimeStamp", SqlDbType.DateTime).Value = DateTime.Now;
			command.Parameters.Add("@CommunityId", SqlDbType.BigInt).Value = DBNull.Value;
			command.Parameters.Add("@CommunityUnitId", SqlDbType.BigInt).Value = DBNull.Value;
			command.Parameters.Add("@ServiceId", SqlDbType.BigInt).Value = this._serviceProviderId;
			command.Parameters.Add("@AdditionalInformationClassId", SqlDbType.Int).Value = 3;
			SqlParameter sqlParameter = command.Parameters.Add("@AdditionalInformationTable", SqlDbType.Structured);
			DataTable additionalInfoTableValue = TableParamsExtensions.GetDateTable(this._startDate, this._endDate, new AdditionalInfoClass?(AdditionalInfoClass.Feature), this._featureTypeId);
			sqlParameter.Value = additionalInfoTableValue;
			command.ExecuteNonQuery();
		}
	}
}