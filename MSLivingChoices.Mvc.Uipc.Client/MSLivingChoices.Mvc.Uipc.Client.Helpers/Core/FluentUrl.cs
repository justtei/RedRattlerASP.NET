using MSLivingChoices.Mvc.Uipc.Client.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Routing;

namespace MSLivingChoices.Mvc.Uipc.Client.Helpers.Core
{

	public class FluentUrl
	{
		private readonly StringBuilder _routeName;

		private readonly RouteValueDictionary _routeValues;

		public FluentUrl()
		{
			_routeName = new StringBuilder();
			_routeValues = new RouteValueDictionary();
		}

		public FluentUrl Refined(IEnumerable<KeyValuePair<string, object>> refinedParameters)
		{
			return Section(string.Empty, refinedParameters);
		}

		public FluentUrl Section(string nameSection)
		{
			_routeName.Append(nameSection);
			return this;
		}

		public FluentUrl Section(string nameSection, string key, object value)
		{
			if (value == null)
			{
				return this;
			}
			_routeValues.Add(key, value);
			return Section(nameSection);
		}

		public FluentUrl Section(string nameSection, IEnumerable<KeyValuePair<string, object>> parameters)
		{
			foreach (KeyValuePair<string, object> parameter in parameters)
			{
				_routeValues.Add(parameter.Key, parameter.Value);
			}
			return Section(nameSection);
		}

		public FluentUrl Section(string nameSection, object parameters)
		{
			RouteValueDictionary parameters2 = new RouteValueDictionary(parameters);
			return Section(nameSection, parameters2);
		}

		public string Url()
		{
			try
			{
				VirtualPathData virtualPath = RouteTable.Routes.GetVirtualPath(null, _routeName.ToString(), _routeValues);
				return ((virtualPath != null) ? (MslcUrlBuilder.BaseUrl + virtualPath.VirtualPath) : string.Empty).ToLower();
			}
            catch
            {
				return string.Empty.ToLower();

			}
		}
	}

}