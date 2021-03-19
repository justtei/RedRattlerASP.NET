using MSLivingChoices.Entities.Admin.Enums;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Entities.Admin
{
	[Serializable]
	public class ServiceProvider
	{
		public MSLivingChoices.Entities.Admin.Address Address
		{
			get;
			set;
		}

		public List<County> AllCounties
		{
			get;
			set;
		}

		public MSLivingChoices.Entities.Admin.Book Book
		{
			get;
			set;
		}

		public List<CallTrackingPhone> CallTrackingPhones
		{
			get;
			set;
		}

		public List<Contact> Contacts
		{
			get;
			set;
		}

		public List<County> CountiesServed
		{
			get;
			set;
		}

		public MSLivingChoices.Entities.Admin.Coupon Coupon
		{
			get;
			set;
		}

		public string Description
		{
			get;
			set;
		}

		public bool DisplayAddress
		{
			get;
			set;
		}

		public bool DisplayWebsiteUrl
		{
			get;
			set;
		}

		public List<Email> Emails
		{
			get;
			set;
		}

		public DateTime? FeatureEndDate
		{
			get;
			set;
		}

		public DateTime? FeatureStartDate
		{
			get;
			set;
		}

		public long? Id
		{
			get;
			set;
		}

		public List<Image> Images
		{
			get;
			set;
		}

		public string MarchexAccountId
		{
			get;
			set;
		}

		public string Name
		{
			get;
			set;
		}

		public List<MSLivingChoices.Entities.Admin.OfficeHours> OfficeHours
		{
			get;
			set;
		}

		public PackageType? Package
		{
			get;
			set;
		}

		public List<long> PaymentTypeIds
		{
			get;
			set;
		}

		public List<Phone> Phones
		{
			get;
			set;
		}

		public DateTime? PublishEndDate
		{
			get;
			set;
		}

		public DateTime? PublishStartDate
		{
			get;
			set;
		}

		public List<KeyValuePair<long, string>> ServiceCategories
		{
			get;
			set;
		}

		public Guid? UserId
		{
			get;
			set;
		}

		public string WebsiteUrl
		{
			get;
			set;
		}

		public ServiceProvider()
		{
		}
	}
}