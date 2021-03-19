using MSLivingChoices.Entities.Admin.Enums;
using System;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Mvc.Uipc.Admin.ViewModels
{
	public class ServiceProviderGridVm : GridVm<ServiceProviderForGridVm>
	{
		private MSLivingChoices.Entities.Admin.Enums.OrderBy? _orderBy;

		public string ChangeFeatureDatesUrl
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

		public FilterForServiceProviderGridVm Filter
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

		public ServiceProviderGridSortByOption? SortBy
		{
			get;
			set;
		}

		public ServiceProviderGridVm()
		{
		}
	}
}