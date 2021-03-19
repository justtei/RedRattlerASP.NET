using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Web.Caching;

namespace MSLivingChoices.Configuration.ConfigurationEntities.MsSqlCache
{
	public class CachedDataSpDependencies
	{
		public HashSet<string> Dependencies
		{
			get;
			set;
		}

		public CacheItemPriority Priority
		{
			get;
			set;
		}

		public string StoredProcedureName
		{
			get;
			set;
		}

		public CachedDataSpDependencies()
		{
			this.Dependencies = new HashSet<string>();
		}
	}
}