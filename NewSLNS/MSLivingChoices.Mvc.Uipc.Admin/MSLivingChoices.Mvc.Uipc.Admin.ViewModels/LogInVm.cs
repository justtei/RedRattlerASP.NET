using MSLivingChoices.Localization;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Web.Mvc;

namespace MSLivingChoices.Mvc.Uipc.Admin.ViewModels
{
	public class LogInVm
	{
		[AllowHtml]
		[DataType(DataType.Password)]
		[Required]
		public string Password
		{
			get;
			set;
		}

		[Display(Name="RememberMe", ResourceType=typeof(DisplayNames))]
		public bool RememberMe
		{
			get;
			set;
		}

		[AllowHtml]
		[Required]
		public string Username
		{
			get;
			set;
		}

		public LogInVm()
		{
		}
	}
}