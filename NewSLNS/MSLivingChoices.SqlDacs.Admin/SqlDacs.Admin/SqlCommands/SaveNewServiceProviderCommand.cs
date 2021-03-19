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
	internal class SaveNewServiceProviderCommand : FreeCacheBaseCommand<ServiceProvider>
	{
		private readonly ServiceProvider _newServiceProvider;

		private readonly int _featureTypeId;

		private readonly int _publishTypeId;

		private readonly int _couponTypeId;

		public SaveNewServiceProviderCommand(ServiceProvider newServiceProvider, int featureTypeId, int publishTypeId, int couponTypeId)
		{
			base.StoredProcedureName = AdminStoredProcedures.SpPutServiceDetail;
			this._newServiceProvider = newServiceProvider;
			this._featureTypeId = featureTypeId;
			this._publishTypeId = publishTypeId;
			this._couponTypeId = couponTypeId;
		}

		protected override void CommandBody(SqlCommand command)
		{
			command.CommandText = base.StoredProcedureName;
			command.CommandType = CommandType.StoredProcedure;
			SqlParameter serviceProviderId = command.Parameters.Add("@ServiceId", SqlDbType.BigInt);
			if (!this._newServiceProvider.Id.HasValue)
			{
				serviceProviderId.Value = -1;
			}
			else
			{
				serviceProviderId.Value = this._newServiceProvider.Id;
			}
			command.Parameters.Add("@ScopeServiceId", SqlDbType.BigInt).Direction = ParameterDirection.Output;
			command.Parameters.Add("@BookId", SqlDbType.Int).Value = this._newServiceProvider.Book.Id;
			command.Parameters.Add("@Name", SqlDbType.VarChar).Value = this._newServiceProvider.Name;
			command.Parameters.Add("@Description", SqlDbType.VarChar).Value = this._newServiceProvider.Description ?? string.Empty;
			command.Parameters.Add("@WebsiteURL", SqlDbType.VarChar, 200).Value = this._newServiceProvider.WebsiteUrl.ValueOrDBNull<string>();
			command.Parameters.Add("@IsDisplayWebsiteURL", SqlDbType.Bit).Value = this._newServiceProvider.DisplayWebsiteUrl;
			command.Parameters.Add("@IsDisplayAddress", SqlDbType.Bit).Value = this._newServiceProvider.DisplayAddress;
			command.Parameters.Add("@IsAutoProvision", SqlDbType.Bit).Value = this._newServiceProvider.CallTrackingPhones.Any<CallTrackingPhone>();
			command.Parameters.Add("@UserId", SqlDbType.UniqueIdentifier).Value = this._newServiceProvider.UserId;
			command.Parameters.Add("@IsActive", SqlDbType.Bit).Value = true;
			command.Parameters.Add("@AddressTable", SqlDbType.Structured).Value = this._newServiceProvider.Address.GetAddressTable();
			command.Parameters.Add("@PhoneTable", SqlDbType.Structured).Value = this._newServiceProvider.Phones.GetPhoneTable();
			command.Parameters.Add("@emailTable", SqlDbType.Structured).Value = this._newServiceProvider.Emails.GetEmailTable();
			command.Parameters.Add("@ContactTable", SqlDbType.Structured).Value = this._newServiceProvider.Contacts.GetContactTable();
			SqlParameter sqlParameter = command.Parameters.Add("@PackageTable", SqlDbType.Structured);
			DataTable packageTableValue = this._newServiceProvider.Package.GetAdditionalInfoTable(true);
			sqlParameter.Value = packageTableValue;
			SqlParameter sqlParameter1 = command.Parameters.Add("@SeniorHousingAndCareCategoryTable", SqlDbType.Structured);
			DataTable housingAndCareTableValue = (
				from sc in this._newServiceProvider.ServiceCategories
				select sc.Key).GetSeniorHousingAdditionalInfoTable(true);
			sqlParameter1.Value = housingAndCareTableValue;
			command.Parameters.Add("@ServiceOfficeHoursTable", SqlDbType.Structured).Value = this._newServiceProvider.OfficeHours.GetOfficeHoursTable();
			SqlParameter sqlParameter2 = command.Parameters.Add("@PaymentTable", SqlDbType.Structured);
			DataTable paymentTableValue = this._newServiceProvider.PaymentTypeIds.GetPaymentAdditionalInfoTable(true);
			sqlParameter2.Value = paymentTableValue;
			SqlParameter sqlParameter3 = command.Parameters.Add("@CouponTable", SqlDbType.Structured);
			DataTable couponTableValue = this._newServiceProvider.Coupon.GetAdditionalInfoTable(this._couponTypeId);
			sqlParameter3.Value = couponTableValue;
			SqlParameter sqlParameter4 = command.Parameters.Add("@FeatureTable", SqlDbType.Structured);
			DataTable featureTableValue = TableParamsExtensions.GetDateTable(this._newServiceProvider.FeatureStartDate, this._newServiceProvider.FeatureEndDate, new AdditionalInfoClass?(AdditionalInfoClass.Feature), this._featureTypeId);
			sqlParameter4.Value = featureTableValue;
			SqlParameter sqlParameter5 = command.Parameters.Add("@PublishTable", SqlDbType.Structured);
			DataTable publishTableValue = TableParamsExtensions.GetDateTable(this._newServiceProvider.PublishStartDate, this._newServiceProvider.PublishEndDate, new AdditionalInfoClass?(AdditionalInfoClass.Publish), this._publishTypeId);
			sqlParameter5.Value = publishTableValue;
			command.Parameters.Add("@ImageTable", SqlDbType.Structured).Value = this._newServiceProvider.Images.GetImageTable();
			command.Parameters.Add("@ServiceCountiesServedTable", SqlDbType.Structured).Value = this._newServiceProvider.CountiesServed.GetServiceCountiesServedTable();
			command.ExecuteNonQuery();
		}

		protected override ServiceProvider GetCommandResult(SqlCommand command)
		{
			this._newServiceProvider.Id = new long?((long)command.Parameters["@ScopeServiceId"].Value);
			return this._newServiceProvider;
		}
	}
}