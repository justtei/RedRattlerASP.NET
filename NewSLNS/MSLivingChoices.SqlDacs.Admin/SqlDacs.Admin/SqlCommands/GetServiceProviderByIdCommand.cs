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

namespace MSLivingChoices.SqlDacs.Admin.SqlCommands
{
	internal class GetServiceProviderByIdCommand : BaseCommand<ServiceProvider>
	{
		private readonly long _id;

		private readonly ServiceProvider _serviceProvider;

		public GetServiceProviderByIdCommand(long id)
		{
			base.StoredProcedureName = AdminStoredProcedures.SpGetServiceDetail;
			this._id = id;
			this._serviceProvider = new ServiceProvider()
			{
				Id = new long?(this._id)
			};
		}

		protected override void CommandBody(SqlCommand command)
		{
			long? nullable;
			command.CommandText = base.StoredProcedureName;
			command.CommandType = CommandType.StoredProcedure;
			command.Parameters.Add("@ServiceId", SqlDbType.BigInt).Value = this._id;
			SqlDataReader reader = command.ExecuteReader();
			this._serviceProvider.Book = new Book();
			if (reader.Read())
			{
				this._serviceProvider.Name = reader["Name"].ToString();
				Book book = this._serviceProvider.Book;
				int? nullableValue = reader.GetNullableValue<int>("BookId");
				if (nullableValue.HasValue)
				{
					nullable = new long?((long)nullableValue.GetValueOrDefault());
				}
				else
				{
					nullable = null;
				}
				book.Id = nullable;
				this._serviceProvider.Description = reader["Description"].ToString();
				this._serviceProvider.WebsiteUrl = reader["WebsiteURL"].ToString();
				this._serviceProvider.DisplayWebsiteUrl = reader.GetNullableValue<bool>("IsDisplayWebsiteUrl").FromNullable();
				this._serviceProvider.DisplayAddress = reader.GetNullableValue<bool>("IsDisplayAddress").FromNullable();
				this._serviceProvider.MarchexAccountId = reader.GetValue<string>("MARCHEX_AccountId");
				this._serviceProvider.UserId = reader.GetNullableValue<Guid>("ModifyUserId");
			}
			if (reader.NextResult())
			{
				this._serviceProvider.Address = reader.GetAddress();
			}
			if (reader.NextResult())
			{
				this._serviceProvider.Phones = reader.GetPhones().Item1;
			}
			if (reader.NextResult())
			{
				this._serviceProvider.Emails = reader.GetEmails();
			}
			if (reader.NextResult())
			{
				this._serviceProvider.Contacts = reader.GetContacts();
			}
			if (reader.NextResult())
			{
				this._serviceProvider.OfficeHours = reader.GetOfficeHours();
			}
			if (reader.NextResult())
			{
				this._serviceProvider.Images = reader.GetImages();
			}
			if (reader.NextResult())
			{
				this._serviceProvider.CallTrackingPhones = reader.GetPhones().Item2;
			}
			if (reader.NextResult())
			{
				List<AdditionalInfo> infos = reader.GetAdditionalInfo();
				this._serviceProvider.PaymentTypeIds = infos.GetServicePaymentTypes();
				this._serviceProvider.ServiceCategories = infos.GetServiceCategories();
				this._serviceProvider.Package = new PackageType?(infos.GetServicePackage());
				DateTimeBoundary<bool> feature = infos.GetFeature();
				this._serviceProvider.FeatureEndDate = feature.EndDate;
				this._serviceProvider.FeatureStartDate = feature.StartDate;
				DateTimeBoundary<PublishingStatus> publish = infos.GetPublishing();
				this._serviceProvider.PublishEndDate = publish.EndDate;
				this._serviceProvider.PublishStartDate = publish.StartDate;
				this._serviceProvider.Coupon = infos.GetCoupon();
			}
		}

		protected override ServiceProvider GetCommandResult(SqlCommand command)
		{
			return this._serviceProvider;
		}
	}
}