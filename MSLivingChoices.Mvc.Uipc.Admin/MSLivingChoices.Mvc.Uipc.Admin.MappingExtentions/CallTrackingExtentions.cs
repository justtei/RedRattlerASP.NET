using MSLivingChoices.Entities.Admin;
using MSLivingChoices.Entities.Admin.Enums;
using MSLivingChoices.Localization;
using MSLivingChoices.Mvc.Uipc.Admin.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Mvc.Uipc.Admin.MappingExtentions
{
	internal static class CallTrackingExtentions
	{
		internal static CallTrackingPhoneForGridVm MapToCallTrackingPhoneForGridVm(this CallTrackingPhone callTrackingPhone)
		{
			CallTrackingPhoneForGridVm callTrackingPhoneForGridVm = new CallTrackingPhoneForGridVm();
			long? communityId = callTrackingPhone.CommunityId;
			callTrackingPhoneForGridVm.CommunityId = (communityId.HasValue ? communityId : callTrackingPhone.ServiceId);
			callTrackingPhoneForGridVm.CommunityName = callTrackingPhone.CommunityName;
			callTrackingPhoneForGridVm.PhoneType = callTrackingPhone.PhoneType.GetEnumLocalizedValue<CallTrackingPhoneType>();
			callTrackingPhoneForGridVm.Phone = callTrackingPhone.Phone;
			callTrackingPhoneForGridVm.ProvisionPhone = callTrackingPhone.ProvisionPhone;
			callTrackingPhoneForGridVm.IsWhisper = callTrackingPhone.IsWhisper;
			callTrackingPhoneForGridVm.IsCallReview = callTrackingPhone.IsCallReview;
			callTrackingPhoneForGridVm.DisconnectDate = callTrackingPhone.DisconnectDate;
			callTrackingPhoneForGridVm.StartDate = callTrackingPhone.StartDate;
			callTrackingPhoneForGridVm.EndDate = callTrackingPhone.EndDate;
			return callTrackingPhoneForGridVm;
		}

		internal static List<CallTrackingPhoneForGridVm> MapToCallTrackingPhoneForGridVmList(this List<CallTrackingPhone> callTrackingPhones)
		{
			return callTrackingPhones.ConvertAll<CallTrackingPhoneForGridVm>(new Converter<CallTrackingPhone, CallTrackingPhoneForGridVm>(CallTrackingExtentions.MapToCallTrackingPhoneForGridVm)).ToList<CallTrackingPhoneForGridVm>();
		}

		internal static CallTrackingPhoneVm MapToCallTrackingPhoneVm(this CallTrackingPhone callTrackingPhone)
		{
			return new CallTrackingPhoneVm()
			{
				Id = callTrackingPhone.Id,
				CampaignId = callTrackingPhone.CampaignId,
				PhoneType = new CallTrackingPhoneType?(callTrackingPhone.PhoneType),
				Phone = callTrackingPhone.Phone,
				ListingPhone = callTrackingPhone.ListingPhone,
				OldPhone = callTrackingPhone.Phone,
				ProvisionPhone = callTrackingPhone.ProvisionPhone,
				IsWhisper = callTrackingPhone.IsWhisper,
				IsCallReview = callTrackingPhone.IsCallReview,
				StartDate = callTrackingPhone.StartDate,
				EndDate = callTrackingPhone.EndDate,
				IsDisconnected = callTrackingPhone.IsDisconnected,
				DisconnectDate = callTrackingPhone.DisconnectDate,
				ReconnectDate = callTrackingPhone.ReconnectDate
			};
		}

		internal static List<CallTrackingPhoneVm> MapToCallTrackingPhoneVmList(this List<CallTrackingPhone> callTrackingPhones)
		{
			return callTrackingPhones.ConvertAll<CallTrackingPhoneVm>(new Converter<CallTrackingPhone, CallTrackingPhoneVm>(CallTrackingExtentions.MapToCallTrackingPhoneVm)).ToList<CallTrackingPhoneVm>();
		}
	}
}