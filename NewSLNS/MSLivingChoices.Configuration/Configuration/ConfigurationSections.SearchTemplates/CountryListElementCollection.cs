using System;
using System.Configuration;
using System.Reflection;

namespace MSLivingChoices.Configuration.ConfigurationSections.SearchTemplates
{
	[ConfigurationCollection(typeof(CountryElement))]
	internal class CountryListElementCollection : ConfigurationElementCollection
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
				return "country";
			}
		}

		public new CountryElement this[string index]
		{
			get
			{
				return (CountryElement)base.BaseGet(index);
			}
		}

		public CountryListElementCollection()
		{
		}

		protected override ConfigurationElement CreateNewElement()
		{
			return new CountryElement();
		}

		protected override object GetElementKey(ConfigurationElement element)
		{
			return ((CountryElement)element).CountryCode;
		}
	}
}