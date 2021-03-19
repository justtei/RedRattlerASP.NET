using MSLivingChoices.Entities.Admin;
using MSLivingChoices.Entities.Admin.Enums;
using MSLivingChoices.Mvc.Uipc.Admin.Attributes;
using MSLivingChoices.Mvc.Uipc.Admin.Attributes.RestrictCollectionLengthAttributes;
using MSLivingChoices.Mvc.Uipc.Admin.Helpers;
using MSLivingChoices.Mvc.Uipc.Admin.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web.Mvc;

namespace MSLivingChoices.Mvc.Uipc.Admin.ViewModels
{
	public class NewServiceProviderVm
	{
		[Required]
		public AddressVm Address
		{
			get;
			set;
		}

		public AddressValidationVm AddressValidation
		{
			get;
			set;
		}

		public List<County> AllCounties
		{
			get;
			set;
		}

		[Required]
		public long? BookId
		{
			get;
			set;
		}

		public List<SelectListItem> Books
		{
			get;
			set;
		}

		[CallTrackingListValidation]
		public List<CallTrackingPhoneVm> CallTrackingPhones
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

		public List<County> CountiesServed
		{
			get;
			set;
		}

		public CouponVm Coupon
		{
			get;
			set;
		}

		[AllowHtml]
		[UIHint("RichTextEditor")]
		public string Description
		{
			get;
			set;
		}

		public bool DisplayWebsiteUrl
		{
			get;
			set;
		}

		public bool DoNotDisplayAddress
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

		public DateTime? FeatureEndDate
		{
			get;
			set;
		}

		[DateRange("FeatureEndDate")]
		public DateTime? FeatureStartDate
		{
			get;
			set;
		}

		[RestrictServiceProviderImageCollectionLength]
		public ImageListVm Images
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

		public List<OfficeHoursVm> OfficeHours
		{
			get;
			set;
		}

		[Required]
		public PackageType? Package
		{
			get;
			set;
		}

		public List<SelectListItem> Packages
		{
			get
			{
				if (!this.Package.HasValue)
				{
					return ConverterHelpers.EnumToKoSelectListItems<PackageType>();
				}
				return ConverterHelpers.EnumToKoSelectListItems<PackageType>(this.Package.Value);
			}
		}

		public List<CheckBoxVm> PaymentTypes
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

		public bool ProvisionCallTrackingNumbers
		{
			get;
			set;
		}

		public DateTime? PublishEndDate
		{
			get;
			set;
		}

		[DateRange("PublishEndDate")]
		public DateTime? PublishStartDate
		{
			get;
			set;
		}

		[RequiredCheckBoxList]
		public List<CheckBoxVm> ServiceCategories
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

		public NewServiceProviderVm()
		{
			this.Images = new ImageListVm();
		}

		public virtual ServiceProvider ToEntity()
		{
			long id;
			ServiceProvider serviceProvider = new ServiceProvider();
			List<long> paymentTypeIds = new List<long>();
			foreach (CheckBoxVm checkBoxVm in 
				from m in this.PaymentTypes
				where m.IsChecked
				select m)
			{
				if (!long.TryParse(checkBoxVm.Value, out id))
				{
					continue;
				}
				paymentTypeIds.Add(id);
			}
			serviceProvider.PaymentTypeIds = paymentTypeIds;
			serviceProvider.Coupon = this.Coupon.ToEntity();
			serviceProvider.Package = this.Package;
			serviceProvider.Book = new Book()
			{
				Id = this.BookId
			};
			serviceProvider.ServiceCategories = (
				from key in ConverterHelpers.CheckBoxListToLongArray(this.ServiceCategories)
				select new KeyValuePair<long, string>(key, string.Empty)).ToList<KeyValuePair<long, string>>();
			serviceProvider.AllCounties = this.AllCounties;
			serviceProvider.CountiesServed = this.CountiesServed;
			serviceProvider.Name = this.Name;
			serviceProvider.Address = (this.AddressValidation.ValidationItems == null ? this.Address.ToEntity() : this.AddressValidation.ToEntity());
			serviceProvider.DisplayAddress = !this.DoNotDisplayAddress;
			serviceProvider.Phones = this.PhoneList.ToEntityList();
			serviceProvider.Emails = this.EmailList.ToEntity();
			serviceProvider.Contacts = this.Contacts.ConvertAll<Contact>((ContactVm m) => m.ToEntity()).Where<Contact>((Contact x) => {
				if (!string.IsNullOrWhiteSpace(x.FirstName))
				{
					return true;
				}
				return !string.IsNullOrWhiteSpace(x.LastName);
			}).ToList<Contact>();
			serviceProvider.OfficeHours = this.OfficeHours.ConvertAll<MSLivingChoices.Entities.Admin.OfficeHours>((OfficeHoursVm m) => m.ToEntity());
			serviceProvider.Description = this.Description;
			serviceProvider.WebsiteUrl = MslcUrlBuilder.NormalizeUri(this.WebsiteUrl);
			serviceProvider.DisplayWebsiteUrl = this.DisplayWebsiteUrl;
			serviceProvider.FeatureStartDate = this.FeatureStartDate;
			serviceProvider.FeatureEndDate = this.FeatureEndDate;
			serviceProvider.PublishStartDate = this.PublishStartDate;
			serviceProvider.PublishEndDate = this.PublishEndDate;
			serviceProvider.Images = (this.Images != null ? this.Images.ToEntity(ImageType.Photo) : new List<Image>());
			serviceProvider.CallTrackingPhones = new List<CallTrackingPhone>();
			if (this.CallTrackingPhones != null)
			{
				if (!this.ProvisionCallTrackingNumbers)
				{
					this.CallTrackingPhones.ForEach((CallTrackingPhoneVm c) => c.IsDisconnected = true);
				}
				serviceProvider.CallTrackingPhones = (
					from p in this.CallTrackingPhones.ConvertAll<CallTrackingPhone>((CallTrackingPhoneVm m) => m.ToEntity())
					where !string.IsNullOrEmpty(p.Phone)
					select p).ToList<CallTrackingPhone>();
			}
			return serviceProvider;
		}
	}
}