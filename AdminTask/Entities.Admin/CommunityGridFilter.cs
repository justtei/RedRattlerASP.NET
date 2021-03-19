using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Entities.Admin
{
	public class CommunityGridFilter
	{
		public bool? AAC
		{
			get;
			set;
		}

		public bool? AAH
		{
			get;
			set;
		}

		public List<KeyValuePair<int, string>> Categories
		{
			get;
			set;
		}

		public string Community
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

		public bool? SHC
		{
			get;
			set;
		}

		public bool? Showcase
		{
			get;
			set;
		}

		public string ShowcaseEnd
		{
			get;
			set;
		}

		public string ShowcaseStart
		{
			get;
			set;
		}

		public CommunityGridFilter()
		{
		}
	}
}