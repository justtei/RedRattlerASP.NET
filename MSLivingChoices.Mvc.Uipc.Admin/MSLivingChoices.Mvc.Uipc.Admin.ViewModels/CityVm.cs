using MSLivingChoices.Entities.Admin;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Web.Mvc;

namespace MSLivingChoices.Mvc.Uipc.Admin.ViewModels
{
	public class CityVm
	{
		public List<SelectListItem> AvailableCities
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

		public CityVm()
		{
		}

		public City ToEntity()
		{
			return new City()
			{
				Id = this.Id,
				Name = this.Name
			};
		}
	}
}