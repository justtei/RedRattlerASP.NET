using MSLivingChoices.Entities.Admin.Enums;
using MSLivingChoices.Mvc.Uipc.Admin.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Mvc.Uipc.Admin.ViewModels
{
	public class EditAmenitiesVm
	{
		public AmenityType CategoryClass
		{
			get;
			set;
		}

		public List<KeyValuePairVm<int, string>> Types
		{
			get;
			set;
		}

		public EditAmenitiesVm()
		{
			this.Types = new List<KeyValuePairVm<int, string>>();
		}
	}
}