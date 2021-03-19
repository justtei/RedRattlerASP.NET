using MSLivingChoices.Mvc.Uipc.Admin.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Mvc.Uipc.Admin.ViewModels
{
	public class FilterForCommunityGridVm
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

		public string Community
		{
			get;
			set;
		}

		public List<CheckBoxVm> Packages
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

		public List<CheckBoxVm> SHCCategories
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

		public FilterForCommunityGridVm()
		{
		}
	}
}