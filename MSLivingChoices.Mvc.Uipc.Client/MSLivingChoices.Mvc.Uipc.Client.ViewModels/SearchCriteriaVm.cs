using MSLivingChoices.Entities.Client.Enums;
using MSLivingChoices.Entities.Client.Search.Criteria;
using MSLivingChoices.Mvc.Uipc.Client.Enums;
using MSLivingChoices.Mvc.Uipc.Client.Helpers;
using MSLivingChoices.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Mvc.Uipc.Client.ViewModels
{
	public class SearchCriteriaVm : ISearchCriteria, ICloneable
	{
		private readonly Dictionary<string, object> _components;

		private SearchDepth? _searchDepth;

		public Dictionary<string, object> Components
		{
			get
			{
				return new Dictionary<string, object>(this._components);
			}
		}

		public SearchDepth Depth
		{
			get
			{
				SearchDepth? nullable = this._searchDepth;
				this._searchDepth = new SearchDepth?((nullable.HasValue ? nullable.GetValueOrDefault() : this.GetSearchDepth()));
				return this._searchDepth.Value;
			}
		}

		public SearchCriteriaVm()
		{
			this._components = new Dictionary<string, object>();
		}

		public SearchCriteriaVm(Dictionary<string, object> components, SearchDepth? searchDepth)
		{
			this._components = new Dictionary<string, object>(components);
			this._searchDepth = searchDepth;
		}

		public object Clone()
		{
			return this.Copy();
		}

		public SearchCriteriaVm CloneLowerDepth()
		{
			SearchCriteriaVm searchCriteriaVm = new SearchCriteriaVm(this._components, new SearchDepth?(this.Depth.Previous<SearchDepth>()));
			searchCriteriaVm.InvalidateCriteria();
			return searchCriteriaVm;
		}

		public ISearchCriteria Component(string key, object value)
		{
			if (string.IsNullOrEmpty(key))
			{
				throw new ArgumentException("Component key can not be null or empty.");
			}
			if (value != null)
			{
				this._components[key] = value;
				this._searchDepth = null;
			}
			return this;
		}

		public T Component<T>(string key)
		{
			if (string.IsNullOrEmpty(key))
			{
				throw new ArgumentException("Component key can not be null or empty.");
			}
			T item = default(T);
			if (this._components.ContainsKey(key))
			{
				item = (T)this._components[key];
			}
			return item;
		}

		public SearchCriteriaVm Copy()
		{
			return new SearchCriteriaVm(this._components, this._searchDepth);
		}

		private SearchDepth GetSearchDepth()
		{
			SearchDepth searchDepth = SearchDepth.Invalid;
			if (!string.IsNullOrWhiteSpace(this.Zip()))
			{
				searchDepth = SearchDepth.Zip;
			}
			else if (!string.IsNullOrWhiteSpace(this.City()))
			{
				searchDepth = SearchDepth.City;
			}
			else if (!string.IsNullOrWhiteSpace(this.StateCode()))
			{
				searchDepth = SearchDepth.State;
			}
			else if (!string.IsNullOrEmpty(this.CountryCode()))
			{
				searchDepth = SearchDepth.Country;
			}
			return searchDepth;
		}

		private bool HasAddressComponents(params string[] keys)
		{
			SearchCriteriaVm searchCriteriaVm = this;
			return keys.Select<string, string>(new Func<string, string>(searchCriteriaVm.Component<string>)).All<string>((string component) => !string.IsNullOrWhiteSpace(component));
		}

		private void InvalidateCriteria()
		{
			SearchDepth? nullable = this._searchDepth;
			if (nullable.HasValue)
			{
				switch (nullable.GetValueOrDefault())
				{
					case SearchDepth.Country:
					{
						this.RemoveRedundantComponents(new string[] { "CountryCode" });
						return;
					}
					case SearchDepth.State:
					{
						this.RemoveRedundantComponents(new string[] { "CountryCode", "StateCode" });
						return;
					}
					case SearchDepth.City:
					{
						this.RemoveRedundantComponents(new string[] { "CountryCode", "StateCode", "City" });
						return;
					}
					case SearchDepth.Zip:
					{
						this.RemoveRedundantComponents(new string[] { "CountryCode", "StateCode", "Zip" });
						break;
					}
					default:
					{
						return;
					}
				}
			}
		}

		private bool IsValidForSearchDepth()
		{
			bool flag = false;
			SearchDepth? nullable = this._searchDepth;
			if (nullable.HasValue)
			{
				switch (nullable.GetValueOrDefault())
				{
					case SearchDepth.Country:
					{
						flag = this.HasAddressComponents(new string[] { "CountryCode" });
						break;
					}
					case SearchDepth.State:
					{
						flag = this.HasAddressComponents(new string[] { "CountryCode", "StateCode" });
						break;
					}
					case SearchDepth.City:
					{
						flag = this.HasAddressComponents(new string[] { "CountryCode", "StateCode", "City" });
						break;
					}
					case SearchDepth.Zip:
					{
						flag = this.HasAddressComponents(new string[] { "CountryCode", "StateCode", "Zip" });
						break;
					}
				}
			}
			return flag;
		}

		private void RemoveRedundantComponents(params string[] validKeys)
		{
			List<string> list = this._components.Keys.Except<string>(validKeys).ToList<string>();
			list.Remove("SearchType");
			foreach (string str in list)
			{
				this._components.Remove(str);
			}
		}

		public SearchCriteria ToSearchCriteria()
		{
			Dictionary<string, object> strs = new Dictionary<string, object>(this._components);
			strs.Remove("SearchType");
			return new SearchCriteria(strs, this._searchDepth);
		}

		public bool Validate()
		{
			return this.Validate(null);
		}

		public bool Validate(PageType? pageType)
		{
			this._searchDepth = new SearchDepth?((pageType.HasValue ? pageType.Value.ToSearchDepth() : this.GetSearchDepth()));
			this.InvalidateCriteria();
			return this.IsValidForSearchDepth();
		}
	}
}