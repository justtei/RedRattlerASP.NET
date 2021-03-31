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
	internal class GetHomesByCommunityIdCommand : CachedBaseCommand<List<Home>>
	{
		private readonly long _communityId;

		private const CommunityUnitType UnitType = CommunityUnitType.Home;

		private readonly List<Home> _homes;

		public GetHomesByCommunityIdCommand(long communityId)
		{
			base.StoredProcedureName = ClientStoredProcedures.SpGetCommunityUnitsByCommunity;
			this._communityId = communityId;
			this._homes = new List<Home>();
			base.CacheKey = CachedBaseCommand<List<Home>>.GetCacheKey(new string[] { base.StoredProcedureName, this._communityId.ToString(), CommunityUnitType.Home.ToString() });
		}

		protected override void CommandBody(SqlCommand command)
		{
			command.CommandText = base.StoredProcedureName;
			command.CommandType = CommandType.StoredProcedure;
			command.Parameters.Add("@CommunityId", SqlDbType.BigInt).Value = this._communityId;
			command.Parameters.Add("@CommunityUnitClassId", SqlDbType.Int).Value = 3;
			SqlDataReader sqlDataReader = command.ExecuteReader();
			while (sqlDataReader.Read())
			{
				Home home = sqlDataReader.GetHome();
				this._homes.Add(home);
			}
			if (sqlDataReader.NextResult())
			{
				while (sqlDataReader.Read())
				{
					long value = sqlDataReader.GetValue<long>("CommunityUnitId");
					string valueOrDefault = sqlDataReader.GetValueOrDefault<string>("Amenity");
					this._homes.First<Home>((Home x) => x.Id == value).Amenities.Add(valueOrDefault);
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
					this._homes.First<Home>((Home x) => x.Id == key).Images = nums[key];
				}
			}
			if (sqlDataReader.NextResult())
			{
				while (sqlDataReader.Read())
				{
					long value1 = sqlDataReader.GetValue<long>("CommunityUnitId");
					Coupon coupon = sqlDataReader.GetCoupon();
					this._homes.First<Home>((Home x) => x.Id == value1).Coupon = coupon;
				}
			}
		}

		protected override List<Home> GetCommandResult(SqlCommand command)
		{
			return this._homes;
		}
	}
}