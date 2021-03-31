using MSLivingChoices.Bcs.Client;
using MSLivingChoices.Configuration;
using MSLivingChoices.Entities.Client.Enums;
using MSLivingChoices.Entities.Client.Search;
using MSLivingChoices.Entities.Client.Search.Criteria;
using MSLivingChoices.IDacs.Client;
using MSLivingChoices.IDacs.Client.Components;
using MSLivingChoices.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace MSLivingChoices.Bcs.Client.Components
{
	public class LocationBc
	{
		private readonly ILocationDac _locationDac;

		private readonly Dictionary<string, string> _states;

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
			this._locationDac = ClientDacFactoryClient.GetConcreteFactory().GetLocationDac();
			this._states = this._locationDac.GetStates(1);
		}

		public List<SearchCriteria> GetAutocomplete(string lookupLocation)
		{
			List<SearchCriteria> searchCriterias = new List<SearchCriteria>();
			string str = "USA";
			if (!string.IsNullOrEmpty(lookupLocation) && !string.IsNullOrEmpty(str))
			{
				SearchCriteria lookupCriteria = this.GetLookupCriteria(lookupLocation, str);
				int maxAutocompleteVariantsCount = ConfigurationManager.Instance.MaxAutocompleteVariantsCount;
				SearchDepth depth = lookupCriteria.Depth;
				if ((int)depth - (int)SearchDepth.State <= (int)SearchDepth.State)
				{
					searchCriterias = this._locationDac.GetSearchAutocompleteVariantsForAddress(lookupCriteria, maxAutocompleteVariantsCount);
				}
				else if (depth == SearchDepth.Zip)
				{
					searchCriterias = this._locationDac.GetSearchAutocompleteVariantsForZip(lookupCriteria, maxAutocompleteVariantsCount);
				}
			}
			return searchCriterias;
		}

		private SearchCriteria GetLookupCriteria(string lookupLocation, string countryCode)
		{
			string str;
			SearchCriteria searchCriterium = new SearchCriteria();
			List<string> list = (
				from p in lookupLocation.Split(new char[] { ',' })
				select p.Trim()).ToList<string>();
			int count = list.Count;
			if (countryCode == "USA")
			{
				str = "^[0-9]*-?[0-9]*$";
			}
			else
			{
				str = (countryCode == "CAN" ? "^[a-zA-Z][0-9]([a-zA-Z]( ([0-9]([a-zA-Z][0-9]?)?)?)?)?$" : "^[0-9]+$");
			}
			searchCriterium.CountryCode(countryCode);
			if (!Regex.IsMatch(list[0], str))
			{
				searchCriterium.StateCode(list[count - 1]);
				if (count == 2)
				{
					searchCriterium.City(list[0]);
				}
				else if (count == 3)
				{
					searchCriterium.City(list[1]);
				}
			}
			else
			{
				searchCriterium.Zip(list[0]);
				if (count == 2)
				{
					searchCriterium.StateCode(list[1]);
				}
				else if (count == 3)
				{
					searchCriterium.City(list[1]);
					searchCriterium.StateCode(list[2]);
				}
			}
			return searchCriterium;
		}

		public string GetStateName(string stateCode)
		{
			if (stateCode.IsNullOrEmpty() || !this._states.ContainsKey(stateCode))
			{
				return stateCode;
			}
			return this._states[stateCode];
		}

		public LookupLocationValidationResult ValidateLookupLocation(string lookupLocation)
		{
			LookupLocationValidationResult lookupLocationValidationResult = new LookupLocationValidationResult();
			string str = "USA";
			if (!string.IsNullOrEmpty(lookupLocation) && !string.IsNullOrEmpty(str))
			{
				SearchCriteria lookupCriteria = this.GetLookupCriteria(lookupLocation, str);
				lookupCriteria = lookupCriteria.ToSearchableCriteria();
				SearchDepth depth = lookupCriteria.Depth;
				if ((int)depth - (int)SearchDepth.State <= (int)SearchDepth.State)
				{
					lookupCriteria = this._locationDac.ValidateAddress(lookupCriteria);
				}
				else if (depth != SearchDepth.Zip)
				{
					lookupCriteria = null;
				}
				else
				{
					lookupCriteria = this._locationDac.ValidateZip(lookupCriteria);
				}
				if (lookupCriteria != null)
				{
					lookupLocationValidationResult.IsValid = true;
					lookupLocationValidationResult.Criteria = lookupCriteria;
					lookupLocationValidationResult.Variants = new List<SearchCriteria>();
				}
				else
				{
					lookupLocationValidationResult.IsValid = false;
					lookupLocationValidationResult.Criteria = null;
					lookupLocationValidationResult.Variants = this.GetAutocomplete(lookupLocation);
				}
			}
			return lookupLocationValidationResult;
		}
	}
}