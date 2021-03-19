using MSLivingChoices.Bcs.Components;
using MSLivingChoices.Configuration;
using MSLivingChoices.Entities.Admin;
using MSLivingChoices.Entities.Admin.Enums;
using MSLivingChoices.Localization;
using MSLivingChoices.Mvc.Uipc.Admin.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Mvc.Uipc.Admin.Helpers
{
	public static class DisplayHelpers
	{
		public static string GetBathrooms(long? bathroomFromId, long? bathroomToId)
		{
			KeyValuePair<int, string> keyValuePair;
			string value;
			string str;
			List<KeyValuePair<int, string>> bathrooms = ItemTypeBc.Instance.GetBathrooms();
			if (bathroomFromId.HasValue)
			{
				keyValuePair = bathrooms.FirstOrDefault<KeyValuePair<int, string>>((KeyValuePair<int, string> m) => {
					long key = (long)m.Key;
					long? nullable = bathroomFromId;
					return key == nullable.GetValueOrDefault() & nullable.HasValue;
				});
				str = keyValuePair.Value;
			}
			else
			{
				str = null;
			}
			if (bathroomToId.HasValue)
			{
				keyValuePair = bathrooms.FirstOrDefault<KeyValuePair<int, string>>((KeyValuePair<int, string> m) => {
					long key = (long)m.Key;
					long? nullable = bathroomToId;
					return key == nullable.GetValueOrDefault() & nullable.HasValue;
				});
				value = keyValuePair.Value;
			}
			else
			{
				value = null;
			}
			return DisplayHelpers.GetRange(str, value);
		}

		public static string GetBathroomsForQuickView(long? bathroomFromId, long? bathroomToId)
		{
			List<KeyValuePair<int, string>> bathrooms = ItemTypeBc.Instance.GetBathrooms();
			string result = DisplayHelpers.GetBathroomsForQuickViewFloorPlans(bathroomFromId, bathroomToId);
			if (result != null)
			{
				if (!bathroomFromId.HasValue || !bathroomToId.HasValue)
				{
					result = ((!bathroomFromId.HasValue || !bathrooms.First<KeyValuePair<int, string>>((KeyValuePair<int, string> b) => {
						long key = (long)b.Key;
						long? nullable = bathroomFromId;
						return key == nullable.GetValueOrDefault() & nullable.HasValue;
					}).Value.Equals("1")) && (!bathroomToId.HasValue || !bathrooms.First<KeyValuePair<int, string>>((KeyValuePair<int, string> b) => {
						long key = (long)b.Key;
						long? nullable = bathroomToId;
						return key == nullable.GetValueOrDefault() & nullable.HasValue;
					}).Value.Equals("1")) ? string.Format("{0} {1}", result, StaticContent.Lbl_Bathrooms) : string.Format("{0} {1}", result, StaticContent.Lbl_Bathroom));
				}
				else
				{
					result = string.Format("{0} {1}", result, StaticContent.Lbl_Bathrooms);
				}
			}
			return result;
		}

		public static string GetBathroomsForQuickViewFloorPlans(long? bathroomFromId, long? bathroomToId)
		{
			KeyValuePair<int, string> keyValuePair;
			string value;
			string str;
			List<KeyValuePair<int, string>> bathrooms = ItemTypeBc.Instance.GetBathrooms();
			if (bathroomFromId.HasValue)
			{
				keyValuePair = bathrooms.FirstOrDefault<KeyValuePair<int, string>>((KeyValuePair<int, string> m) => {
					long key = (long)m.Key;
					long? nullable = bathroomFromId;
					return key == nullable.GetValueOrDefault() & nullable.HasValue;
				});
				str = keyValuePair.Value;
			}
			else
			{
				str = null;
			}
			if (bathroomToId.HasValue)
			{
				keyValuePair = bathrooms.FirstOrDefault<KeyValuePair<int, string>>((KeyValuePair<int, string> m) => {
					long key = (long)m.Key;
					long? nullable = bathroomToId;
					return key == nullable.GetValueOrDefault() & nullable.HasValue;
				});
				value = keyValuePair.Value;
			}
			else
			{
				value = null;
			}
			return DisplayHelpers.GetRangeForQuickView(str, value);
		}

		public static string GetBedrooms(long? bedroomFromId, long? bedroomToId)
		{
			KeyValuePair<int, string> keyValuePair;
			string value;
			string str;
			List<KeyValuePair<int, string>> bedrooms = ItemTypeBc.Instance.GetBedrooms();
			if (bedroomFromId.HasValue)
			{
				keyValuePair = bedrooms.FirstOrDefault<KeyValuePair<int, string>>((KeyValuePair<int, string> m) => {
					long key = (long)m.Key;
					long? nullable = bedroomFromId;
					return key == nullable.GetValueOrDefault() & nullable.HasValue;
				});
				str = keyValuePair.Value;
			}
			else
			{
				str = null;
			}
			if (bedroomToId.HasValue)
			{
				keyValuePair = bedrooms.FirstOrDefault<KeyValuePair<int, string>>((KeyValuePair<int, string> m) => {
					long key = (long)m.Key;
					long? nullable = bedroomToId;
					return key == nullable.GetValueOrDefault() & nullable.HasValue;
				});
				value = keyValuePair.Value;
			}
			else
			{
				value = null;
			}
			return DisplayHelpers.GetRange(str, value);
		}

		public static string GetBedroomsForQuickView(long? bedroomFromId, long? bedroomToId)
		{
			List<KeyValuePair<int, string>> bedrooms = ItemTypeBc.Instance.GetBedrooms();
			string result = DisplayHelpers.GetBedroomsForQuickViewFloorPlans(bedroomFromId, bedroomToId);
			if (result != null)
			{
				if (!bedroomFromId.HasValue || !bedroomToId.HasValue)
				{
					result = ((!bedroomFromId.HasValue || !bedrooms.First<KeyValuePair<int, string>>((KeyValuePair<int, string> b) => {
						long key = (long)b.Key;
						long? nullable = bedroomFromId;
						return key == nullable.GetValueOrDefault() & nullable.HasValue;
					}).Value.Equals("1")) && (!bedroomToId.HasValue || !bedrooms.First<KeyValuePair<int, string>>((KeyValuePair<int, string> b) => {
						long key = (long)b.Key;
						long? nullable = bedroomToId;
						return key == nullable.GetValueOrDefault() & nullable.HasValue;
					}).Value.Equals("1")) ? string.Format("{0} {1}", result, StaticContent.Lbl_Bedrooms) : string.Format("{0} {1}", result, StaticContent.Lbl_Bedroom));
				}
				else
				{
					result = string.Format("{0} {1}", result, StaticContent.Lbl_Bedrooms);
				}
			}
			return result;
		}

		public static string GetBedroomsForQuickViewFloorPlans(long? bedroomFromId, long? bedroomToId)
		{
			KeyValuePair<int, string> keyValuePair;
			string value;
			string str;
			List<KeyValuePair<int, string>> bedrooms = ItemTypeBc.Instance.GetBedrooms();
			if (bedroomFromId.HasValue)
			{
				keyValuePair = bedrooms.FirstOrDefault<KeyValuePair<int, string>>((KeyValuePair<int, string> m) => {
					long key = (long)m.Key;
					long? nullable = bedroomFromId;
					return key == nullable.GetValueOrDefault() & nullable.HasValue;
				});
				str = keyValuePair.Value;
			}
			else
			{
				str = null;
			}
			if (bedroomToId.HasValue)
			{
				keyValuePair = bedrooms.FirstOrDefault<KeyValuePair<int, string>>((KeyValuePair<int, string> m) => {
					long key = (long)m.Key;
					long? nullable = bedroomToId;
					return key == nullable.GetValueOrDefault() & nullable.HasValue;
				});
				value = keyValuePair.Value;
			}
			else
			{
				value = null;
			}
			return DisplayHelpers.GetRangeForQuickView(str, value);
		}

		public static string GetDisplayNameForCommunityUnitImages(CommunityUnitType communityUnitType)
		{
			string displayName;
			switch (communityUnitType)
			{
				case CommunityUnitType.FloorPlan:
				{
					displayName = DisplayNames.FloorPlanImages;
					break;
				}
				case CommunityUnitType.SpecHome:
				{
					displayName = DisplayNames.SpecHomeImages;
					break;
				}
				case CommunityUnitType.House:
				{
					displayName = DisplayNames.HouseImages;
					break;
				}
				default:
				{
					displayName = string.Empty;
					break;
				}
			}
			return displayName;
		}

		public static string GetDisplayNameForOwnerLogo(OwnerType ownerType)
		{
			string dispalyName;
			if (ownerType == OwnerType.Builder)
			{
				dispalyName = DisplayNames.BuilderLogo;
			}
			else
			{
				dispalyName = (ownerType == OwnerType.PropertyManager ? DisplayNames.PMCLogo : string.Empty);
			}
			return dispalyName;
		}

		public static string GetDisplayPhone(Community community)
		{
			if (community != null)
			{
				if (community.CallTrackingPhones != null)
				{
					CallTrackingPhone callTrackingPhone = community.CallTrackingPhones.FirstOrDefault<CallTrackingPhone>((CallTrackingPhone x) => {
						if (x.PhoneType == CallTrackingPhoneType.ProvisionOnlineAndPrintAd && !x.IsDisconnected)
						{
							DateTime? startDate = x.StartDate;
							DateTime now = DateTime.Now;
							if ((startDate.HasValue ? startDate.GetValueOrDefault() < now : false))
							{
								startDate = x.EndDate;
								now = DateTime.Now;
								if (!startDate.HasValue)
								{
									return false;
								}
								return startDate.GetValueOrDefault() > now;
							}
						}
						return false;
					});
					if (callTrackingPhone != null)
					{
						return callTrackingPhone.ProvisionPhone;
					}
					callTrackingPhone = community.CallTrackingPhones.FirstOrDefault<CallTrackingPhone>((CallTrackingPhone x) => {
						if (x.PhoneType == CallTrackingPhoneType.ProvisionOnline && !x.IsDisconnected)
						{
							DateTime? startDate = x.StartDate;
							DateTime now = DateTime.Now;
							if ((startDate.HasValue ? startDate.GetValueOrDefault() < now : false))
							{
								startDate = x.EndDate;
								now = DateTime.Now;
								if (!startDate.HasValue)
								{
									return false;
								}
								return startDate.GetValueOrDefault() > now;
							}
						}
						return false;
					});
					if (callTrackingPhone != null)
					{
						return callTrackingPhone.ProvisionPhone;
					}
					callTrackingPhone = community.CallTrackingPhones.FirstOrDefault<CallTrackingPhone>((CallTrackingPhone x) => {
						if (x.PhoneType == CallTrackingPhoneType.ProvisionPrintAd && !x.IsDisconnected)
						{
							DateTime? startDate = x.StartDate;
							DateTime now = DateTime.Now;
							if ((startDate.HasValue ? startDate.GetValueOrDefault() < now : false))
							{
								startDate = x.EndDate;
								now = DateTime.Now;
								if (!startDate.HasValue)
								{
									return false;
								}
								return startDate.GetValueOrDefault() > now;
							}
						}
						return false;
					});
					if (callTrackingPhone != null)
					{
						return callTrackingPhone.ProvisionPhone;
					}
				}
				if (community.Phones != null)
				{
					Phone phone = community.Phones.FirstOrDefault<Phone>((Phone p) => {
						long? phoneTypeId = p.PhoneTypeId;
						long? communityListingPhoneTypeId = ConfigurationManager.Instance.CommunityListingPhoneTypeId;
						return phoneTypeId.GetValueOrDefault() == communityListingPhoneTypeId.GetValueOrDefault() & phoneTypeId.HasValue == communityListingPhoneTypeId.HasValue;
					});
					if (phone != null)
					{
						return phone.Number;
					}
					phone = community.Phones.FirstOrDefault<Phone>();
					if (phone != null)
					{
						return phone.Number;
					}
				}
			}
			return string.Empty;
		}

		public static string GetDisplayPhone(ServiceProvider serviceProvider)
		{
			if (serviceProvider != null && serviceProvider.Phones != null)
			{
				Phone phone = serviceProvider.Phones.FirstOrDefault<Phone>((Phone x) => {
					long? phoneTypeId = x.PhoneTypeId;
					long? serviceListingPhoneTypeId = ConfigurationManager.Instance.ServiceListingPhoneTypeId;
					return phoneTypeId.GetValueOrDefault() == serviceListingPhoneTypeId.GetValueOrDefault() & phoneTypeId.HasValue == serviceListingPhoneTypeId.HasValue;
				});
				if (phone != null)
				{
					return phone.Number;
				}
				phone = serviceProvider.Phones.FirstOrDefault<Phone>();
				if (phone != null)
				{
					return phone.Number;
				}
			}
			return string.Empty;
		}

		public static string GetLivingSpace(MeasureBoundary<int, LivingSpaceMeasure> livingSpace)
		{
			if (!livingSpace.Min.HasValue && !livingSpace.Max.HasValue)
			{
				return null;
			}
			string measure = livingSpace.Measure.GetEnumLocalizedValue<LivingSpaceMeasure>();
			if (livingSpace.Min.HasValue && livingSpace.Max.HasValue)
			{
				int value = livingSpace.Min.Value;
				string str = value.ToString(ConfigurationManager.Instance.NumberFormat);
				value = livingSpace.Max.Value;
				return string.Format("{0} - {1} {2}", str, value.ToString(ConfigurationManager.Instance.NumberFormat), measure);
			}
			decimal num = Math.Round((decimal)(livingSpace.Min.HasValue ? livingSpace.Min.Value : livingSpace.Max.Value));
			return string.Format("{0} {1}", num.ToString(ConfigurationManager.Instance.NumberFormat), measure);
		}

		public static string GetLivingSpaceForQuickView(MeasureBoundaryVm<int, LivingSpaceMeasure> livingSpace)
		{
			int value;
			string str;
			string str1;
			string measure = livingSpace.Measure.GetEnumLocalizedValue<LivingSpaceMeasure>();
			if (livingSpace.Min.HasValue)
			{
				value = livingSpace.Min.Value;
				str1 = value.ToString(ConfigurationManager.Instance.NumberFormat);
			}
			else
			{
				str1 = null;
			}
			if (livingSpace.Max.HasValue)
			{
				value = livingSpace.Max.Value;
				str = value.ToString(ConfigurationManager.Instance.NumberFormat);
			}
			else
			{
				str = null;
			}
			string result = DisplayHelpers.GetRangeForQuickView(str1, str);
			if (result != null)
			{
				result = string.Format("{0} {1}", result, measure);
			}
			return result;
		}

		public static string GetPriceRange(MeasureBoundary<decimal, MoneyType> priceRange)
		{
			decimal num;
			if (!priceRange.Min.HasValue && !priceRange.Max.HasValue)
			{
				return null;
			}
			string currency = priceRange.Measure.GetEnumLocalizedValue<MoneyType>();
			if (priceRange.Min.HasValue && priceRange.Max.HasValue)
			{
				decimal? min = priceRange.Min;
				num = Math.Round(min.Value);
				string str = num.ToString(ConfigurationManager.Instance.NumberFormat);
				min = priceRange.Max;
				num = Math.Round(min.Value);
				return string.Format("{0}{1} - {0}{2}", currency, str, num.ToString(ConfigurationManager.Instance.NumberFormat));
			}
			num = Math.Round((priceRange.Min.HasValue ? priceRange.Min.Value : priceRange.Max.Value));
			return string.Format("{0}{1}", currency, num.ToString(ConfigurationManager.Instance.NumberFormat));
		}

		public static string GetPriceRange(MeasureBoundaryVm<decimal, MoneyType> priceRange)
		{
			return DisplayHelpers.GetPriceRange(priceRange.ToEntity());
		}

		private static string GetRange(string from, string to)
		{
			string result = null;
			if (!string.IsNullOrWhiteSpace(from) || !string.IsNullOrWhiteSpace(to))
			{
				if (string.IsNullOrWhiteSpace(from) || string.IsNullOrWhiteSpace(to))
				{
					result = (string.IsNullOrWhiteSpace(from) ? to : from);
				}
				else
				{
					result = string.Format("{0} - {1}", from, to);
				}
			}
			return result;
		}

		private static string GetRangeForQuickView(string from, string to)
		{
			string result = null;
			if (!string.IsNullOrWhiteSpace(from) || !string.IsNullOrWhiteSpace(to))
			{
				if (string.IsNullOrWhiteSpace(from) || string.IsNullOrWhiteSpace(to))
				{
					result = (string.IsNullOrWhiteSpace(from) ? string.Format("{0} {1}", StaticContent.Txt_To, to) : string.Format("{0} {1}", StaticContent.Txt_From, from));
				}
				else
				{
					result = string.Format("{0} - {1}", from, to);
				}
			}
			return result;
		}
	}
}