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
	internal class SaveServiceProviderCommand : FreeCacheBaseCommand<ServiceProvider>
	{
		private readonly ServiceProvider _serviceProvider;

		private readonly int _featureTypeId;

		private readonly int _publishTypeId;

		private readonly int _couponTypeId;

		public SaveServiceProviderCommand(ServiceProvider serviceProvider, int featureTypeId, int publishTypeId, int couponTypeId)
		{
			base.StoredProcedureName = AdminStoredProcedures.SpPutServiceDetail;
			this._serviceProvider = serviceProvider;
			this._featureTypeId = featureTypeId;
			this._publishTypeId = publishTypeId;
			this._couponTypeId = couponTypeId;
		}

		protected override void CommandBody(SqlCommand command)
		{
			command.CommandText = base.StoredProcedureName;
			command.CommandType = CommandType.StoredProcedure;
			SqlParameter serviceProviderId = command.Parameters.Add("@ServiceId", SqlDbType.BigInt);
			if (!this._serviceProvider.Id.HasValue)
			{
				serviceProviderId.Value = -1;
			}
			else
			{
				serviceProviderId.Value = this._serviceProvider.Id;
			}
			command.Parameters.Add("@ScopeServiceId", SqlDbType.BigInt).Direction = ParameterDirection.Output;
			command.Parameters.Add("@BookId", SqlDbType.Int).Value = this._serviceProvider.Book.Id;
			command.Parameters.Add("@Name", SqlDbType.VarChar).Value = this._serviceProvider.Name;
			command.Parameters.Add("@Description", SqlDbType.VarChar).Value = this._serviceProvider.Description ?? string.Empty;
			command.Parameters.Add("@WebsiteURL", SqlDbType.VarChar, 200).Value = this._serviceProvider.WebsiteUrl.ValueOrDBNull<string>();
			command.Parameters.Add("@IsDisplayWebsiteURL", SqlDbType.Bit).Value = this._serviceProvider.DisplayWebsiteUrl;
			command.Parameters.Add("@IsDisplayAddress", SqlDbType.Bit).Value = this._serviceProvider.DisplayAddress;
			command.Parameters.Add("@IsAutoProvision", SqlDbType.Bit).Value = this._serviceProvider.CallTrackingPhones.Any<CallTrackingPhone>();
			command.Parameters.Add("@UserId", SqlDbType.UniqueIdentifier).Value = this._serviceProvider.UserId;
			command.Parameters.Add("@IsActive", SqlDbType.Bit).Value = true;
			command.Parameters.Add("@AddressTable", SqlDbType.Structured).Value = this._serviceProvider.Address.GetAddressTable();
			command.Parameters.Add("@PhoneTable", SqlDbType.Structured).Value = this._serviceProvider.Phones.GetPhoneTable();
			command.Parameters.Add("@emailTable", SqlDbType.Structured).Value = this._serviceProvider.Emails.GetEmailTable();
			command.Parameters.Add("@ContactTable", SqlDbType.Structured).Value = this._serviceProvider.Contacts.GetContactTable();
			SqlParameter sqlParameter = command.Parameters.Add("@PackageTable", SqlDbType.Structured);
			DataTable packageTableValue = this._serviceProvider.Package.GetAdditionalInfoTable(true);
			sqlParameter.Value = packageTableValue;
			SqlParameter sqlParameter1 = command.Parameters.Add("@SeniorHousingAndCareCategoryTable", SqlDbType.Structured);
			DataTable housingAndCareTableValue = (
				from sc in this._serviceProvider.ServiceCategories
				select sc.Key).GetSeniorHousingAdditionalInfoTable(true);
			sqlParameter1.Value = housingAndCareTableValue;
			command.Parameters.Add("@ServiceOfficeHoursTable", SqlDbType.Structured).Value = this._serviceProvider.OfficeHours.GetOfficeHoursTable();
			SqlParameter sqlParameter2 = command.Parameters.Add("@PaymentTable", SqlDbType.Structured);
			DataTable paymentTableValue = this._serviceProvider.PaymentTypeIds.GetPaymentAdditionalInfoTable(true);
			sqlParameter2.Value = paymentTableValue;
			SqlParameter sqlParameter3 = command.Parameters.Add("@CouponTable", SqlDbType.Structured);
			DataTable couponTableValue = this._serviceProvider.Coupon.GetAdditionalInfoTable(this._couponTypeId);
			sqlParameter3.Value = couponTableValue;
			SqlParameter sqlParameter4 = command.Parameters.Add("@FeatureTable", SqlDbType.Structured);
			DataTable featureTableValue = TableParamsExtensions.GetDateTable(this._serviceProvider.FeatureStartDate, this._serviceProvider.FeatureEndDate, new AdditionalInfoClass?(AdditionalInfoClass.Feature), this._featureTypeId);
			sqlParameter4.Value = featureTableValue;
			SqlParameter sqlParameter5 = command.Parameters.Add("@PublishTable", SqlDbType.Structured);
			DataTable publishTableValue = TableParamsExtensions.GetDateTable(this._serviceProvider.PublishStartDate, this._serviceProvider.PublishEndDate, new AdditionalInfoClass?(AdditionalInfoClass.Publish), this._publishTypeId);
			sqlParameter5.Value = publishTableValue;
			command.Parameters.Add("@ImageTable", SqlDbType.Structured).Value = this._serviceProvider.Images.GetImageTable();
			command.Parameters.Add("@ServiceCountiesServedTable", SqlDbType.Structured).Value = this._serviceProvider.CountiesServed.GetServiceCountiesServedTable();
			command.ExecuteNonQuery();
		}

		protected override ServiceProvider GetCommandResult(SqlCommand command)
		{
			return this._serviceProvider;
		}
	}
}