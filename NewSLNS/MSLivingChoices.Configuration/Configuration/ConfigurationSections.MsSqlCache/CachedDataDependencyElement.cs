using System;
using System.Configuration;

namespace MSLivingChoices.Configuration.ConfigurationSections.MsSqlCache
{
	internal class CachedDataDependencyElement : ConfigurationElement
	{
		[ConfigurationProperty("table", IsKey=true, IsRequired=true)]
		public string Table
		{
			get
			{
				return (string)base["table"];
			}
		}

		public CachedDataDependencyElement()
		{
		}
	}
}