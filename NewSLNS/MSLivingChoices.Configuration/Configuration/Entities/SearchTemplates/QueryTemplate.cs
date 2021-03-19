using System;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Configuration.Entities.SearchTemplates
{
	public class QueryTemplate
	{
		public string LookupLocation
		{
			get;
			set;
		}

		public string Template
		{
			get;
			set;
		}

		public string Url
		{
			get;
			set;
		}

		public QueryTemplate()
		{
		}
	}
}