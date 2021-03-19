using MSLivingChoices.Logging;
using MSLivingChoices.Logging.Messages;
using System;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.SqlDacs.SqlCommands
{
	public class BaseCommand<TResult> : BaseCommand
	{
		public TResult CommandResult
		{
			get;
			set;
		}

		protected BaseCommand()
		{
		}

		protected BaseCommand(string connectionString) : base(connectionString)
		{
			this.CommandResult = default(TResult);
		}

		public override void Execute()
		{
			try
			{
				using (SqlConnection sqlConnection = new SqlConnection(this.ConnectionString))
				{
					using (SqlCommand sqlCommand = sqlConnection.CreateCommand())
					{
						sqlConnection.Open();
						this.CommandBody(sqlCommand);
						sqlConnection.Close();
						this.CommandResult = this.GetCommandResult(sqlCommand);
					}
				}
			}
			catch (Exception exception)
			{
				Logger.Error(LogMessages.SqlDacs.SqlCommands.CommandExecutionError, exception);
				throw;
			}
		}

		protected virtual TResult GetCommandResult(SqlCommand command)
		{
			return default(TResult);
		}
	}
}