using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Mvc.Uipc.Admin.ViewModels
{
	public class GridVm<T> : PagingVm
	where T : class
	{
		public string GridUrl
		{
			get;
			set;
		}

		public string JsonGridUrl
		{
			get;
			set;
		}

		public List<T> List
		{
			get;
			set;
		}

		public GridVm()
		{
		}
	}
}