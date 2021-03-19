using System;
using System.Configuration;

namespace MSLivingChoices.Configuration.ConfigurationSections.MsSqlCache
{
	[ConfigurationCollection(typeof(CachedDataDependencyElement))]
	internal class CachedDataSpDependenciesElementCollection : ConfigurationElementCollection
	{
		public override ConfigurationElementCollectionType CollectionType
		{
			get
			{
				return ConfigurationElementCollectionType.BasicMap;
			}
		}

		protected override string ElementName
		{
			get
			{
				return "dependency";
			}
		}

		public CachedDataSpDependenciesElementCollection()
		{
		}

		protected override ConfigurationElement CreateNewElement()
		{
			return new CachedDataDependencyElement();
		}

		protected override object GetElementKey(ConfigurationElement element)
		{
			return ((CachedDataDependencyElement)element).Table;
		}
	}
}