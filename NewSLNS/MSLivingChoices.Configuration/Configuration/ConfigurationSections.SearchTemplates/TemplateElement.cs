using System;
using System.Configuration;

namespace MSLivingChoices.Configuration.ConfigurationSections.SearchTemplates
{
	internal class TemplateElement : ConfigurationElement
	{
		[ConfigurationProperty("lookupLocation", IsRequired=true)]
		public string LookupLocation
		{
			get
			{
				return (string)base["lookupLocation"];
			}
		}

		[ConfigurationProperty("template", IsKey=true, IsRequired=true)]
		public string Template
		{
			get
			{
				return (string)base["template"];
			}
		}

		[ConfigurationProperty("url", IsRequired=true)]
		public string Url
		{
			get
			{
				return (string)base["url"];
			}
		}

		public TemplateElement()
		{
		}
	}
}