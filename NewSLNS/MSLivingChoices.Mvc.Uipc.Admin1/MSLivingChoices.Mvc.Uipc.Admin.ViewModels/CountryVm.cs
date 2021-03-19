using MSLivingChoices.Entities.Admin;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Web.Mvc;

namespace MSLivingChoices.Mvc.Uipc.Admin.ViewModels
{
	public class CountryVm
	{
		public List<SelectListItem> AvailableCountries
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

		public CountryVm()
		{
		}

		public Country ToEntity()
		{
			return new Country()
			{
				Id = this.Id,
				Code = this.Code,
				Name = this.Name
			};
		}
	}
}