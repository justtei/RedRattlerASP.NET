using System;
using System.Configuration;

namespace MSLivingChoices.Configuration.ConfigurationSections.MsSqlCache
{
	internal class FreeCacheDependencyMapElementCollection : ConfigurationElementCollection
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
				return "storedProcedure";
			}
		}

		public FreeCacheDependencyMapElementCollection()
		{
		}

		protected override ConfigurationElement CreateNewElement()
		{
			return new FreeCacheSpElement();
		}

		protected override object GetElementKey(ConfigurationElement element)
		{
			return ((FreeCacheSpElement)element).Name;
		}
	}
}