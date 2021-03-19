using MSLivingChoices.Configuration;
using MSLivingChoices.Entities.Admin;
using MSLivingChoices.Entities.Admin.Enums;
using MSLivingChoices.SqlDacs.SqlCommands;
using System;
using System.Data;
using System.Data.SqlClient;

namespace MSLivingChoices.SqlDacs.Admin.SqlCommands
{
	internal class ChangeListingTypeStateCommand : FreeCacheBaseCommand<Community>
	{
		private readonly long _communityId;

		private readonly ListingType _listingType;

		private readonly bool _value;

		public ChangeListingTypeStateCommand(long communityId, ListingType listingType, bool value)
		{
			base.StoredProcedureName = AdminStoredProcedures.SpPutCommunityListingType;
			this._communityId = communityId;
			this._listingType = listingType;
			this._value = value;
		}

		protected override void CommandBody(SqlCommand command)
		{
			command.CommandText = base.StoredProcedureName;
			command.CommandType = CommandType.StoredProcedure;
			command.Parameters.Add("@CommunityId", SqlDbType.BigInt).Value = this._communityId;
			command.Parameters.Add("@ListingType", SqlDbType.Int).Value = this._listingType;
			command.Parameters.Add("@Value", SqlDbType.Bit).Value = this._value;
			command.Parameters.Add("@UserId", SqlDbType.UniqueIdentifier).Value = ConfigurationManager.Instance.CurrentUserId;
			command.Parameters.Add("@DateTimeStamp", SqlDbType.DateTime).Value = DateTime.Now;
			command.ExecuteNonQuery();
		}
	}
}