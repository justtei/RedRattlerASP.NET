using MSLivingChoices.Entities.Admin;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Mvc.Uipc.Admin.ViewModels
{
	public class PhoneListVm
	{
		public List<PhoneVm> AdditionalPhones
		{
			get;
			set;
		}

		public long? DefaultPhoneId
		{
			get;
			set;
		}

		[Required]
		public string DefaultPhoneNumber
		{
			get;
			set;
		}

		public long? DefaultPhoneTypeId
		{
			get;
			set;
		}

		public string DefaultPhoneTypeName
		{
			get;
			set;
		}

		public PhoneListVm()
		{
		}

		public List<Phone> ToEntityList()
		{
			List<Phone> result = new List<Phone>();
			Phone listingTypePhone = new Phone()
			{
				Id = this.DefaultPhoneId,
				PhoneTypeId = this.DefaultPhoneTypeId,
				Number = this.DefaultPhoneNumber
			};
			result.Add(listingTypePhone);
			foreach (PhoneVm phone in 
				from m in this.AdditionalPhones
				where !string.IsNullOrWhiteSpace(m.Number)
				select m)
			{
				result.Add(phone.ToEntity());
			}
			return result;
		}
	}
}