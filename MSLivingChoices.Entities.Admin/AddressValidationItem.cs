using System;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Entities.Admin
{
	public class AddressValidationItem
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

		public MSLivingChoices.Entities.Admin.Location Location
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

		public AddressValidationItem()
		{
		}
	}
}