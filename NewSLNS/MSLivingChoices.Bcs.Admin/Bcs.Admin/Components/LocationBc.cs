using MSLivingChoices.AddressGeocodingService;
using MSLivingChoices.Bcs.Admin;
using MSLivingChoices.Entities.Admin;
using MSLivingChoices.Entities.Admin.Enums;
using MSLivingChoices.IDacs.Admin;
using MSLivingChoices.IDacs.Admin.Components;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MSLivingChoices.Bcs.Admin.Components
{
	public class LocationBc
	{
		private readonly ILocationDac _locationDac;

		private static LocationBc _locationBc;

		private readonly static object Locker;

		public readonly Country DefaultCountry;

		public static LocationBc Instance
		{
			get
			{
				if (LocationBc._locationBc == null)
				{
					lock (LocationBc.Locker)
					{
						if (LocationBc._locationBc == null)
						{
							LocationBc._locationBc = new LocationBc();
						}
					}
				}
				return LocationBc._locationBc;
			}
		}

		static LocationBc()
		{
			LocationBc.Locker = new object();
		}

		private LocationBc()
		{
			this._locationDac = AdminDacFactoryClient.GetConcreteFactory().GetLocationDac();
			this.DefaultCountry = new Country()
			{
				Id = new long?((long)1)
			};
		}

		public AddressValidation GeocodeAddress(Address address)
		{
			AddressValidation addressValidation = new AddressValidation()
			{
				AddressId = address.Id,
				IsValid = false,
				Condidates = new List<AddressValidationItem>()
			};
			Country countryById = this.GetCountryById(address.Country.Id);
			State stateById = this.GetStateById(address.State.Id);
			City cityById = this.GetCityById(address.City.Id);
			LocationPoint locationPoint = AddressGeocoder.Geocode(countryById.Code, stateById.Code, cityById.Name, address.PostalCode, address.StreetAddress);
			addressValidation.IsValid = locationPoint != null;
			AddressValidationItem addressValidationItem = new AddressValidationItem()
			{
				AddressLine1 = address.StreetAddress,
				AddressLine2 = string.Format("{0} {1} {2} {3}", new object[] { cityById.Name, stateById.Code, address.PostalCode, countryById.Code }),
				CityId = cityById.Id,
				CountryId = countryById.Id,
				StateId = stateById.Id,
				Location = new Location()
				{
					Latitude = (addressValidation.IsValid ? locationPoint.Latitude : 0),
					Longitude = (addressValidation.IsValid ? locationPoint.Longitude : 0)
				},
				PostalCode = address.PostalCode
			};
			addressValidation.Condidates.Add(addressValidationItem);
			if (addressValidation.IsValid)
			{
				addressValidation.ValidAddress = addressValidation.Condidates.FirstOrDefault<AddressValidationItem>();
			}
			return addressValidation;
		}

		public List<County> GetAllCounties()
		{
			return this._locationDac.GetAllCounties();
		}

		public List<Country> GetAllCountries()
		{
			return this._locationDac.GetAllCountries();
		}

		public List<City> GetCities(long? stateId)
		{
			return this._locationDac.GetCities(stateId);
		}

		public List<City> GetCities(string stateCode, SearchType searchType)
		{
			if (searchType == SearchType.ProductsAndServices)
			{
				return this._locationDac.GetCitiesForServices(stateCode);
			}
			return this._locationDac.GetCities(stateCode, searchType);
		}

		public List<City> GetCities(long? stateId, SearchType searchType)
		{
			return this._locationDac.GetCities(stateId, searchType);
		}

		public List<City> GetCities(long? stateId, Guid userId)
		{
			return this._locationDac.GetCities(stateId, userId);
		}

		public City GetCityById(long? id)
		{
			return this._locationDac.GetCityById(id);
		}

		public Country GetCountryById(long? id)
		{
			return this._locationDac.GetCountryById(id);
		}

		public State GetStateById(long? id)
		{
			return this._locationDac.GetStateById(id);
		}

		public string GetStateName(string countryCode, string stateCode)
		{
			return stateCode;
		}

		public List<State> GetStates(long? countryId)
		{
			return this._locationDac.GetStates(countryId);
		}

		public List<State> GetStates(long? countryId, SearchType searchType)
		{
			if (searchType == SearchType.ProductsAndServices)
			{
				return this._locationDac.GetStatesForServices(countryId);
			}
			return this._locationDac.GetStates(countryId, searchType);
		}

		public List<State> GetStates(long? countryId, Guid userId)
		{
			return this._locationDac.GetStates(countryId, userId);
		}

		public List<Country> GetUsableCountries()
		{
			return this._locationDac.GetUsableCountries();
		}
	}
}