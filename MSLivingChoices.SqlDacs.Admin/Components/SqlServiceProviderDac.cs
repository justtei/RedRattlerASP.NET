using MSLivingChoices.Configuration;
using MSLivingChoices.Entities.Admin;
using MSLivingChoices.Entities.Admin.Enums;
using MSLivingChoices.IDacs.Admin.Components;
using MSLivingChoices.SqlDacs.Admin;
using MSLivingChoices.SqlDacs.Admin.SqlCommands;
using MSLivingChoices.SqlDacs.SqlCommands;
using System;
using System.Collections.Generic;

namespace MSLivingChoices.SqlDacs.Admin.Components
{
	public class SqlServiceProviderDac : IServiceProviderDac
	{
		public ServiceProvider SaveNewServiceProvider(ServiceProvider serviceProvider, int featureTypeId, int publishTypeId, int couponTypeId)
		{
			SaveNewServiceProviderCommand saveNewServiceProviderCommand = new SaveNewServiceProviderCommand(serviceProvider, featureTypeId, publishTypeId, couponTypeId);
			saveNewServiceProviderCommand.Execute();
			return saveNewServiceProviderCommand.CommandResult;
		}

		public ServiceProvider SaveEditedServiceProvider(ServiceProvider serviceProvider, int featureTypeId, int publishTypeId, int couponTypeId)
		{
			SaveServiceProviderCommand saveServiceProviderCommand = new SaveServiceProviderCommand(serviceProvider, featureTypeId, publishTypeId, couponTypeId);
			saveServiceProviderCommand.Execute();
			return saveServiceProviderCommand.CommandResult;
		}

		public List<ServiceProvider> GetAll(List<Book> books, int? pageNumber, int? pageSize, ServiceProviderGridSortByOption? sortBy, OrderBy? orderBy, ServiceProviderGridFilter filter, out int totalCount)
		{
			pageNumber = pageNumber ?? ConfigurationManager.Instance.DefaultGridPageNumber;
			pageSize = pageSize ?? ConfigurationManager.Instance.DefaultGridPageSize;
			GetServiceProviderGridCommand command = new GetServiceProviderGridCommand(books, pageNumber, pageSize, sortBy, orderBy, filter);
			command.Execute();
			totalCount = command.GetTotalCount();
			return command.CommandResult;
		}

		public void ChangePackageType(long serviceProviderId, PackageType packageType)
		{
			new ChangePackageTypeForServiceProviderCommand(serviceProviderId, packageType).Execute();
		}

		public void ChangeServiceCategories(long serviceProviderId, List<long> serviceCategoriesIds)
		{
			new ChangeServiceCategoriesCommand(serviceProviderId, serviceCategoriesIds).Execute();
		}

		public void ChangeFeatureDates(long serviceProviderId, DateTime? startDate, DateTime? endDate, int featureTypeId)
		{
			new ChangeFeatureDatesCommand(serviceProviderId, startDate, endDate, featureTypeId).Execute();
		}

		public void ChangePublishDates(long serviceProviderId, DateTime? startDate, DateTime? endDate, int publishTypeId)
		{
			new ChangePublishDatesForServiceProviderCommand(serviceProviderId, startDate, endDate, publishTypeId).Execute();
		}

		public ServiceProvider GetById(long id)
		{
			GetServiceProviderByIdCommand getServiceProviderByIdCommand = new GetServiceProviderByIdCommand(id);
			getServiceProviderByIdCommand.Execute();
			return getServiceProviderByIdCommand.CommandResult;
		}

		public bool IsUsersService(List<Book> books, long serviceId)
		{
			IsUsersServiceCommand isUsersServiceCommand = new IsUsersServiceCommand(books, serviceId);
			isUsersServiceCommand.Execute();
			return isUsersServiceCommand.CommandResult.Value;
		}

		public List<County> GetCountiesServedById(long id)
		{
			GetCountiesServedByIdCommand getCountiesServedByIdCommand = new GetCountiesServedByIdCommand(id);
			getCountiesServedByIdCommand.Execute();
			return getCountiesServedByIdCommand.CommandResult;
		}
	}

}