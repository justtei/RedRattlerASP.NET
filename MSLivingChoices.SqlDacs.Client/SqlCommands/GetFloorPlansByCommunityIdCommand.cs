using MSLivingChoices.Entities.Client;
using MSLivingChoices.Entities.Client.Enums;
using MSLivingChoices.SqlDacs.Client.Helpers;
using MSLivingChoices.SqlDacs.Helpers;
using MSLivingChoices.SqlDacs.SqlCommands;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.SqlDacs.Client.SqlCommands
{
	internal class GetFloorPlansByCommunityIdCommand : CachedBaseCommand<List<FloorPlan>>
	{
		private readonly long _communityId;

		private const CommunityUnitType UnitType = CommunityUnitType.FloorPlan;

		private readonly List<FloorPlan> _floorPlans;

		public GetFloorPlansByCommunityIdCommand(long communityId)
		{
			base.StoredProcedureName = ClientStoredProcedures.SpGetCommunityUnitsByCommunity;
			this._communityId = communityId;
			this._floorPlans = new List<FloorPlan>();
			base.CacheKey = CachedBaseCommand<List<FloorPlan>>.GetCacheKey(new string[] { base.StoredProcedureName, this._communityId.ToString(), CommunityUnitType.FloorPlan.ToString() });
		}

		protected override void CommandBody(SqlCommand command)
		{
			command.CommandText = base.StoredProcedureName;
			command.CommandType = CommandType.StoredProcedure;
			command.Parameters.Add("@CommunityId", SqlDbType.BigInt).Value = this._communityId;
			command.Parameters.Add("@CommunityUnitClassId", SqlDbType.Int).Value = 1;
			SqlDataReader sqlDataReader = command.ExecuteReader();
			while (sqlDataReader.Read())
			{
				FloorPlan floorPlan = sqlDataReader.GetFloorPlan();
				this._floorPlans.Add(floorPlan);
			}
			if (sqlDataReader.NextResult())
			{
				while (sqlDataReader.Read())
				{
					long value = sqlDataReader.GetValue<long>("CommunityUnitId");
					string valueOrDefault = sqlDataReader.GetValueOrDefault<string>("Amenity");
					this._floorPlans.First<FloorPlan>((FloorPlan x) => x.Id == value).Amenities.Add(valueOrDefault);
				}
			}
			if (sqlDataReader.NextResult())
			{
				Dictionary<long, List<Image>> nums = new Dictionary<long, List<Image>>();
				while (sqlDataReader.Read())
				{
					long num = sqlDataReader.GetValue<long>("CommunityUnitId");
					Image image = sqlDataReader.GetImage();
					if (!nums.Keys.Contains<long>(num))
					{
						nums.Add(num, new List<Image>());
					}
					nums[num].Add(image);
				}
				foreach (long key in nums.Keys)
				{
					this._floorPlans.First<FloorPlan>((FloorPlan x) => x.Id == key).Images = nums[key];
				}
			}
			if (sqlDataReader.NextResult())
			{
				while (sqlDataReader.Read())
				{
					long value1 = sqlDataReader.GetValue<long>("CommunityUnitId");
					Coupon coupon = sqlDataReader.GetCoupon();
					this._floorPlans.First<FloorPlan>((FloorPlan x) => x.Id == value1).Coupon = coupon;
				}
			}
		}

		protected override List<FloorPlan> GetCommandResult(SqlCommand command)
		{
			return this._floorPlans;
		}
	}
}