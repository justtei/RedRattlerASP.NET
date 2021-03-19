using System;
using System.Web.Mvc;
using System.Web.Security;
using UserManagementSystem.Business.Components;
using UserManagementSystem.Localization;
using UserManagementSystem.Shared.Entities;
using UserManagementSystem.Shared.Entities.Enum;
using UserManagementSystem.Web.Models;

namespace Main.Controllers
{
    public class AdminAccontController : BaseController
    {
            private const string AdminRoleString = "Admin";

            public AdminAccontController()
            {
            }

            [Authorize(Roles = "Admin")]
            [HttpGet]
            public ActionResult ChangePassword()
            {
                return base.View();
            }

            [Authorize(Roles = "Admin")]
            [HttpPost]
            public ActionResult ChangePassword(ChangePasswordViewModel model)
            {
                string unsuccessfulPasswordChange;
                ActionResult action;
                if (base.ModelState.IsValid)
                {
                    Guid? currentUserId = AccountBc.Instance.GetCurrentUserId();
                    ChangePasswordResult changePasswordResult = AccountBc.Instance.ChangePassword(currentUserId.Value, model.OldPassword, model.NewPassword);
                    if (changePasswordResult != ChangePasswordResult.Success)
                    {
                        switch (changePasswordResult)
                        {
                            case ChangePasswordResult.Fail:
                                {
                                    unsuccessfulPasswordChange = ErrorMessages.UnsuccessfulPasswordChange;
                                    break;
                                }
                            case ChangePasswordResult.InvalidNewPasswordLength:
                                {
                                    unsuccessfulPasswordChange = ErrorMessages.MinNewPasswordLength;
                                    break;
                                }
                            case ChangePasswordResult.InvalidNewPasswordNonAlphanumericCharacters:
                                {
                                    unsuccessfulPasswordChange = ErrorMessages.MinNewPasswordNonAlphanumericSymbols;
                                    break;
                                }
                            case ChangePasswordResult.InvalidNewPasswordFormat:
                                {
                                    unsuccessfulPasswordChange = ErrorMessages.NewPasswordWrongFormat;
                                    break;
                                }
                            case ChangePasswordResult.CurrentPasswordIncorrect:
                                {
                                    unsuccessfulPasswordChange = ErrorMessages.IncorrectCurrentPassword;
                                    break;
                                }
                            default:
                                {
                                    unsuccessfulPasswordChange = ErrorMessages.UnsuccessfulPasswordChange;
                                    break;
                                }
                        }
                        base.ModelState.AddModelError(ModelErrorKey.UnsuccessfulPasswordChange.ToString(), string.Format(unsuccessfulPasswordChange, Membership.MinRequiredPasswordLength, Membership.MinRequiredNonAlphanumericCharacters));
                        action = base.View(model);
                    }
                    else
                    {
                        action = base.RedirectToAction("List");
                    }
                }
                else
                {
                    action = base.View(model);
                }
                return action;
            }

            [Authorize(Roles = "Admin")]
            [HttpGet]
            public ActionResult Create()
            {
                return base.View(ViewModelsProvider.GetCreateUserViewModel());
            }

            [Authorize(Roles = "Admin")]
            [HttpPost]
            public ActionResult Create(CreateUserViewModel userModel)
            {
                ActionResult action;
                userModel = ViewModelsProvider.UpdateCreateUserViewModel(userModel);
                if (base.ModelState.IsValid)
                {
                    MembershipCreateStatus membershipCreateStatu = AccountBc.Instance.SaveUser(userModel.ToBusinessEntity());
                    if (membershipCreateStatu == MembershipCreateStatus.Success)
                    {
                        action = base.RedirectToAction("List", "AdminAccount");
                    }
                    else
                    {
                        if (membershipCreateStatu == MembershipCreateStatus.DuplicateUserName)
                        {
                            base.ModelState.AddModelError(ModelErrorKey.UnsuccesessfulPrimaryEmail.ToString(), ErrorMessages.UnsuccessfulPrimaryEmail);
                        }
                        else
                        {
                            base.ModelState.AddModelError(ModelErrorKey.UnknownErrorDuringUserSaving.ToString(), ErrorMessages.UnknownErrorDuringAccountSaving);
                        }
                        action = base.View(userModel);
                    }
                }
                else
                {
                    action = base.View(userModel);
                }
                return action;
            }

            [Authorize(Roles = "Admin")]
            [HttpGet]
            public ActionResult CreateAdmin()
            {
                return base.View(ViewModelsProvider.GetCreateAdminViewModel());
            }

