using MSLivingChoices.Entities.Client.Enums;
using System;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.SqlDacs.Client.Utilities
{
	internal static class LeadUtilities
	{
		public static LeadEventType ToLeadEventType(this InquiryType inquiry)
		{
			switch (inquiry)
			{
				case InquiryType.Community:
				case InquiryType.ServiceProvider:
				{
					return LeadEventType.GetMoreInformation;
				}
				case InquiryType.FloorPlan:
				{
					return LeadEventType.FloorPlanCheckAvailability;
				}
				case InquiryType.SpecialHome:
				case InquiryType.Home:
				{
					return LeadEventType.SpecHomeCheckAvailability;
				}
			}
			throw new ArgumentOutOfRangeException();
		}

		public static string ToLegacyBrand(this BrandType? brand)
		{
			string str;
			BrandType? nullable = brand;
			if (nullable.HasValue)
			{
				BrandType valueOrDefault = nullable.GetValueOrDefault();
				if (valueOrDefault == BrandType.MatureLivingChoices)
				{
					str = "MLC";
					return str;
				}
				else
				{
					if (valueOrDefault != BrandType.SeniorLivingChoices)
					{
						str = "MLC";
						return str;
					}
					str = "SLC";
					return str;
				}
			}
			str = "MLC";
			return str;
		}

		public static LeadPageType ToLegacyLeadPageType(this InquiryType inquiry)
		{
			if (inquiry == InquiryType.ServiceProvider)
			{
				return LeadPageType.ServiceDetails;
			}
			return LeadPageType.PropertyDetails;
		}

		public static LegacyLeadType ToLegacyLeadType(this DeviceMetric? metric)
		{
			DeviceMetric? nullable = metric;
			if (!nullable.HasValue)
			{
				return LegacyLeadType.Web;
			}
			DeviceMetric valueOrDefault = nullable.GetValueOrDefault();
			if (valueOrDefault == DeviceMetric.Desktop)
			{
				return LegacyLeadType.Web;
			}
			if (valueOrDefault != DeviceMetric.Mobile)
			{
				throw new ArgumentOutOfRangeException("metric");
			}
			return LegacyLeadType.Web;
		}
	}
}