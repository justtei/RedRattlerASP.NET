using System;
using System.Runtime.CompilerServices;
using System.Web.Mvc;

namespace MSLivingChoices.Mvc.Uipc.Client.ViewModels
{
	public class CustomerInfoVm
	{
		[AllowHtml]
		public string Email
		{
			get;
			set;
		}

		[AllowHtml]
		public string Name
		{
			get;
			set;
		}

		[AllowHtml]
		public string Phone
		{
			get;
			set;
		}

		public CustomerInfoVm()
		{
		}
	}
}