using MSLivingChoices.Configuration;
using MSLivingChoices.Logging;
using MSLivingChoices.Logging.Messages;
using System;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.SqlDacs.SqlCommands
{
	public class BaseCommand
	{
		protected readonly string ConnectionString;

		protected readonly int CommandTimeout;

		public string StoredProcedureName
		{
			get;
			protected set;
		}

		public BaseCommand() : this(ConfigurationManager.Instance.MlcSlcConnectionString)
		{
		}

		public BaseCommand(string connectionString)
		{
			this.ConnectionString = connectionString;
			this.CommandTimeout = ConfigurationManager.Instance.SqlCommandTimeoutSeconds;
		}

		protected virtual void CommandBody(SqlCommand command)
		{
		}

		public virtual void Execute()
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
					}
				}
			}
			catch (Exception exception)
			{
				Logger.Error(LogMessages.SqlDacs.SqlCommands.CommandExecutionError, exception);
				throw;
			}
		}
	}
}