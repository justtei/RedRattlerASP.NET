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
	internal class GetSpecHomeCommand : BaseCommand<SpecHome>
	{
		private readonly long _id;

		private readonly List<Amenity> _defaultAmenities;

		private readonly SpecHome _specHome;

		public GetSpecHomeCommand(long id)
		{
			base.StoredProcedureName = AdminStoredProcedures.SpGetCommunityUnitDetail;
			this._id = id;
			this._specHome = new SpecHome()
			{
				Id = new long?(this._id)
			};
			this._defaultAmenities = DefaultItemsProvider.Instance.DefaultSpecHomeAmenities();
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
				this._specHome.Amenities = reader.GetAmenities(this._defaultAmenities);
			}
			if (reader.NextResult())
			{
				this._specHome.Images = (
					from x in reader.GetImages()
					where x.ImageType == ImageType.Photo
					select x).ToList<Image>();
			}
			if (reader.NextResult())
			{
				this._specHome.Coupon = reader.GetCoupon();
			}
		}

		protected void GetBasicInfo(SqlDataReader reader)
		{
			long? nullable;
			long? nullable1;
			long? nullable2;
			long? nullable3;
			long? nullable4;
			this._specHome.PriceRange = new MeasureBoundary<decimal, MoneyType>();
			this._specHome.Deposit = new MeasureBoundary<decimal, MoneyType>();
			this._specHome.ApplicationFee = new MeasureBoundary<decimal, MoneyType>();
			this._specHome.PetDeposit = new MeasureBoundary<decimal, MoneyType>();
			this._specHome.LivingSpace = new MeasureBoundary<int, LivingSpaceMeasure>();
			if (reader.Read())
			{
				this._specHome.Name = reader["Name"].ToString();
				this._specHome.Description = reader["Description"].ToString();
				this._specHome.PriceRange.Min = reader.GetNullableValue<decimal>("PricedFrom");
				this._specHome.PriceRange.Max = reader.GetNullableValue<decimal>("PricedTo");
				this._specHome.PriceRange.Measure = reader.GetEnum<MoneyType>("PriceCurrencyTypeId");
				this._specHome.Deposit.Min = reader.GetNullableValue<decimal>("DepositFrom");
				this._specHome.Deposit.Max = reader.GetNullableValue<decimal>("DepositTo");
				this._specHome.Deposit.Measure = reader.GetEnum<MoneyType>("DepositCurrencyTypeId");
				this._specHome.ApplicationFee.Min = reader.GetNullableValue<decimal>("ApplicationFeeFrom");
				this._specHome.ApplicationFee.Max = reader.GetNullableValue<decimal>("ApplicationFeeTo");
				this._specHome.ApplicationFee.Measure = reader.GetEnum<MoneyType>("ApplicationFeeCurrencyTypeId");
				this._specHome.PetDeposit.Min = reader.GetNullableValue<decimal>("PetDepositFrom");
				this._specHome.PetDeposit.Max = reader.GetNullableValue<decimal>("PetDepositTo");
				this._specHome.PetDeposit.Measure = reader.GetEnum<MoneyType>("PetDepositCurrencyTypeId");
				this._specHome.SaleType = reader.GetEnum<SaleType>("SaleTypeId");
				this._specHome.Status = reader.GetEnum<SpecHomeStatus>("SpecHomeStatusTypeId");
				SpecHome specHome = this._specHome;
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
				specHome.BedroomFromId = nullable1;
				SpecHome specHome1 = this._specHome;
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
				specHome1.BedroomToId = nullable2;
				SpecHome specHome2 = this._specHome;
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
				specHome2.BathroomFromId = nullable3;
				SpecHome specHome3 = this._specHome;
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
				specHome3.BathroomToId = nullable4;
				this._specHome.LivingSpace.Min = reader.GetNullableValue<int>("LivingSpaceFrom");
				this._specHome.LivingSpace.Max = reader.GetNullableValue<int>("LivingSpaceTo");
				this._specHome.LivingSpace.Measure = reader.GetEnum<LivingSpaceMeasure>("LivingSpaceUnitOfMeasureTypeId");
			}
		}

		protected override SpecHome GetCommandResult(SqlCommand command)
		{
			return this._specHome;
		}
	}
}