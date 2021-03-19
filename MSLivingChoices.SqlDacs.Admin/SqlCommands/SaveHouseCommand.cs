using MSLivingChoices.Entities.Admin;
using MSLivingChoices.SqlDacs.Admin.Helpers;
using MSLivingChoices.SqlDacs.Helpers;
using MSLivingChoices.SqlDacs.SqlCommands;
using System;
using System.Data;
using System.Data.SqlClient;

namespace MSLivingChoices.SqlDacs.Admin.SqlCommands
{
	internal class SaveHouseCommand : FreeCacheBaseCommand<House>
	{
		private readonly House _house;

		private readonly int _sequence;

		private readonly int _couponTypeId;

		public SaveHouseCommand(House house, int sequence, int couponTypeId)
		{
			base.StoredProcedureName = AdminStoredProcedures.SpPutCommunityUnitDetail;
			this._house = house;
			this._sequence = sequence;
			this._couponTypeId = couponTypeId;
		}

		protected override void CommandBody(SqlCommand command)
		{
			command.CommandText = base.StoredProcedureName;
			command.CommandType = CommandType.StoredProcedure;
			command.Parameters.Add("@CommunityUnitId", SqlDbType.BigInt).Value = (!this._house.Id.HasValue ? (long)-1 : this._house.Id.Value);
			command.Parameters.Add("@CommunityId", SqlDbType.BigInt).Value = this._house.Community.Id;
			command.Parameters.Add("@CommunityUnitClassId", SqlDbType.Int).Value = 3;
			command.Parameters.Add("@Name", SqlDbType.VarChar, 50).Value = this._house.Name.ValueOrDBNull<string>();
			command.Parameters.Add("@PricedFrom", SqlDbType.Money).Value = this._house.PriceRange.Min.ValueOrDBNull<decimal?>();
			command.Parameters.Add("@PricedTo", SqlDbType.Money).Value = this._house.PriceRange.Max.ValueOrDBNull<decimal?>();
			command.Parameters.Add("@PriceCurrencyTypeId", SqlDbType.Int).Value = (int)this._house.PriceRange.Measure;
			command.Parameters.Add("@DepositFrom", SqlDbType.Money).Value = this._house.Deposit.Min.ValueOrDBNull<decimal?>();
			command.Parameters.Add("@DepositTo", SqlDbType.Money).Value = this._house.Deposit.Max.ValueOrDBNull<decimal?>();
			command.Parameters.Add("@DepositCurrencyTypeId", SqlDbType.Int).Value = (int)this._house.Deposit.Measure;
			command.Parameters.Add("@ApplicationFeeFrom", SqlDbType.Money).Value = this._house.ApplicationFee.Min.ValueOrDBNull<decimal?>();
			command.Parameters.Add("@ApplicationFeeTo", SqlDbType.Money).Value = this._house.ApplicationFee.Max.ValueOrDBNull<decimal?>();
			command.Parameters.Add("@ApplicationFeeCurrencyTypeId", SqlDbType.Int).Value = (int)this._house.ApplicationFee.Measure;
			command.Parameters.Add("@PetDepositFrom", SqlDbType.Money).Value = this._house.PetDeposit.Min.ValueOrDBNull<decimal?>();
			command.Parameters.Add("@PetDepositTo", SqlDbType.Money).Value = this._house.PetDeposit.Max.ValueOrDBNull<decimal?>();
			command.Parameters.Add("@PetDepositCurrencyTypeId", SqlDbType.Int).Value = (int)this._house.PetDeposit.Measure;
			command.Parameters.Add("@BathroomFromId", SqlDbType.Int).Value = this._house.BathroomFromId.ValueOrDBNull<long?>();
			command.Parameters.Add("@BathroomToId", SqlDbType.Int).Value = this._house.BathroomToId.ValueOrDBNull<long?>();
			command.Parameters.Add("@BedroomFromId", SqlDbType.Int).Value = this._house.BedroomFromId.ValueOrDBNull<long?>();
			command.Parameters.Add("@BedroomToId", SqlDbType.Int).Value = this._house.BedroomToId.ValueOrDBNull<long?>();
			command.Parameters.Add("@LivingSpaceFrom", SqlDbType.Int).Value = this._house.LivingSpace.Min.ValueOrDBNull<int?>();
			command.Parameters.Add("@LivingSpaceTo", SqlDbType.Int).Value = this._house.LivingSpace.Max.ValueOrDBNull<int?>();
			command.Parameters.Add("@LivingSpaceUnitOfMeasureTypeId", SqlDbType.Int).Value = (int)this._house.LivingSpace.Measure;
			command.Parameters.Add("@SaleTypeId", SqlDbType.Int).Value = (int)this._house.SaleType;
			command.Parameters.Add("@YearBuilt", SqlDbType.Int).Value = this._house.YearBuilt.ValueOrDBNull<int?>();
			command.Parameters.Add("@SpecHomeStatusTypeId", SqlDbType.Int).Value = 1;
			command.Parameters.Add("@Description", SqlDbType.VarChar).Value = this._house.Description.ValueOrDBNull<string>();
			command.Parameters.Add("@UserId", SqlDbType.UniqueIdentifier).Value = this._house.Community.UserId;
			command.Parameters.Add("@Sequence", SqlDbType.Int).Value = this._sequence;
			command.Parameters.Add("@ScopeCommunityUnitId", SqlDbType.BigInt).Direction = ParameterDirection.Output;
			command.Parameters.Add("@AddressTable", SqlDbType.Structured).Value = this._house.Address.GetAddressTable();
			command.Parameters.Add("@AmenityTable", SqlDbType.Structured).Value = this._house.Amenities.GetAmenityTable();
			command.Parameters.Add("@ImageTable", SqlDbType.Structured).Value = this._house.Images.GetImageTable();
			SqlParameter sqlParameter = command.Parameters.Add("@CouponTable", SqlDbType.Structured);
			DataTable couponTableValue = this._house.Coupon.GetAdditionalInfoTable(this._couponTypeId);
			sqlParameter.Value = couponTableValue;
			command.ExecuteNonQuery();
		}

		protected override House GetCommandResult(SqlCommand command)
		{
			this._house.Id = new long?((long)command.Parameters["@ScopeCommunityUnitId"].Value);
			return this._house;
		}
	}
}