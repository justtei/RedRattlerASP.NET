using MSLivingChoices.Entities.Admin;
using MSLivingChoices.Entities.Admin.Enums;
using System;
using System.Collections.Generic;

namespace MSLivingChoices.IDacs.Admin.Components
{
	public interface ICommunityDac
	{
		void ChangeListingTypeState(long communityId, ListingType listingType, bool value);

		void ChangePackageType(long communityId, PackageType packageType);

		void ChangePublishDates(long communityId, DateTime? startDate, DateTime? endDate, int publishTypeId);

		void ChangeSeniorHousingAndCareCategories(long communityId, List<long> seniorHousingAndCareCategoryIds);

		void ChangeShowcaseDates(long communityId, DateTime? startDate, DateTime? endDate, int showcaseTypeId);

		void Delete(long id);

		List<Community> GetAll(List<Book> books, int? pageNumber, int? pageSize, CommunityGridSortByOption? sortBy, OrderBy? orderBy, CommunityGridFilter filter, out int totalCount);

		Community GetById(long id);

		Tuple<List<Phone>, List<CallTrackingPhone>> GetCommunityPhones(long communityId);

		bool IsUsersCommunity(List<Book> books, long communityId);

		Community SaveEditedCommunity(Community community, int publishTypeId, int showcaseTypeId, int couponTypeId, int customCommunityServiceId);

		Community SaveNewCommunity(Community community, int publishTypeId, int showcaseTypeId, int couponTypeId, int customCommunityServiceTypeId);
	}
}