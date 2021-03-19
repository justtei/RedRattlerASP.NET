using System;
using System.Configuration;

namespace MSLivingChoices.Configuration.ConfigurationSections.MsSqlCache
{
	internal class FreeCacheSpDependenciesElementCollection : ConfigurationElementCollection
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

		public FreeCacheSpDependenciesElementCollection()
		{
		}

		protected override ConfigurationElement CreateNewElement()
		{
			return new FreeCacheDependencyElement();
		}

		protected override object GetElementKey(ConfigurationElement element)
		{
			return ((FreeCacheDependencyElement)element).StoredProcedure;
		}
	}
}