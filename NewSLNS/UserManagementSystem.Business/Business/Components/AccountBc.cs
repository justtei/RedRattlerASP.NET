using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Web.Security;
using UserManagementSystem.Business;
using UserManagementSystem.Business.Enums;
using UserManagementSystem.DAL.Interfaces;
using UserManagementSystem.DAL.Interfaces.Components;
using UserManagementSystem.Entities;
using UserManagementSystem.Logging;
using UserManagementSystem.Mailing.Business;

namespace UserManagementSystem.Business.Components
{
	public class AccountBc
	{
		private readonly IAccountDac _accountDac;

		private static AccountBc _accountBc;

		private readonly static object Locker;

		public static AccountBc Instance
		{
			get
			{
				if (AccountBc._accountBc == null)
				{
					lock (AccountBc.Locker)
					{
						if (AccountBc._accountBc == null)
						{
							AccountBc._accountBc = new AccountBc();
						}
					}
				}
				return AccountBc._accountBc;
			}
		}

		static AccountBc()
		{
			AccountBc.Locker = new object();
		}

		private AccountBc()
		{
			this._accountDac = DacFactoryClient.GetFactory().GetAccountDac();
		}

		public ChangePasswordResult ChangePassword(Guid userId, string oldPassword, string newPassword)
		{
			MembershipUser user = Membership.GetUser(userId);
			return this.ChangePassword(user, oldPassword, newPassword);
		}

		public ChangePasswordResult ChangePassword(string userName, string oldPassword, string newPassword)
		{
			MembershipUser user = Membership.GetUser(userName);
			return this.ChangePassword(user, oldPassword, newPassword);
		}

