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
	internal class GetAllByOwnerTypeWithPagingCommand : BaseCommand<List<Owner>>
	{
		private readonly OwnerType _ownerType;

		private readonly int _pageNumber;

		private readonly int _pageSize;

		private int _totalCount;

		private readonly List<Owner> _result = new List<Owner>();

		public GetAllByOwnerTypeWithPagingCommand(OwnerType ownerType, int pageNumber, int pageSize)
		{
			base.StoredProcedureName = AdminStoredProcedures.SpGetOwnerGridByClassWithPaging;
			this._ownerType = ownerType;
			this._pageNumber = pageNumber;
			this._pageSize = pageSize;
		}

		protected override void CommandBody(SqlCommand command)
		{
			command.CommandText = base.StoredProcedureName;
			command.CommandType = CommandType.StoredProcedure;
			command.Parameters.Add("@OwnerClassId", SqlDbType.Int).Value = (int)this._ownerType;
			command.Parameters.Add("@PageNumber", SqlDbType.Int).Value = this._pageNumber;
			command.Parameters.Add("@PageSize", SqlDbType.Int).Value = this._pageSize;
			command.Parameters.Add("@TotalCount", SqlDbType.Int).Direction = ParameterDirection.Output;
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
			this._totalCount = (int)command.Parameters["@TotalCount"].Value;
			return this._result;
		}

		public int GetTotalCount()
		{
			return this._totalCount;
		}
	}
}