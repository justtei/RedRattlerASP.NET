using MSLivingChoices.Mvc.Uipc.Admin.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Mvc.Uipc.Admin.ViewModels
{
	public class FilterForServiceProviderGridVm
	{
		public List<CheckBoxVm> Categories
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

		public string ServiceProvider
		{
			get;
			set;
		}

		public FilterForServiceProviderGridVm()
		{
		}
	}
}