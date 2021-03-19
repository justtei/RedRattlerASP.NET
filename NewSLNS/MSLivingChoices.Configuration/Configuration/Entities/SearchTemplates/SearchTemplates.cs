using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Configuration.Entities.SearchTemplates
{
	public class SearchTemplates
	{
		public string CountryCode
		{
			get;
			set;
		}

		public string Placeholder
		{
			get;
			set;
		}

		public List<QueryTemplate> Templates
		{
			get;
			set;
		}

		public SearchTemplates()
		{
			this.Templates = new List<QueryTemplate>();
		}
	}
}