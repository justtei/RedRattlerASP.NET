using MSLivingChoices.Entities.Admin;
using MSLivingChoices.Entities.Admin.Enums;
using MSLivingChoices.SqlDacs.Admin.Helpers;
using MSLivingChoices.SqlDacs.SqlCommands;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace MSLivingChoices.SqlDacs.Admin.SqlCommands
{
	internal class GetUnprocessedImagesCommand : BaseCommand<List<Image>>
	{
		private readonly ImageOwner _owner;

		private readonly long _entityId;

		private List<Image> _result;

		public GetUnprocessedImagesCommand(ImageOwner owner, long entityId)
		{
			this._owner = owner;
			this._entityId = entityId;
			base.StoredProcedureName = AdminStoredProcedures.SpGetUnprocessedImages;
		}

		protected override void CommandBody(SqlCommand command)
		{
			string primaryParamName;
			command.CommandText = base.StoredProcedureName;
			command.CommandType = CommandType.StoredProcedure;
			switch (this._owner)
			{
				case ImageOwner.Community:
				{
					primaryParamName = "@CommunityId";
					break;
				}
				case ImageOwner.CommunityUnit:
				{
					primaryParamName = "@CommunityUnitId";
					break;
				}
				case ImageOwner.Service:
				{
					primaryParamName = "@ServiceId";
					break;
				}
				case ImageOwner.Owner:
				{
					primaryParamName = "@OwnerId";
					break;
				}
				case ImageOwner.Contact:
				{
					primaryParamName = "@ContactId";
					break;
				}
				default:
				{
					primaryParamName = "@CommunityId";
					break;
				}
			}
			command.Parameters.Add(primaryParamName, SqlDbType.BigInt).Value = this._entityId;
			this._result = command.ExecuteReader().GetImages();
		}

		protected override List<Image> GetCommandResult(SqlCommand command)
		{
			return this._result;
		}
	}
}