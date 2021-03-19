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
	internal class IsUserCommunityCommand : BaseCommand<BooleanShell>
	{
		private readonly List<Book> _books;

		private readonly long _communityId;

		private BooleanShell _result;

		public IsUserCommunityCommand(List<Book> books, long communityId)
		{
			base.StoredProcedureName = AdminStoredProcedures.SpIsUsersCommunity;
			this._books = books;
			this._communityId = communityId;
		}

		protected override void CommandBody(SqlCommand command)
		{
			command.CommandText = base.StoredProcedureName;
			command.CommandType = CommandType.StoredProcedure;
			command.Parameters.Add("@CommunityId", SqlDbType.BigInt).Value = this._communityId;
			command.Parameters.Add("@BookTable", SqlDbType.Structured).Value = this._books.GetBookTable();
			SqlDataReader dr = command.ExecuteReader();
			if (dr.Read())
			{
				this._result = new BooleanShell()
				{
					Value = dr.GetValue<bool>("IsUsersCommunity")
				};
			}
		}

		protected override BooleanShell GetCommandResult(SqlCommand command)
		{
			return this._result;
		}
	}
}