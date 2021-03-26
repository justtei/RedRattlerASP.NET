using MSLivingChoices.Entities.Client.Search.Criteria;
using MSLivingChoices.Mvc.Uipc.Client.ViewModelsProviders;
using MSLivingChoices.Utilities;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Mvc.Uipc.Client.ViewModels
{
	public class SearchVm : PageVm
	{
		private SearchBarVm _searchBar;

		public List<LinkVm> Breadcrumbs
		{
			get;
			set;
		}

		public SearchCriteriaVm Criteria
		{
			get;
			set;
		}

		public ExpandoObject Dimensions
		{
			get
			{
				return this.ToDimensionsData();
			}
		}

		public SearchBarVm SearchBar
		{
			get
			{
				SearchBarVm searchBarVm = this._searchBar;
				if (searchBarVm == null)
				{
					SearchBarVm searchBarVm1 = ClientViewModelsProvider.GetSearchBarVm(this);
					SearchBarVm searchBarVm2 = searchBarVm1;
					this._searchBar = searchBarVm1;
					searchBarVm = searchBarVm2;
				}
				return searchBarVm;
			}
			set
			{
				this._searchBar = value;
			}
		}

		public SearchVm()
		{
			this.Criteria = new SearchCriteriaVm();
			this.Breadcrumbs = new List<LinkVm>();
		}

		protected virtual ExpandoObject ToDimensionsData()
		{
			dynamic expandoObjects = new ExpandoObject();
			expandoObjects.country = this.Criteria.CountryCode();
			if (!this.Criteria.StateCode().IsNullOrEmpty())
			{
				expandoObjects.stateCountry = string.Format("{0}, {1}", this.Criteria.StateCode(), this.Criteria.CountryCode());
			}
			if (!this.Criteria.City().IsNullOrEmpty())
			{
				expandoObjects.cityStateCountry = string.Format("{0}, {1}, {2}", this.Criteria.City(), this.Criteria.StateCode(), this.Criteria.CountryCode());
			}
			if (!this.Criteria.Zip().IsNullOrEmpty())
			{
				expandoObjects.zipStateCountry = string.Format("{0}, {1}, {2}", this.Criteria.Zip(), this.Criteria.StateCode(), this.Criteria.CountryCode());
			}
			return (ExpandoObject)expandoObjects;
		}
	}
}