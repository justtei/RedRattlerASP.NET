using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Entities.Admin
{
	public class ServiceProviderGridFilter
	{
		public List<KeyValuePair<int, string>> Categories
		{
			get;
			set;
		}

		public bool? Feature
		{
			get;
			set;
		}

		public string FeatureEnd
		{
			get;
			set;
		}

		public string FeatureStart
		{
			get;
			set;
		}

		public List<KeyValuePair<int, string>> Packages
		{
			get;
			set;
		}

		public bool? Publish
		{
			get;
			set;
		}

		public string PublishEnd
		{
			get;
			set;
		}

		public string PublishStart
		{
			get;
			set;
		}

		public string ServiceProvider
		{
			get;
			set;
		}

		public ServiceProviderGridFilter()
		{
		}
	}
}