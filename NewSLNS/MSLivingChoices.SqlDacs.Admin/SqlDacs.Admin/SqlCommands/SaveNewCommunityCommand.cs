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

namespace MSLivingChoices.SqlDacs.Admin.SqlCommands
{
	internal class SaveNewCommunityCommand : FreeCacheBaseCommand<Community>
	{
		private readonly Community _community;

		private readonly int _publishTypeId;

		private readonly int _showcaseTypeId;

		private readonly int _couponTypeId;

		private readonly int _customCommunityServiceTypeId;

		public SaveNewCommunityCommand(Community community, int publishTypeId, int showcaseTypeId, int couponTypeId, int customCommunityServiceTypeId)
		{
			base.StoredProcedureName = AdminStoredProcedures.SpPutCommunityDetail;
			this._community = community;
			this._publishTypeId = publishTypeId;
			this._showcaseTypeId = showcaseTypeId;
			this._couponTypeId = couponTypeId;
			this._customCommunityServiceTypeId = customCommunityServiceTypeId;
		}

		protected override void CommandBody(SqlCommand command)
		{
			object valueOrDefault;
			object value;
			command.CommandText = base.StoredProcedureName;
			command.CommandType = CommandType.StoredProcedure;
			SqlParameter communityId = command.Parameters.Add("@CommunityId", SqlDbType.BigInt);
			long? id = this._community.Id;
			if (!id.HasValue)
			{
				communityId.Value = -1;
			}
			else
			{
				communityId.Value = this._community.Id;
			}
			command.Parameters.Add("@BookId", SqlDbType.Int).Value = this._community.Book.Id;
			command.Parameters.Add("@HasAdultHomes", SqlDbType.Bit).Value = this.HasListingType(this._community.ListingTypes, ListingType.ActiveAdultHomes);
			command.Parameters.Add("@HasAdultApartments", SqlDbType.Bit).Value = this.HasListingType(this._community.ListingTypes, ListingType.ActiveAdultCommunities);
			command.Parameters.Add("@HasSeniorHousing", SqlDbType.Bit).Value = this.HasListingType(this._community.ListingTypes, ListingType.SeniorHousingAndCare);
			command.Parameters.Add("@IsAllAges", SqlDbType.Bit).Value = this._community.AgeRestrictions.Contains(AgeRestriction.AllAges);
			command.Parameters.Add("@IsAgeTargeted", SqlDbType.Bit).Value = this._community.AgeRestrictions.Contains(AgeRestriction.AgeTargeted);
			command.Parameters.Add("@IsAgeQualified", SqlDbType.Bit).Value = this._community.AgeRestrictions.Contains(AgeRestriction.AgeQualified);
			command.Parameters.Add("@Name", SqlDbType.VarChar, 50).Value = this._community.Name ?? string.Empty;
			command.Parameters.Add("@Description", SqlDbType.VarChar).Value = this._community.Description ?? string.Empty;
			command.Parameters.Add("@WebsiteURL", SqlDbType.VarChar, 200).Value = this._community.WebsiteUrl ?? string.Empty;
			command.Parameters.Add("@IsDisplayWebsiteURL", SqlDbType.Bit).Value = this._community.DisplayWebsiteUrl;
			command.Parameters.Add("@IsDisplayAddress", SqlDbType.Bit).Value = this._community.DisplayAddress;
			command.Parameters.Add("@PricedFrom", SqlDbType.Money).Value = this._community.PriceRange.Min.ValueOrDBNull<decimal?>();
			command.Parameters.Add("@PricedTo", SqlDbType.Money).Value = this._community.PriceRange.Max.ValueOrDBNull<decimal?>();
			command.Parameters.Add("@PriceCurrencyTypeId", SqlDbType.Int).Value = (int)this._community.PriceRange.Measure;
			command.Parameters.Add("@DepositFrom", SqlDbType.Money).Value = this._community.Deposit.Min.ValueOrDBNull<decimal?>();
			command.Parameters.Add("@DepositTo", SqlDbType.Money).Value = this._community.Deposit.Max.ValueOrDBNull<decimal?>();
			command.Parameters.Add("@DepositCurrencyTypeId", SqlDbType.Int).Value = (int)this._community.Deposit.Measure;
			command.Parameters.Add("@ApplicationFeeFrom", SqlDbType.Money).Value = this._community.ApplicationFee.Min.ValueOrDBNull<decimal?>();
			command.Parameters.Add("@ApplicationFeeTo", SqlDbType.Money).Value = this._community.ApplicationFee.Max.ValueOrDBNull<decimal?>();
			command.Parameters.Add("@ApplicationFeeCurrencyTypeId", SqlDbType.Int).Value = (int)this._community.ApplicationFee.Measure;
			command.Parameters.Add("@PetDepositFrom", SqlDbType.Money).Value = this._community.PetDeposit.Min.ValueOrDBNull<decimal?>();
			command.Parameters.Add("@PetDepositTo", SqlDbType.Money).Value = this._community.PetDeposit.Max.ValueOrDBNull<decimal?>();
			command.Parameters.Add("@PetDepositCurrencyTypeId", SqlDbType.Int).Value = (int)this._community.PetDeposit.Measure;
			command.Parameters.Add("@LivingSpaceFrom", SqlDbType.Int).Value = this._community.LivingSpace.Min.ValueOrDBNull<int?>();
			command.Parameters.Add("@LivingSpaceTo", SqlDbType.Int).Value = this._community.LivingSpace.Max.ValueOrDBNull<int?>();
			command.Parameters.Add("@BathroomFromId", SqlDbType.Int).Value = this._community.BathroomFromId.ValueOrDBNull<long?>();
			command.Parameters.Add("@LivingSpaceUnitOfMeasureTypeId", SqlDbType.Int).Value = (int)this._community.LivingSpace.Measure;
			command.Parameters.Add("@BathroomToId", SqlDbType.Int).Value = this._community.BathroomToId.ValueOrDBNull<long?>();
			command.Parameters.Add("@BedroomFromId", SqlDbType.Int).Value = this._community.BedroomFromId.ValueOrDBNull<long?>();
			command.Parameters.Add("@BedroomToId", SqlDbType.Int).Value = this._community.BedroomToId.ValueOrDBNull<long?>();
			command.Parameters.Add("@UnitCount", SqlDbType.Int).Value = this._community.UnitCount.ValueOrDBNull<int?>();
			SqlParameter sqlParameter = command.Parameters.Add("@PMCId", SqlDbType.BigInt);
			if (this._community.PropertyManager != null)
			{
				id = this._community.PropertyManager.Id;
				if (id.HasValue)
				{
					valueOrDefault = id.GetValueOrDefault();
				}
				else
				{
					valueOrDefault = DBNull.Value;
				}
			}
			else
			{
				valueOrDefault = DBNull.Value;
			}
			sqlParameter.Value = valueOrDefault;
			SqlParameter sqlParameter1 = command.Parameters.Add("@BuilderId", SqlDbType.BigInt);
			if (this._community.Builder != null)
			{
				id = this._community.Builder.Id;
				if (id.HasValue)
				{
					value = id.GetValueOrDefault();
				}
				else
				{
					value = DBNull.Value;
				}
			}
			else
			{
				value = DBNull.Value;
			}
			sqlParameter1.Value = value;
			command.Parameters.Add("@IsAutoProvision", SqlDbType.Bit).Value = this._community.CallTrackingPhones.Any<CallTrackingPhone>();
			command.Parameters.Add("@IsActive", SqlDbType.Bit).Value = true;
			command.Parameters.Add("@UserId", SqlDbType.UniqueIdentifier).Value = this._community.UserId;
			command.Parameters.Add("@iTourURL", SqlDbType.VarChar, 200).Value = this._community.VirtualTour.ValueOrDBNull<string>();
			command.Parameters.Add("@ScopeCommunityId", SqlDbType.BigInt).Direction = ParameterDirection.Output;
			command.Parameters.Add("@AddressTable", SqlDbType.Structured).Value = this._community.Address.GetAddressTable();
			command.Parameters.Add("@CommonPhoneTable", SqlDbType.Structured).Value = this._community.Phones.GetPhoneTable();
			command.Parameters.Add("@emailTable", SqlDbType.Structured).Value = this._community.Emails.GetEmailTable();
			command.Parameters.Add("@ContactTable", SqlDbType.Structured).Value = this._community.Contacts.GetContactTable();
			SqlParameter sqlParameter2 = command.Parameters.Add("@PackageTable", SqlDbType.Structured);
			DataTable packageTableValue = this._community.Package.GetAdditionalInfoTable(false);
			sqlParameter2.Value = packageTableValue;
			SqlParameter sqlParameter3 = command.Parameters.Add("@SeniorHousingAndCareCategoryTable", SqlDbType.Structured);
			DataTable housingAndCareTableValue = this._community.SeniorHousingAndCareCategoryIds.GetSeniorHousingAdditionalInfoTable(false);
			sqlParameter3.Value = housingAndCareTableValue;
			command.Parameters.Add("@CommunityOfficeHoursTable", SqlDbType.Structured).Value = this._community.OfficeHours.GetOfficeHoursTable();
			SqlParameter sqlParameter4 = command.Parameters.Add("@PaymentTable", SqlDbType.Structured);
			DataTable paymentTableValue = this._community.PaymentTypeIds.GetPaymentAdditionalInfoTable(false);
			sqlParameter4.Value = paymentTableValue;
			command.Parameters.Add("@AmenityTable", SqlDbType.Structured).Value = this._community.Amenities.GetAmenityTable();
			SqlParameter sqlParameter5 = command.Parameters.Add("@ServiceTable", SqlDbType.Structured);
			DataTable serviceTableValue = this._community.CommunityServices.GetAdditionalInfoTable(this._customCommunityServiceTypeId);
			sqlParameter5.Value = serviceTableValue;
			SqlParameter imageTable = command.Parameters.Add("@ImageTable", SqlDbType.Structured);
			List<Image> images = new List<Image>(this._community.Images);
			images.AddRange(this._community.LogoImages);
			imageTable.Value = images.GetImageTable();
			SqlParameter sqlParameter6 = command.Parameters.Add("@CouponTable", SqlDbType.Structured);
			DataTable couponTableValue = this._community.Coupon.GetAdditionalInfoTable(this._couponTypeId);
			sqlParameter6.Value = couponTableValue;
			SqlParameter sqlParameter7 = command.Parameters.Add("@CommunityUnitTable", SqlDbType.Structured);
			DataTable communityUnitTableValue = TableParamsExtensions.GetCommunityUnitTable(this._community.FloorPlans, this._community.SpecHomes, this._community.Houses);
			sqlParameter7.Value = communityUnitTableValue;
			SqlParameter sqlParameter8 = command.Parameters.Add("@PublishTable", SqlDbType.Structured);
			DataTable publishDateValue = TableParamsExtensions.GetDateTable(this._community.Publishing.StartDate, this._community.Publishing.EndDate, new AdditionalInfoClass?(AdditionalInfoClass.Publish), this._publishTypeId);
			sqlParameter8.Value = publishDateValue;
			SqlParameter sqlParameter9 = command.Parameters.Add("@ShowcaseTable", SqlDbType.Structured);
			DataTable showcaseDateValue = TableParamsExtensions.GetDateTable(this._community.Showcase.StartDate, this._community.Showcase.EndDate, new AdditionalInfoClass?(AdditionalInfoClass.Showcase), this._showcaseTypeId);
			sqlParameter9.Value = showcaseDateValue;
			command.ExecuteNonQuery();
		}

		protected override Community GetCommandResult(SqlCommand command)
		{
			this._community.Id = new long?((long)command.Parameters["@ScopeCommunityId"].Value);
			return this._community;
		}

		private bool HasListingType(List<ListingType> list, ListingType type)
		{
			if (list == null || !list.Any<ListingType>())
			{
				return false;
			}
			return list.Contains(type);
		}
	}
}