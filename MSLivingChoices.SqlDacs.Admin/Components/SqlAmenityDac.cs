using MSLivingChoices.Entities.Admin;
using MSLivingChoices.Entities.Admin.Enums;
using MSLivingChoices.IDacs.Admin.Components;
using MSLivingChoices.SqlDacs.Admin.SqlCommands;
using MSLivingChoices.SqlDacs.SqlCommands;
using System;
using System.Collections.Generic;

namespace MSLivingChoices.SqlDacs.Admin.Components
{
	public class SqlAmenityDac : IAmenityDac
	{
		public SqlAmenityDac()
		{
		}

		public List<Amenity> GetDefaultAmenities(CommunityType communityType)
		{
			GetDefaultAmenitiesCommand getDefaultAmenitiesCommand = new GetDefaultAmenitiesCommand(communityType);
			getDefaultAmenitiesCommand.Execute();
			return getDefaultAmenitiesCommand.CommandResult;
		}

		public List<Amenity> GetDefaultAmenities(CommunityUnitType unitType)
		{
			GetDefaultAmenitiesCommand getDefaultAmenitiesCommand = new GetDefaultAmenitiesCommand(unitType);
			getDefaultAmenitiesCommand.Execute();
			return getDefaultAmenitiesCommand.CommandResult;
		}
	}
}