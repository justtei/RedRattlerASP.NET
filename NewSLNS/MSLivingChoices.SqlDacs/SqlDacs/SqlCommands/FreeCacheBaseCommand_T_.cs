using MSLivingChoices.Configuration;
using MSLivingChoices.Logging;
using MSLivingChoices.Logging.Messages;
using MSLivingChoices.SqlDacs.Caching;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.SqlDacs.SqlCommands
{
	public class FreeCacheBaseCommand<T> : BaseCommand<T>
	{
		protected string[] CacheKeyPrefixes
		{
			get;
			set;
		}

		public FreeCacheBaseCommand()
		{
			this.CacheKeyPrefixes = new string[0];
		}

		public override void Execute()
		{
			if (!ConfigurationManager.Instance.IsEnabledDbCache)
			{
				base.Execute();
				return;
			}
			try
			{
				IEnumerable<string> freeCacheDependencies = CacheDependencyResolver.GetFreeCacheDependencies(base.StoredProcedureName);
				if (freeCacheDependencies == null)
				{
					Logger.WarnFormat(LogMessages.SqlDacs.SqlCommands.FreeCacheDependencyNotFound, new object[] { base.StoredProcedureName });
				}
				else
				{
					this.CacheKeyPrefixes = freeCacheDependencies.Select<string, string>(new Func<string, string>(MlcSlcCache.GetCacheKeyPrefix)).ToArray<string>();
					MlcSlcCache.RemoveItemsFromCache(this.CacheKeyPrefixes);
				}
				using (SqlConnection sqlConnection = new SqlConnection(this.ConnectionString))
				{
					using (SqlCommand sqlCommand = sqlConnection.CreateCommand())
					{
						sqlConnection.Open();
						this.CommandBody(sqlCommand);
						sqlConnection.Close();
						base.CommandResult = this.GetCommandResult(sqlCommand);
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