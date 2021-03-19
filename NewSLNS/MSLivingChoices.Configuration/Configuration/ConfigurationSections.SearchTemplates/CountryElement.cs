using System;
using System.Configuration;

namespace MSLivingChoices.Configuration.ConfigurationSections.SearchTemplates
{
	internal class CountryElement : ConfigurationElement
	{
		[ConfigurationProperty("countryCode", IsKey=true, IsRequired=true)]
		public string CountryCode
		{
			get
			{
				return (string)base["countryCode"];
			}
		}

		[ConfigurationProperty("placeholder", IsRequired=true)]
		public string Placeholder
		{
			get
			{
				return (string)base["placeholder"];
			}
		}

		[ConfigurationProperty("templates", IsRequired=true)]
		public TemplatesElementCollection Templates
		{
			get
			{
				return (TemplatesElementCollection)base["templates"];
			}
		}

		public CountryElement()
		{
		}
	}
}