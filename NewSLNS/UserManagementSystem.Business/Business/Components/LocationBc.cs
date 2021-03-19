using System;
using System.Collections.Generic;
using UserManagementSystem.Business;
using UserManagementSystem.DAL.Interfaces;
using UserManagementSystem.DAL.Interfaces.Components;
using UserManagementSystem.Entities;

namespace UserManagementSystem.Business.Components
{
	public class LocationBc
	{
		private readonly ILocationDac _locationDac;

		private static LocationBc _locationBc;

		private readonly static object Locker;

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
			this._locationDac = DacFactoryClient.GetFactory().GetLocationDac();
		}

		public List<City> GetCities(int stateId)
		{
			return this._locationDac.GetCities(stateId);
		}

		public List<Country> GetCountries()
		{
			return this._locationDac.GetAllCountries();
		}

		public List<State> GetStates(int countryId)
		{
			return this._locationDac.GetAllStates(countryId);
		}
	}
}