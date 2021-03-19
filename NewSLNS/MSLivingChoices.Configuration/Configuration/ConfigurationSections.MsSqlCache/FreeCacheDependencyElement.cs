using System;
using System.Configuration;

namespace MSLivingChoices.Configuration.ConfigurationSections.MsSqlCache
{
	internal class FreeCacheDependencyElement : ConfigurationElement
	{
		[ConfigurationProperty("storedProcedure", IsKey=true, IsRequired=true)]
		public string StoredProcedure
		{
			get
			{
				return (string)base["storedProcedure"];
			}
		}

		public FreeCacheDependencyElement()
		{
		}
	}
}