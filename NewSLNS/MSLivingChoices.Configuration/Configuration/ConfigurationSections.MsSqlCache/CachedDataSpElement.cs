using System;
using System.Configuration;

namespace MSLivingChoices.Configuration.ConfigurationSections.MsSqlCache
{
	internal class CachedDataSpElement : ConfigurationElement
	{
		[ConfigurationProperty("dependencies", IsDefaultCollection=true)]
		public CachedDataSpDependenciesElementCollection Dependencies
		{
			get
			{
				return (CachedDataSpDependenciesElementCollection)base["dependencies"];
			}
		}

		[ConfigurationProperty("name", IsKey=true, IsRequired=true)]
		public string Name
		{
			get
			{
				return (string)base["name"];
			}
		}

		[ConfigurationProperty("priority")]
		public string Priority
		{
			get
			{
				return (string)base["priority"];
			}
		}

		public CachedDataSpElement()
		{
		}
	}
}