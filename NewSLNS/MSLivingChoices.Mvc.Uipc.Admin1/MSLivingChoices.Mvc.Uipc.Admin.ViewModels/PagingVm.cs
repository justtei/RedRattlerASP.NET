using MSLivingChoices.Configuration;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Web.Mvc;

namespace MSLivingChoices.Mvc.Uipc.Admin.ViewModels
{
	public class PagingVm
	{
		private int _pageNumber;

		private int _pageSize;

		public int PageCount
		{
			get
			{
				return (int)Math.Ceiling(this.TotalCount / this.PageSize);
			}
		}

		public int PageNumber
		{
			get
			{
				if (this._pageNumber <= 0)
				{
					return ConfigurationManager.Instance.DefaultGridPageNumber;
				}
				return this._pageNumber;
			}
			set
			{
				this._pageNumber = value;
			}
		}

		public List<SelectListItem> PageNumbers
		{
			get
			{
				List<SelectListItem> pageNumbers = new List<SelectListItem>();
				for (int i = 1; i <= this.PageCount; i++)
				{
					SelectListItem selectListItem = new SelectListItem();
					selectListItem.set_Value(i.ToString());
					selectListItem.set_Text(i.ToString());
					pageNumbers.Add(selectListItem);
				}
				return pageNumbers;
			}
		}

		public List<int> Pages
		{
			get
			{
				List<int> pages = new List<int>();
				if (this.PageCount <= 10)
				{
					for (int i = 1; i <= this.PageCount; i++)
					{
						pages.Add(i);
					}
				}
				else if (this.PageNumber > this.PageCount || this.PageNumber <= 5)
				{
					for (int i = 1; i <= 10; i++)
					{
						pages.Add(i);
					}
				}
				else if (this.PageNumber >= this.PageCount - 4)
				{
					for (int i = this.PageCount - 9; i <= this.PageCount; i++)
					{
						pages.Add(i);
					}
				}
				else
				{
					for (int i = this.PageNumber - 4; i <= this.PageNumber + 5; i++)
					{
						pages.Add(i);
					}
				}
				return pages;
			}
		}

		public int PageSize
		{
			get
			{
				if (this._pageSize <= 0)
				{
					return ConfigurationManager.Instance.DefaultGridPageSize;
				}
				return this._pageSize;
			}
			set
			{
				this._pageSize = value;
			}
		}

		public List<SelectListItem> PageSizes
		{
			get
			{
				List<SelectListItem> pageSizes = new List<SelectListItem>();
				for (int i = 1; i <= 30; i++)
				{
					SelectListItem selectListItem = new SelectListItem();
					selectListItem.set_Value(i.ToString());
					selectListItem.set_Text(i.ToString());
					pageSizes.Add(selectListItem);
				}
				return pageSizes;
			}
		}

		public int TotalCount
		{
			get;
			set;
		}

		public PagingVm()
		{
		}
	}
}