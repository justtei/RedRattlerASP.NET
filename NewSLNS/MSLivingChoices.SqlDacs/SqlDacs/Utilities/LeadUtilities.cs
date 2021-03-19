using MSLivingChoices.Entities.Client;
using MSLivingChoices.Entities.Client.Enums;
using MSLivingChoices.SqlDacs.Utilities.Entities;
using System;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.SqlDacs.Utilities
{
	internal static class LeadUtilities
	{
		public static LeadEventType ToLeadEventType(this Lead lead)
		{
			throw new NotImplementedException();
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