using MSLivingChoices.Configuration;
using MSLivingChoices.Entities.Admin.Enums;
using MSLivingChoices.SqlDacs.Admin.Helpers;
using MSLivingChoices.SqlDacs.SqlCommands;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace MSLivingChoices.SqlDacs.Admin.SqlCommands
{
	internal class SaveAdditionInfoCommand : FreeCacheBaseCommand
	{
		private readonly List<KeyValuePair<int, string>> _additionInfo;

		private readonly AdditionalInfoClass _additionalInfoClass;

		public SaveAdditionInfoCommand(List<KeyValuePair<int, string>> additionInfo, AdditionalInfoClass additionalInfoClass)
		{
			base.StoredProcedureName = AdminStoredProcedures.SpPutAdditionalInformationType;
			this._additionInfo = additionInfo;
			this._additionalInfoClass = additionalInfoClass;
		}

		protected override void CommandBody(SqlCommand command)
		{
			command.CommandText = base.StoredProcedureName;
			command.CommandType = CommandType.StoredProcedure;
			command.Parameters.Add("@UserId", SqlDbType.UniqueIdentifier).Value = ConfigurationManager.Instance.CurrentUserId;
			command.Parameters.Add("@DateTimeStamp", SqlDbType.DateTime).Value = DateTime.Now;
			command.Parameters.Add("@AdditionalInformationClassId", SqlDbType.Int).Value = (int)this._additionalInfoClass;
			command.Parameters.Add("@AdditionalInformationTypeTable", SqlDbType.Structured).Value = this._additionInfo.GetAdditionInfoTypeTable(this._additionalInfoClass);
			command.ExecuteNonQuery();
		}
	}
}