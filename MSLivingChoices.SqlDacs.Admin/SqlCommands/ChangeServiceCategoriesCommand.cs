using MSLivingChoices.Configuration;
using MSLivingChoices.Entities.Admin;
using MSLivingChoices.SqlDacs.Admin.Helpers;
using MSLivingChoices.SqlDacs.SqlCommands;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace MSLivingChoices.SqlDacs.Admin.SqlCommands
{
	internal class ChangeServiceCategoriesCommand : FreeCacheBaseCommand<ServiceProvider>
	{
		private readonly long _serviceProviderId;

		private readonly List<long> _serviceCategoriesIds;

		public ChangeServiceCategoriesCommand(long serviceProviderId, List<long> serviceCategoriesIds)
		{
			base.StoredProcedureName = AdminStoredProcedures.SpPutAdditionalInformation;
			this._serviceProviderId = serviceProviderId;
			this._serviceCategoriesIds = serviceCategoriesIds;
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
			command.Parameters.Add("@AdditionalInformationClassId", SqlDbType.Int).Value = 10;
			command.Parameters.Add("@AdditionalInformationTable", SqlDbType.Structured).Value = this._serviceCategoriesIds.GetSeniorHousingAdditionalInfoTable(true);
			command.ExecuteNonQuery();
		}
	}
}