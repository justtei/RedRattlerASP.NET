using System;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Mvc.Uipc.Client.ViewModels
{
	public class LinkVm
	{
		public string Css
		{
			get;
			set;
		}

		public string Href
		{
			get;
			set;
		}

		public string InnerText
		{
			get;
			set;
		}

		public LinkVm()
		{
			this.InnerText = string.Empty;
		}

		public LinkVm(string innerText, string href)
		{
			this.InnerText = innerText;
			this.Href = href;
		}
	}
}