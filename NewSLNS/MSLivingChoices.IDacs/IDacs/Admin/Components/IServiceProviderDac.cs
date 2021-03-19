using MSLivingChoices.Entities.Admin;
using MSLivingChoices.Entities.Admin.Enums;
using System;
using System.Collections.Generic;

namespace MSLivingChoices.IDacs.Admin.Components
{
	public interface IServiceProviderDac
	{
		void ChangeFeatureDates(long serviceProviderId, DateTime? startDate, DateTime? endDate, int featureTypeId);

		void ChangePackageType(long serviceProviderId, PackageType packageType);

		void ChangePublishDates(long serviceProviderId, DateTime? startDate, DateTime? endDate, int publishTypeId);

		void ChangeServiceCategories(long serviceProviderId, List<long> serviceCategoriesIds);

		List<ServiceProvider> GetAll(List<Book> books, int? pageNumber, int? pageSize, ServiceProviderGridSortByOption? sortBy, OrderBy? orderBy, ServiceProviderGridFilter filter, out int totalCount);

		ServiceProvider GetById(long id);

		List<County> GetCountiesServedById(long serviceId);

		bool IsUsersService(List<Book> books, long serviceId);

		ServiceProvider SaveEditedServiceProvider(ServiceProvider serviceProvider, int featureTypeId, int publishTypeId, int couponTypeId);

		ServiceProvider SaveNewServiceProvider(ServiceProvider serviceProvider, int featureTypeId, int publishTypeId, int couponTypeId);
	}
}