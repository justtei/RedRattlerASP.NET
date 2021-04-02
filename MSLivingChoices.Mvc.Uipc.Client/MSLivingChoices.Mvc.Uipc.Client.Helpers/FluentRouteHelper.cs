using MSLivingChoices.Mvc.Uipc.Client.Enums;
using MSLivingChoices.Mvc.Uipc.Client.Helpers.Core;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Mvc.Uipc.Client.Helpers
{
	public static class FluentRouteHelper
	{
		public static FluentRoute City(this FluentRoute route)
		{
			return route.Section("City", "/{cityName}");
		}

		public static FluentRoute DetailsId(this FluentRoute route)
		{
			return route.Section("DetailsId", "-id{id}", new KeyValuePair<string, object>?(new KeyValuePair<string, object>("id", "[0-9]{1,}")));
		}

		public static FluentRoute FluentRoute(this PageType pageType)
		{
			KeyValuePair<string, object>? nullable = null;
			return (new FluentRoute()).Section(string.Format("Search{0}By", pageType.RoutePrefix()), pageType.UrlPrefix(), nullable, new KeyValuePair<string, object>?(new KeyValuePair<string, object>("pageType", (object)pageType)));
		}

		public static FluentRoute Name(this FluentRoute route)
		{
			return route.Section("Name", "/{name}");
		}

		public static FluentRoute Print(this FluentRoute route)
		{
			return route.Section("Print", "/print");
		}

		public static FluentRoute PrintCoupon(this FluentRoute route)
		{
			return route.Section("PrintCoupon", "/print-coupon");
		}

		public static FluentRoute PrintDirection(this FluentRoute route)
		{
			return route.Section("PrintDirection", "/print-direction");
		}

		public static FluentRoute State(this FluentRoute route)
		{
			return route.Section("State", "/{stateCode}", new KeyValuePair<string, object>?(new KeyValuePair<string, object>("stateCode", "^[a-zA-Z]{2}$")));
		}

		public static FluentRoute WithPaging(this FluentRoute route)
		{
			return route.Section("WithPaging", "/page-{pageNumber}", new KeyValuePair<string, object>?(new KeyValuePair<string, object>("pageNumber", "^[0-9]{1,}$")));
		}

		public static FluentRoute Zip(this FluentRoute route)
		{
			return route.Section("Zip", "/{zip}", new KeyValuePair<string, object>?(new KeyValuePair<string, object>("zip", "^\\d{5}(-\\d{4})?$|^[a-zA-Z]\\d[a-zA-Z]-\\d[a-zA-Z]\\d$")));
		}

		public static FluentRoute BlogID(this FluentRoute route)
		{
			return route.Section("BlogID", "/{id}", new KeyValuePair<string, object>?(new KeyValuePair<string, object>("id", "^[0-9]{1,}$")));
		}
	}
}