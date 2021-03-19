using System;
using System.Configuration;

namespace MSLivingChoices.Configuration.ConfigurationSections.MsSqlCache
{
	[ConfigurationCollection(typeof(CachedDataSpElement))]
	internal class CachedDataDependencyMapElementCollection : ConfigurationElementCollection
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

		public CachedDataDependencyMapElementCollection()
		{
		}

		protected override ConfigurationElement CreateNewElement()
		{
			return new CachedDataSpElement();
		}

		protected override object GetElementKey(ConfigurationElement element)
		{
			return ((CachedDataSpElement)element).Name;
		}
	}
}