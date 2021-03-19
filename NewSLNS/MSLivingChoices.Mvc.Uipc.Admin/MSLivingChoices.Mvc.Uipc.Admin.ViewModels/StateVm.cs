using MSLivingChoices.Entities.Admin;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Web.Mvc;

namespace MSLivingChoices.Mvc.Uipc.Admin.ViewModels
{
	public class StateVm
	{
		public List<SelectListItem> AvailableStates
		{
			get;
			set;
		}

		public string Code
		{
			get;
			set;
		}

		[Required]
		public long? Id
		{
			get;
			set;
		}

		public string Name
		{
			get;
			set;
		}

		public StateVm()
		{
		}

		public State ToEntity()
		{
			return new State()
			{
				Id = this.Id,
				Code = this.Code,
				Name = this.Name
			};
		}
	}
}