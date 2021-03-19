using MSLivingChoices.Entities.Admin.Enums;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Mvc.Uipc.Admin.ViewModels
{
	public class OwnerGridVm<T> : PagingVm
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

		public MSLivingChoices.Entities.Admin.Enums.OwnerType OwnerType
		{
			get;
			set;
		}

		public OwnerGridVm()
		{
		}
	}
}