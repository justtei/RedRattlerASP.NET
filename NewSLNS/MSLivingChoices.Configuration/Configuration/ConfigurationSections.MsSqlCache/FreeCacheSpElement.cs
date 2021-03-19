using System;
using System.Configuration;

namespace MSLivingChoices.Configuration.ConfigurationSections.MsSqlCache
{
	internal class FreeCacheSpElement : ConfigurationElement
	{
		[ConfigurationProperty("dependencies", IsDefaultCollection=true)]
		public FreeCacheSpDependenciesElementCollection Dependencies
		{
			get
			{
				return (FreeCacheSpDependenciesElementCollection)base["dependencies"];
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

		public FreeCacheSpElement()
		{
		}
	}
}