            [Authorize(Roles = "Admin")]
            [HttpPost]
            public ActionResult CreateAdmin(CreateAdminViewModel createAdminViewModel)
            {
                ActionResult action;
                if (base.ModelState.IsValid)
                {
                    MembershipCreateStatus membershipCreateStatu = AccountBc.Instance.SaveUser(createAdminViewModel.ToBuissnessEntity());
                    if (membershipCreateStatu == MembershipCreateStatus.Success)
                    {
                        action = base.RedirectToAction("List", "AdminAccount");
                    }
                    else
                    {
                        if (membershipCreateStatu == MembershipCreateStatus.DuplicateUserName)
                        {
                            base.ModelState.AddModelError(ModelErrorKey.UnsuccesessfulPrimaryEmail.ToString(), ErrorMessages.UnsuccessfulPrimaryEmail);
                        }
                        else
                        {
                            base.ModelState.AddModelError(ModelErrorKey.UnknownErrorDuringUserSaving.ToString(), ErrorMessages.UnknownErrorDuringAccountSaving);
                        }
                        action = base.View(createAdminViewModel);
                    }
                }
                else
                {
                    action = base.View(createAdminViewModel);
                }
                return action;
            }

            [Authorize(Roles = "Admin")]
            public JsonResult Delete(Guid id)
            {
                JsonResult jsonResult;
                try
                {
                    AccountBc.Instance.Delete(id);
                    JsonResult jsonResult1 = new JsonResult()
                    {
                        Data = true,
                        ContentType = "json",
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet
                    };
                    jsonResult = jsonResult1;
                }
                catch (Exception exception)
                {
                    JsonResult jsonResult2 = new JsonResult()
                    {
                        Data = false,
                        ContentType = "json",
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet
                    };
                    jsonResult = jsonResult2;
                }
                return jsonResult;
            }

            [Authorize(Roles = "Admin")]
            [HttpGet]
            public ActionResult Edit(Guid id)
            {
                ActionResult action;
                if (!AccountBc.Instance.IsUserInRoles(id, UmsRoles.Admin))
                {
                    Account byId = AccountBc.Instance.GetById(id);
                    if (!AccountBc.Instance.IsUserInRoles(byId.PrimaryEmail, UmsRoles.Admin))
                    {
                        action = base.View(ViewModelsProvider.GetEditUserViewModel(byId));
                    }
                    else
                    {
                        action = base.RedirectToAction("EditAdmin", new { id = byId.Id });
                    }
                }
                else
                {
                    action = base.RedirectToAction("EditAdmin", new { id = id });
                }
                return action;
            }

            [Authorize(Roles = "Admin")]
            [HttpPost]
            public ActionResult Edit(EditUserViewModel editUserViewModel)
            {
                ActionResult action;
                if (base.ModelState.IsValid)
                {
                    Guid value = AccountBc.Instance.GetCurrentUserId().Value;
                    if (AccountBc.Instance.UpdateUser(editUserViewModel.ToBusinessEntity(), value))
                    {
                        action = base.RedirectToAction("List");
                    }
                    else
                    {
                        base.ModelState.AddModelError(ModelErrorKey.UnknownErrorDuringUserSaving.ToString(), ErrorMessages.UnknownErrorDuringAccountSaving);
                        action = base.View(ViewModelsProvider.GetEditUserViewModel(editUserViewModel));
                    }
                }
                else
                {
                    action = base.View(ViewModelsProvider.GetEditUserViewModel(editUserViewModel));
                }
                return action;
            }

            [Authorize(Roles = "Admin")]
            [HttpGet]
            public ActionResult EditAdmin(Guid id)
            {
                ActionResult action;
                if (AccountBc.Instance.IsUserInRoles(id, UmsRoles.Admin))
                {
                    Account shortenedAccountById = AccountBc.Instance.GetShortenedAccountById(id);
                    action = base.View(ViewModelsProvider.GetEditAdminViewModel(shortenedAccountById));
                }
                else
                {
                    action = base.RedirectToAction("Edit", new { id = id });
                }
                return action;
            }

            [Authorize(Roles = "Admin")]
            [HttpPost]
            public ActionResult EditAdmin(EditAdminViewModel editAdminViewModel)
            {
                ActionResult action;
                if (base.ModelState.IsValid)
                {
                    Guid value = AccountBc.Instance.GetCurrentUserId().Value;
                    if (AccountBc.Instance.UpdateUser(editAdminViewModel.ToBuissnessEntity(), value))
                    {
                        action = base.RedirectToAction("List", "AdminAccount");
                    }
                    else
                    {
                        base.ModelState.AddModelError(ModelErrorKey.UnknownErrorDuringUserSaving.ToString(), ErrorMessages.UnknownErrorDuringAccountSaving);
                        action = base.View(editAdminViewModel);
                    }
                }
                else
                {
                    action = base.View(editAdminViewModel);
                }
                return action;
            }

            [HttpGet]
            public ActionResult ForgotPassword()
            {
                return base.View();
            }

