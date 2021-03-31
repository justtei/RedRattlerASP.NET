using System;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Entities.Client
{
	[Serializable]
	public class Address : IAddress
	{
		public string City
		{
			get;
			set;
		}

		public string CountryCode
		{
			get;
			set;
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

		public Address()
		{
		}

		public override string ToString()
		{
			return string.Format("{0}, {1} {2} {3}", new object[] { this.Line, this.City, this.StateCode, this.Zip });
		}
	}
}