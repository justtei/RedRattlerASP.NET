using MSLivingChoices.Entities.Client;
using MSLivingChoices.Entities.Client.Enums;
using MSLivingChoices.Mvc.Uipc.Client.MappingExtentions;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Web.Mvc;

namespace MSLivingChoices.Mvc.Uipc.Client.ViewModels
{
	public class LeadFormVm
	{
		public BrandType Brand
		{
			get;
			set;
		}

		public long? CommunityUnitId
		{
			get;
			set;
		}

		public CustomerInfoVm Customer
		{
			get;
			set;
		}

		public LeadFormDisplayProperties DisplayProperties
		{
			get;
			set;
		}

		public InquiryType Inquiry
		{
			get;
			set;
		}

		public long? ListingId
		{
			get;
			set;
		}

		public string ListingName
		{
			get;
			set;
		}

		public LookingForType? LookingFor
		{
			get;
			set;
		}

		public List<SelectListItem> LookingForChoices
		{
			get;
			set;
		}

		public string Message
		{
			get;
			set;
		}

		public string MoveInDate
		{
			get;
			set;
		}

		public LeadFormVm()
		{
		}

		public virtual Lead ToEntity()
		{
			DateTime dateTime;
			Lead lead = new Lead();
			if (this.ListingId.HasValue)
			{
				LeadTarget leadTarget = new LeadTarget()
				{
					InnerId = this.ListingId.Value,
					Type = this.Inquiry.MapToLeadTargetType()
				};
				lead.Targets.Add(leadTarget);
			}
			lead.Customer = this.Customer.ToCustomer();
			lead.Message = this.Message;
			lead.Inquiry = this.Inquiry;
			lead.Data.Brand = new BrandType?(this.Brand);
			lead.Metadata.Device = new DeviceMetric?(DeviceMetric.Desktop);
			if (this.LookingFor.HasValue)
			{
				lead.Data.LookingFor = new LookingForType?(this.LookingFor.Value);
			}
			if (this.CommunityUnitId.HasValue)
			{
				lead.Data.CommunityUnitId = new long?(this.CommunityUnitId.Value);
			}
			if (DateTime.TryParse(this.MoveInDate, out dateTime))
			{
				lead.Data.MoveInDate = new DateTime?(dateTime);
			}
			return lead;
		}
	}
}