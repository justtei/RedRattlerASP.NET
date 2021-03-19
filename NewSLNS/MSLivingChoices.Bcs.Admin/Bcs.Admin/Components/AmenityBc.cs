using MSLivingChoices.Bcs.Admin;
using MSLivingChoices.Entities.Admin;
using MSLivingChoices.Entities.Admin.Enums;
using MSLivingChoices.IDacs.Admin;
using MSLivingChoices.IDacs.Admin.Components;
using System;
using System.Collections.Generic;

namespace MSLivingChoices.Bcs.Admin.Components
{
	public class AmenityBc
	{
		private readonly IAmenityDac _amenityDac;

		private static AmenityBc _amenityBc;

		private readonly static object Locker;

		public static AmenityBc Instance
		{
			get
			{
				if (AmenityBc._amenityBc == null)
				{
					lock (AmenityBc.Locker)
					{
						if (AmenityBc._amenityBc == null)
						{
							AmenityBc._amenityBc = new AmenityBc();
						}
					}
				}
				return AmenityBc._amenityBc;
			}
		}

		static AmenityBc()
		{
			AmenityBc.Locker = new object();
		}

		private AmenityBc()
		{
			this._amenityDac = AdminDacFactoryClient.GetConcreteFactory().GetAmenityDac();
		}

		public List<Amenity> GetDefaultAmenities(CommunityType communityType)
		{
			return this._amenityDac.GetDefaultAmenities(communityType);
		}

		public List<Amenity> GetDefaultAmenities(CommunityUnitType unitType)
		{
			return this._amenityDac.GetDefaultAmenities(unitType);
		}
	}
}