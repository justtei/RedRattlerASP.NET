using MSLivingChoices.Entities.Client.Enums;
using MSLivingChoices.Mvc.Uipc.Enums;
using System;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Mvc.Uipc.Client.MappingExtentions
{
	internal static class LeadExtensions
	{
		public static BrandType MapToBrandType(this SearchType searchType)
		{
			if (searchType == SearchType.SeniorHousingAndCare)
			{
				return BrandType.SeniorLivingChoices;
			}
			return BrandType.MatureLivingChoices;
		}

		public static LeadTargetType MapToLeadTargetType(this InquiryType inquiry)
		{
			switch (inquiry)
			{
				case InquiryType.Community:
				{
					return LeadTargetType.Community;
				}
				case InquiryType.ServiceProvider:
				{
					return LeadTargetType.ServiceProvider;
				}
				case InquiryType.FloorPlan:
				{
					return LeadTargetType.Community;
				}
				case InquiryType.SpecialHome:
				{
					return LeadTargetType.Community;
				}
				case InquiryType.Home:
				{
					return LeadTargetType.Community;
				}
			}
			throw new ArgumentOutOfRangeException("inquiry");
		}
	}
}