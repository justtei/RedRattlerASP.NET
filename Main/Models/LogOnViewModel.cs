using System;
using System.Runtime.CompilerServices;
using UserManagementSystem.Business.Components;
using UserManagementSystem.Shared.Entities;

namespace UserManagementSystem.Web.Models
{
	public class LogOnViewModel
	{
		public string Username
		{
			get;
			set;
		}

		public LogOnViewModel()
		{
			Guid? currentUserId = AccountBc.Instance.GetCurrentUserId();
			Account shortenedAccountById = AccountBc.Instance.GetShortenedAccountById(currentUserId.Value);
			this.Username = string.Format("{0} {1}", shortenedAccountById.FirstName, shortenedAccountById.LastName);
		}
	}
}