using MSLivingChoices.Entities.Admin;
using MSLivingChoices.Entities.Admin.Enums;
using MSLivingChoices.SqlDacs.Helpers;
using MSLivingChoices.SqlDacs.SqlCommands;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace MSLivingChoices.SqlDacs.Admin.SqlCommands
{
	internal class GetDefaultAmenitiesCommand : CachedBaseCommand<List<Amenity>>
	{
		private List<Amenity> _result;

		protected int? SpParameter;

		protected readonly string ParameterName;

		public GetDefaultAmenitiesCommand(CommunityType communityType)
		{
			base.StoredProcedureName = CommonStoredProcedures.SpGetCommunityAmenityType;
			this.ParameterName = "@CommunityClassId";
			this.SpParameter = (int)(communityType);
			base.CacheKey = CachedBaseCommand<List<Amenity>>.GetCacheKey(new string[] { base.StoredProcedureName, "admin", this.ParameterName, this.SpParameter.ToString() });
		}

		public GetDefaultAmenitiesCommand(CommunityUnitType unitType)
		{
			base.StoredProcedureName = AdminStoredProcedures.SpGetCommunityUnitAmenityType;
			ParameterName = "@CommunityUnitClassId";
			SpParameter = (int)unitType;
			base.CacheKey = CachedBaseCommand<List<Amenity>>.GetCacheKey(base.StoredProcedureName, ParameterName, SpParameter.ToString());
		}

		protected override void CommandBody(SqlCommand command)
		{
			command.CommandType = CommandType.StoredProcedure;
			command.CommandText = base.StoredProcedureName;
			if (this.SpParameter.HasValue)
			{
				command.Parameters.Add(this.ParameterName, SqlDbType.Int).Value = this.SpParameter;
			}
			SqlDataReader reader = command.ExecuteReader();
			this._result = new List<Amenity>();
			while (reader.Read())
			{
				Amenity item = new Amenity()
				{
					Id = reader.GetNullableValue<long>("AmenityId"),
					ClassId = reader.GetNullableValue<int>("AmenityTypeId"),
					Name = reader["Description"].ToString()
				};
				this._result.Add(item);
			}
		}

		protected override List<Amenity> GetCommandResult(SqlCommand command)
		{
			return this._result;
		}
	}
}