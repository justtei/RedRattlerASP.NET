using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Configuration.ConfigurationEntities.MsSqlCache
{
	public class FreeCacheSpDependencies
	{
		public HashSet<string> Dependencies
		{
			get;
			set;
		}

		public string StoredProcedureName
		{
			get;
			set;
		}

		public FreeCacheSpDependencies()
		{
			this.Dependencies = new HashSet<string>();
		}
	}
}