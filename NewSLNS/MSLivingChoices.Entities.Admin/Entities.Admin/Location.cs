using System;

namespace MSLivingChoices.Entities.Admin
{
	[Serializable]
	public class Location
	{
		private double _longitude;

		private double _latitude;

		public double Latitude
		{
			get
			{
				return Math.Round(this._latitude, 4);
			}
			set
			{
				this._latitude = value;
			}
		}

		public double Longitude
		{
			get
			{
				return Math.Round(this._longitude, 4);
			}
			set
			{
				this._longitude = value;
			}
		}

		public Location()
		{
		}

		public override string ToString()
		{
			return string.Format("Lon: '{0}'; Lat: '{1}'", this.Longitude, this.Latitude);
		}
	}
}