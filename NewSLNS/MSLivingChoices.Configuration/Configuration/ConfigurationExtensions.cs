using MSLivingChoices.Configuration.ConfigurationEntities.MsSqlCache;
using System;
using System.Linq;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Configuration
{
	public static class ConfigurationExtensions
	{
		public static CachedDataSpDependencies GetCachedDataSpDependencies(string storedProcedureName)
		{
			return ConfigurationManager.Instance.MsSqlCache.CachedDataDependencyMap.FirstOrDefault<CachedDataSpDependencies>((CachedDataSpDependencies sp) => sp.StoredProcedureName.Equals(storedProcedureName));
		}

		public static FreeCacheSpDependencies GetFreeCacheSpDependencies(string storedProcedureName)
		{
			return ConfigurationManager.Instance.MsSqlCache.FreeCacheDependencyMap.FirstOrDefault<FreeCacheSpDependencies>((FreeCacheSpDependencies sp) => sp.StoredProcedureName.Equals(storedProcedureName));
		}
	}
}