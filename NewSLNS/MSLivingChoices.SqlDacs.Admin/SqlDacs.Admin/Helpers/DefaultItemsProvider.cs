using MSLivingChoices.Entities.Admin;
using MSLivingChoices.Entities.Admin.Enums;
using MSLivingChoices.SqlDacs.Admin.SqlCommands;
using MSLivingChoices.SqlDacs.SqlCommands;
using System;
using System.Collections.Generic;

namespace MSLivingChoices.SqlDacs.Admin.Helpers
{
	public class DefaultItemsProvider
	{
		private static DefaultItemsProvider _defaultItemsProvider;

		private readonly static object Locker;

		private List<KeyValuePair<int, string>> _defaultServiceTypes;

		private List<Amenity> _defaultFloorPlanAmenities;

		private List<Amenity> _defaultSpecHomeAmenities;

		private List<Amenity> _defaultHouseAmenities;

		public static DefaultItemsProvider Instance
		{
			get
			{
				if (DefaultItemsProvider._defaultItemsProvider == null)
				{
					lock (DefaultItemsProvider.Locker)
					{
						if (DefaultItemsProvider._defaultItemsProvider == null)
						{
							DefaultItemsProvider._defaultItemsProvider = new DefaultItemsProvider();
						}
					}
				}
				return DefaultItemsProvider._defaultItemsProvider;
			}
		}

		static DefaultItemsProvider()
		{
			DefaultItemsProvider.Locker = new object();
		}

		public DefaultItemsProvider()
		{
		}

		public List<Amenity> DefaultFloorPlanAmenities()
		{
			if (this._defaultFloorPlanAmenities == null)
			{
				GetDefaultAmenitiesCommand getDefaultFloorPlanAmenitiesCommand = new GetDefaultAmenitiesCommand(CommunityUnitType.FloorPlan);
				getDefaultFloorPlanAmenitiesCommand.Execute();
				this._defaultFloorPlanAmenities = getDefaultFloorPlanAmenitiesCommand.CommandResult;
			}
			return this._defaultFloorPlanAmenities;
		}

		public List<Amenity> DefaultHouseAmenities()
		{
			if (this._defaultHouseAmenities == null)
			{
				GetDefaultAmenitiesCommand getDefaultHouseAmenitiesCommand = new GetDefaultAmenitiesCommand(CommunityUnitType.House);
				getDefaultHouseAmenitiesCommand.Execute();
				this._defaultHouseAmenities = getDefaultHouseAmenitiesCommand.CommandResult;
			}
			return this._defaultHouseAmenities;
		}

		public List<KeyValuePair<int, string>> DefaultServiceTypes()
		{
			if (this._defaultServiceTypes == null)
			{
				GetAdditionalInfoCommand getDefaultServicesCommand = new GetAdditionalInfoCommand(AdditionalInfoClass.Service);
				getDefaultServicesCommand.Execute();
				this._defaultServiceTypes = getDefaultServicesCommand.CommandResult;
			}
			return this._defaultServiceTypes;
		}

		public List<Amenity> DefaultSpecHomeAmenities()
		{
			if (this._defaultSpecHomeAmenities == null)
			{
				GetDefaultAmenitiesCommand getDefaultSpecHomeAmenitiesCommand = new GetDefaultAmenitiesCommand(CommunityUnitType.SpecHome);
				getDefaultSpecHomeAmenitiesCommand.Execute();
				this._defaultSpecHomeAmenities = getDefaultSpecHomeAmenitiesCommand.CommandResult;
			}
			return this._defaultSpecHomeAmenities;
		}
	}
}