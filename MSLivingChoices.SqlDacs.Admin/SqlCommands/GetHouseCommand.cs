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
	internal class GetHouseCommand : BaseCommand<House>
	{
		private readonly long _id;

		private readonly List<Amenity> _defaultAmenities;

		private readonly House _house;

		public GetHouseCommand(long id)
		{
			base.StoredProcedureName = AdminStoredProcedures.SpGetCommunityUnitDetail;
			this._id = id;
			this._house = new House()
			{
				Id = new long?(this._id)
			};
			this._defaultAmenities = DefaultItemsProvider.Instance.DefaultHouseAmenities();
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
				this._house.Amenities = reader.GetAmenities(this._defaultAmenities);
			}
			if (reader.NextResult())
			{
				this._house.Images = (
					from x in reader.GetImages()
					where x.ImageType == ImageType.Photo
					select x).ToList<Image>();
			}
			if (reader.NextResult())
			{
				this._house.Coupon = reader.GetCoupon();
			}
			if (reader.NextResult())
			{
				this._house.Address = reader.GetAddress();
			}
		}

		protected void GetBasicInfo(SqlDataReader reader)
		{
			long? nullable;
			long? nullable1;
			long? nullable2;
			long? nullable3;
			long? nullable4;
			this._house.PriceRange = new MeasureBoundary<decimal, MoneyType>();
			this._house.Deposit = new MeasureBoundary<decimal, MoneyType>();
			this._house.ApplicationFee = new MeasureBoundary<decimal, MoneyType>();
			this._house.PetDeposit = new MeasureBoundary<decimal, MoneyType>();
			this._house.LivingSpace = new MeasureBoundary<int, LivingSpaceMeasure>();
			if (reader.Read())
			{
				this._house.Name = reader["Name"].ToString();
				this._house.Description = reader["Description"].ToString();
				this._house.PriceRange.Min = reader.GetNullableValue<decimal>("PricedFrom");
				this._house.PriceRange.Max = reader.GetNullableValue<decimal>("PricedTo");
				this._house.PriceRange.Measure = reader.GetEnum<MoneyType>("PriceCurrencyTypeId");
				this._house.Deposit.Min = reader.GetNullableValue<decimal>("DepositFrom");
				this._house.Deposit.Max = reader.GetNullableValue<decimal>("DepositTo");
				this._house.Deposit.Measure = reader.GetEnum<MoneyType>("DepositCurrencyTypeId");
				this._house.ApplicationFee.Min = reader.GetNullableValue<decimal>("ApplicationFeeFrom");
				this._house.ApplicationFee.Max = reader.GetNullableValue<decimal>("ApplicationFeeTo");
				this._house.ApplicationFee.Measure = reader.GetEnum<MoneyType>("ApplicationFeeCurrencyTypeId");
				this._house.PetDeposit.Min = reader.GetNullableValue<decimal>("PetDepositFrom");
				this._house.PetDeposit.Max = reader.GetNullableValue<decimal>("PetDepositTo");
				this._house.PetDeposit.Measure = reader.GetEnum<MoneyType>("PetDepositCurrencyTypeId");
				this._house.SaleType = reader.GetEnum<HomeSaleType>("SaleTypeId");
				this._house.YearBuilt = reader.GetNullableValue<int>("YearBuilt");
				House house = this._house;
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
				house.BedroomFromId = nullable1;
				House house1 = this._house;
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
				house1.BedroomToId = nullable2;
				House house2 = this._house;
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
				house2.BathroomFromId = nullable3;
				House house3 = this._house;
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
				house3.BathroomToId = nullable4;
				this._house.LivingSpace.Min = reader.GetNullableValue<int>("LivingSpaceFrom");
				this._house.LivingSpace.Max = reader.GetNullableValue<int>("LivingSpaceTo");
				this._house.LivingSpace.Measure = reader.GetEnum<LivingSpaceMeasure>("LivingSpaceUnitOfMeasureTypeId");
			}
		}

		protected override House GetCommandResult(SqlCommand command)
		{
			return this._house;
		}
	}
}