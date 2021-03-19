using MSLivingChoices.Entities.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Mvc.Uipc.Admin.ViewModels
{
	public class AddressValidationVm
	{
		public long? AddressId
		{
			get;
			set;
		}

		public bool IsAddressValid
		{
			get;
			set;
		}

		public double SelectedLatitude
		{
			get;
			set;
		}

		public double SelectedLongitude
		{
			get;
			set;
		}

		public int SelectedValidationItem
		{
			get;
			set;
		}

		public List<AddressValidationItemVm> ValidationItems
		{
			get;
			set;
		}

		public AddressValidationVm()
		{
		}

		public Address ToEntity()
		{
			Address address = new Address();
			if (this.ValidationItems != null)
			{
				AddressValidationItemVm validItem = this.ValidationItems.FirstOrDefault<AddressValidationItemVm>((AddressValidationItemVm i) => i.Id == this.SelectedValidationItem);
				if (validItem != null)
				{
					address.Id = this.AddressId;
					address.AddressLine1 = validItem.AddressLine1;
					address.AddressLine2 = validItem.AddressLine2;
					address.City = new City()
					{
						Id = validItem.CityId
					};
					address.Country = new Country()
					{
						Id = validItem.CountryId
					};
					address.Location = new Location()
					{
						Latitude = this.SelectedLatitude,
						Longitude = this.SelectedLongitude
					};
					address.PostalCode = validItem.PostalCode;
					address.State = new State()
					{
						Id = validItem.StateId
					};
				}
			}
			return address;
		}
	}
}