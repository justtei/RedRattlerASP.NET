using MSLivingChoices.Entities.Admin;
using MSLivingChoices.Entities.Admin.Enums;
using MSLivingChoices.SqlDacs.Admin;
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
	internal class GetCommunityByIdCommand : BaseCommand<Community>
	{
		private readonly long _id;

		private Community _community;

		public GetCommunityByIdCommand(long id)
		{
			base.StoredProcedureName = AdminStoredProcedures.SpGetCommunityDetail;
			this._id = id;
		}

		protected override void CommandBody(SqlCommand command)
		{
			command.CommandText = base.StoredProcedureName;
			command.CommandType = CommandType.StoredProcedure;
			command.Parameters.Add("@CommunityId", SqlDbType.BigInt).Value = this._id;
			SqlDataReader reader = command.ExecuteReader();
			this.GetBasicInfo(reader);
			if (this._community == null)
			{
				return;
			}
			if (reader.NextResult())
			{
				this._community.Address = reader.GetAddress();
			}
			if (reader.NextResult())
			{
				Tuple<List<Phone>, List<CallTrackingPhone>> phones = reader.GetPhones();
				this._community.Phones = phones.Item1;
				this._community.CallTrackingPhones = phones.Item2;
			}
			if (reader.NextResult())
			{
				this._community.Emails = reader.GetEmails();
			}
			if (reader.NextResult())
			{
				this._community.Contacts = reader.GetContacts();
			}
			if (reader.NextResult())
			{
				this._community.OfficeHours = reader.GetOfficeHours();
			}
			if (reader.NextResult())
			{
				this._community.Amenities = reader.GetCommunityAmenities();
			}
			if (reader.NextResult())
			{
				List<Image> communityImages = reader.GetImages();
				this._community.Images = (
					from x in communityImages
					where x.ImageType == ImageType.Photo
					select x).ToList<Image>();
				this._community.LogoImages = (
					from x in communityImages
					where x.ImageType == ImageType.Logo
					select x).ToList<Image>();
			}
			if (reader.NextResult())
			{
				Tuple<List<FloorPlan>, List<SpecHome>, List<House>> communityUnits = reader.GetCommunityUnits();
				this._community.FloorPlans = communityUnits.Item1;
				this._community.SpecHomes = communityUnits.Item2;
				this._community.Houses = communityUnits.Item3;
			}
			if (reader.NextResult())
			{
				Tuple<List<Phone>, List<CallTrackingPhone>> provisionPhones = reader.GetPhones();
				this._community.Phones.AddRange(provisionPhones.Item1);
				this._community.CallTrackingPhones.AddRange(provisionPhones.Item2);
			}
			if (reader.NextResult())
			{
				List<AdditionalInfo> infos = reader.GetAdditionalInfo();
				this._community.SeniorHousingAndCareCategoryIds = infos.GetCommunitySeniorHousingAndCareCategoryIds();
				this._community.PaymentTypeIds = infos.GetCommunityPaymentTypes();
				this._community.CommunityServices = infos.GetServices();
				this._community.Package = new PackageType?(infos.GetCommunityPackage());
				this._community.Feature = infos.GetFeature();
				this._community.Showcase = infos.GetShowcase();
				this._community.Publishing = infos.GetPublishing();
				this._community.Coupon = infos.GetCoupon();
			}
		}

		protected void GetBasicInfo(SqlDataReader reader)
		{
			long? nullable;
			long? nullable1;
			long? nullable2;
			long? nullable3;
			long? nullable4;
			long? nullable5;
			if (!reader.Read())
			{
				this._community = null;
				return;
			}
			this._community = new Community()
			{
				Id = new long?(this._id),
				Book = new Book(),
				PriceRange = new MeasureBoundary<decimal, MoneyType>(),
				Deposit = new MeasureBoundary<decimal, MoneyType>(),
				ApplicationFee = new MeasureBoundary<decimal, MoneyType>(),
				PetDeposit = new MeasureBoundary<decimal, MoneyType>(),
				LivingSpace = new MeasureBoundary<int, LivingSpaceMeasure>(),
				ListingTypes = new List<ListingType>(),
				AgeRestrictions = new List<AgeRestriction>(),
				Builder = new Owner()
				{
					OwnerType = OwnerType.Builder
				},
				PropertyManager = new Owner()
				{
					OwnerType = OwnerType.PropertyManager
				},
				Name = reader["Name"].ToString().Trim()
			};
			Book book = this._community.Book;
			int? nullableValue = reader.GetNullableValue<int>("BookId");
			if (nullableValue.HasValue)
			{
				nullable1 = new long?((long)nullableValue.GetValueOrDefault());
			}
			else
			{
				nullable = null;
				nullable1 = nullable;
			}
			book.Id = nullable1;
			this._community.PropertyManager.Id = reader.GetNullableValue<long>("PMCId");
			this._community.Builder.Id = reader.GetNullableValue<long>("BuilderId");
			this._community.Description = reader["Description"].ToString();
			this._community.WebsiteUrl = reader["WebsiteURL"].ToString();
			this._community.DisplayWebsiteUrl = reader.GetNullableValue<bool>("IsDisplayWebsiteUrl").FromNullable();
			this._community.DisplayAddress = reader.GetNullableValue<bool>("IsDisplayAddress").FromNullable();
			this._community.PriceRange.Min = reader.GetNullableValue<decimal>("PricedFrom");
			this._community.PriceRange.Max = reader.GetNullableValue<decimal>("PricedTo");
			this._community.PriceRange.Measure = reader.GetEnum<MoneyType>("PriceCurrencyTypeId");
			this._community.Deposit.Min = reader.GetNullableValue<decimal>("DepositFrom");
			this._community.Deposit.Max = reader.GetNullableValue<decimal>("DepositTo");
			this._community.Deposit.Measure = reader.GetEnum<MoneyType>("DepositCurrencyTypeId");
			this._community.ApplicationFee.Min = reader.GetNullableValue<decimal>("ApplicationFeeFrom");
			this._community.ApplicationFee.Max = reader.GetNullableValue<decimal>("ApplicationFeeTo");
			this._community.ApplicationFee.Measure = reader.GetEnum<MoneyType>("ApplicationFeeCurrencyTypeId");
			this._community.PetDeposit.Min = reader.GetNullableValue<decimal>("PetDepositFrom");
			this._community.PetDeposit.Max = reader.GetNullableValue<decimal>("PetDepositTo");
			this._community.PetDeposit.Measure = reader.GetEnum<MoneyType>("PetDepositCurrencyTypeId");
			this._community.LivingSpace.Min = reader.GetNullableValue<int>("LivingSpaceFrom");
			this._community.LivingSpace.Max = reader.GetNullableValue<int>("LivingSpaceTo");
			this._community.LivingSpace.Measure = reader.GetEnum<LivingSpaceMeasure>("LivingSpaceUnitOfMeasureTypeId");
			Community community = this._community;
			nullableValue = reader.GetNullableValue<int>("BedroomFromId");
			if (nullableValue.HasValue)
			{
				nullable2 = new long?((long)nullableValue.GetValueOrDefault());
			}
			else
			{
				nullable = null;
				nullable2 = nullable;
			}
			community.BedroomFromId = nullable2;
			Community community1 = this._community;
			nullableValue = reader.GetNullableValue<int>("BedroomToId");
			if (nullableValue.HasValue)
			{
				nullable3 = new long?((long)nullableValue.GetValueOrDefault());
			}
			else
			{
				nullable = null;
				nullable3 = nullable;
			}
			community1.BedroomToId = nullable3;
			Community community2 = this._community;
			nullableValue = reader.GetNullableValue<int>("BathroomFromId");
			if (nullableValue.HasValue)
			{
				nullable4 = new long?((long)nullableValue.GetValueOrDefault());
			}
			else
			{
				nullable = null;
				nullable4 = nullable;
			}
			community2.BathroomFromId = nullable4;
			Community community3 = this._community;
			nullableValue = reader.GetNullableValue<int>("BathroomToId");
			if (nullableValue.HasValue)
			{
				nullable5 = new long?((long)nullableValue.GetValueOrDefault());
			}
			else
			{
				nullable = null;
				nullable5 = nullable;
			}
			community3.BathroomToId = nullable5;
			this._community.UnitCount = reader.GetNullableValue<int>("UnitCount");
			bool flag = reader.GetNullableValue<bool>("HasAdultApartments").FromNullable();
			bool hasAdultHomes = reader.GetNullableValue<bool>("HasAdultHomes").FromNullable();
			bool hasSeniorHousing = reader.GetNullableValue<bool>("HasSeniorHousing").FromNullable();
			if (flag)
			{
				this._community.ListingTypes.Add(ListingType.ActiveAdultCommunities);
			}
			if (hasAdultHomes)
			{
				this._community.ListingTypes.Add(ListingType.ActiveAdultHomes);
			}
			if (hasSeniorHousing)
			{
				this._community.ListingTypes.Add(ListingType.SeniorHousingAndCare);
			}
			bool flag1 = reader.GetNullableValue<bool>("IsAllAges").FromNullable();
			bool isAgeTargeted = reader.GetNullableValue<bool>("IsAgeTargeted").FromNullable();
			bool isAgeQualified = reader.GetNullableValue<bool>("IsAgeQualified").FromNullable();
			if (flag1)
			{
				this._community.AgeRestrictions.Add(AgeRestriction.AllAges);
			}
			if (isAgeTargeted)
			{
				this._community.AgeRestrictions.Add(AgeRestriction.AgeTargeted);
			}
			if (isAgeQualified)
			{
				this._community.AgeRestrictions.Add(AgeRestriction.AgeQualified);
			}
			this._community.MarchexAccountId = reader.GetValue<string>("MARCHEX_AccountId");
			this._community.UserId = reader.GetNullableValue<Guid>("ModifyUserId");
			this._community.VirtualTour = reader.GetValue<string>("iTourURL");
		}

		protected override Community GetCommandResult(SqlCommand command)
		{
			return this._community;
		}
	}
}