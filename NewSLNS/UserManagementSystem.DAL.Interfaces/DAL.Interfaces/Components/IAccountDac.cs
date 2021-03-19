using System;
using System.Collections.Generic;
using UserManagementSystem.Entities;

namespace UserManagementSystem.DAL.Interfaces.Components
{
	public interface IAccountDac
	{
		void ChangePrimaryEmail(string oldPrimaryEmail, string newPrimaryEmail);

		void Delete(Guid id);

		List<Account> GetAllUsers(Guid userId, int pageSize, int pageIndex, bool isAdmin, string subnameFilter, string subEmailFilter, SortOrder nameOrder, SortOrder emailOrder, CheckFilter leadFilter, CheckFilter notificationFilter, out int totalCount);

		Account GetById(Guid id);

		List<EmailType> GetEmailTypes();

		List<PhoneType> GetPhoneTypes();

		Account GetShortenedAccountById(Guid id);

		Guid Save(Account entity);

		void SetLeads(Guid userId, bool leads);

		void SetNotifications(Guid userId, bool notifications);
	}
}