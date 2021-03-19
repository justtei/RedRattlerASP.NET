using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Configuration.ConfigurationEntities.MsSqlCache
{
	public class MsSqlCache
	{
		public HashSet<CachedDataSpDependencies> CachedDataDependencyMap
		{
			get;
			set;
		}

		public HashSet<FreeCacheSpDependencies> FreeCacheDependencyMap
		{
			get;
			set;
		}

		public MsSqlCache()
		{
			this.CachedDataDependencyMap = new HashSet<CachedDataSpDependencies>();
			this.FreeCacheDependencyMap = new HashSet<FreeCacheSpDependencies>();
		}
	}
}