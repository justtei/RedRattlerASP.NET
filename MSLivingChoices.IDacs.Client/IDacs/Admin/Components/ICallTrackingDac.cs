using MSLivingChoices.Entities.Admin;
using System;
using System.Collections.Generic;

namespace MSLivingChoices.IDacs.Admin.Components
{
	public interface ICallTrackingDac
	{
		void DeleteCallTrackingPhones(Guid userId, List<CallTrackingPhone> phones);

		void DisconnectCallTrackingPhones(Guid userId, List<CallTrackingPhone> phones);

		List<CallTrackingPhone> GetAll(List<Book> books);

		List<CallTrackingPhone> GetAll(List<Book> books, int? pageNumber, int? pageSize, out int totalCount);

		void SaveCallTrackingPhones(long communityId, List<CallTrackingPhone> phones);

		void SaveCallTrackingPhones(Community community);

		void SaveCallTrackingPhones(ServiceProvider serviceProvider);

		void ValidateCallTrackingPhones(Guid userId);
	}
}