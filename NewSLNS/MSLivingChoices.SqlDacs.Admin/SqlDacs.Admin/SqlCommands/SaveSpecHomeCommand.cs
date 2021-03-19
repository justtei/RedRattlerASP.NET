using MSLivingChoices.Entities.Admin;
using MSLivingChoices.SqlDacs.Admin.Helpers;
using MSLivingChoices.SqlDacs.Helpers;
using MSLivingChoices.SqlDacs.SqlCommands;
using System;
using System.Data;
using System.Data.SqlClient;

namespace MSLivingChoices.SqlDacs.Admin.SqlCommands
{
	internal class SaveSpecHomeCommand : FreeCacheBaseCommand<SpecHome>
	{
		private readonly SpecHome _specHome;

		private readonly int _sequence;

		private readonly int _couponTypeId;

		public SaveSpecHomeCommand(SpecHome specHome, int sequence, int couponTypeId)
		{
			base.StoredProcedureName = AdminStoredProcedures.SpPutCommunityUnitDetail;
			this._specHome = specHome;
			this._sequence = sequence;
			this._couponTypeId = couponTypeId;
		}

		protected override void CommandBody(SqlCommand command)
		{
			command.CommandText = base.StoredProcedureName;
			command.CommandType = CommandType.StoredProcedure;
			command.Parameters.Add("@CommunityUnitId", SqlDbType.BigInt).Value = (!this._specHome.Id.HasValue ? (long)-1 : this._specHome.Id.Value);
			command.Parameters.Add("@CommunityId", SqlDbType.BigInt).Value = this._specHome.Community.Id;
			command.Parameters.Add("@CommunityUnitClassId", SqlDbType.Int).Value = 2;
			command.Parameters.Add("@Name", SqlDbType.VarChar, 50).Value = this._specHome.Name.ValueOrDBNull<string>();
			command.Parameters.Add("@PricedFrom", SqlDbType.Money).Value = this._specHome.PriceRange.Min.ValueOrDBNull<decimal?>();
			command.Parameters.Add("@PricedTo", SqlDbType.Money).Value = this._specHome.PriceRange.Max.ValueOrDBNull<decimal?>();
			command.Parameters.Add("@PriceCurrencyTypeId", SqlDbType.Int).Value = (int)this._specHome.PriceRange.Measure;
			command.Parameters.Add("@DepositFrom", SqlDbType.Money).Value = this._specHome.Deposit.Min.ValueOrDBNull<decimal?>();
			command.Parameters.Add("@DepositTo", SqlDbType.Money).Value = this._specHome.Deposit.Max.ValueOrDBNull<decimal?>();
			command.Parameters.Add("@DepositCurrencyTypeId", SqlDbType.Int).Value = (int)this._specHome.Deposit.Measure;
			command.Parameters.Add("@ApplicationFeeFrom", SqlDbType.Money).Value = this._specHome.ApplicationFee.Min.ValueOrDBNull<decimal?>();
			command.Parameters.Add("@ApplicationFeeTo", SqlDbType.Money).Value = this._specHome.ApplicationFee.Max.ValueOrDBNull<decimal?>();
			command.Parameters.Add("@ApplicationFeeCurrencyTypeId", SqlDbType.Int).Value = (int)this._specHome.ApplicationFee.Measure;
			command.Parameters.Add("@PetDepositFrom", SqlDbType.Money).Value = this._specHome.PetDeposit.Min.ValueOrDBNull<decimal?>();
			command.Parameters.Add("@PetDepositTo", SqlDbType.Money).Value = this._specHome.PetDeposit.Max.ValueOrDBNull<decimal?>();
			command.Parameters.Add("@PetDepositCurrencyTypeId", SqlDbType.Int).Value = (int)this._specHome.PetDeposit.Measure;
			command.Parameters.Add("@BathroomFromId", SqlDbType.Int).Value = this._specHome.BathroomFromId.ValueOrDBNull<long?>();
			command.Parameters.Add("@BathroomToId", SqlDbType.Int).Value = this._specHome.BathroomToId.ValueOrDBNull<long?>();
			command.Parameters.Add("@BedroomFromId", SqlDbType.Int).Value = this._specHome.BedroomFromId.ValueOrDBNull<long?>();
			command.Parameters.Add("@BedroomToId", SqlDbType.Int).Value = this._specHome.BedroomToId.ValueOrDBNull<long?>();
			command.Parameters.Add("@LivingSpaceFrom", SqlDbType.Int).Value = this._specHome.LivingSpace.Min.ValueOrDBNull<int?>();
			command.Parameters.Add("@LivingSpaceTo", SqlDbType.Int).Value = this._specHome.LivingSpace.Max.ValueOrDBNull<int?>();
			command.Parameters.Add("@LivingSpaceUnitOfMeasureTypeId", SqlDbType.Int).Value = (int)this._specHome.LivingSpace.Measure;
			command.Parameters.Add("@SaleTypeId", SqlDbType.Int).Value = (int)this._specHome.SaleType;
			command.Parameters.Add("@SpecHomeStatusTypeId", SqlDbType.Int).Value = (int)this._specHome.Status;
			command.Parameters.Add("@Description", SqlDbType.VarChar).Value = this._specHome.Description.ValueOrDBNull<string>();
			command.Parameters.Add("@UserId", SqlDbType.UniqueIdentifier).Value = this._specHome.Community.UserId;
			command.Parameters.Add("@Sequence", SqlDbType.Int).Value = this._sequence;
			command.Parameters.Add("@YearBuilt", SqlDbType.Int).Value = DBNull.Value;
			command.Parameters.Add("@ScopeCommunityUnitId", SqlDbType.BigInt).Direction = ParameterDirection.Output;
			command.Parameters.Add("@AddressTable", SqlDbType.Structured).Value = ((Address)null).GetAddressTable();
			command.Parameters.Add("@AmenityTable", SqlDbType.Structured).Value = this._specHome.Amenities.GetAmenityTable();
			command.Parameters.Add("@ImageTable", SqlDbType.Structured).Value = this._specHome.Images.GetImageTable();
			SqlParameter sqlParameter = command.Parameters.Add("@CouponTable", SqlDbType.Structured);
			DataTable couponTableValue = this._specHome.Coupon.GetAdditionalInfoTable(this._couponTypeId);
			sqlParameter.Value = couponTableValue;
			command.ExecuteNonQuery();
		}

		protected override SpecHome GetCommandResult(SqlCommand command)
		{
			this._specHome.Id = new long?((long)command.Parameters["@ScopeCommunityUnitId"].Value);
			return this._specHome;
		}
	}
}