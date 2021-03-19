using MSLivingChoices.Configuration;
using MSLivingChoices.Entities.Admin;
using MSLivingChoices.Entities.Admin.Enums;
using MSLivingChoices.Mvc.Uipc.Admin.Attributes;
using MSLivingChoices.Mvc.Uipc.Admin.Helpers;
using MSLivingChoices.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Web.Mvc;

namespace MSLivingChoices.Mvc.Uipc.Admin.ViewModels
{
	public class CallTrackingPhoneVm
	{
		private string _listingPhone;

		public string CampaignId
		{
			get;
			set;
		}

		public DateTime? DisconnectDate
		{
			get;
			set;
		}

		[Required]
		public DateTime? EndDate
		{
			get;
			set;
		}

		public string ExpiresAt
		{
			get
			{
				if (!this.DisconnectDate.HasValue)
				{
					return string.Empty;
				}
				DateTime value = this.DisconnectDate.Value;
				value = value.AddDays(180);
				return value.ToString(ConfigurationManager.Instance.AdminServerDateFormat);
			}
		}

		public long? Id
		{
			get;
			set;
		}

		public bool IsCallReview
		{
			get;
			set;
		}

		public bool IsChanged
		{
			get;
			set;
		}

		public bool IsDisconnected
		{
			get;
			set;
		}

		public bool IsWhisper
		{
			get;
			set;
		}

		[AllowHtml]
		[Required]
		[StringLength(20)]
		public string ListingPhone
		{
			get
			{
				if (!this._listingPhone.IsNullOrWhitespace())
				{
					return this._listingPhone;
				}
				return this.Phone;
			}
			set
			{
				this._listingPhone = value;
			}
		}

		[AllowHtml]
		public string OldPhone
		{
			get;
			set;
		}

		[AllowHtml]
		[Required]
		[StringLength(20)]
		public string Phone
		{
			get;
			set;
		}

		[Required]
		public CallTrackingPhoneType? PhoneType
		{
			get;
			set;
		}

		public List<SelectListItem> PhoneTypes
		{
			get
			{
				if (!this.PhoneType.HasValue)
				{
					return ConverterHelpers.EnumToKoSelectListItems<CallTrackingPhoneType>();
				}
				return ConverterHelpers.EnumToKoSelectListItems<CallTrackingPhoneType>(this.PhoneType.Value);
			}
		}

		[AllowHtml]
		[StringLength(20)]
		public string ProvisionPhone
		{
			get;
			set;
		}

		public DateTime? ReconnectDate
		{
			get;
			set;
		}

		[DateRange("EndDate")]
		[Required]
		public DateTime? StartDate
		{
			get;
			set;
		}

		public CallTrackingPhoneVm()
		{
		}

		public CallTrackingPhone ToEntity()
		{
			DateTime? reconnectDate;
			CallTrackingPhone callTrackingPhone = new CallTrackingPhone()
			{
				Id = this.Id,
				CampaignId = this.CampaignId,
				IsDisconnected = this.IsDisconnected,
				PhoneType = (this.PhoneType.HasValue ? this.PhoneType.Value : CallTrackingPhoneType.ProvisionOnline),
				Phone = this.Phone,
				ListingPhone = this.ListingPhone,
				OldPhone = this.OldPhone,
				ProvisionPhone = this.ProvisionPhone,
				IsWhisper = this.IsWhisper,
				IsCallReview = this.IsCallReview,
				IsChanged = this.IsChanged,
				StartDate = this.StartDate,
				EndDate = this.EndDate
			};
			if (callTrackingPhone.IsDisconnected)
			{
				reconnectDate = null;
				callTrackingPhone.ReconnectDate = reconnectDate;
				CallTrackingPhone nullable = callTrackingPhone;
				reconnectDate = this.DisconnectDate;
				nullable.DisconnectDate = new DateTime?((reconnectDate.HasValue ? reconnectDate.GetValueOrDefault() : DateTime.Now));
			}
			else
			{
				reconnectDate = null;
				callTrackingPhone.DisconnectDate = reconnectDate;
				CallTrackingPhone nullable1 = callTrackingPhone;
				reconnectDate = this.ReconnectDate;
				nullable1.ReconnectDate = new DateTime?((reconnectDate.HasValue ? reconnectDate.GetValueOrDefault() : DateTime.Now));
			}
			return callTrackingPhone;
		}
	}
}