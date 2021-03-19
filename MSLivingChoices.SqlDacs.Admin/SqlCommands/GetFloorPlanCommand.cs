using MSLivingChoices.Entities.Admin;
using MSLivingChoices.Entities.Admin.Enums;
using MSLivingChoices.SqlDacs.Admin.Helpers;
using MSLivingChoices.SqlDacs.Helpers;
using MSLivingChoices.SqlDacs.SqlCommands;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.SqlDacs.Admin.SqlCommands
{
	internal class GetFloorPlanCommand : BaseCommand<FloorPlan>
	{
		private readonly long _id;

		private readonly List<Amenity> _defaultAmenities;

		private readonly FloorPlan _floorPlan;

		public GetFloorPlanCommand(long id)
		{
			base.StoredProcedureName = AdminStoredProcedures.SpGetCommunityUnitDetail;
			this._id = id;
			this._floorPlan = new FloorPlan()
			{
				Id = new long?(this._id)
			};
			this._defaultAmenities = DefaultItemsProvider.Instance.DefaultFloorPlanAmenities();
		}

		protected override void CommandBody(SqlCommand command)
		{
			command.CommandText = base.StoredProcedureName;
			command.CommandType = CommandType.StoredProcedure;
			command.Parameters.Add("@CommunityUnitId", SqlDbType.BigInt).Value = this._id;
			SqlDataReader reader = command.ExecuteReader();
			this.GetBasicInfo(reader);
			if (reader.NextResult())
			{
				this._floorPlan.Amenities = reader.GetAmenities(this._defaultAmenities);
			}
			if (reader.NextResult())
			{
				this._floorPlan.Images = (
					from x in reader.GetImages()
					where x.ImageType == ImageType.Photo
					select x).ToList<Image>();
			}
			if (reader.NextResult())
			{
				this._floorPlan.Coupon = reader.GetCoupon();
			}
		}

		protected void GetBasicInfo(SqlDataReader reader)
		{
			long? nullable;
			long? nullable1;
			long? nullable2;
			long? nullable3;
			long? nullable4;
			this._floorPlan.PriceRange = new MeasureBoundary<decimal, MoneyType>();
			this._floorPlan.Deposit = new MeasureBoundary<decimal, MoneyType>();
			this._floorPlan.ApplicationFee = new MeasureBoundary<decimal, MoneyType>();
			this._floorPlan.PetDeposit = new MeasureBoundary<decimal, MoneyType>();
			this._floorPlan.LivingSpace = new MeasureBoundary<int, LivingSpaceMeasure>();
			if (reader.Read())
			{
				this._floorPlan.Name = reader["Name"].ToString();
				this._floorPlan.PriceRange.Min = reader.GetNullableValue<decimal>("PricedFrom");
				this._floorPlan.PriceRange.Max = reader.GetNullableValue<decimal>("PricedTo");
				this._floorPlan.PriceRange.Measure = reader.GetEnum<MoneyType>("PriceCurrencyTypeId");
				this._floorPlan.Deposit.Min = reader.GetNullableValue<decimal>("DepositFrom");
				this._floorPlan.Deposit.Max = reader.GetNullableValue<decimal>("DepositTo");
				this._floorPlan.Deposit.Measure = reader.GetEnum<MoneyType>("DepositCurrencyTypeId");
				this._floorPlan.ApplicationFee.Min = reader.GetNullableValue<decimal>("ApplicationFeeFrom");
				this._floorPlan.ApplicationFee.Max = reader.GetNullableValue<decimal>("ApplicationFeeTo");
				this._floorPlan.ApplicationFee.Measure = reader.GetEnum<MoneyType>("ApplicationFeeCurrencyTypeId");
				this._floorPlan.PetDeposit.Min = reader.GetNullableValue<decimal>("PetDepositFrom");
				this._floorPlan.PetDeposit.Max = reader.GetNullableValue<decimal>("PetDepositTo");
				this._floorPlan.PetDeposit.Measure = reader.GetEnum<MoneyType>("PetDepositCurrencyTypeId");
				FloorPlan floorPlan = this._floorPlan;
				int? nullableValue = reader.GetNullableValue<int>("BedroomFromId");
				if (nullableValue.HasValue)
				{
					nullable1 = new long?((long)nullableValue.GetValueOrDefault());
				}
				else
				{
					nullable = null;
					nullable1 = nullable;
				}
				floorPlan.BedroomFromId = nullable1;
				FloorPlan floorPlan1 = this._floorPlan;
				nullableValue = reader.GetNullableValue<int>("BedroomToId");
				if (nullableValue.HasValue)
				{
					nullable2 = new long?((long)nullableValue.GetValueOrDefault());
				}
				else
				{
					nullable = null;
					nullable2 = nullable;
				}
				floorPlan1.BedroomToId = nullable2;
				FloorPlan floorPlan2 = this._floorPlan;
				nullableValue = reader.GetNullableValue<int>("BathroomFromId");
				if (nullableValue.HasValue)
				{
					nullable3 = new long?((long)nullableValue.GetValueOrDefault());
				}
				else
				{
					nullable = null;
					nullable3 = nullable;
				}
				floorPlan2.BathroomFromId = nullable3;
				FloorPlan floorPlan3 = this._floorPlan;
				nullableValue = reader.GetNullableValue<int>("BathroomToId");
				if (nullableValue.HasValue)
				{
					nullable4 = new long?((long)nullableValue.GetValueOrDefault());
				}
				else
				{
					nullable = null;
					nullable4 = nullable;
				}
				floorPlan3.BathroomToId = nullable4;
				this._floorPlan.LivingSpace.Min = reader.GetNullableValue<int>("LivingSpaceFrom");
				this._floorPlan.LivingSpace.Max = reader.GetNullableValue<int>("LivingSpaceTo");
				this._floorPlan.LivingSpace.Measure = reader.GetEnum<LivingSpaceMeasure>("LivingSpaceUnitOfMeasureTypeId");
			}
		}

		protected override FloorPlan GetCommandResult(SqlCommand command)
		{
			return this._floorPlan;
		}
	}
}