		private ChangePasswordResult ChangePassword(MembershipUser currentUser, string oldPassword, string newPassword)
		{
			ChangePasswordResult changePasswordResult;
			try
			{
				if (currentUser != null)
				{
					if (currentUser.IsLockedOut)
					{
						currentUser.UnlockUser();
					}
					if (!currentUser.ChangePassword(oldPassword, newPassword))
					{
						changePasswordResult = ChangePasswordResult.CurrentPasswordIncorrect;
					}
					else
					{
						currentUser.Comment = string.Empty;
						Membership.UpdateUser(currentUser);
						UmsMailing.Instance.SendChangePasswordMail(currentUser.UserName, newPassword);
						changePasswordResult = ChangePasswordResult.Success;
					}
				}
				else
				{
					changePasswordResult = ChangePasswordResult.NoSuchUser;
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				Logger.Error(string.Format("Error during change password. User name: '{0}'", currentUser.UserName), exception);
				if (string.IsNullOrEmpty(newPassword))
				{
					changePasswordResult = ChangePasswordResult.InvalidNewPasswordLength;
				}
				else if (newPassword.Length >= Membership.MinRequiredPasswordLength)
				{
					int num = 0;
					for (int i = 0; i < newPassword.Length; i++)
					{
						if (!char.IsLetterOrDigit(newPassword, i))
						{
							num++;
						}
					}
					if (num >= Membership.MinRequiredNonAlphanumericCharacters)
					{
						changePasswordResult = ((string.IsNullOrEmpty(Membership.PasswordStrengthRegularExpression) ? true : Regex.IsMatch(newPassword, Membership.PasswordStrengthRegularExpression)) ? ChangePasswordResult.CurrentPasswordIncorrect : ChangePasswordResult.InvalidNewPasswordFormat);
					}
					else
					{
						changePasswordResult = ChangePasswordResult.InvalidNewPasswordNonAlphanumericCharacters;
					}
				}
				else
				{
					changePasswordResult = ChangePasswordResult.InvalidNewPasswordLength;
				}
			}
			return changePasswordResult;
		}

		public bool ChangePrimaryEmail(Guid userId, string newPrimaryEmail)
		{
			bool flag;
			if (!this.IsExistPrimatyEmail(newPrimaryEmail))
			{
				Account shortenedAccountById = this.GetShortenedAccountById(userId);
				this._accountDac.ChangePrimaryEmail(shortenedAccountById.PrimaryEmail, newPrimaryEmail);
				UmsMailing.Instance.SendChangeUserName(shortenedAccountById.PrimaryEmail, newPrimaryEmail);
				flag = true;
			}
			else
			{
				flag = false;
			}
			return flag;
		}

		public void Delete(Guid id, Guid currentUserid)
		{
			MembershipUser user = Membership.GetUser(id);
			if (user != null)
			{
				if (currentUserid != id)
				{
					this._accountDac.Delete(id);
					Membership.DeleteUser(user.UserName, true);
				}
			}
		}

		public bool ForgotPassword(string email)
		{
			bool flag;
			try
			{
				MembershipUser user = Membership.GetUser(email);
				if (user != null)
				{
					if (user.IsLockedOut)
					{
						user.UnlockUser();
					}
					string str = user.ResetPassword();
					user.Comment = "Redirect to change password";
					Membership.UpdateUser(user);
					UmsMailing.Instance.SendResetPasswordMail(user.UserName, str);
					flag = true;
				}
				else
				{
					flag = false;
				}
			}
			catch (Exception exception)
			{
				Logger.Error(string.Format("Error during reset password. User email: '{0}'", email), exception);
				flag = false;
			}
			return flag;
		}

		public Account GetById(Guid id)
		{
			Account byId = this._accountDac.GetById(id);
			MembershipUser user = Membership.GetUser(id);
			if (user != null)
			{
				byId.Role = Roles.GetRolesForUser(user.UserName).ToList<string>().FirstOrDefault<string>();
				byId.IsActive = user.IsApproved;
				byId.NeedChangePassword = "Redirect to change password".Equals(user.Comment);
			}
			return byId;
		}

		public List<EmailType> GetEmailTypes()
		{
			return this._accountDac.GetEmailTypes();
		}

		public List<PhoneType> GetPhoneTypes()
		{
			return this._accountDac.GetPhoneTypes();
		}

		public Account GetShortenedAccountById(Guid id)
		{
			Account shortenedAccountById = this._accountDac.GetShortenedAccountById(id);
			MembershipUser user = Membership.GetUser(id);
			if (user != null)
			{
				shortenedAccountById.Role = Roles.GetRolesForUser(user.UserName).FirstOrDefault<string>();
				shortenedAccountById.IsActive = user.IsApproved;
				shortenedAccountById.NeedChangePassword = "Redirect to change password".Equals(user.Comment);
			}
			return shortenedAccountById;
		}

		public List<Account> GetUsers(Guid userId, int pageSize, int pageIndex, string subnameFilter, string subEmailFilter, SortOrder nameOrder, SortOrder emailOrder, CheckFilter leadFilter, CheckFilter notificationFilter, out int totalCount)
		{
			MembershipUser user = Membership.GetUser(userId);
			bool flag = (user == null ? false : Roles.IsUserInRole(user.UserName, "Admin"));
			List<Account> allUsers = this._accountDac.GetAllUsers(userId, pageSize, pageIndex, flag, subnameFilter, subEmailFilter, nameOrder, emailOrder, leadFilter, notificationFilter, out totalCount);
			allUsers.RemoveAll((Account a) => a.PrimaryEmail == user.UserName);
			return allUsers;
		}

		public bool IsExistPrimatyEmail(string primaryEmail)
		{
			return Membership.GetUser(primaryEmail) != null;
		}

		public bool IsUserEditedPrimaryEmail(Guid userId, string newPrimaryEmail)
		{
			bool flag;
			MembershipUser user = Membership.GetUser(userId);
			if (user == null)
			{
				flag = false;
			}
			else
			{
				flag = (user.UserName == null ? false : user.UserName != newPrimaryEmail);
			}
			return flag;
		}

		public bool ResetPassword(Guid id)
		{
			bool flag;
			try
			{
				MembershipUser user = Membership.GetUser(id);
				if (user != null)
				{
					if (user.IsLockedOut)
					{
						user.UnlockUser();
					}
					string str = user.ResetPassword();
					user.Comment = "Redirect to change password";
					Membership.UpdateUser(user);
					UmsMailing.Instance.SendResetPasswordMail(user.UserName, str);
					flag = true;
				}
				else
				{
					flag = false;
				}
			}
			catch (Exception exception)
			{
				Logger.Error(string.Format("Error during reset password. User id: '{0}'", id), exception);
				flag = false;
			}
			return flag;
		}

		public MembershipCreateStatus SaveUser(Account account, Guid curentUserId)
		{
			MembershipCreateStatus membershipCreateStatu;
			MembershipCreateStatus membershipCreateStatu1;
			string str = Membership.GeneratePassword(12, 1);
			MembershipUser primaryEmail = Membership.CreateUser(account.PrimaryEmail, str, account.PrimaryEmail, null, null, account.IsActive, null, out membershipCreateStatu);
			if (membershipCreateStatu == MembershipCreateStatus.Success)
			{
				Roles.AddUserToRole(account.PrimaryEmail, account.Role);
				if (primaryEmail != null)
				{
					if (primaryEmail.ProviderUserKey != null)
					{
						account.Id = (Guid)primaryEmail.ProviderUserKey;
					}
					primaryEmail.Email = account.PrimaryEmail;
					primaryEmail.Comment = "Redirect to change password";
					Guid guid = curentUserId;
					DateTime now = DateTime.Now;
					Guid guid1 = guid;
					Guid guid2 = guid1;
					account.ModifyUserId = guid1;
					account.CreateUserId = guid2;
					DateTime dateTime = now;
					DateTime dateTime1 = dateTime;
					account.ModifyDate = dateTime;
					account.CreateDate = dateTime1;
					foreach (FullAddress fullAddress in account.FullAddresses)
					{
						DateTime dateTime2 = now;
						dateTime1 = dateTime2;
						fullAddress.ModifyDate = dateTime2;
						fullAddress.CreateDate = dateTime1;
						Guid guid3 = guid;
						guid2 = guid3;
						fullAddress.ModifyUserId = guid3;
						fullAddress.CreateUserId = guid2;
					}
					foreach (Email email in account.Emails)
					{
						DateTime dateTime3 = now;
						dateTime1 = dateTime3;
						email.ModifyDate = dateTime3;
						email.CreateDate = dateTime1;
						Guid guid4 = guid;
						guid2 = guid4;
						email.ModifyUserId = guid4;
						email.CreateUserId = guid2;
					}
					foreach (Phone phone in account.Phones)
					{
						DateTime dateTime4 = now;
						dateTime1 = dateTime4;
						phone.ModifyDate = dateTime4;
						phone.CreateDate = dateTime1;
						Guid guid5 = guid;
						guid2 = guid5;
						phone.ModifyUserId = guid5;
						phone.CreateUserId = guid2;
					}
					Membership.UpdateUser(primaryEmail);
					this._accountDac.Save(account);
					UmsMailing.Instance.SendSuccessRegistrationMail(account.PrimaryEmail, account.FirstName, account.LastName, account.PrimaryEmail, str);
				}
				membershipCreateStatu1 = membershipCreateStatu;
			}
			else
			{
				membershipCreateStatu1 = membershipCreateStatu;
			}
			return membershipCreateStatu1;
		}

		public bool SetLeads(Guid userId, bool leads)
		{
			bool flag;
			try
			{
				this._accountDac.SetLeads(userId, leads);
				flag = true;
			}
			catch (Exception exception)
			{
				flag = false;
			}
			return flag;
		}

		public bool SetNotifications(Guid userId, bool notifications)
		{
			bool flag;
			try
			{
				this._accountDac.SetNotifications(userId, notifications);
				flag = true;
			}
			catch (Exception exception)
			{
				flag = false;
			}
			return flag;
		}

		public void UpdateUser(Account account, Guid modifyUserId)
		{
			MembershipUser user = Membership.GetUser(account.PrimaryEmail);
			if (user != null)
			{
				if (user.IsApproved != account.IsActive)
				{
					if (!account.IsActive)
					{
						UmsMailing.Instance.SendBlockAccountMail(account.PrimaryEmail);
					}
					else
					{
						UmsMailing.Instance.SendUnlockAccountMail(account.PrimaryEmail);
					}
					user.IsApproved = account.IsActive;
					Membership.UpdateUser(user);
				}
			}
			if (!Roles.IsUserInRole(account.PrimaryEmail, account.Role))
			{
				Roles.RemoveUserFromRoles(account.PrimaryEmail, Roles.GetRolesForUser(account.PrimaryEmail));
				Roles.AddUserToRole(account.PrimaryEmail, account.Role);
			}
			DateTime now = DateTime.Now;
			account.ModifyUserId = modifyUserId;
			account.ModifyDate = now;
			foreach (FullAddress fullAddress in account.FullAddresses)
			{
				if (fullAddress.CreateUserId == Guid.Empty)
				{
					fullAddress.CreateUserId = modifyUserId;
					fullAddress.CreateDate = now;
				}
				fullAddress.ModifyUserId = modifyUserId;
				fullAddress.ModifyDate = now;
			}
			foreach (Phone phone in account.Phones)
			{
				if (phone.CreateUserId == Guid.Empty)
				{
					phone.CreateUserId = modifyUserId;
					phone.CreateDate = now;
				}
				phone.ModifyUserId = modifyUserId;
				phone.ModifyDate = now;
			}
			foreach (Email email in account.Emails)
			{
				if (email.CreateUserId == Guid.Empty)
				{
					email.CreateUserId = modifyUserId;
					email.CreateDate = now;
				}
				email.ModifyUserId = modifyUserId;
				email.ModifyDate = now;
			}
			this._accountDac.Save(account);
		}
	}
}