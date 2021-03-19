using MSLivingChoices.Entities.Admin;
using MSLivingChoices.Entities.Admin.Enums;
using MSLivingChoices.SqlDacs.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.SqlDacs.Admin.Helpers
{
	internal static class AdditionalInfoHelper
	{
		public static PackageType GetCommunityPackage(this IEnumerable<AdditionalInfo> items)
		{
			AdditionalInfo result = items.GetInfosByClass(AdditionalInfoClass.Package).FirstOrDefault<AdditionalInfo>();
			if (result == null || !result.AdditionalInfoTypeId.HasValue)
			{
				return 0;
			}
			return (PackageType)result.AdditionalInfoTypeId.Value;
		}

		public static List<long> GetCommunityPaymentTypes(this IEnumerable<AdditionalInfo> items)
		{
			List<long> paymentTypeIds = new List<long>();
			foreach (AdditionalInfo item in items.GetInfosByClass(AdditionalInfoClass.Payment))
			{
				if (!item.AdditionalInfoTypeId.HasValue)
				{
					continue;
				}
				paymentTypeIds.Add((long)item.AdditionalInfoTypeId.Value);
			}
			return paymentTypeIds;
		}

		public static List<long> GetCommunitySeniorHousingAndCareCategoryIds(this IEnumerable<AdditionalInfo> items)
		{
			List<long> seniorHousingAndCareCategoryIds = new List<long>();
			foreach (AdditionalInfo item in items.GetInfosByClass(AdditionalInfoClass.SeniorHousingAndCareCategory))
			{
				if (!item.AdditionalInfoTypeId.HasValue)
				{
					continue;
				}
				seniorHousingAndCareCategoryIds.Add((long)item.AdditionalInfoTypeId.Value);
			}
			return seniorHousingAndCareCategoryIds;
		}

		public static Coupon GetCoupon(this IEnumerable<AdditionalInfo> items)
		{
			AdditionalInfo result = items.GetInfosByClass(AdditionalInfoClass.Coupon).FirstOrDefault<AdditionalInfo>();
			Coupon coupon = null;
			if (result != null)
			{
				coupon = new Coupon()
				{
					Id = result.Id,
					PublishDate = result.StartDate,
					ExpirationDate = result.EndDate,
					Name = result.ShortText,
					Description = result.LongText
				};
			}
			return coupon;
		}

		public static DateTimeBoundary<bool> GetFeature(this IEnumerable<AdditionalInfo> items)
		{
			!0 valueOrDefault;
			AdditionalInfo result = items.GetInfosByClass(AdditionalInfoClass.Feature).FirstOrDefault<AdditionalInfo>();
			DateTimeBoundary<bool> feature = new DateTimeBoundary<bool>();
			if (result != null)
			{
				feature.Id = result.Id;
				feature.StartDate = result.StartDate;
				feature.EndDate = result.EndDate;
				DateTimeBoundary<bool> dateTimeBoundary = feature;
				DateTime now = DateTime.Now;
				DateTime? startDate = result.StartDate;
				if ((startDate.HasValue ? now < startDate.GetValueOrDefault() : true))
				{
					valueOrDefault = 0;
				}
				else
				{
					now = DateTime.Now;
					startDate = result.EndDate;
					if (startDate.HasValue)
					{
						valueOrDefault = now <= startDate.GetValueOrDefault();
					}
					else
					{
						valueOrDefault = 0;
					}
				}
				dateTimeBoundary.Status = valueOrDefault;
			}
			return feature;
		}

		public static IEnumerable<AdditionalInfo> GetInfosByClass(this IEnumerable<AdditionalInfo> items, AdditionalInfoClass infoClass)
		{
			return 
				from x in items
				where x.AdditionalInfoClass == infoClass
				orderby x.Sequence
				select x;
		}

		public static List<KeyValuePair<long, PackageType>> GetPackages(this IEnumerable<AdditionalInfo> items)
		{
			IEnumerable<AdditionalInfo> result = items.GetInfosByClass(AdditionalInfoClass.Package);
			List<KeyValuePair<long, PackageType>> list = new List<KeyValuePair<long, PackageType>>();
			if (result.Any<AdditionalInfo>())
			{
				foreach (AdditionalInfo item in result)
				{
					if (!item.CommunityId.HasValue)
					{
						continue;
					}
					list.Add(new KeyValuePair<long, PackageType>(item.CommunityId.Value, (item.AdditionalInfoTypeId.HasValue ? item.AdditionalInfoTypeId.Value : 0)));
				}
			}
			return list;
		}

		public static DateTimeBoundary<PublishingStatus> GetPublishing(this IEnumerable<AdditionalInfo> items)
		{
			AdditionalInfo result = items.GetInfosByClass(AdditionalInfoClass.Publish).FirstOrDefault<AdditionalInfo>();
			DateTimeBoundary<PublishingStatus> publishing = new DateTimeBoundary<PublishingStatus>();
			if (result != null && result.AdditionalInfoTypeId.HasValue)
			{
				publishing.Status = result.AdditionalInfoTypeId.Value;
				publishing.StartDate = result.StartDate;
				publishing.EndDate = result.EndDate;
			}
			return publishing;
		}

		public static List<KeyValuePair<long, string>> GetServiceCategories(this IEnumerable<AdditionalInfo> items)
		{
			List<KeyValuePair<long, string>> serviceCategories = new List<KeyValuePair<long, string>>();
			foreach (AdditionalInfo item in items.GetInfosByClass(AdditionalInfoClass.SeniorHousingAndCareCategoryService))
			{
				if (!item.AdditionalInfoTypeId.HasValue)
				{
					continue;
				}
				int? additionalInfoTypeId = item.AdditionalInfoTypeId;
				serviceCategories.Add(new KeyValuePair<long, string>((long)additionalInfoTypeId.Value, item.Description));
			}
			return serviceCategories;
		}

		public static PackageType GetServicePackage(this IEnumerable<AdditionalInfo> items)
		{
			AdditionalInfo result = items.GetInfosByClass(AdditionalInfoClass.PackageService).FirstOrDefault<AdditionalInfo>();
			if (result == null || !result.AdditionalInfoTypeId.HasValue)
			{
				return 0;
			}
			return (PackageType)result.AdditionalInfoTypeId.Value;
		}

		public static List<long> GetServicePaymentTypes(this IEnumerable<AdditionalInfo> items)
		{
			List<long> paymentTypeIds = new List<long>();
			foreach (AdditionalInfo item in items.GetInfosByClass(AdditionalInfoClass.PaymentService))
			{
				if (!item.AdditionalInfoTypeId.HasValue)
				{
					continue;
				}
				paymentTypeIds.Add((long)item.AdditionalInfoTypeId.Value);
			}
			return paymentTypeIds;
		}

		public static List<CommunityService> GetServices(this IEnumerable<AdditionalInfo> items)
		{
			Dictionary<long, string> defaultServices = new Dictionary<long, string>();
			foreach (KeyValuePair<int, string> item in DefaultItemsProvider.Instance.DefaultServiceTypes())
			{
				defaultServices.Add((long)item.Key, item.Value);
			}
			List<CommunityService> communityServices = new List<CommunityService>();
			foreach (AdditionalInfo item in items.GetInfosByClass(AdditionalInfoClass.Service))
			{
				CommunityService service = new CommunityService();
				int? additionalInfoTypeId = item.AdditionalInfoTypeId;
				service.AdditionInfoTypeId = new int?(additionalInfoTypeId.Value);
				if (!string.IsNullOrEmpty(item.ShortText))
				{
					service.Name = item.ShortText;
				}
				else if (defaultServices.ContainsKey((long)service.AdditionInfoTypeId.Value))
				{
					additionalInfoTypeId = service.AdditionInfoTypeId;
					service.Name = defaultServices[(long)additionalInfoTypeId.Value];
				}
				communityServices.Add(service);
			}
			return communityServices;
		}

		public static DateTimeBoundary GetShowcase(this IEnumerable<AdditionalInfo> items)
		{
			AdditionalInfo result = items.GetInfosByClass(AdditionalInfoClass.Showcase).FirstOrDefault<AdditionalInfo>();
			DateTimeBoundary showcase = new DateTimeBoundary();
			if (result != null)
			{
				showcase.Id = result.Id;
				showcase.StartDate = result.StartDate;
				showcase.EndDate = result.EndDate;
			}
			return showcase;
		}
	}
}