using System;
using System.Configuration;

namespace MSLivingChoices.Configuration.ConfigurationSections.UrlRedirects
{
	public class RedirectElement : ConfigurationElement
	{
		[ConfigurationProperty("from", IsRequired=true)]
		public string From
		{
			get
			{
				return (string)base["from"];
			}
		}

		[ConfigurationProperty("name", IsRequired=true, IsKey=true)]
		public string Name
		{
			get
			{
				return (string)base["name"];
			}
		}

		[ConfigurationProperty("to", IsRequired=true)]
		public string To
		{
			get
			{
				return (string)base["to"];
			}
		}

		public RedirectElement()
		{
		}
	}
}