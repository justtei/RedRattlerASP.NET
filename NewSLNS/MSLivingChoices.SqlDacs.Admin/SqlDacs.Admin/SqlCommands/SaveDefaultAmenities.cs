using MSLivingChoices.Configuration;
using MSLivingChoices.Entities.Admin;
using MSLivingChoices.Entities.Admin.Enums;
using MSLivingChoices.SqlDacs.Admin.Helpers;
using MSLivingChoices.SqlDacs.Helpers;
using MSLivingChoices.SqlDacs.SqlCommands;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace MSLivingChoices.SqlDacs.Admin.SqlCommands
{
	internal class SaveDefaultAmenities : FreeCacheBaseCommand
	{
		private readonly List<Amenity> _amenities;

		private readonly CommunityType? _communityType;

		private readonly CommunityUnitType? _communityUnitType;

		public SaveDefaultAmenities(List<Amenity> amenities, CommunityType? communityType, CommunityUnitType? communityUnitType)
		{
			base.StoredProcedureName = AdminStoredProcedures.SpPutAmenityType;
			this._amenities = amenities;
			this._communityType = communityType;
			this._communityUnitType = communityUnitType;
		}

		public SaveDefaultAmenities(CommunityType communityType, List<Amenity> amenities) : this(amenities, new CommunityType?(communityType), null)
		{
		}

		public SaveDefaultAmenities(CommunityUnitType communityUnitType, List<Amenity> amenities) : this(amenities, null, new CommunityUnitType?(communityUnitType))
		{
		}

		protected override void CommandBody(SqlCommand command)
		{
			command.CommandText = base.StoredProcedureName;
			command.CommandType = CommandType.StoredProcedure;
			command.Parameters.Add("@UserId", SqlDbType.UniqueIdentifier).Value = ConfigurationManager.Instance.CurrentUserId;
			command.Parameters.Add("@DateTimeStamp", SqlDbType.DateTime).Value = DateTime.Now;
			command.Parameters.Add("@CommunityClassId", SqlDbType.Int).Value = this._communityType.ValueOrDBNull<CommunityType?>();
			command.Parameters.Add("@CommunityUnitClassId", SqlDbType.Int).Value = this._communityUnitType.ValueOrDBNull<CommunityUnitType?>();
			SqlParameter sqlParameter = command.Parameters.Add("@AmenityTypeTable", SqlDbType.Structured);
			DataTable dataTable = this._amenities.GetAmenityTypeTable(this._communityType, this._communityUnitType);
			sqlParameter.Value = dataTable;
			command.ExecuteNonQuery();
		}
	}
}