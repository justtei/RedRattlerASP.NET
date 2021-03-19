using MSLivingChoices.Entities.Admin;
using MSLivingChoices.Entities.Admin.Enums;
using MSLivingChoices.Mvc.Uipc.Admin.Attributes;
using MSLivingChoices.Mvc.Uipc.Admin.Attributes.RestrictCollectionLengthAttributes;
using MSLivingChoices.Mvc.Uipc.Admin.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web.Mvc;

namespace MSLivingChoices.Mvc.Uipc.Admin.ViewModels
{
	public class NewOwnerVm
	{
		[Required]
		public AddressVm Address
		{
			get;
			set;
		}

		[Required]
		public List<ContactVm> Contacts
		{
			get;
			set;
		}

		public bool DisplayAddress
		{
			get;
			set;
		}

		public bool DisplayLogo
		{
			get;
			set;
		}

		public bool DisplayName
		{
			get;
			set;
		}

		public bool DisplayPhone
		{
			get;
			set;
		}

		public bool DisplayWebsiteUrl
		{
			get;
			set;
		}

		[Required]
		public EmailListVm EmailList
		{
			get;
			set;
		}

		public long? Id
		{
			get;
			set;
		}

		[RestrictLogoImageCollectionLength]
		public ImageListVm LogoImages
		{
			get;
			set;
		}

		[AllowHtml]
		[Required]
		[StringLength(50)]
		public string Name
		{
			get;
			set;
		}

		public MSLivingChoices.Entities.Admin.Enums.OwnerType OwnerType
		{
			get;
			set;
		}

		[Required]
		public PhoneListVm PhoneList
		{
			get;
			set;
		}

		[AllowHtml]
		[CustomUrl]
		[StringLength(200)]
		public string WebsiteUrl
		{
			get;
			set;
		}

		public NewOwnerVm()
		{
			this.LogoImages = new ImageListVm();
			this.DisplayWebsiteUrl = true;
			this.DisplayAddress = true;
			this.DisplayName = true;
			this.DisplayPhone = true;
			this.DisplayLogo = true;
		}

		public Owner ToEntity(MSLivingChoices.Entities.Admin.Enums.OwnerType ownerType)
		{
			return new Owner()
			{
				Id = this.Id,
				Name = this.Name,
				OwnerType = ownerType,
				Address = this.Address.ToEntity(),
				Phones = this.PhoneList.ToEntityList(),
				Emails = this.EmailList.ToEntity(),
				Contacts = this.Contacts.ConvertAll<Contact>((ContactVm m) => m.ToEntity()).Where<Contact>((Contact x) => {
					if (!string.IsNullOrWhiteSpace(x.FirstName))
					{
						return true;
					}
					return !string.IsNullOrWhiteSpace(x.LastName);
				}).ToList<Contact>(),
				WebsiteUrl = MslcUrlBuilder.NormalizeUri(this.WebsiteUrl),
				DisplayWebsiteUrl = this.DisplayWebsiteUrl,
				DisplayName = this.DisplayName,
				DisplayAddress = this.DisplayAddress,
				DisplayPhone = this.DisplayPhone,
				DisplayLogo = this.DisplayLogo,
				LogoImages = (this.LogoImages != null ? this.LogoImages.ToEntity(ImageType.Logo) : new List<Image>())
			};
		}
	}
}