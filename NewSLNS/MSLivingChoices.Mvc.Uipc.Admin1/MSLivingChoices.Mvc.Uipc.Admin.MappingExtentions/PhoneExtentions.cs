using MSLivingChoices.Bcs.Admin.Components;
using MSLivingChoices.Entities.Admin;
using MSLivingChoices.Entities.Admin.Enums;
using MSLivingChoices.Mvc.Uipc.Admin.ViewModels;
using MSLivingChoices.Mvc.Uipc.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Mvc.Uipc.Admin.MappingExtentions
{
	internal static class PhoneExtentions
	{
		internal static PhoneListVm MapToPhoneListVm(this List<Phone> phones, CommunityType communityType)
		{
			return phones.MapToPhoneListVm(ItemTypeBc.Instance.GetPhoneTypes(communityType));
		}

		internal static PhoneListVm MapToPhoneListVm(this List<Phone> phones, OwnerType ownerType)
		{
			return phones.MapToPhoneListVm(ItemTypeBc.Instance.GetPhoneTypes(ownerType));
		}

		internal static PhoneListVm MapToPhoneListVm(this List<Phone> phones, ServiceType serviceType)
		{
			return phones.MapToPhoneListVm(ItemTypeBc.Instance.GetPhoneTypes(serviceType));
		}

		private static PhoneListVm MapToPhoneListVm(this List<Phone> phones, List<KeyValuePair<int, string>> phoneTypes)
		{
			Func<Phone, bool> func = null;
			PhoneListVm phoneListVm = new PhoneListVm();
			KeyValuePair<int, string> keyValuePair = phoneTypes.FirstOrDefault<KeyValuePair<int, string>>();
			phoneListVm.AdditionalPhones = new List<PhoneVm>();
			phoneListVm.DefaultPhoneTypeName = keyValuePair.Value;
			phoneListVm.DefaultPhoneTypeId = new long?((long)keyValuePair.Key);
			if (phones != null && phones.Any<Phone>())
			{
				Phone listingTypePhone = phones.FirstOrDefault<Phone>((Phone p) => {
					long? phoneTypeId = p.PhoneTypeId;
					long key = (long)keyValuePair.Key;
					return phoneTypeId.GetValueOrDefault() == key & phoneTypeId.HasValue;
				});
				if (listingTypePhone != null)
				{
					phoneListVm.DefaultPhoneId = listingTypePhone.Id;
					phoneListVm.DefaultPhoneNumber = listingTypePhone.Number;
				}
				List<Phone> phones1 = phones;
				Func<Phone, bool> func1 = func;
				if (func1 == null)
				{
					Func<Phone, bool> func2 = (Phone m) => {
						long? id = m.Id;
						long? defaultPhoneId = phoneListVm.DefaultPhoneId;
						return !(id.GetValueOrDefault() == defaultPhoneId.GetValueOrDefault() & id.HasValue == defaultPhoneId.HasValue);
					};
					Func<Phone, bool> func3 = func2;
					func = func2;
					func1 = func3;
				}
				foreach (Phone phone in phones1.Where<Phone>(func1))
				{
					PhoneVm phoneVm = new PhoneVm()
					{
						Id = phone.Id,
						PhoneTypeId = phone.PhoneTypeId,
						Number = phone.Number,
						PhoneTypes = phoneTypes.ToSelectListItemList(phone.PhoneTypeId)
					};
					phoneListVm.AdditionalPhones.Add(phoneVm);
				}
			}
			if (!phoneListVm.AdditionalPhones.Any<PhoneVm>())
			{
				PhoneVm phoneVm1 = new PhoneVm()
				{
					PhoneTypes = phoneTypes.ToSelectListItemList()
				};
				phoneListVm.AdditionalPhones.Add(phoneVm1);
			}
			return phoneListVm;
		}
	}
}