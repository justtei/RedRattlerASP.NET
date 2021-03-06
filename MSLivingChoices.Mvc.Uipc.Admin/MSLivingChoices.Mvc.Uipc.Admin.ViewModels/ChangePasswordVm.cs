using MSLivingChoices.Localization;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Web.Mvc;

namespace MSLivingChoices.Mvc.Uipc.Admin.ViewModels
{
	public class ChangePasswordVm
	{
		[AllowHtml]
		[System.Web.Mvc.Compare("NewPassword", ErrorMessageResourceName="PasswordConfirm", ErrorMessageResourceType=typeof(ErrorMessages))]
		[DataType(DataType.Password)]
		[Display(Name="Ttl_ConfirmNewPassword", ResourceType=typeof(StaticContent))]
		public string ConfirmPassword
		{
			get;
			set;
		}

		[AllowHtml]
		[DataType(DataType.Password)]
		[Display(Name="Ttl_NewPassword", ResourceType=typeof(StaticContent))]
		[Required]
		[StringLength(100, MinimumLength=6, ErrorMessageResourceName="PasswordLengthRange", ErrorMessageResourceType=typeof(ErrorMessages))]
		public string NewPassword
		{
			get;
			set;
		}

		[AllowHtml]
		[DataType(DataType.Password)]
		[Display(Name="Ttl_OldPassword", ResourceType=typeof(StaticContent))]
		[Required]
		public string OldPassword
		{
			get;
			set;
		}

		public ChangePasswordVm()
		{
		}
	}
}