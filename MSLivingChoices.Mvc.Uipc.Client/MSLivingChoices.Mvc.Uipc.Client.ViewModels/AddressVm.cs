using MSLivingChoices.Bcs.Client.Components;
using MSLivingChoices.Entities.Client;
using Newtonsoft.Json;
using System;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Mvc.Uipc.Client.ViewModels
{
	public class AddressVm : IAddress
	{
		public string City
		{
			get;
			set;
		}

		[JsonIgnore]
		public string CountryCode
		{
			get;
			set;
		}

		public string Full
		{
			get
			{
				return string.Format("{0}, {1}, {2} {3}", new object[] { this.Line, this.City, this.StateCode, this.Zip });
			}
		}

		public double? Latitude
		{
			get;
			set;
		}

		public string Line
		{
			get;
			set;
		}

		public double? Longitude
		{
			get;
			set;
		}

		[JsonIgnore]
		public string State
		{
			get
			{
				return LocationBc.Instance.GetStateName(this.StateCode);
			}
		}

		public string StateCode
		{
			get;
			set;
		}

		public string Zip
		{
			get;
			set;
		}

		public AddressVm()
		{
		}

		public override string ToString()
		{
			return this.Full;
		}
	}
}