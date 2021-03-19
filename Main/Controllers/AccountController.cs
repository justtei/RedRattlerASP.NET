using MSLivingChoices.Bcs.Admin.Components;
using MSLivingChoices.Localization;
using MSLivingChoices.Mvc.Uipc.Admin.ViewModels;
using System;
using System.Web.Mvc;
using System.Web.Security;
using UserManagementSystem.Shared.Entities;
using UserManagementSystem.Shared.Entities.Enum;

namespace Main.Controllers
{
	public class AccountController : BaseController
	{
		public AccountController()
		{
		}

		[Authorize]
		[HttpGet]
		public ActionResult ChangePassword()
		{
			return base.View();
		}

		[Authorize]
		[HttpPost]
		public ActionResult ChangePassword(ChangePasswordVm model)
		{
			string errorMessage;
			if (!base.ModelState.IsValid)
			{
				return base.View(model);
			}
			ChangePasswordResult passwordChangeResult = AccountBc.Instance.ChangePassword(model.OldPassword, model.NewPassword);
			if (passwordChangeResult == ChangePasswordResult.Success)
			{
				return base.RedirectToAction("Grid", "Community");
			}
			switch (passwordChangeResult)
			{
				case ChangePasswordResult.Fail:
				{
					errorMessage = ErrorMessages.UnsuccessfulPasswordChange;
					break;
				}
				case ChangePasswordResult.InvalidNewPasswordLength:
				{
					errorMessage = ErrorMessages.MinNewPasswordLength;
					break;
				}
				case ChangePasswordResult.InvalidNewPasswordNonAlphanumericCharacters:
				{
					errorMessage = ErrorMessages.MinNewPasswordNonAlphanumericSymbols;
					break;
				}
				case ChangePasswordResult.InvalidNewPasswordFormat:
				{
					errorMessage = ErrorMessages.NewPasswordWrongFormat;
					break;
				}
				case ChangePasswordResult.CurrentPasswordIncorrect:
				{

					errorMessage = ErrorMessages.IncorrectCurrentPassword;
					break;
				}
				default:
				{
					errorMessage = ErrorMessages.UnsuccessfulPasswordChange;
					break;
				}
			}
			base.ModelState.AddModelError("UnsuccessfulPasswordChange", string.Format(errorMessage, Membership.MinRequiredPasswordLength, Membership.MinRequiredNonAlphanumericCharacters));
			return base.View(model);
		}

		[HttpGet]
		public ActionResult LogIn()
		{
			return base.View();
		}

		[HttpPost]
		public ActionResult LogIn(LogInVm model, string returnUrl)
		{
			if (!base.ModelState.IsValid)
			{
				return base.View(model);
			}
			Account user = AccountBc.Instance.LogOn(model.Username, model.Password, model.RememberMe);
			if (user == null)
			{
				base.ModelState.AddModelError(ErrorMessages.UnsuccessfulLogin, ErrorMessages.UnsuccessfulLogin);
				return base.View(model);
			}
			if (user.NeedChangePassword)
			{
				return base.RedirectToAction("ChangePassword");
			}
			if (base.Url.IsLocalUrl(returnUrl) && !string.IsNullOrEmpty(returnUrl))
			{
				return this.Redirect(returnUrl);
			}
			return base.RedirectToAction("Grid", "Community");
		}

		[HttpGet]
		public ActionResult LogOff()
		{
			AccountBc.Instance.LogOff();
			return base.RedirectToRoute("Default", new { controller = "Client", action = "Index" });
		}
	}
}