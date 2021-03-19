using MSLivingChoices.Entities.Admin;
using MSLivingChoices.SqlDacs.Admin.Helpers;
using MSLivingChoices.SqlDacs.SqlCommands;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace MSLivingChoices.SqlDacs.Admin.SqlCommands
{
	internal class GetUnprocessedCommunityImagesCommand : BaseCommand<List<Image>>
	{
		private readonly long _communityId;

		private List<Image> _result;

		public GetUnprocessedCommunityImagesCommand(long communityId)
		{
			this._communityId = communityId;
			base.StoredProcedureName = AdminStoredProcedures.SpGetUnprocessedImages;
		}

		protected override void CommandBody(SqlCommand command)
		{
			command.CommandText = base.StoredProcedureName;
			command.CommandType = CommandType.StoredProcedure;
			command.Parameters.Add("@CommunityId", SqlDbType.BigInt).Value = this._communityId;
			this._result = command.ExecuteReader().GetImages();
		}

		protected override List<Image> GetCommandResult(SqlCommand command)
		{
			return this._result;
		}
	}
}