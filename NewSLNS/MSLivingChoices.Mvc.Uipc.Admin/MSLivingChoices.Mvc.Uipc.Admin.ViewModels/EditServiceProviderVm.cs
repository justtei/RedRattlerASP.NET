using MSLivingChoices.Entities.Admin;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Mvc.Uipc.Admin.ViewModels
{
	public class EditServiceProviderVm : NewServiceProviderVm
	{
		[Required]
		public long? Id
		{
			get;
			set;
		}

		public string MarchexAccountId
		{
			get;
			set;
		}

		public EditServiceProviderVm()
		{
		}

		public override ServiceProvider ToEntity()
		{
			ServiceProvider entity = base.ToEntity();
			entity.Id = this.Id;
			entity.MarchexAccountId = this.MarchexAccountId;
			return entity;
		}
	}
}