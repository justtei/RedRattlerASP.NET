using MSLivingChoices.Entities.Admin;
using MSLivingChoices.SqlDacs.Admin;
using MSLivingChoices.SqlDacs.Admin.Helpers;
using MSLivingChoices.SqlDacs.Helpers;
using MSLivingChoices.SqlDacs.SqlCommands;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace MSLivingChoices.SqlDacs.Admin.SqlCommands
{
	internal class IsUsersServiceCommand : BaseCommand<BooleanShell>
	{
		private readonly List<Book> _books;

		private readonly long _serviceId;

		private BooleanShell _result;

		public IsUsersServiceCommand(List<Book> books, long serviceId)
		{
			base.StoredProcedureName = AdminStoredProcedures.SpIsUsersService;
			this._books = books;
			this._serviceId = serviceId;
		}

		protected override void CommandBody(SqlCommand command)
		{
			command.CommandText = base.StoredProcedureName;
			command.CommandType = CommandType.StoredProcedure;
			command.Parameters.Add("@ServiceId", SqlDbType.BigInt).Value = this._serviceId;
			command.Parameters.Add("@BookTable", SqlDbType.Structured).Value = this._books.GetBookTable();
			SqlDataReader dr = command.ExecuteReader();
			if (dr.Read())
			{
				this._result = new BooleanShell()
				{
					Value = dr.GetValue<bool>("IsUsersService")
				};
			}
		}

		protected override BooleanShell GetCommandResult(SqlCommand command)
		{
			return this._result;
		}
	}
}