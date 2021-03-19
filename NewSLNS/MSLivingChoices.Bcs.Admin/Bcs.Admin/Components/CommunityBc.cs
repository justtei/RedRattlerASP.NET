using MSLivingChoices.Bcs.Admin;
using MSLivingChoices.Entities.Admin;
using MSLivingChoices.Entities.Admin.Enums;
using MSLivingChoices.IDacs.Admin;
using MSLivingChoices.IDacs.Admin.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UserManagementSystem.Shared.Entities;
using UserManagementSystem.Shared.Entities.Enum;

namespace MSLivingChoices.Bcs.Admin.Components
{
	public class CommunityBc
	{
		private readonly ICommunityDac _communityDac;

		private static CommunityBc _communityBc;

		private readonly static object Locker;

		public static CommunityBc Instance
		{
			get
			{
				if (CommunityBc._communityBc == null)
				{
					lock (CommunityBc.Locker)
					{
						if (CommunityBc._communityBc == null)
						{
							CommunityBc._communityBc = new CommunityBc();
						}
					}
				}
				return CommunityBc._communityBc;
			}
		}

		static CommunityBc()
		{
			CommunityBc.Locker = new object();
		}

		private CommunityBc()
		{
			this._communityDac = AdminDacFactoryClient.GetConcreteFactory().GetCommunityDac();
		}

		public void ChangeListingTypeState(long communityId, ListingType listingType, bool value)
		{
			this._communityDac.ChangeListingTypeState(communityId, listingType, value);
		}

		public void ChangePackageType(long communityId, PackageType packageType)
		{
			this._communityDac.ChangePackageType(communityId, packageType);
		}

		public void ChangePublishDates(long communityId, DateTime? startDate, DateTime? endDate)
		{
			ICommunityDac communityDac = this._communityDac;
			KeyValuePair<int, string> publishType = ItemTypeBc.Instance.GetPublishType();
			communityDac.ChangePublishDates(communityId, startDate, endDate, publishType.Key);
		}

		public void ChangeSeniorHousingAndCareCategories(long communityId, List<long> seniorHousingAndCareCategoryIds)
		{
			this._communityDac.ChangeListingTypeState(communityId, ListingType.SeniorHousingAndCare, seniorHousingAndCareCategoryIds.Any<long>());
			this._communityDac.ChangeSeniorHousingAndCareCategories(communityId, seniorHousingAndCareCategoryIds);
		}

		public void ChangeShowcaseDates(long communityId, DateTime? startDate, DateTime? endDate)
		{
			ICommunityDac communityDac = this._communityDac;
			KeyValuePair<int, string> showcaseType = ItemTypeBc.Instance.GetShowcaseType();
			communityDac.ChangeShowcaseDates(communityId, startDate, endDate, showcaseType.Key);
		}

		public void Delete(long id)
		{
			this._communityDac.Delete(id);
		}

		public List<Community> GetAll(int? pageNumber, int? pageSize, CommunityGridSortByOption? sortBy, OrderBy? orderBy, CommunityGridFilter filter, out int totalCount)
		{
			List<Book> books = new List<Book>();
			if (!AccountBc.Instance.IsUserInRole(UmsRoles.Admin))
			{
				books = AccountBc.Instance.GetBooks().ConvertAll<Book>((Publication p) => new Book()
				{
					Id = new long?((long)p.Id)
				});
			}
			else
			{
				books.Add(new Book()
				{
					Id = new long?((long)-1)
				});
			}
			return this._communityDac.GetAll(books, pageNumber, pageSize, sortBy, orderBy, filter, out totalCount);
		}

		public Community GetById(long id)
		{
			return this._communityDac.GetById(id);
		}

		public Tuple<List<MSLivingChoices.Entities.Admin.Phone>, List<CallTrackingPhone>> GetCommunityPhones(long communityId)
		{
			return this._communityDac.GetCommunityPhones(communityId);
		}

		public List<FloorPlan> GetFloorPlans(long communityId)
		{
			Community byId = this._communityDac.GetById(communityId);
			List<FloorPlan> floorPlans = new List<FloorPlan>();
			if (byId.FloorPlans != null)
			{
				floorPlans = byId.FloorPlans;
			}
			return floorPlans;
		}

		public List<House> GetHomes(long communityId)
		{
			Community byId = this._communityDac.GetById(communityId);
			List<House> houses = new List<House>();
			if (byId.Houses != null)
			{
				houses = byId.Houses;
			}
			return houses;
		}

		public List<SpecHome> GetSpecHomes(long communityId)
		{
			Community byId = this._communityDac.GetById(communityId);
			List<SpecHome> specHomes = new List<SpecHome>();
			if (byId.SpecHomes != null)
			{
				specHomes = byId.SpecHomes;
			}
			return specHomes;
		}

		public bool IsUsersCommunity(IEnumerable<Publication> publications, long communityId)
		{
			List<Book> list = (
				from p in publications
				select new Book()
				{
					Id = new long?((long)p.Id)
				}).ToList<Book>();
			return this._communityDac.IsUsersCommunity(list, communityId);
		}

		public bool IsUsersCommunity(long communityId)
		{
			Guid? currentUserId = AccountBc.Instance.GetCurrentUserId();
			if (currentUserId.HasValue && this.IsUsersCommunity(AccountBc.Instance.GetBooks(currentUserId.Value), communityId))
			{
				return true;
			}
			return false;
		}

		public Community SaveEditedCommunity(Community community)
		{
			Guid? currentUserId = AccountBc.Instance.GetCurrentUserId();
			if (currentUserId.HasValue)
			{
				community.UserId = new Guid?(currentUserId.Value);
			}
			KeyValuePair<int, string> publishType = ItemTypeBc.Instance.GetPublishType();
			int key = publishType.Key;
			publishType = ItemTypeBc.Instance.GetShowcaseType();
			int num = publishType.Key;
			publishType = ItemTypeBc.Instance.GetCouponType();
			int key1 = publishType.Key;
			publishType = ItemTypeBc.Instance.GetCustomCommunityServiceType();
			int num1 = publishType.Key;
			Community community1 = this._communityDac.SaveEditedCommunity(community, key, num, key1, num1);
			if (community.CallTrackingPhones.Any<CallTrackingPhone>())
			{
				community1 = CallTrackingBc.Instance.ProvisionPhones(community1);
				CallTrackingBc.Instance.SaveCallTrackingPhones(community1);
			}
			ImageBc.Instance.ProcessCommunityImages(community1.Id.Value);
			return community1;
		}

		public Community SaveNewCommunity(Community community)
		{
			Guid? currentUserId = AccountBc.Instance.GetCurrentUserId();
			if (currentUserId.HasValue)
			{
				community.UserId = new Guid?(currentUserId.Value);
			}
			KeyValuePair<int, string> publishType = ItemTypeBc.Instance.GetPublishType();
			int key = publishType.Key;
			publishType = ItemTypeBc.Instance.GetShowcaseType();
			int num = publishType.Key;
			publishType = ItemTypeBc.Instance.GetCouponType();
			int key1 = publishType.Key;
			publishType = ItemTypeBc.Instance.GetCustomCommunityServiceType();
			int num1 = publishType.Key;
			Community community1 = this._communityDac.SaveNewCommunity(community, key, num, key1, num1);
			if (community1.CallTrackingPhones.Any<CallTrackingPhone>())
			{
				community1 = CallTrackingBc.Instance.ProvisionPhones(community1);
				CallTrackingBc.Instance.SaveCallTrackingPhones(community1);
			}
			ImageBc.Instance.ProcessCommunityImages(community1.Id.Value);
			return community1;
		}
	}
}