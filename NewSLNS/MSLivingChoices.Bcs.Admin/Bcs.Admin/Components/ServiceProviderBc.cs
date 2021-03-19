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
	public class ServiceProviderBc
	{
		private readonly IServiceProviderDac _serviceProviderDac;

		private static ServiceProviderBc _serviceProviderBc;

		private readonly static object Locker;

		public static ServiceProviderBc Instance
		{
			get
			{
				if (ServiceProviderBc._serviceProviderBc == null)
				{
					lock (ServiceProviderBc.Locker)
					{
						if (ServiceProviderBc._serviceProviderBc == null)
						{
							ServiceProviderBc._serviceProviderBc = new ServiceProviderBc();
						}
					}
				}
				return ServiceProviderBc._serviceProviderBc;
			}
		}

		static ServiceProviderBc()
		{
			ServiceProviderBc.Locker = new object();
		}

		private ServiceProviderBc()
		{
			this._serviceProviderDac = AdminDacFactoryClient.GetConcreteFactory().GetServiceProviderDac();
		}

		public void ChangeFeatureDates(long serviceProviderId, DateTime? startDate, DateTime? endDate)
		{
			IServiceProviderDac serviceProviderDac = this._serviceProviderDac;
			KeyValuePair<int, string> featureType = ItemTypeBc.Instance.GetFeatureType();
			serviceProviderDac.ChangeFeatureDates(serviceProviderId, startDate, endDate, featureType.Key);
		}

		public void ChangePackageType(long serviceProviderId, PackageType packageType)
		{
			this._serviceProviderDac.ChangePackageType(serviceProviderId, packageType);
		}

		public void ChangePublishDates(long serviceProviderId, DateTime? startDate, DateTime? endDate)
		{
			IServiceProviderDac serviceProviderDac = this._serviceProviderDac;
			KeyValuePair<int, string> publishType = ItemTypeBc.Instance.GetPublishType();
			serviceProviderDac.ChangePublishDates(serviceProviderId, startDate, endDate, publishType.Key);
		}

		public void ChangeServiceCategories(long serviceProviderId, List<long> srviceCategoriesIds)
		{
			this._serviceProviderDac.ChangeServiceCategories(serviceProviderId, srviceCategoriesIds);
		}

		public List<ServiceProvider> GetAll(int? pageNumber, int? pageSize, ServiceProviderGridSortByOption? sortBy, OrderBy? orderBy, ServiceProviderGridFilter filter, out int totalCount)
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
			return this._serviceProviderDac.GetAll(books, pageNumber, pageSize, sortBy, orderBy, filter, out totalCount);
		}

		public virtual ServiceProvider GetById(long id)
		{
			ServiceProvider byId = this._serviceProviderDac.GetById(id);
			this.RestoreServiceProviderCallTrackingPhoneTypes(byId.CallTrackingPhones);
			return byId;
		}

		public List<County> GetCountiesServedById(long serviceId)
		{
			return this._serviceProviderDac.GetCountiesServedById(serviceId);
		}

		public bool IsUsersService(IEnumerable<Publication> publications, long serviceId)
		{
			List<Book> list = (
				from p in publications
				select new Book()
				{
					Id = new long?((long)p.Id)
				}).ToList<Book>();
			return this._serviceProviderDac.IsUsersService(list, serviceId);
		}

		public bool IsUsersService(long serviceId)
		{
			Guid? currentUserId = AccountBc.Instance.GetCurrentUserId();
			if (currentUserId.HasValue && this.IsUsersService(AccountBc.Instance.GetBooks(currentUserId.Value), serviceId))
			{
				return true;
			}
			return false;
		}

		private void RestoreServiceProviderCallTrackingPhoneTypes(IEnumerable<CallTrackingPhone> phones)
		{
			foreach (CallTrackingPhone phone in phones)
			{
				switch (phone.PhoneType)
				{
					case 25:
					{
						phone.PhoneType = CallTrackingPhoneType.ProvisionOnline;
						continue;
					}
					case 26:
					{
						phone.PhoneType = CallTrackingPhoneType.ProvisionPrintAd;
						continue;
					}
					case CallTrackingPhoneType.ProvisionOnline | CallTrackingPhoneType.ProvisionOnlineAndPrintAd:
					{
						phone.PhoneType = CallTrackingPhoneType.ProvisionCampaign;
						continue;
					}
					default:
					{
						continue;
					}
				}
			}
		}

		public void SaveEditedServiceProvider(ServiceProvider serviceProvider)
		{
			this.SetUserId(serviceProvider);
			this.SetServiceProviderCallTrackingPhoneTypes(serviceProvider.CallTrackingPhones);
			KeyValuePair<int, string> featureType = ItemTypeBc.Instance.GetFeatureType();
			int key = featureType.Key;
			featureType = ItemTypeBc.Instance.GetPublishType();
			int num = featureType.Key;
			featureType = ItemTypeBc.Instance.GetCouponType();
			int key1 = featureType.Key;
			ServiceProvider serviceProvider1 = this._serviceProviderDac.SaveEditedServiceProvider(serviceProvider, key, num, key1);
			if (serviceProvider1.CallTrackingPhones.Any<CallTrackingPhone>())
			{
				serviceProvider1 = CallTrackingBc.Instance.ProvisionPhones(serviceProvider1);
				CallTrackingBc.Instance.SaveCallTrackingPhones(serviceProvider1);
			}
			ImageBc.Instance.ProcessImages(ImageOwner.Service, serviceProvider1.Id.Value);
		}

		public void SaveNewServiceProvider(ServiceProvider serviceProvider)
		{
			this.SetUserId(serviceProvider);
			this.SetServiceProviderCallTrackingPhoneTypes(serviceProvider.CallTrackingPhones);
			KeyValuePair<int, string> featureType = ItemTypeBc.Instance.GetFeatureType();
			int key = featureType.Key;
			featureType = ItemTypeBc.Instance.GetPublishType();
			int num = featureType.Key;
			featureType = ItemTypeBc.Instance.GetCouponType();
			int key1 = featureType.Key;
			ServiceProvider serviceProvider1 = this._serviceProviderDac.SaveNewServiceProvider(serviceProvider, key, num, key1);
			if (serviceProvider1.CallTrackingPhones.Any<CallTrackingPhone>())
			{
				serviceProvider1 = CallTrackingBc.Instance.ProvisionPhones(serviceProvider1);
				CallTrackingBc.Instance.SaveCallTrackingPhones(serviceProvider1);
			}
			ImageBc.Instance.ProcessImages(ImageOwner.Service, serviceProvider1.Id.Value);
		}

		private void SetServiceProviderCallTrackingPhoneTypes(IEnumerable<CallTrackingPhone> phones)
		{
			foreach (CallTrackingPhone phone in phones)
			{
				switch (phone.PhoneType)
				{
					case CallTrackingPhoneType.ProvisionOnline:
					{
						phone.PhoneType = (CallTrackingPhoneType)25;
						continue;
					}
					case CallTrackingPhoneType.ProvisionPrintAd:
					{
						phone.PhoneType = (CallTrackingPhoneType)26;
						continue;
					}
					case CallTrackingPhoneType.ProvisionCampaign:
					{
						phone.PhoneType = CallTrackingPhoneType.ProvisionOnline | CallTrackingPhoneType.ProvisionOnlineAndPrintAd;
						continue;
					}
					default:
					{
						continue;
					}
				}
			}
		}

		private void SetUserId(ServiceProvider serviceProvider)
		{
			Guid? currentUserId = AccountBc.Instance.GetCurrentUserId();
			if (currentUserId.HasValue)
			{
				serviceProvider.UserId = new Guid?(currentUserId.Value);
			}
		}
	}
}