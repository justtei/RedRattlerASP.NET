using MSLivingChoices.Entities.Admin;
using MSLivingChoices.Entities.Admin.Enums;
using System.Collections.Generic;

namespace MSLivingChoices.IDacs.Admin.Components
{
	public interface IAmenityDac
	{
		List<Amenity> GetDefaultAmenities(CommunityType communityType);

		List<Amenity> GetDefaultAmenities(CommunityUnitType unitType);
	}
}