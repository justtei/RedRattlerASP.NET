using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;
using System.Web.Routing;

namespace MSLivingChoices.Mvc.Uipc.Client.Helpers.Core
{
	public class FluentRoute
	{
		private readonly RouteValueDictionary _constraints;

		private readonly RouteValueDictionary _defaults;

		private readonly StringBuilder _name;

		private readonly StringBuilder _url;

		public FluentRoute()
		{
			this._url = new StringBuilder();
			this._name = new StringBuilder();
			this._constraints = new RouteValueDictionary();
			this._defaults = new RouteValueDictionary();
		}

		public Route Map(object defaults)
		{
			if (defaults != null)
			{
				foreach (KeyValuePair<string, object> keyValuePair in new RouteValueDictionary(defaults))
				{
					this._defaults.Add(keyValuePair.Key, keyValuePair.Value);
				}
			}
			Route route = new Route(this._url.ToString(), this._defaults, this._constraints, new MvcRouteHandler());
			RouteTable.Routes.Add(this._name.ToString(), route);
			return route;
		}

		public FluentRoute Section(string nameSection, string urlSection)
		{
			KeyValuePair<string, object>? nullable = null;
			KeyValuePair<string, object>? nullable1 = nullable;
			nullable = null;
			return this.Section(nameSection, urlSection, nullable1, nullable);
		}

		public FluentRoute Section(string nameSection, string urlSection, KeyValuePair<string, object>? constraint)
		{
			return this.Section(nameSection, urlSection, constraint, null);
		}

		public FluentRoute Section(string nameSection, string urlSection, KeyValuePair<string, object>? constraint, KeyValuePair<string, object>? defaultValue)
		{
			KeyValuePair<string, object> value;
			this._name.Append(nameSection);
			this._url.Append(urlSection);
			if (constraint.HasValue)
			{
				RouteValueDictionary routeValueDictionaries = this._constraints;
				value = constraint.Value;
				string key = value.Key;
				value = constraint.Value;
				routeValueDictionaries.Add(key, value.Value);
			}
			if (defaultValue.HasValue)
			{
				RouteValueDictionary routeValueDictionaries1 = this._defaults;
				value = defaultValue.Value;
				string str = value.Key;
				value = defaultValue.Value;
				routeValueDictionaries1.Add(str, value.Value);
			}
			return this;
		}
	}
}