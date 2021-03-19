using System;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Mvc.Uipc.Admin.ViewModels
{
	public class AddressValidationItemVm
	{
		public string AddressLine1
		{
			get;
			set;
		}

		public string AddressLine2
		{
			get;
			set;
		}

		public long? CityId
		{
			get;
			set;
		}

		public long? CountryId
		{
			get;
			set;
		}

		public int Id
		{
			get;
			set;
		}

		public double Latitude
		{
			get;
			set;
		}

		public double Longitude
		{
			get;
			set;
		}

		public string PostalCode
		{
			get;
			set;
		}

		public long? StateId
		{
			get;
			set;
		}

		public AddressValidationItemVm()
		{
		}
	}
}