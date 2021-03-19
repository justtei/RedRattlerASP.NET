using MSLivingChoices.Entities.Admin;
using MSLivingChoices.Entities.Admin.Enums;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Web.Mvc;

namespace MSLivingChoices.Mvc.Uipc.Admin.ViewModels
{
	public class OwnerVm
	{
		public bool HasNewOwner
		{
			get;
			set;
		}

		public long? Id
		{
			get;
			set;
		}

		public NewOwnerVm NewOwner
		{
			get;
			set;
		}

		public List<SelectListItem> Owners
		{
			get;
			set;
		}

		public OwnerVm()
		{
			this.Owners = new List<SelectListItem>();
		}

		public Owner ToEntity(OwnerType ownerType)
		{
			if (this.HasNewOwner)
			{
				return this.NewOwner.ToEntity(ownerType);
			}
			if (!this.Id.HasValue)
			{
				return null;
			}
			return new Owner()
			{
				Id = this.Id,
				OwnerType = ownerType
			};
		}
	}
}