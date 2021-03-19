using MSLivingChoices.Entities.Admin.Enums;
using MSLivingChoices.SqlDacs.Helpers;
using MSLivingChoices.SqlDacs.SqlCommands;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace MSLivingChoices.SqlDacs.Admin.SqlCommands
{
	internal class ThreeParamGenericGetCommand : GetItemTypesCommand
	{
		protected MSLivingChoices.Entities.Admin.Enums.OwnerType? OwnerType;

		protected MSLivingChoices.Entities.Admin.Enums.CommunityType? CommunityType;

		protected MSLivingChoices.Entities.Admin.Enums.ServiceType? ServiceType;

		protected ThreeParamGenericGetCommand()
		{
		}

		protected override void CommandBody(SqlCommand command)
		{
			command.CommandText = base.StoredProcedureName;
			command.CommandType = CommandType.StoredProcedure;
			command.Parameters.Add("OwnerClassId", SqlDbType.Int).Value = this.OwnerType.ValueOrDBNull<MSLivingChoices.Entities.Admin.Enums.OwnerType?>();
			command.Parameters.Add("CommunityClassId", SqlDbType.Int).Value = this.CommunityType.ValueOrDBNull<MSLivingChoices.Entities.Admin.Enums.CommunityType?>();
			command.Parameters.Add("ServiceClassId", SqlDbType.Int).Value = this.ServiceType.ValueOrDBNull<MSLivingChoices.Entities.Admin.Enums.ServiceType?>();
			SqlDataReader reader = command.ExecuteReader();
			this._result = new List<KeyValuePair<int, string>>();
			while (reader.Read())
			{
				int id = (int)reader[this.IdColumnName];
				string description = reader[this.DescriptionColumnName].ToString();
				this._result.Add(new KeyValuePair<int, string>(id, description));
			}
		}
	}
}