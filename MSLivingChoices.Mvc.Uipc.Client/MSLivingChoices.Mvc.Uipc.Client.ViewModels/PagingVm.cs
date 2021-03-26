using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Mvc.Uipc.Client.ViewModels
{
	public class PagingVm
	{
		public int CurrentPage
		{
			get;
			set;
		}

		public string CurrentPageUrl
		{
			get
			{
				if (!this.Pages.Any<PageLinkVm>())
				{
					return string.Empty;
				}
				return this.Pages.First<PageLinkVm>((PageLinkVm vm) => vm.PageNumber == this.CurrentPage).Href;
			}
		}

		public int DisplayVector
		{
			get
			{
				return 3;
			}
		}

		public List<PageLinkVm> Pages
		{
			get;
			private set;
		}

		public int PageSize
		{
			get;
			set;
		}

		public string Status
		{
			get
			{
				return string.Format("Showing from {0} to {1} of {2}", (this.CurrentPage - 1) * this.PageSize + 1, Math.Min(this.TotalCount, this.CurrentPage * this.PageSize), this.TotalCount);
			}
		}

		public int TotalCount
		{
			get;
			set;
		}

		public int TotalDisplay
		{
			get
			{
				return this.DisplayVector * 2 + 1;
			}
		}

		public int TotalPages
		{
			get
			{
				if (this.PageSize == 0)
				{
					return 0;
				}
				return (int)Math.Ceiling((double)this.TotalCount / (double)this.PageSize);
			}
		}

		public PagingVm()
		{
			this.Pages = new List<PageLinkVm>();
		}
	}
}