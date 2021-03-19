using System;
using System.Configuration;

namespace MSLivingChoices.Configuration.ConfigurationSections.SearchTemplates
{
	internal sealed class SearchTemplatesSection : ConfigurationSection
	{
		[ConfigurationProperty("countryList", IsRequired=true, IsDefaultCollection=true)]
		public CountryListElementCollection CountryList
		{
			get
			{
				return (CountryListElementCollection)base["countryList"];
			}
		}

		public SearchTemplatesSection()
		{
		}
	}
}