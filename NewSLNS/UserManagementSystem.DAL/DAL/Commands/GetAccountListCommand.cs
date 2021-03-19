using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using UserManagementSystem.DAL;
using UserManagementSystem.Entities;

namespace UserManagementSystem.DAL.Commands
{
	internal class GetAccountListCommand : BaseCommand<List<Account>>
	{
		private readonly Guid _userId;

		private readonly int _pageSize;

		private readonly int _pageIndex;

		private readonly bool _isAdmin;

		private readonly string _subnameFilter;

		private readonly string _subEmailFilter;

		private readonly SortOrder _nameOrder;

		private readonly SortOrder _emailOrder;

		private readonly CheckFilter _leadFilter;

		private readonly CheckFilter _notificationFilter;

		public int TotalCount
		{
			get;
			private set;
		}

		public GetAccountListCommand(Guid userId, int pageSize, int pageIndex, bool isAdmin, string subnameFilter, string subEmailFilter, SortOrder nameOrder, SortOrder emailOrder, CheckFilter leadFilter, CheckFilter notificationFilter)
		{
			this._userId = userId;
			this._pageSize = pageSize;
			this._pageIndex = pageIndex;
			this._isAdmin = isAdmin;
			this._subnameFilter = subnameFilter;
			this._subEmailFilter = subEmailFilter;
			this._nameOrder = nameOrder;
			this._emailOrder = emailOrder;
			this._leadFilter = leadFilter;
			this._notificationFilter = notificationFilter;
		}

		protected override void CommandBody(UMSEntities context)
		{
			List<User> list = (this._isAdmin ? context.Users.ToList<User>() : (
				from u in context.Users
				where u.UserToBooks.Any<UserToBook>((UserToBook utb) => utb.UserId == this._userId)
				select u).ToList<User>());
			list.RemoveAll((User u) => u.UserId == this._userId);
			if (!string.IsNullOrWhiteSpace(this._subnameFilter))
			{
				string lower = this._subnameFilter.Trim().ToLower();
				list = (
					from u in list
					where string.Format("{0} {1}", u.FirstName, u.LastName).ToLower().Contains(lower)
					select u).ToList<User>();
			}
			if (!string.IsNullOrWhiteSpace(this._subEmailFilter))
			{
				string str = this._subEmailFilter.Trim().ToLower();
				list = (
					from u in list
					where u.PrimaryEmail.ToLower().Contains(str)
					select u).ToList<User>();
			}
			if (this._leadFilter != CheckFilter.Any)
			{
				list = (this._leadFilter == CheckFilter.Checked ? (
					from u in list
					where u.HasLeadsNotifications
					select u).ToList<User>() : (
					from u in list
					where !u.HasLeadsNotifications
					select u).ToList<User>());
			}
			if (this._notificationFilter != CheckFilter.Any)
			{
				list = (this._notificationFilter == CheckFilter.Checked ? (
					from u in list
					where u.HasNotifications
					select u).ToList<User>() : (
					from u in list
					where !u.HasNotifications
					select u).ToList<User>());
			}
			this.TotalCount = list.Count<User>();
			if (this._nameOrder != SortOrder.Unsorted)
			{
				list = (this._nameOrder == SortOrder.Ascending ? (
					from u in list
					orderby string.Format("{0} {1}", u.FirstName, u.LastName)
					select u).ToList<User>() : (
					from u in list
					orderby string.Format("{0} {1}", u.FirstName, u.LastName) descending
					select u).ToList<User>());
			}
			if (this._emailOrder != SortOrder.Unsorted)
			{
				list = (this._emailOrder == SortOrder.Ascending ? (
					from u in list
					orderby u.PrimaryEmail
					select u).ToList<User>() : (
					from u in list
					orderby u.PrimaryEmail descending
					select u).ToList<User>());
			}
			list = list.Skip<User>(this._pageSize * (this._pageIndex - 1)).Take<User>(this._pageSize).ToList<User>();
			List<Account> accounts = new List<Account>();
			foreach (User user in list)
			{
				Account account = new Account()
				{
					Id = user.UserId,
					FirstName = user.FirstName,
					LastName = user.LastName,
					PrimaryEmail = user.PrimaryEmail,
					CommunicationSettings = new CommunicationSettings(user.HasLeadsNotifications, user.HasNotifications),
					CreateUserId = user.CreateUserId,
					CreateDate = user.CreateDate,
					ModifyUserId = user.ModifyUserId,
					ModifyDate = user.ModifyDate
				};
				accounts.Add(account);
			}
			this.CommandResult = accounts;
		}
	}
}