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
	internal class GetCallTrackingGridCommand : BaseCommand<List<CallTrackingPhone>>
	{
		private readonly List<Book> _books;

		private readonly int? _pageNumber;

		private readonly int? _pageSize;

		private int _totalCount;

		private List<CallTrackingPhone> _result;

		public GetCallTrackingGridCommand(List<Book> books, int? pageNumber, int? pageSize)
		{
			base.StoredProcedureName = AdminStoredProcedures.SpGetCallTrackingGridWithPaging;
			this._books = books;
			this._pageNumber = pageNumber;
			this._pageSize = pageSize;
		}

		protected override void CommandBody(SqlCommand command)
		{
			command.CommandText = base.StoredProcedureName;
			command.CommandType = CommandType.StoredProcedure;
			command.Parameters.Add("@PageNumber", SqlDbType.Int).Value = this._pageNumber;
			command.Parameters.Add("@Pagesize", SqlDbType.Int).Value = this._pageSize;
			command.Parameters.Add("@TotalCount", SqlDbType.Int).Direction = ParameterDirection.Output;
			using (DataTable bookTable = this._books.GetBookTable())
			{
				command.Parameters.Add("@BookTable", SqlDbType.Structured).Value = bookTable;
				using (SqlDataReader dataReader = command.ExecuteReader())
				{
					this._result = dataReader.GetCallTrackingPhones();
				}
			}
			command.Dispose();
		}

		protected override List<CallTrackingPhone> GetCommandResult(SqlCommand command)
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