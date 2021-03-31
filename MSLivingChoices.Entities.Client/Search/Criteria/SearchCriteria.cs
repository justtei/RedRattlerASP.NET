using MSLivingChoices.Entities.Client.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace MSLivingChoices.Entities.Client.Search.Criteria
{
	[Serializable]
	public class SearchCriteria : ISearchCriteria
	{
		private readonly Dictionary<string, object> _components;

		private SearchDepth? _searchDepth;

		public Dictionary<string, object> Components => new Dictionary<string, object>(_components);

		public SearchDepth Depth
		{
			get
			{
				_searchDepth = _searchDepth ?? GetSearchDepth();
				return _searchDepth.Value;
			}
		}

		public SearchCriteria()
		{
			_components = new Dictionary<string, object>();
		}

		public SearchCriteria(Dictionary<string, object> components, SearchDepth? searchDepth)
		{
			_components = new Dictionary<string, object>(components);
			_searchDepth = searchDepth;
		}

		public ISearchCriteria Component(string key, object value)
		{
			if (string.IsNullOrEmpty(key))
			{
				throw new ArgumentException("Component key can not be null or empty.");
			}
			if (value != null)
			{
				_components[key] = value;
				_searchDepth = null;
			}
			return this;
		}

		public T Component<T>(string key)
		{
			if (string.IsNullOrEmpty(key))
			{
				throw new ArgumentException("Component key can not be null or empty.");
			}
			T result = default(T);
			if (_components.ContainsKey(key))
			{
				return (T)_components[key];
			}
			return result;
		}

		public SearchCriteria ToSearchableCriteria()
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			foreach (KeyValuePair<string, object> component in _components)
			{
				dictionary.Add(component.Key, component.Value);
				if (component.Value is string)
				{
					dictionary[component.Key] = ToSearchableString(component.Value as string);
				}
			}
			return new SearchCriteria(dictionary, Depth);
		}

		public override string ToString()
		{
			return string.Join("_", _components.Select((KeyValuePair<string, object> component) => component.Value.ToString()));
		}

		private SearchDepth GetSearchDepth()
		{
			SearchDepth result = SearchDepth.Invalid;
			if (!string.IsNullOrWhiteSpace(this.Zip()))
			{
				result = SearchDepth.Zip;
			}
			else if (!string.IsNullOrWhiteSpace(this.City()))
			{
				result = SearchDepth.City;
			}
			else if (!string.IsNullOrWhiteSpace(this.StateCode()))
			{
				result = SearchDepth.State;
			}
			return result;
		}

		private static string ToSearchableString(string str)
		{
			if (!string.IsNullOrEmpty(str))
			{
				str = Regex.Replace(str.Trim(), "[^a-zA-Z0-9]{1,}", " ").Trim().ToLowerInvariant();
			}
			return str;
		}
	}
}