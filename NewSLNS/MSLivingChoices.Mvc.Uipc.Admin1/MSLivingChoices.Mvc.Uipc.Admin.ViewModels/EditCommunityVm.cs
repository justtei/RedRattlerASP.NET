using MSLivingChoices.Entities.Admin;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Mvc.Uipc.Admin.ViewModels
{
	public class EditCommunityVm : NewCommunityVm
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

		public EditCommunityVm()
		{
		}

		public override Community ToEntity()
		{
			Community entity = base.ToEntity();
			entity.Id = this.Id;
			entity.MarchexAccountId = this.MarchexAccountId;
			return entity;
		}
	}
}