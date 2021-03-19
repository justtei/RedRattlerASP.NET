using MSLivingChoices.Entities.Admin;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Web.Mvc;

namespace MSLivingChoices.Mvc.Uipc.Admin.ViewModels
{
	public class ContactVm
	{
		public long? ContactTypeId
		{
			get;
			set;
		}

		public List<SelectListItem> ContactTypes
		{
			get;
			set;
		}

		[AllowHtml]
		[StringLength(50)]
		public string FirstName
		{
			get;
			set;
		}

		public long? Id
		{
			get;
			set;
		}

		[AllowHtml]
		[StringLength(50)]
		public string LastName
		{
			get;
			set;
		}

		public ContactVm()
		{
			this.ContactTypes = new List<SelectListItem>();
		}

		public Contact ToEntity()
		{
			return new Contact()
			{
				Id = this.Id,
				ContactTypeId = this.ContactTypeId,
				FirstName = this.FirstName,
				LastName = this.LastName
			};
		}
	}
}