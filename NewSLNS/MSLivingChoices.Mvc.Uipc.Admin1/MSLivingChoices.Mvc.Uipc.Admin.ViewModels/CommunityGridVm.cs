using MSLivingChoices.Entities.Admin.Enums;
using System;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Mvc.Uipc.Admin.ViewModels
{
	public class CommunityGridVm : GridVm<CommunityForGridVm>
	{
		private MSLivingChoices.Entities.Admin.Enums.OrderBy? _orderBy;

		public string ChangeListingTypeStateUrl
		{
			get;
			set;
		}

		public string ChangePackageTypeUrl
		{
			get;
			set;
		}

		public string ChangePublishDatesUrl
		{
			get;
			set;
		}

		public string ChangeSeniorHousingAndCareCategoriesUrl
		{
			get;
			set;
		}

		public string ChangeShowcaseDatesUrl
		{
			get;
			set;
		}

		public string DeleteCommunityUrl
		{
			get;
			set;
		}

		public FilterForCommunityGridVm Filter
		{
			get;
			set;
		}

		public bool IsAdmin
		{
			get;
			set;
		}

		public MSLivingChoices.Entities.Admin.Enums.OrderBy? OrderBy
		{
			get
			{
				MSLivingChoices.Entities.Admin.Enums.OrderBy? nullable;
				if (!this.SortBy.HasValue)
				{
					nullable = null;
					return nullable;
				}
				nullable = this._orderBy;
				return new MSLivingChoices.Entities.Admin.Enums.OrderBy?((nullable.HasValue ? nullable.GetValueOrDefault() : MSLivingChoices.Entities.Admin.Enums.OrderBy.Asc));
			}
			set
			{
				this._orderBy = value;
			}
		}

		public CommunityGridSortByOption? SortBy
		{
			get;
			set;
		}

		public CommunityGridVm()
		{
		}
	}
}