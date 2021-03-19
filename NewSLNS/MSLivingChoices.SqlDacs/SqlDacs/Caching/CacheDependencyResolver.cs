using MSLivingChoices.Configuration;
using MSLivingChoices.Configuration.ConfigurationEntities.MsSqlCache;
using System;
using System.Collections.Generic;
using System.Web.Caching;

namespace MSLivingChoices.SqlDacs.Caching
{
	public static class CacheDependencyResolver
	{
		public static AggregateCacheDependency GetCachedDataDependencies(string storedProcedureName)
		{
			AggregateCacheDependency aggregateCacheDependency = null;
			CachedDataSpDependencies cachedDataSpDependencies = ConfigurationExtensions.GetCachedDataSpDependencies(storedProcedureName);
			if (cachedDataSpDependencies != null)
			{
				aggregateCacheDependency = new AggregateCacheDependency();
				foreach (string dependency in cachedDataSpDependencies.Dependencies)
				{
					CacheDependency sqlCacheDependency = new SqlCacheDependency(ConfigurationManager.Instance.MlcSlcEntryName, dependency);
					aggregateCacheDependency.Add(new CacheDependency[] { sqlCacheDependency });
				}
			}
			return aggregateCacheDependency;
		}

		public static CacheItemPriority GetCacheItemPriority(string storedProcedureName)
		{
			CachedDataSpDependencies cachedDataSpDependencies = ConfigurationExtensions.GetCachedDataSpDependencies(storedProcedureName);
			if (cachedDataSpDependencies == null)
			{
				return CacheItemPriority.Normal;
			}
			return cachedDataSpDependencies.Priority;
		}

		public static IEnumerable<string> GetFreeCacheDependencies(string storedProcedureName)
		{
			FreeCacheSpDependencies freeCacheSpDependencies = ConfigurationExtensions.GetFreeCacheSpDependencies(storedProcedureName);
			if (freeCacheSpDependencies == null)
			{
				return null;
			}
			return freeCacheSpDependencies.Dependencies;
		}
	}
}