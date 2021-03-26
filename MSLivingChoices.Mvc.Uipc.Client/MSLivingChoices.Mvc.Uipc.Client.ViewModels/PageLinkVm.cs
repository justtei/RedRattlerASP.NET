using System;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Mvc.Uipc.Client.ViewModels
{
	public class PageLinkVm : LinkVm
	{
		public const string CssFirst = "first";

		public const string CssPrev = "prev";

		public const string CssNext = "next";

		public const string CssLast = "last";

		public const string CssActive = "active";

		public bool IsActive
		{
			get
			{
				return base.Css == "active";
			}
		}

		public int PageNumber
		{
			get;
			set;
		}

		public PageLinkVm()
		{
		}
	}
}