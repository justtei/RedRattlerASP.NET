using MSLivingChoices.Configuration;
using MSLivingChoices.Entities.Admin.Enums;
using MSLivingChoices.SqlDacs.Admin.Helpers;
using MSLivingChoices.SqlDacs.SqlCommands;
using System;
using System.Data;
using System.Data.SqlClient;

namespace MSLivingChoices.SqlDacs.Admin.SqlCommands
{
	internal class ChangePackageTypeForCommunityCommand : FreeCacheBaseCommand<PackageType>
	{
		private readonly long _communityId;

		private readonly PackageType _packageType;

		public ChangePackageTypeForCommunityCommand(long communityId, PackageType packageType)
		{
			base.StoredProcedureName = AdminStoredProcedures.SpPutAdditionalInformation;
			this._communityId = communityId;
			this._packageType = packageType;
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
			command.Parameters.Add("@AdditionalInformationClassId", SqlDbType.Int).Value = 1;
			command.Parameters.Add("@AdditionalInformationTable", SqlDbType.Structured).Value = this._packageType.GetAdditionalInfoTable(false);
			command.ExecuteNonQuery();
		}
	}
}