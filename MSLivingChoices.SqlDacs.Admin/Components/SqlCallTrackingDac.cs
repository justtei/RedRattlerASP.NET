using MSLivingChoices.Configuration;
using MSLivingChoices.Entities.Admin;
using MSLivingChoices.IDacs.Admin.Components;
using MSLivingChoices.SqlDacs.Admin.SqlCommands;
using MSLivingChoices.SqlDacs.SqlCommands;
using System;
using System.Collections.Generic;

namespace MSLivingChoices.SqlDacs.Admin.Components
{
	public class SqlCallTrackingDac : ICallTrackingDac
	{
		public SqlCallTrackingDac()
		{
		}

		public void DeleteCallTrackingPhones(Guid userId, List<CallTrackingPhone> phones)
		{
			(new DeleteCallTrackingPhonesCommand(userId, phones)).Execute();
		}

		public void DisconnectCallTrackingPhones(Guid userId, List<CallTrackingPhone> phones)
		{
			(new DisconnectCallTrackingPhonesCommand(userId, phones)).Execute();
		}

		public List<CallTrackingPhone> GetAll(List<Book> books)
		{
			GetAllCallTrackingPhonesCommand getAllCallTrackingPhonesCommand = new GetAllCallTrackingPhonesCommand(books);
			getAllCallTrackingPhonesCommand.Execute();
			return getAllCallTrackingPhonesCommand.CommandResult;
		}

		public List<CallTrackingPhone> GetAll(List<Book> books, int? pageNumber, int? pageSize, out int totalCount)
		{
			pageNumber = pageNumber ?? ConfigurationManager.Instance.DefaultGridPageNumber;
			pageSize = pageSize ?? ConfigurationManager.Instance.DefaultGridPageSize;
			GetCallTrackingGridCommand command = new GetCallTrackingGridCommand(books, pageNumber, pageSize);
			command.Execute();
			totalCount = command.GetTotalCount();
			return command.CommandResult;
		}

		public void SaveCallTrackingPhones(long communityId, List<CallTrackingPhone> phones)
		{
			(new SaveCallTrackingPhonesCommand(communityId, phones)).Execute();
		}

		public void SaveCallTrackingPhones(Community community)
		{
			(new SaveCallTrackingPhonesCommand(community)).Execute();
		}

		public void SaveCallTrackingPhones(ServiceProvider serviceProvider)
		{
			(new SaveCallTrackingPhonesCommand(serviceProvider)).Execute();
		}

		public void ValidateCallTrackingPhones(Guid userId)
		{
			(new ValidateCallTrackingPhonesCommand(userId)).Execute();
		}
	}
}