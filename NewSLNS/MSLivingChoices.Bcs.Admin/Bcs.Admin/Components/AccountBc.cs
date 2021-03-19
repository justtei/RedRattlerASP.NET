using MSLivingChoices.Session;
using System;
using System.Collections.Generic;
using UserManagementSystem.Shared.Entities;
using UserManagementSystem.Shared.Entities.Enum;
using UserManagementSystem.Shared.Service;

namespace MSLivingChoices.Bcs.Admin.Components
{
	public class AccountBc
	{
		private readonly UmsServiceClient _client;

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
			this._client = new UmsServiceClient();
		}

		public ChangePasswordResult ChangePassword(string oldPassword, string newPassword)
		{
			Guid? currentUserId = this.GetCurrentUserId();
			if (!currentUserId.HasValue)
			{
				return ChangePasswordResult.Fail;
			}
			return this._client.ChangePassword(currentUserId.Value, oldPassword, newPassword);
		}

		public List<Publication> GetBooks(Guid userId)
		{
			List<Publication> userBooks;
			if (!SessionManager.GetCurrentUserData<List<Publication>>(userId, SessionKeys.CurrentUserBooks, out userBooks))
			{
				userBooks = this._client.GetUserBooks(userId);
				SessionManager.PutCurrentUserData<List<Publication>>(userId, SessionKeys.CurrentUserBooks, userBooks);
			}
			return userBooks;
		}

		public List<Publication> GetBooks()
		{
			Guid? currentUserId = this.GetCurrentUserId();
			List<Publication> publications = new List<Publication>();
			if (currentUserId.HasValue && currentUserId.Value != Guid.Empty)
			{
				publications = this.GetBooks(currentUserId.Value);
			}
			return publications;
		}

		public Guid? GetCurrentUserId()
		{
			Guid? currentUserId;
			if (!SessionManager.GetCurrentUserId(out currentUserId))
			{
				currentUserId = this._client.GetCurrentUserId();
				SessionManager.PutCurrentUserId(currentUserId);
			}
			return currentUserId;
		}

		public Account GetShortedAccount(Guid userId)
		{
			Account shortedAccountById;
			if (!SessionManager.GetCurrentUserData<Account>(userId, SessionKeys.CurrentShortedAccount, out shortedAccountById))
			{
				shortedAccountById = this._client.GetShortedAccountById(userId);
				SessionManager.PutCurrentUserData<Account>(userId, SessionKeys.CurrentShortedAccount, shortedAccountById);
			}
			return shortedAccountById;
		}

		public Account GetShortedAccount()
		{
			Guid? currentUserId = this.GetCurrentUserId();
			Account shortedAccount = null;
			if (currentUserId.HasValue && currentUserId.Value != Guid.Empty)
			{
				shortedAccount = this.GetShortedAccount(currentUserId.Value);
			}
			return shortedAccount;
		}

		public bool IsUserInRole(Guid userId, UmsRoles roleName)
		{
			UmsRoles umsRole;
			if (SessionManager.GetCurrentUserData<UmsRoles>(userId, SessionKeys.CurrentUserRole, out umsRole))
			{
				return roleName.Equals(umsRole);
			}
			bool flag = this._client.IsUserInRole(userId, roleName);
			if (flag)
			{
				SessionManager.PutCurrentUserData<UmsRoles>(userId, SessionKeys.CurrentUserRole, roleName);
			}
			return flag;
		}

		public bool IsUserInRole(UmsRoles roleName)
		{
			Guid? currentUserId = this.GetCurrentUserId();
			bool flag = false;
			if (currentUserId.HasValue && currentUserId.Value != Guid.Empty)
			{
				flag = this.IsUserInRole(currentUserId.Value, roleName);
			}
			return flag;
		}

		public void LogOff()
		{
			this._client.LogOff();
			SessionManager.RemoveDataFromSession(new SessionKeys[] { SessionKeys.CurrentUserId, SessionKeys.CurrentUserRole, SessionKeys.CurrentUserBooks, SessionKeys.CurrentShortedAccount });
		}

		public Account LogOn(string username, string password, bool rememberMe)
		{
			return this._client.LogOn(username, password, rememberMe);
		}
	}
}