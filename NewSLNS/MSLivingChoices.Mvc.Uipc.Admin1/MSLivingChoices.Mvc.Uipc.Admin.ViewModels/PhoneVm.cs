using MSLivingChoices.Entities.Admin;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Web.Mvc;

namespace MSLivingChoices.Mvc.Uipc.Admin.ViewModels
{
	public class PhoneVm
	{
		public long? Id
		{
			get;
			set;
		}

		[AllowHtml]
		[StringLength(20)]
		public string Number
		{
			get;
			set;
		}

		public long? PhoneTypeId
		{
			get;
			set;
		}

		public List<SelectListItem> PhoneTypes
		{
			get;
			set;
		}

		public PhoneVm()
		{
			this.PhoneTypes = new List<SelectListItem>();
		}

		public Phone ToEntity()
		{
			return new Phone()
			{
				Id = this.Id,
				PhoneTypeId = this.PhoneTypeId,
				Number = this.Number
			};
		}
	}
}