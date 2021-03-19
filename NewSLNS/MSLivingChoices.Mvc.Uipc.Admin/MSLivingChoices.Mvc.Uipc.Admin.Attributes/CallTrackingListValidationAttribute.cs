using MSLivingChoices.Entities.Admin.Enums;
using MSLivingChoices.Localization;
using MSLivingChoices.Mvc.Uipc.Admin.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Mvc.Uipc.Admin.Attributes
{
	internal class CallTrackingListValidationAttribute : ValidationAttribute
	{
		public CallTrackingListValidationAttribute()
		{
			base.ErrorMessageResourceType = typeof(ErrorMessages);
			base.ErrorMessageResourceName = "CallTrackingListValidationError";
		}

		public override bool IsValid(object value)
		{
			if (value is List<CallTrackingPhoneVm>)
			{
				List<CallTrackingPhoneVm> list = (
					from i in value as List<CallTrackingPhoneVm>
					where !i.IsDisconnected
					select i).ToList<CallTrackingPhoneVm>();
				if (list.Count > 3)
				{
					return false;
				}
				if ((
					from x in list
					group x by x.PhoneType).ToDictionary<IGrouping<CallTrackingPhoneType?, CallTrackingPhoneVm>, CallTrackingPhoneType?, List<CallTrackingPhoneVm>>((IGrouping<CallTrackingPhoneType?, CallTrackingPhoneVm> x) => x.Key, (IGrouping<CallTrackingPhoneType?, CallTrackingPhoneVm> x) => x.ToList<CallTrackingPhoneVm>()).Any<KeyValuePair<CallTrackingPhoneType?, List<CallTrackingPhoneVm>>>((KeyValuePair<CallTrackingPhoneType?, List<CallTrackingPhoneVm>> item) => item.Value.Count > 1))
				{
					return false;
				}
				if (list.Any<CallTrackingPhoneVm>((CallTrackingPhoneVm i) => {
					CallTrackingPhoneType? phoneType = i.PhoneType;
					return phoneType.GetValueOrDefault() == CallTrackingPhoneType.ProvisionOnlineAndPrintAd & phoneType.HasValue;
				}))
				{
					if (!list.Any<CallTrackingPhoneVm>((CallTrackingPhoneVm i) => {
						CallTrackingPhoneType? phoneType = i.PhoneType;
						return phoneType.GetValueOrDefault() == CallTrackingPhoneType.ProvisionOnline & phoneType.HasValue;
					}))
					{
						if (!list.Any<CallTrackingPhoneVm>((CallTrackingPhoneVm i) => {
							CallTrackingPhoneType? phoneType = i.PhoneType;
							return phoneType.GetValueOrDefault() == CallTrackingPhoneType.ProvisionPrintAd & phoneType.HasValue;
						}))
						{
							return true;
						}
					}
					return false;
				}
			}
			return true;
		}
	}
}