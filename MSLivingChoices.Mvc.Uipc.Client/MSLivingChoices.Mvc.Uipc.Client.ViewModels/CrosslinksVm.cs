using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Mvc.Uipc.Client.ViewModels
{
	public class CrosslinksVm
	{
		public List<LinkVm> Categories
		{
			get;
			set;
		}

		public List<LinkVm> Cities
		{
			get;
			set;
		}

		public CrosslinksVm()
		{
			this.Cities = new List<LinkVm>();
			this.Categories = new List<LinkVm>();
		}
	}
}