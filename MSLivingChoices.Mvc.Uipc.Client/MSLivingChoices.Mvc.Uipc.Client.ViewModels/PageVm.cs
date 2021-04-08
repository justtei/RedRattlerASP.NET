using MSLivingChoices.Mvc.Uipc.Client.Enums;
using System;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Mvc.Uipc.Client.ViewModels
{
	public class PageVm
	{
		public PageType PageType
		{
			get;
			set;
		}

		public SeoVm Seo
		{
			get;
			set;
		}

		public PageVm()
		{
		}
	}
}