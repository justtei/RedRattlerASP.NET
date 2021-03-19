using System;
using System.Configuration;

namespace MSLivingChoices.Configuration.ConfigurationSections.UrlRedirects
{
	[ConfigurationCollection(typeof(RedirectElement))]
	internal class RedirectElementCollection : ConfigurationElementCollection
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
				return "redirect";
			}
		}

		public RedirectElementCollection()
		{
		}

		protected override ConfigurationElement CreateNewElement()
		{
			return new RedirectElement();
		}

		protected override object GetElementKey(ConfigurationElement element)
		{
			return ((RedirectElement)element).Name;
		}
	}
}