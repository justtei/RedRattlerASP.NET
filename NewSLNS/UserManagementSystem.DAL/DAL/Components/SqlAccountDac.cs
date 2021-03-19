using System;
using System.Collections.Generic;
using UserManagementSystem.DAL.Commands;
using UserManagementSystem.DAL.Interfaces.Components;
using UserManagementSystem.Entities;

namespace UserManagementSystem.DAL.Components
{
	public class SqlAccountDac : IAccountDac
	{
		public SqlAccountDac()
		{
		}

		public void ChangePrimaryEmail(string oldPrimaryEmail, string newPrimaryEmail)
		{
			(new GetChangePimaryEmailCommand(oldPrimaryEmail, newPrimaryEmail)).Execute();
		}

		public void Delete(Guid id)
		{
			(new DeleteUserCommand(id)).Execute();
		}

		public List<Account> GetAllUsers(Guid userId, int pageSize, int pageIndex, bool isAdmin, string subnameFilter, string subEmailFilter, SortOrder nameOrder, SortOrder emailOrder, CheckFilter leadFilter, CheckFilter notificationFilter, out int totalCount)
		{
			GetAccountListCommand getAccountListCommand = new GetAccountListCommand(userId, pageSize, pageIndex, isAdmin, subnameFilter, subEmailFilter, nameOrder, emailOrder, leadFilter, notificationFilter);
			getAccountListCommand.Execute();
			totalCount = getAccountListCommand.TotalCount;
			return getAccountListCommand.CommandResult;
		}

		public Account GetById(Guid id)
		{
			GetAccountCommand getAccountCommand = new GetAccountCommand(id);
			getAccountCommand.Execute();
			return getAccountCommand.CommandResult;
		}

		public List<UserManagementSystem.Entities.EmailType> GetEmailTypes()
		{
			GetEmailTypesCommand getEmailTypesCommand = new GetEmailTypesCommand();
			getEmailTypesCommand.Execute();
			return getEmailTypesCommand.CommandResult;
		}

		public List<UserManagementSystem.Entities.PhoneType> GetPhoneTypes()
		{
			GetPhoneTypesCommand getPhoneTypesCommand = new GetPhoneTypesCommand();
			getPhoneTypesCommand.Execute();
			return getPhoneTypesCommand.CommandResult;
		}

		public Account GetShortenedAccountById(Guid id)
		{
			GetShortenedAccountCommand getShortenedAccountCommand = new GetShortenedAccountCommand(id);
			getShortenedAccountCommand.Execute();
			return getShortenedAccountCommand.CommandResult;
		}

		public Guid Save(Account entity)
		{
			(new SaveAccountCommand(entity)).Execute();
			return entity.Id;
		}

		public void SetLeads(Guid userId, bool leads)
		{
			(new SetLeadsCommand(userId, leads)).Execute();
		}

		public void SetNotifications(Guid userId, bool notifications)
		{
			(new SetNotificationsCommand(userId, notifications)).Execute();
		}
	}
}