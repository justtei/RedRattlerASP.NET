using System;
using System.Configuration;

namespace MSLivingChoices.Configuration.ConfigurationSections.SearchTemplates
{
	[ConfigurationCollection(typeof(TemplateElement))]
	internal class TemplatesElementCollection : ConfigurationElementCollection
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
				return "template";
			}
		}

		public TemplatesElementCollection()
		{
		}

		protected override ConfigurationElement CreateNewElement()
		{
			return new TemplateElement();
		}

		protected override object GetElementKey(ConfigurationElement element)
		{
			return ((TemplateElement)element).LookupLocation;
		}
	}
}