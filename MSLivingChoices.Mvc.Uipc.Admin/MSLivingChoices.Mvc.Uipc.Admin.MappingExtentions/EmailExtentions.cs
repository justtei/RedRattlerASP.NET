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
	internal static class EmailExtentions
	{
		internal static EmailListVm MapToEmailListVm(this List<Email> emails, CommunityType communityType)
		{
			return emails.MapToEmailListVm(ItemTypeBc.Instance.GetEmailTypes(communityType));
		}

		internal static EmailListVm MapToEmailListVm(this List<Email> emails, OwnerType ownerType)
		{
			return emails.MapToEmailListVm(ItemTypeBc.Instance.GetEmailTypes(ownerType));
		}

		internal static EmailListVm MapToEmailListVm(this List<Email> emails, ServiceType serviceType)
		{
			return emails.MapToEmailListVm(ItemTypeBc.Instance.GetEmailTypes(serviceType));
		}

		private static EmailListVm MapToEmailListVm(this List<Email> emails, List<KeyValuePair<int, string>> emailTypes)
		{
			Func<Email, bool> func = null;
			EmailListVm emailListVm = new EmailListVm();
			KeyValuePair<int, string> keyValuePair = emailTypes.FirstOrDefault<KeyValuePair<int, string>>();
			emailListVm.AdditionalEmails = new List<EmailVm>();
			emailListVm.DefaultEmailTypeName = keyValuePair.Value;
			emailListVm.DefaultEmailTypeId = new long?((long)keyValuePair.Key);
			if (emails != null && emails.Any<Email>())
			{
				Email leadTypeEmail = emails.FirstOrDefault<Email>((Email m) => {
					long? emailTypeId = m.EmailTypeId;
					long key = (long)keyValuePair.Key;
					return emailTypeId.GetValueOrDefault() == key & emailTypeId.HasValue;
				});
				if (leadTypeEmail != null)
				{
					emailListVm.DefaultEmailId = leadTypeEmail.Id;
					emailListVm.DefaultEmail = leadTypeEmail.Value;
				}
				List<Email> emails1 = emails;
				Func<Email, bool> func1 = func;
				if (func1 == null)
				{
					Func<Email, bool> func2 = (Email m) => {
						long? id = m.Id;
						long? defaultEmailId = emailListVm.DefaultEmailId;
						return !(id.GetValueOrDefault() == defaultEmailId.GetValueOrDefault() & id.HasValue == defaultEmailId.HasValue);
					};
					Func<Email, bool> func3 = func2;
					func = func2;
					func1 = func3;
				}
				foreach (Email email in emails1.Where<Email>(func1))
				{
					EmailVm additionalEmail = new EmailVm()
					{
						Id = email.Id,
						EmailTypeId = email.EmailTypeId,
						Email = email.Value,
						EmailTypes = emailTypes.ToSelectListItemList(email.EmailTypeId)
					};
					emailListVm.AdditionalEmails.Add(additionalEmail);
				}
			}
			if (!emailListVm.AdditionalEmails.Any<EmailVm>())
			{
				EmailVm emptyAdditionalEmail = new EmailVm()
				{
					EmailTypes = emailTypes.ToSelectListItemList()
				};
				emailListVm.AdditionalEmails.Add(emptyAdditionalEmail);
			}
			return emailListVm;
		}
	}
}