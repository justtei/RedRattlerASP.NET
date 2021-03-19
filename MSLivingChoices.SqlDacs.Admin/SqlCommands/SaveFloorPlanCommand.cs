using MSLivingChoices.Entities.Admin;
using MSLivingChoices.SqlDacs.Admin.Helpers;
using MSLivingChoices.SqlDacs.Helpers;
using MSLivingChoices.SqlDacs.SqlCommands;
using System;
using System.Data;
using System.Data.SqlClient;

namespace MSLivingChoices.SqlDacs.Admin.SqlCommands
{
	internal class SaveFloorPlanCommand : FreeCacheBaseCommand<FloorPlan>
	{
		private readonly FloorPlan _floorPlan;

		private readonly int _sequence;

		private readonly int _couponTypeId;

		public SaveFloorPlanCommand(FloorPlan floorPlan, int sequence, int couponTypeId)
		{
			base.StoredProcedureName = AdminStoredProcedures.SpPutCommunityUnitDetail;
			this._floorPlan = floorPlan;
			this._sequence = sequence;
			this._couponTypeId = couponTypeId;
		}

		protected override void CommandBody(SqlCommand command)
		{
			command.CommandText = base.StoredProcedureName;
			command.CommandType = CommandType.StoredProcedure;
			command.Parameters.Add("@CommunityUnitId", SqlDbType.BigInt).Value = (!this._floorPlan.Id.HasValue ? (long)-1 : this._floorPlan.Id.Value);
			command.Parameters.Add("@CommunityId", SqlDbType.BigInt).Value = this._floorPlan.Community.Id.ValueOrDBNull<long?>();
			command.Parameters.Add("@CommunityUnitClassId", SqlDbType.Int).Value = 1;
			command.Parameters.Add("@Name", SqlDbType.VarChar, 50).Value = this._floorPlan.Name.ValueOrDBNull<string>();
			command.Parameters.Add("@PricedFrom", SqlDbType.Money).Value = this._floorPlan.PriceRange.Min.ValueOrDBNull<decimal?>();
			command.Parameters.Add("@PricedTo", SqlDbType.Money).Value = this._floorPlan.PriceRange.Max.ValueOrDBNull<decimal?>();
			command.Parameters.Add("@PriceCurrencyTypeId", SqlDbType.Int).Value = (int)this._floorPlan.PriceRange.Measure;
			command.Parameters.Add("@DepositFrom", SqlDbType.Money).Value = this._floorPlan.Deposit.Min.ValueOrDBNull<decimal?>();
			command.Parameters.Add("@DepositTo", SqlDbType.Money).Value = this._floorPlan.Deposit.Max.ValueOrDBNull<decimal?>();
			command.Parameters.Add("@DepositCurrencyTypeId", SqlDbType.Int).Value = (int)this._floorPlan.Deposit.Measure;
			command.Parameters.Add("@ApplicationFeeFrom", SqlDbType.Money).Value = this._floorPlan.ApplicationFee.Min.ValueOrDBNull<decimal?>();
			command.Parameters.Add("@ApplicationFeeTo", SqlDbType.Money).Value = this._floorPlan.ApplicationFee.Max.ValueOrDBNull<decimal?>();
			command.Parameters.Add("@ApplicationFeeCurrencyTypeId", SqlDbType.Int).Value = (int)this._floorPlan.ApplicationFee.Measure;
			command.Parameters.Add("@PetDepositFrom", SqlDbType.Money).Value = this._floorPlan.PetDeposit.Min.ValueOrDBNull<decimal?>();
			command.Parameters.Add("@PetDepositTo", SqlDbType.Money).Value = this._floorPlan.PetDeposit.Max.ValueOrDBNull<decimal?>();
			command.Parameters.Add("@PetDepositCurrencyTypeId", SqlDbType.Int).Value = (int)this._floorPlan.PetDeposit.Measure;
			command.Parameters.Add("@BathroomFromId", SqlDbType.Int).Value = this._floorPlan.BathroomFromId.ValueOrDBNull<long?>();
			command.Parameters.Add("@BathroomToId", SqlDbType.Int).Value = this._floorPlan.BathroomToId.ValueOrDBNull<long?>();
			command.Parameters.Add("@BedroomFromId", SqlDbType.Int).Value = this._floorPlan.BedroomFromId.ValueOrDBNull<long?>();
			command.Parameters.Add("@BedroomToId", SqlDbType.Int).Value = this._floorPlan.BedroomToId.ValueOrDBNull<long?>();
			command.Parameters.Add("@LivingSpaceFrom", SqlDbType.Int).Value = this._floorPlan.LivingSpace.Min.ValueOrDBNull<int?>();
			command.Parameters.Add("@LivingSpaceTo", SqlDbType.Int).Value = this._floorPlan.LivingSpace.Max.ValueOrDBNull<int?>();
			command.Parameters.Add("@LivingSpaceUnitOfMeasureTypeId", SqlDbType.Int).Value = (int)this._floorPlan.LivingSpace.Measure;
			command.Parameters.Add("@SaleTypeId", SqlDbType.Int).Value = 1;
			command.Parameters.Add("@SpecHomeStatusTypeId", SqlDbType.Int).Value = 1;
			command.Parameters.Add("@Description", SqlDbType.VarChar).Value = this._floorPlan.Name.ValueOrDBNull<string>();
			command.Parameters.Add("@UserId", SqlDbType.UniqueIdentifier).Value = this._floorPlan.Community.UserId;
			command.Parameters.Add("@Sequence", SqlDbType.Int).Value = this._sequence;
			command.Parameters.Add("@YearBuilt", SqlDbType.Int).Value = DBNull.Value;
			command.Parameters.Add("@ScopeCommunityUnitId", SqlDbType.BigInt).Direction = ParameterDirection.Output;
			command.Parameters.Add("@AddressTable", SqlDbType.Structured).Value = ((Address)null).GetAddressTable();
			command.Parameters.Add("@AmenityTable", SqlDbType.Structured).Value = this._floorPlan.Amenities.GetAmenityTable();
			command.Parameters.Add("@ImageTable", SqlDbType.Structured).Value = this._floorPlan.Images.GetImageTable();
			SqlParameter sqlParameter = command.Parameters.Add("@CouponTable", SqlDbType.Structured);
			DataTable couponTableValue = this._floorPlan.Coupon.GetAdditionalInfoTable(this._couponTypeId);
			sqlParameter.Value = couponTableValue;
			command.ExecuteNonQuery();
		}

		protected override FloorPlan GetCommandResult(SqlCommand command)
		{
			this._floorPlan.Id = new long?((long)command.Parameters["@ScopeCommunityUnitId"].Value);
			return this._floorPlan;
		}
	}
}