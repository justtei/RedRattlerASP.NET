using System;
using System.Configuration;

namespace MSLivingChoices.Configuration.ConfigurationSections.MsSqlCache
{
	internal class MsSqlCacheSection : ConfigurationSection
	{
		[ConfigurationProperty("cachedDataDependencyMap", IsRequired=true)]
		public CachedDataDependencyMapElementCollection CachedDataDependencyMap
		{
			get
			{
				return (CachedDataDependencyMapElementCollection)base["cachedDataDependencyMap"];
			}
		}

		[ConfigurationProperty("freeCacheDependencyMap", IsRequired=true)]
		public FreeCacheDependencyMapElementCollection FreeCacheDependencyMap
		{
			get
			{
				return (FreeCacheDependencyMapElementCollection)base["freeCacheDependencyMap"];
			}
		}

		public MsSqlCacheSection()
		{
		}
	}
}