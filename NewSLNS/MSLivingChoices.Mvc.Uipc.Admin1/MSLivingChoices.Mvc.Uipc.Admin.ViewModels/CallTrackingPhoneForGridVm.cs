using System;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Mvc.Uipc.Admin.ViewModels
{
	public class CallTrackingPhoneForGridVm
	{
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

		public DateTime? ExpiresDate
		{
			get
			{
				DateTime value;
				DateTime? disconnectDate = this.DisconnectDate;
				if (disconnectDate.HasValue)
				{
					disconnectDate = this.DisconnectDate;
					value = disconnectDate.Value;
					return new DateTime?(value.Add(new TimeSpan(60, 0, 0, 0)));
				}
				disconnectDate = this.EndDate;
				if (!disconnectDate.HasValue)
				{
					disconnectDate = null;
					return disconnectDate;
				}
				disconnectDate = this.EndDate;
				value = disconnectDate.Value;
				return new DateTime?(value.Add(new TimeSpan(60, 0, 0, 0)));
			}
		}

		public bool IsCallReview
		{
			get;
			set;
		}

		public bool IsWhisper
		{
			get;
			set;
		}

		public string Phone
		{
			get;
			set;
		}

		public string PhoneType
		{
			get;
			set;
		}

		public string ProvisionPhone
		{
			get;
			set;
		}

		public DateTime? StartDate
		{
			get;
			set;
		}

		public string Status
		{
			get
			{
				if (this.DisconnectDate.HasValue)
				{
					return "Disconnected";
				}
				return "Active";
			}
		}

		public CallTrackingPhoneForGridVm()
		{
		}
	}
}