using MSLivingChoices.Entities.Admin;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Web.Mvc;

namespace MSLivingChoices.Mvc.Uipc.Admin.ViewModels
{
	public class AddressVm
	{
		[Required]
		public CityVm City
		{
			get;
			set;
		}

		[Required]
		public CountryVm Country
		{
			get;
			set;
		}

		public long? Id
		{
			get;
			set;
		}

		public LocationVm Location
		{
			get;
			set;
		}

		[AllowHtml]
		[Required]
		[StringLength(10)]
		public string PostalCode
		{
			get;
			set;
		}

		[Required]
		public StateVm State
		{
			get;
			set;
		}

		[AllowHtml]
		[Required]
		[StringLength(50)]
		public string StreetAddress
		{
			get;
			set;
		}

		public AddressVm()
		{
			this.Country = new CountryVm();
			this.State = new StateVm();
			this.City = new CityVm();
			this.Location = new LocationVm();
		}

		public Address ToEntity()
		{
			return new Address()
			{
				Id = this.Id,
				StreetAddress = this.StreetAddress,
				Country = this.Country.ToEntity(),
				State = this.State.ToEntity(),
				City = this.City.ToEntity(),
				PostalCode = this.PostalCode,
				Location = this.Location.ToEntity()
			};
		}
	}
}