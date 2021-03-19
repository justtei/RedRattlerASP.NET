using MSLivingChoices.Mvc.Uipc.Admin.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Mvc.Uipc.Admin.ViewModels
{
	public class CommunityForGridVm
	{
		public Guid CreateUser { get; set; }
		public bool ActiveAdultCommunities
		{
			get;
			set;
		}

		public bool ActiveAdultHomes
		{
			get;
			set;
		}

		public string BookNumber
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

		public bool SeniorHousingAndCare
		{
			get;
			set;
		}

		public List<CheckBoxVm> SeniorHousingAndCareCategories
		{
			get;
			set;
		}

		public DateTime? ShowcaseEndDate
		{
			get;
			set;
		}

		public DateTime? ShowcaseStartDate
		{
			get;
			set;
		}

		public CommunityForGridVm()
		{
		}
	}
}