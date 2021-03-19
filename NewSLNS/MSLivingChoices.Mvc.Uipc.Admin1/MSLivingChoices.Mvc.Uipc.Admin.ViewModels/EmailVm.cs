using MSLivingChoices.Entities.Admin;
using MSLivingChoices.Mvc.Uipc.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Web.Mvc;

namespace MSLivingChoices.Mvc.Uipc.Admin.ViewModels
{
	public class EmailVm
	{
		[AllowHtml]
		[Email]
		[StringLength(255)]
		public string Email
		{
			get;
			set;
		}

		public long? EmailTypeId
		{
			get;
			set;
		}

		public List<SelectListItem> EmailTypes
		{
			get;
			set;
		}

		public long? Id
		{
			get;
			set;
		}

		public EmailVm()
		{
			this.EmailTypes = new List<SelectListItem>();
		}

		public MSLivingChoices.Entities.Admin.Email ToEntity()
		{
			return new MSLivingChoices.Entities.Admin.Email()
			{
				Id = this.Id,
				EmailTypeId = this.EmailTypeId,
				Value = this.Email
			};
		}
	}
}