            [HttpPost]
            public ActionResult ForgotPassword(ForgotPasswordViewModel model)
            {
                ActionResult action;
                if (!base.ModelState.IsValid)
                {
                    action = base.View(model);
                }
                else if (!AccountBc.Instance.ForgotPassword(model.Email))
                {
                    base.ModelState.AddModelError(ModelErrorKey.UnsuccessfulForgot.ToString(), ErrorMessages.UnsuccessfulForgot);
                    action = base.View(model);
                }
                else
                {
                    action = base.RedirectToAction("ForgotPasswordSuccess");
                }
                return action;
            }

            [HttpGet]
            public ActionResult ForgotPasswordSuccess()
            {
                return base.View();
            }

            [Authorize(Roles = "Admin")]
            public JsonResult JsonList(int? pageIndex, int? pageSize, string subnameFilter, string subEmailFilter, SortOrder? nameOrder, SortOrder? emailOrder, CheckFilter? leadFilter, CheckFilter? notificationFilter)
            {
                UsersPageResultViewModel usersPageResultViewModel = ViewModelsProvider.GetUsersPageResultViewModel(pageSize, pageIndex, subnameFilter, subEmailFilter, nameOrder, emailOrder, leadFilter, notificationFilter);
                JsonResult jsonResult = new JsonResult()
                {
                    Data = new { success = true, model = usersPageResultViewModel },
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
                return jsonResult;
            }

            [Authorize(Roles = "Admin")]
            [HttpGet]
            public ActionResult List(int? pageIndex, int? pageSize, string subnameFilter, string subEmailFilter, SortOrder? nameOrder, SortOrder? emailOrder, CheckFilter? leadFilter, CheckFilter? notificationFilter)
            {
                UsersPageResultViewModel usersPageResultViewModel = ViewModelsProvider.GetUsersPageResultViewModel(pageSize, pageIndex, subnameFilter, subEmailFilter, nameOrder, emailOrder, leadFilter, notificationFilter);
                return base.View(usersPageResultViewModel);
            }

            [HttpGet]
            public ActionResult LogOff()
            {
                AccountBc.Instance.LogOut();
                return base.RedirectToAction("LogOn");
            }

            [HttpGet]
            public ActionResult LogOn()
            {
                return base.View();
            }

            [HttpPost]
            public ActionResult LogOn(LogInViewModel model, string returnUri)
            {
                ActionResult action;
                if (base.ModelState.IsValid)
                {
                    Account account = AccountBc.Instance.LogOn(model.UserName, model.Password, model.RememberMe);
                    if ((account == null ? true : !AccountBc.Instance.IsUserInRoles(account.Id, UmsRoles.Admin)))
                    {
                        base.ModelState.AddModelError(ModelErrorKey.UnsuccessfulLogin.ToString(), ErrorMessages.UnsuccessfulLogin);
                        action = base.View(model);
                    }
                    else if (account.NeedChangePassword)
                    {
                        action = base.RedirectToAction("ChangePassword");
                    }
                    else if ((!base.Url.IsLocalUrl(returnUri) ? true : string.IsNullOrEmpty(returnUri)))
                    {
                        action = base.RedirectToAction("List");
                    }
                    else
                    {
                        action = this.Redirect(returnUri);
                    }
                }
                else
                {
                    action = base.View(model);
                }
                return action;
            }

            [Authorize(Roles = "Admin")]
            public bool ResetPassword(Guid id)
            {
                return AccountBc.Instance.ResetPassword(id);
            }

            [Authorize(Roles = "Admin")]
            public JsonResult SetLeads(Guid id, bool value)
            {
                JsonResult jsonResult;
                try
                {
                    bool flag = AccountBc.Instance.SetLeads(id, value);
                    JsonResult jsonResult1 = new JsonResult()
                    {
                        Data = flag,
                        ContentType = "json",
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet
                    };
                    jsonResult = jsonResult1;
                }
                catch (Exception exception)
                {
                    JsonResult jsonResult2 = new JsonResult()
                    {
                        Data = false,
                        ContentType = "json",
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet
                    };
                    jsonResult = jsonResult2;
                }
                return jsonResult;
            }

            [Authorize(Roles = "Admin")]
        public JsonResult SetNotifications(Guid id, bool value)
        {
            JsonResult jsonResult;
            try
            {
                bool flag = AccountBc.Instance.SetNotifications(id, value);
                JsonResult jsonResult1 = new JsonResult()
                {
                    Data = flag,
                    ContentType = "json",
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
                jsonResult = jsonResult1;
            }
            catch (Exception exception)
            {
                JsonResult jsonResult2 = new JsonResult()
                {
                    Data = false,
                    ContentType = "json",
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
                jsonResult = jsonResult2;
            }
            return jsonResult;
        }
    }
}