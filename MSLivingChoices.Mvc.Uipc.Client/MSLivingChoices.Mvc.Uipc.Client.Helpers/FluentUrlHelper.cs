using MSLivingChoices.Mvc.Uipc.Client.Enums;
using MSLivingChoices.Mvc.Uipc.Client.Helpers.Core;
using MSLivingChoices.Mvc.Uipc.Enums;
using MSLivingChoices.Utilities;
using System;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Mvc.Uipc.Client.Helpers
{
	public static class FluentUrlHelper
	{
		public static FluentUrl Address(this FluentUrl url, string address)
		{
			if (!address.IsNullOrEmpty())
			{
				url.Section("Address", "address", address.ToUrlSectionString());
			}
			return url;
		}

		public static FluentUrl Api(this FluentUrl url, string action, string controller, object routeValues)
		{
			if (!action.IsNullOrEmpty() && !controller.IsNullOrEmpty())
			{
				url.Section("Default", new { action = action, controller = controller });
				if (routeValues != null)
				{
					url.Section(string.Empty, routeValues);
				}
			}
			return url;
		}

		public static FluentUrl City(this FluentUrl url, string cityName)
		{
			if (!cityName.IsNullOrEmpty())
			{
				url.Section("City", "cityName", cityName.ToUrlSectionString());
			}
			return url;
		}

		public static FluentUrl DetailsId(this FluentUrl url, long id)
		{
			if (id > (long)0)
			{
				url.Section("DetailsId", new { id = id });
			}
			return url;
		}

		public static FluentUrl FluentUrl(this PageType pageType)
		{
			return (new FluentUrl()).Section(string.Format("Search{0}By", pageType.RoutePrefix()));
		}

		public static FluentUrl FluentUrl(this SearchType searchTypeType)
		{
			return (new FluentUrl()).Section(string.Format("Search{0}By", searchTypeType.RoutePrefix()));
		}

		public static FluentUrl Name(this FluentUrl url, string name)
		{
			if (!name.IsNullOrEmpty())
			{
				url.Section("Name", "name", name.ToUrlSectionString());
			}
			return url;
		}

		public static FluentUrl Print(this FluentUrl url)
		{
			url.Section("Print");
			return url;
		}

		public static FluentUrl PrintCoupon(this FluentUrl url)
		{
			url.Section("PrintCoupon");
			return url;
		}

		public static FluentUrl PrintDirection(this FluentUrl url)
		{
			url.Section("PrintDirection");
			return url;
		}

		public static FluentUrl State(this FluentUrl url, string stateCode)
		{
			if (!stateCode.IsNullOrEmpty())
			{
				url.Section("State", "stateCode", stateCode.ToUrlSectionString());
			}
			return url;
		}

		public static FluentUrl WithPaging(this FluentUrl url, int pageNumber)
		{
			if (pageNumber > 1)
			{
				url.Section("WithPaging", "pageNumber", pageNumber);
			}
			return url;
		}

		public static FluentUrl Zip(this FluentUrl url, string zip)
		{
			if (!zip.IsNullOrEmpty())
			{
				url.Section("Zip", "zip", zip.ToUrlSectionString());
			}
			return url;
		}
	}
}