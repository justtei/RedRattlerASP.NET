using MSLivingChoices.Entities.Admin;
using MSLivingChoices.Entities.Admin.Enums;
using MSLivingChoices.Mvc.Uipc.Admin.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Mvc.Uipc.Admin.ViewModels
{
	public class ListingDetailsVm
	{
		public OwnerVm Builder
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

		public OwnerVm PropertyManager
		{
			get;
			set;
		}

		public bool ProvisionCallTrackingNumbers
		{
			get;
			set;
		}

		public ListingDetailsVm()
		{
		}

		public Community ToEntity()
		{
			return new Community()
			{
				PropertyManager = this.PropertyManager.ToEntity(OwnerType.PropertyManager),
				Builder = this.Builder.ToEntity(OwnerType.Builder),
				CallTrackingPhones = (this.ProvisionCallTrackingNumbers ? (
					from p in this.CallTrackingPhones.ConvertAll<CallTrackingPhone>((CallTrackingPhoneVm m) => m.ToEntity())
					where !string.IsNullOrEmpty(p.Phone)
					select p).ToList<CallTrackingPhone>() : new List<CallTrackingPhone>())
			};
		}
	}
}