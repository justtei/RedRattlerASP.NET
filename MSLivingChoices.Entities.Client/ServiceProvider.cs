using MSLivingChoices.Entities.Client.DisplayOptions;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Entities.Client
{
	[Serializable]
	public class ServiceProvider : IProvider
	{
		public List<string> AcceptedPayments
		{
			get;
			set;
		}

		public MSLivingChoices.Entities.Client.Address Address
		{
			get;
			set;
		}

		public string BookNumber
		{
			get;
			set;
		}

		public List<County> CountiesServed
		{
			get;
			set;
		}

		public MSLivingChoices.Entities.Client.Coupon Coupon
		{
			get;
			set;
		}

		public string Description
		{
			get;
			set;
		}

		public ServiceDisplayOptions DisplayOptions
		{
			get;
			set;
		}

		public long Id
		{
			get;
			set;
		}

		public List<Image> Images
		{
			get;
			set;
		}

		IAddress MSLivingChoices.Entities.Client.IProvider.Address
		{
			get
			{
				return this.Address;
			}
			set
			{
				this.Address = value as MSLivingChoices.Entities.Client.Address;
			}
		}

		public string Name
		{
			get;
			set;
		}

		public List<MSLivingChoices.Entities.Client.OfficeHours> OfficeHours
		{
			get;
			set;
		}

		public long PackageId
		{
			get;
			set;
		}

		public string Phone
		{
			get;
			set;
		}

		public int SearchResultRadius
		{
			get;
			set;
		}

		public List<string> ServiceCategories
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