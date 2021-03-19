using MSLivingChoices.Configuration;
using MSLivingChoices.Logging;
using MSLivingChoices.Logging.Messages;
using MSLivingChoices.SqlDacs.Caching;
using System;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using System.Web.Caching;

namespace MSLivingChoices.SqlDacs.SqlCommands
{
	public class CachedBaseCommand<TResult> : BaseCommand<TResult>
	where TResult : class
	{
		protected AggregateCacheDependency CacheDependency
		{
			get;
			set;
		}

		protected System.Web.Caching.CacheItemPriority CacheItemPriority
		{
			get;
			set;
		}

		protected string CacheKey
		{
			get;
			set;
		}

		internal bool IsDataFromCache
		{
			get;
			set;
		}

		protected TimeSpan SlidingExpiration
		{
			get;
			set;
		}

		protected CachedBaseCommand() : this(ConfigurationManager.Instance.MlcSlcConnectionString)
		{
		}

		protected CachedBaseCommand(string connectionString) : base(connectionString)
		{
			base.CommandResult = default(TResult);
			this.SlidingExpiration = new TimeSpan(0, ConfigurationManager.Instance.DbCacheSlidingExpirationMinutes, 0);
			this.IsDataFromCache = false;
		}

		public override void Execute()
		{
			if (!ConfigurationManager.Instance.IsEnabledDbCache)
			{
				base.Execute();
				return;
			}
			TResult itemFromCache = MlcSlcCache.GetItemFromCache<TResult>(this.CacheKey);
			if (itemFromCache != null)
			{
				this.IsDataFromCache = true;
			}
			else
			{
				MlcSlcCache.LockKey(this.CacheKey);
				try
				{
					try
					{
						itemFromCache = MlcSlcCache.GetItemFromCache<TResult>(this.CacheKey);
						if (itemFromCache != null)
						{
							this.IsDataFromCache = true;
						}
						else
						{
							itemFromCache = this.ExecuteSqlRequest();
						}
					}
					catch (Exception exception)
					{
						Logger.Error(LogMessages.SqlDacs.SqlCommands.CommandExecutionError, exception);
						throw;
					}
				}
				finally
				{
					MlcSlcCache.UnlockKey(this.CacheKey);
				}
			}
			base.CommandResult = itemFromCache;
		}

		private TResult ExecuteSqlRequest()
		{
			TResult commandResult;
			using (SqlConnection sqlConnection = new SqlConnection(this.ConnectionString))
			{
				using (SqlCommand sqlCommand = sqlConnection.CreateCommand())
				{
					sqlConnection.Open();
					this.CommandBody(sqlCommand);
					sqlConnection.Close();
					commandResult = this.GetCommandResult(sqlCommand);
					if (commandResult != null)
					{
						this.CacheDependency = CacheDependencyResolver.GetCachedDataDependencies(base.StoredProcedureName);
						this.CacheItemPriority = CacheDependencyResolver.GetCacheItemPriority(base.StoredProcedureName);
						if (this.CacheDependency == null)
						{
							Logger.WarnFormat(LogMessages.SqlDacs.SqlCommands.CacheDependencyNotFound, new object[] { base.StoredProcedureName });
						}
						else
						{
							MlcSlcCache.InsertItemInCache<TResult>(this.CacheKey, commandResult, this.CacheDependency, this.SlidingExpiration, this.CacheItemPriority);
							return commandResult;
						}
					}
				}
			}
			return commandResult;
		}

		protected static string GetCacheKey(params string[] args)
		{
			return MlcSlcCache.GetCacheKey(args);
		}
	}
}