using MSLivingChoices.Mvc.Uipc.Client.Enums;
using System;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Mvc.Uipc.Client.ViewModels
{
	public class SeoVm
	{
		public string CanonicalUrl
		{
			get;
			set;
		}

		public string Description
		{
			get;
			set;
		}

		public string Header
		{
			get;
			set;
		}

		public string LinkNext
		{
			get;
			set;
		}

		public string LinkPrev
		{
			get;
			set;
		}

		public string MarketCopy
		{
			get;
			set;
		}

		public PageType PageType
		{
			get;
			set;
		}

		public string Title
		{
			get;
			set;
		}

		public SeoVm()
		{
		}
	}
}