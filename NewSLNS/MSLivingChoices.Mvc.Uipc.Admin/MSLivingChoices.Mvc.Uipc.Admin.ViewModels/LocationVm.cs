using MSLivingChoices.Entities.Admin;
using System;

namespace MSLivingChoices.Mvc.Uipc.Admin.ViewModels
{
	public class LocationVm
	{
		private double? _latitude;

		private double? _longitude;

		public double? Latitude
		{
			get
			{
				if (!this._latitude.HasValue)
				{
					return null;
				}
				return new double?(Math.Round(this._latitude.Value, 4));
			}
			set
			{
				this._latitude = value;
			}
		}

		public double? Longitude
		{
			get
			{
				if (!this._longitude.HasValue)
				{
					return null;
				}
				return new double?(Math.Round(this._longitude.Value, 4));
			}
			set
			{
				this._longitude = value;
			}
		}

		public LocationVm()
		{
		}

		public Location ToEntity()
		{
			Location location = new Location();
			double? latitude = this.Latitude;
			location.Latitude = (latitude.HasValue ? latitude.GetValueOrDefault() : 0);
			latitude = this.Longitude;
			location.Longitude = (latitude.HasValue ? latitude.GetValueOrDefault() : 0);
			return location;
		}

		public override string ToString()
		{
			return string.Format("Lon: '{0}'; Lat: '{1}'", this.Longitude, this.Latitude);
		}
	}
}