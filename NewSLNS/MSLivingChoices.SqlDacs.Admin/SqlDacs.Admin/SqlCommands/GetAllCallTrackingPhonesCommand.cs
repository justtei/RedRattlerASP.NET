using MSLivingChoices.Entities.Admin;
using MSLivingChoices.SqlDacs.Admin.Helpers;
using MSLivingChoices.SqlDacs.SqlCommands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;

namespace MSLivingChoices.SqlDacs.Admin.SqlCommands
{
	internal class GetAllCallTrackingPhonesCommand : BaseCommand<List<CallTrackingPhone>>
	{
		private List<CallTrackingPhone> _result;

		private readonly List<Book> _books;

		public GetAllCallTrackingPhonesCommand(List<Book> books)
		{
			base.StoredProcedureName = AdminStoredProcedures.SpGetCallTrackingPhones;
			this._books = books;
		}

		protected override void CommandBody(SqlCommand command)
		{
			command.CommandText = base.StoredProcedureName;
			command.CommandType = CommandType.StoredProcedure;
			DataTable bookTable = this._books.GetBookTable();
			command.Parameters.Add("@BookTable", SqlDbType.Structured).Value = bookTable;
			using (SqlDataReader dataReader = command.ExecuteReader())
			{
				this._result = dataReader.GetCallTrackingPhones();
			}
			command.Dispose();
		}

		protected override List<CallTrackingPhone> GetCommandResult(SqlCommand command)
		{
			return this._result;
		}
	}
}