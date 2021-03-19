using MSLivingChoices.Entities.Admin;
using MSLivingChoices.Mvc.Uipc.Admin.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web.Mvc;

namespace MSLivingChoices.Mvc.Uipc.Admin.ViewModels
{
	public class CommunityCallTrackingPhonesVm
	{
		[CallTrackingListValidation]
		public List<CallTrackingPhoneVm> CallTrackingPhones
		{
			get;
			set;
		}

		[Required]
		public long? CommunityId
		{
			get;
			set;
		}

		[AllowHtml]
		public string CommunityName
		{
			get;
			set;
		}

		public bool ProvisionCallTrackingNumbers
		{
			get;
			set;
		}

		public DateTime? PublishEnd
		{
			get;
			set;
		}

		public DateTime? PublishStart
		{
			get;
			set;
		}

		public CommunityCallTrackingPhonesVm()
		{
		}

		public List<CallTrackingPhone> ToEntity()
		{
			List<CallTrackingPhone> callTrackingPhones = null;
			if (this.CallTrackingPhones != null)
			{
				if (!this.ProvisionCallTrackingNumbers)
				{
					this.CallTrackingPhones.ForEach((CallTrackingPhoneVm c) => c.IsDisconnected = true);
				}
				callTrackingPhones = (
					from p in this.CallTrackingPhones.ConvertAll<CallTrackingPhone>((CallTrackingPhoneVm x) => x.ToEntity())
					where !string.IsNullOrEmpty(p.Phone)
					select p).ToList<CallTrackingPhone>();
			}
			return callTrackingPhones;
		}
	}
}