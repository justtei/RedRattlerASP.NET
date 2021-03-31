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
	internal class GetCommunityByIdCommand : CachedBaseCommand<Community>
	{
		private readonly long _id;

		private Community _community;

		public GetCommunityByIdCommand(long id)
		{
			base.StoredProcedureName = ClientStoredProcedures.SpGetCommunityClientDetail;
			this._id = id;
			base.CacheKey = CachedBaseCommand<Community>.GetCacheKey(new string[] { base.StoredProcedureName, this._id.ToString() });
		}

		protected override void CommandBody(SqlCommand command)
		{
			command.CommandText = base.StoredProcedureName;
			command.CommandType = CommandType.StoredProcedure;
			command.Parameters.Add("@CommunityId", SqlDbType.BigInt).Value = this._id;
			SqlDataReader sqlDataReader = command.ExecuteReader();
			if (sqlDataReader.Read())
			{
				this._community = sqlDataReader.GetCommunityDetail();
			}
			if (this._community == null)
			{
				return;
			}
			if (sqlDataReader.NextResult())
			{
				while (sqlDataReader.Read())
				{
					Image image = sqlDataReader.GetImage();
					this._community.Images.Add(image);
				}
			}
			if (sqlDataReader.NextResult())
			{
				while (sqlDataReader.Read())
				{
					string valueOrDefault = sqlDataReader.GetValueOrDefault<string>("Amenity");
					this._community.Amenities.Add(valueOrDefault);
				}
			}
			if (sqlDataReader.NextResult())
			{
				this._community.OfficeHours = sqlDataReader.GetOfficeHours();
			}
			if (sqlDataReader.NextResult())
			{
				this._community.Services = new List<string>();
				while (sqlDataReader.Read())
				{
					this._community.Services.Add(sqlDataReader.GetShortAdditionalInfo());
				}
			}
			if (sqlDataReader.NextResult())
			{
				this._community.AcceptedPayments = new List<string>();
				while (sqlDataReader.Read())
				{
					this._community.AcceptedPayments.Add(sqlDataReader.GetShortAdditionalInfo());
				}
			}
			if (sqlDataReader.NextResult())
			{
				this._community.ShcCategories = new List<string>();
				while (sqlDataReader.Read())
				{
					this._community.ShcCategories.Add(sqlDataReader.GetShortAdditionalInfo());
				}
			}
			if (sqlDataReader.NextResult() && sqlDataReader.Read())
			{
				this._community.Coupon = sqlDataReader.GetCoupon();
			}
			if (sqlDataReader.NextResult() && sqlDataReader.Read())
			{
				this._community.Pmc = sqlDataReader.GetOwner();
			}
			if (sqlDataReader.NextResult() && this._community.Pmc != null)
			{
				List<Image> images = new List<Image>();
				while (sqlDataReader.Read())
				{
					images.Add(sqlDataReader.GetImage());
				}
				this._community.Pmc.Logo = images.FirstOrDefault<Image>((Image x) => x.Type == ImageType.Logo) ?? (
					from x in images
					orderby x.Type
					select x).FirstOrDefault<Image>();
			}
			if (sqlDataReader.NextResult())
			{
				this._community.FloorPlans = new List<FloorPlan>();
				this._community.SpecHomes = new List<SpecHome>();
				this._community.Homes = new List<Home>();
				sqlDataReader.FillCommunityUnits(this._community.FloorPlans, this._community.SpecHomes, this._community.Homes);
				foreach (FloorPlan floorPlan in this._community.FloorPlans)
				{
					floorPlan.PackageId = this._community.PackageId;
				}
				foreach (SpecHome specHome in this._community.SpecHomes)
				{
					specHome.PackageId = this._community.PackageId;
				}
				foreach (Home home in this._community.Homes)
				{
					home.PackageId = this._community.PackageId;
				}
			}
			if (sqlDataReader.NextResult())
			{
				while (sqlDataReader.Read())
				{
					long value = sqlDataReader.GetValue<long>("CommunityUnitId");
					string str = sqlDataReader.GetValueOrDefault<string>("Amenity");
					if (this._community.FloorPlans.Any<FloorPlan>((FloorPlan x) => x.Id == value))
					{
						this._community.FloorPlans.First<FloorPlan>((FloorPlan x) => x.Id == value).Amenities.Add(str);
					}
					if (this._community.SpecHomes.Any<SpecHome>((SpecHome x) => x.Id == value))
					{
						this._community.SpecHomes.First<SpecHome>((SpecHome x) => x.Id == value).Amenities.Add(str);
					}
					if (!this._community.Homes.Any<Home>((Home x) => x.Id == value))
					{
						continue;
					}
					this._community.Homes.First<Home>((Home x) => x.Id == value).Amenities.Add(str);
				}
			}
			if (sqlDataReader.NextResult())
			{
				Dictionary<long, List<Image>> nums = new Dictionary<long, List<Image>>();
				while (sqlDataReader.Read())
				{
					long num = sqlDataReader.GetValue<long>("CommunityUnitId");
					Image image1 = sqlDataReader.GetImage();
					if (!nums.Keys.Contains<long>(num))
					{
						nums.Add(num, new List<Image>());
					}
					nums[num].Add(image1);
				}
				foreach (long key in nums.Keys)
				{
					if (this._community.FloorPlans.Any<FloorPlan>((FloorPlan x) => x.Id == key))
					{
						this._community.FloorPlans.First<FloorPlan>((FloorPlan x) => x.Id == key).Images = nums[key];
					}
					if (this._community.SpecHomes.Any<SpecHome>((SpecHome x) => x.Id == key))
					{
						this._community.SpecHomes.First<SpecHome>((SpecHome x) => x.Id == key).Images = nums[key];
					}
					if (!this._community.Homes.Any<Home>((Home x) => x.Id == key))
					{
						continue;
					}
					this._community.Homes.First<Home>((Home x) => x.Id == key).Images = nums[key];
				}
			}
			if (sqlDataReader.NextResult())
			{
				while (sqlDataReader.Read())
				{
					long value1 = sqlDataReader.GetValue<long>("CommunityUnitId");
					Coupon coupon = sqlDataReader.GetCoupon();
					if (this._community.FloorPlans.Any<FloorPlan>((FloorPlan x) => x.Id == value1))
					{
						this._community.FloorPlans.First<FloorPlan>((FloorPlan x) => x.Id == value1).Coupon = coupon;
					}
					if (this._community.SpecHomes.Any<SpecHome>((SpecHome x) => x.Id == value1))
					{
						this._community.SpecHomes.First<SpecHome>((SpecHome x) => x.Id == value1).Coupon = coupon;
					}
					if (!this._community.Homes.Any<Home>((Home x) => x.Id == value1))
					{
						continue;
					}
					this._community.Homes.First<Home>((Home x) => x.Id == value1).Coupon = coupon;
				}
			}
		}

		protected override Community GetCommandResult(SqlCommand command)
		{
			return this._community;
		}
	}
}