using MSLivingChoices.Entities.Admin;
using MSLivingChoices.Entities.Admin.Enums;
using MSLivingChoices.SqlDacs.Helpers;
using MSLivingChoices.SqlDacs.SqlCommands;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace MSLivingChoices.SqlDacs.Admin.SqlCommands
{
	internal class GetOwnerByIdCommand : BaseCommand<Owner>
	{
		private readonly Owner _owner = new Owner();

		private readonly long _id;

		public GetOwnerByIdCommand(long id)
		{
			base.StoredProcedureName = AdminStoredProcedures.SpGetOwner;
			this._id = id;
		}

		protected override void CommandBody(SqlCommand command)
		{
			command.CommandText = base.StoredProcedureName;
			command.CommandType = CommandType.StoredProcedure;
			command.Parameters.Add("@OwnerId", SqlDbType.BigInt).Value = this._id;
			SqlDataReader dataReader = command.ExecuteReader();
			if (dataReader.Read())
			{
				this._owner.Id = dataReader.GetValue<long?>("OwnerId");
				this._owner.Name = dataReader.GetValue<string>("Name");
				this._owner.OwnerType = (OwnerType)Convert.ToInt32(dataReader["OwnerClassId"]);
				int websiteUrl = dataReader.GetOrdinal("WebsiteURL");
				int isDisplayName = dataReader.GetOrdinal("IsDisplayName");
				int isDisplayAddress = dataReader.GetOrdinal("IsDisplayAddress");
				int isDisplayPhone = dataReader.GetOrdinal("IsDisplayPhone");
				int isDisplayWebsite = dataReader.GetOrdinal("IsDisplayWebsite");
				int isDisplayLogo = dataReader.GetOrdinal("IsDisplayLogo");
				this._owner.WebsiteUrl = (!dataReader.IsDBNull(websiteUrl) ? dataReader["WebsiteURL"].ToString() : string.Empty);
				this._owner.DisplayName = (dataReader.IsDBNull(isDisplayName) ? false : Convert.ToBoolean(dataReader["IsDisplayName"]));
				this._owner.DisplayAddress = (dataReader.IsDBNull(isDisplayAddress) ? false : Convert.ToBoolean(dataReader["IsDisplayAddress"]));
				this._owner.DisplayPhone = (dataReader.IsDBNull(isDisplayPhone) ? false : Convert.ToBoolean(dataReader["IsDisplayPhone"]));
				this._owner.DisplayWebsiteUrl = (dataReader.IsDBNull(isDisplayWebsite) ? false : Convert.ToBoolean(dataReader["IsDisplayWebsite"]));
				this._owner.DisplayLogo = (dataReader.IsDBNull(isDisplayLogo) ? false : Convert.ToBoolean(dataReader["IsDisplayLogo"]));
			}
			if (dataReader.NextResult())
			{
				this._owner.Address = new Address();
				if (dataReader.Read())
				{
					this._owner.Address.Id = dataReader.GetNullableValue<long>("AddressId");
					int num = (int)dataReader["CityId"];
					int stateId = (int)dataReader["StateId"];
					int countryId = (int)dataReader["CountryId"];
					GetCityByIdCommand getCity = new GetCityByIdCommand(new long?((long)num));
					GetStateByIdCommand getState = new GetStateByIdCommand(new long?((long)stateId));
					GetCountryByIdCommand getCountry = new GetCountryByIdCommand(new long?((long)countryId));
					getCity.Execute();
					getState.Execute();
					getCountry.Execute();
					this._owner.Address.City = getCity.CommandResult;
					this._owner.Address.State = getState.CommandResult;
					this._owner.Address.Country = getCountry.CommandResult;
					this._owner.Address.StreetAddress = dataReader["AddressLine1"].ToString();
					this._owner.Address.PostalCode = dataReader["PostalCode"].ToString();
				}
				this._owner.Phones = new List<Phone>();
				if (dataReader.NextResult())
				{
					while (dataReader.Read())
					{
						bool? isActive = dataReader.GetNullableValue<bool>("IsActive");
						if (!isActive.HasValue || !isActive.Value)
						{
							continue;
						}
						Phone item = new Phone()
						{
							Id = new long?((long)dataReader["PhoneId"]),
							PhoneTypeId = new long?((long)((int)dataReader["PhoneTypeId"])),
							Number = dataReader["Phone"].ToString(),
							Sequence = (int)dataReader["Sequence"]
						};
						this._owner.Phones.Add(item);
					}
				}
			}
			this._owner.Emails = new List<Email>();
			if (dataReader.NextResult())
			{
				while (dataReader.Read())
				{
					bool? isActive = dataReader.GetNullableValue<bool>("IsActive");
					if (!isActive.HasValue || !isActive.Value)
					{
						continue;
					}
					Email item = new Email()
					{
						Id = dataReader.GetNullableValue<long>("EmailId"),
						EmailTypeId = new long?((long)((int)dataReader["EmailTypeId"])),
						Value = dataReader["Email"].ToString(),
						Sequence = (int)dataReader["Sequence"]
					};
					this._owner.Emails.Add(item);
				}
			}
			this._owner.Contacts = new List<Contact>();
			if (dataReader.NextResult())
			{
				while (dataReader.Read())
				{
					bool? isActive = dataReader.GetNullableValue<bool>("IsActive");
					if (!isActive.HasValue || !isActive.Value)
					{
						continue;
					}
					Contact item = new Contact()
					{
						Id = new long?((long)dataReader["ContactId"]),
						ContactTypeId = new long?((long)((int)dataReader["ContactTypeId"])),
						FirstName = dataReader["FirstName"].ToString(),
						LastName = dataReader["LastName"].ToString(),
						Sequence = (int)dataReader["sequence"]
					};
					this._owner.Contacts.Add(item);
				}
			}
			this._owner.LogoImages = new List<Image>();
			if (dataReader.NextResult())
			{
				while (dataReader.Read())
				{
					bool? isActive = dataReader.GetNullableValue<bool>("IsActive");
					if (!isActive.HasValue || !isActive.Value)
					{
						continue;
					}
					Image image = new Image()
					{
						Id = dataReader.GetNullableValue<long>("ImageId"),
						ImageType = dataReader.GetEnum<ImageType>("ImageTypeId"),
						Name = dataReader.GetValue<string>("PathFileName"),
						Url = dataReader.GetValueOrDefault<string>("OriginalPath"),
						ThumbnailUrl = dataReader.GetValueOrDefault<string>("ThumbnailPath")
					};
					if (image.ImageType != ImageType.Logo)
					{
						continue;
					}
					this._owner.LogoImages.Add(image);
				}
			}
		}

		protected override Owner GetCommandResult(SqlCommand command)
		{
			return this._owner;
		}
	}
}