using MSLivingChoices.Bcs.Admin.Components;
using MSLivingChoices.Entities.Admin;
using MSLivingChoices.Entities.Admin.Enums;
using MSLivingChoices.Localization;
using MSLivingChoices.Mvc.Uipc.Admin.ViewModels;
using MSLivingChoices.Mvc.Uipc.Admin.ViewModelsProviders;
using MSLivingChoices.Mvc.Uipc.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web.Mvc;

namespace MSLivingChoices.Mvc.Uipc.Admin.MappingExtentions
{
	internal static class OwnerExtentions
	{
		internal static string MapToDisplayName(this OwnerType ownerType)
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

		internal static NewOwnerVm MapToNewOwnerVm(this Owner owner)
		{
			NewOwnerVm result = new NewOwnerVm()
			{
				Id = owner.Id,
				Name = owner.Name,
				OwnerType = owner.OwnerType,
				WebsiteUrl = owner.WebsiteUrl,
				DisplayName = owner.DisplayName,
				DisplayAddress = owner.DisplayAddress,
				DisplayPhone = owner.DisplayPhone,
				DisplayWebsiteUrl = owner.DisplayWebsiteUrl,
				DisplayLogo = owner.DisplayLogo,
				Address = owner.Address.MapToAddressVm(),
				PhoneList = (owner.Phones.Any<Phone>() ? owner.Phones.MapToPhoneListVm(owner.OwnerType) : AdminViewModelsProvider.GetPhoneList(owner.OwnerType)),
				EmailList = (owner.Emails.Any<Email>() ? owner.Emails.MapToEmailListVm(owner.OwnerType) : AdminViewModelsProvider.GetEmailListVm(owner.OwnerType))
			};
			if (owner.Contacts.Any<Contact>())
			{
				result.Contacts = new List<ContactVm>();
				List<KeyValuePair<int, string>> contactTypes = ItemTypeBc.Instance.GetContactTypes(owner.OwnerType);
				foreach (Contact contactItem in owner.Contacts)
				{
					ContactVm contactViewModel = new ContactVm()
					{
						Id = contactItem.Id,
						ContactTypeId = contactItem.ContactTypeId,
						FirstName = contactItem.FirstName,
						LastName = contactItem.LastName,
						ContactTypes = contactTypes.ToSelectListItemList(contactItem.ContactTypeId)
					};
					result.Contacts.Add(contactViewModel);
				}
			}
			else
			{
				result.Contacts = new List<ContactVm>()
				{
					AdminViewModelsProvider.GetContactVm(owner.OwnerType)
				};
			}
			result.LogoImages = owner.LogoImages.MapToImageListVm(owner.OwnerType.MapToDisplayName());
			return result;
		}

		internal static OwnerVm MapToOwnerVm(this Owner owner, OwnerType ownerType)
		{
			OwnerVm result = new OwnerVm();
			result.Id = owner.Id;
			result.NewOwner = new NewOwnerVm
			{
				Address = AdminViewModelsProvider.GetAddressVm(),
				PhoneList = AdminViewModelsProvider.GetPhoneList(ownerType),
				EmailList = AdminViewModelsProvider.GetEmailListVm(ownerType),
				Contacts = new List<ContactVm>
			{
				AdminViewModelsProvider.GetContactVm(ownerType)
			},
				LogoImages = new ImageListVm(ownerType.MapToDisplayName()),
				OwnerType = ownerType
			};
			result.Owners = (from m in OwnerBc.Instance.GetAllByOwnerType(owner.OwnerType)
							 select new SelectListItem
							 {
								 Value = m.Id.ToString(),
								 Text = m.Name,
								 Selected = (result.Id == m.Id)
							 }).ToList();
			return result;
		}
	}
}