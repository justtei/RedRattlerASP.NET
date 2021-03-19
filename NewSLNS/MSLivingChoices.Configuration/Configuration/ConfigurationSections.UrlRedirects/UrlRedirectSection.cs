using System;
using System.Configuration;

namespace MSLivingChoices.Configuration.ConfigurationSections.UrlRedirects
{
	internal sealed class UrlRedirectSection : ConfigurationSection
	{
		[ConfigurationProperty("", IsDefaultCollection=true)]
		public RedirectElementCollection Redirects
		{
			get
			{
				return (RedirectElementCollection)base[""];
			}
		}

		public UrlRedirectSection()
		{
		}
	}
}