using MSLivingChoices.Localization;
using MSLivingChoices.Mvc.Uipc.Admin.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Mvc.Uipc.Admin.ViewModels
{
	public class ServiceProviderForGridVm
	{
		public DateTime? FeatureEndDate
		{
			get;
			set;
		}

		public DateTime? FeatureStartDate
		{
			get;
			set;
		}

		public long? Id
		{
			get;
			set;
		}

		public string Name
		{
			get;
			set;
		}

		public string Package
		{
			get;
			set;
		}

		public List<string> Packages
		{
			get;
			set;
		}

		public DateTime? PublishEndDate
		{
			get;
			set;
		}

		public DateTime? PublishStartDate
		{
			get;
			set;
		}

		[Display(Name="Categories", ResourceType=typeof(DisplayNames))]
		public List<CheckBoxVm> SeniorHousingAndCareCategories
		{
			get;
			set;
		}

		public ServiceProviderForGridVm()
		{
		}
	}
}