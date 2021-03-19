using MSLivingChoices.Entities.Admin;
using MSLivingChoices.Entities.Admin.Enums;
using MSLivingChoices.SqlDacs.Helpers;
using MSLivingChoices.SqlDacs.SqlCommands;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace MSLivingChoices.SqlDacs.Admin.SqlCommands
{
	internal class GetAllByOwnerTypeCommand : BaseCommand<List<Owner>>
	{
		private readonly OwnerType _ownerType;

		private readonly List<Owner> _result = new List<Owner>();

		public GetAllByOwnerTypeCommand(OwnerType ownerType)
		{
			base.StoredProcedureName = AdminStoredProcedures.SpGetOwnerGridByClass;
			this._ownerType = ownerType;
		}

		protected override void CommandBody(SqlCommand command)
		{
			command.CommandText = base.StoredProcedureName;
			command.CommandType = CommandType.StoredProcedure;
			command.Parameters.Add("@OwnerClassId", SqlDbType.Int).Value = (int)this._ownerType;
			SqlDataReader dataReader = command.ExecuteReader();
			while (dataReader.Read())
			{
				Owner owner = new Owner()
				{
					Id = dataReader.GetValue<long?>("OwnerId"),
					Name = dataReader.GetValue<string>("Name"),
					WebsiteUrl = dataReader.GetValue<string>("WebsiteUrl")
				};
				this._result.Add(owner);
			}
		}

		protected override List<Owner> GetCommandResult(SqlCommand command)
		{
			return this._result;
		}
	}
}