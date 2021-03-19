using MSLivingChoices.Entities.Admin.Enums;
using System;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Entities.Admin
{
	[Serializable]
	public class CallTrackingPhone
	{
		public string CampaignId
		{
			get;
			set;
		}

		public long? CommunityId
		{
			get;
			set;
		}

		public string CommunityName
		{
			get;
			set;
		}

		public DateTime? DisconnectDate
		{
			get;
			set;
		}

		public DateTime? EndDate
		{
			get;
			set;
		}

		public long? Id
		{
			get;
			set;
		}

		public bool IsActive
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

		public bool IsClickToCall
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

		public string ListingPhone
		{
			get;
			set;
		}

		public string MarchexAccountId
		{
			get;
			set;
		}

		public string OldPhone
		{
			get;
			set;
		}

		public string Phone
		{
			get;
			set;
		}

		public string PhoneExtension
		{
			get;
			set;
		}

		public CallTrackingPhoneType PhoneType
		{
			get;
			set;
		}

		public string ProvisionPhone
		{
			get;
			set;
		}

		public string ProvisionPhoneExtension
		{
			get;
			set;
		}

		public DateTime? ReconnectDate
		{
			get;
			set;
		}

		public long? ServiceId
		{
			get;
			set;
		}

		public DateTime? StartDate
		{
			get;
			set;
		}

		public CallTrackingPhone()
		{
		}
	}
}