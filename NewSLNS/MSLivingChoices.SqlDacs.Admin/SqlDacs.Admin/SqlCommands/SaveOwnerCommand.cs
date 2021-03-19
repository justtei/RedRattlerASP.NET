using MSLivingChoices.Entities.Admin;
using MSLivingChoices.SqlDacs.Admin.Helpers;
using MSLivingChoices.SqlDacs.Helpers;
using MSLivingChoices.SqlDacs.SqlCommands;
using System;
using System.Data;
using System.Data.SqlClient;

namespace MSLivingChoices.SqlDacs.Admin.SqlCommands
{
	internal class SaveOwnerCommand : FreeCacheBaseCommand<Owner>
	{
		private readonly Owner _result;

		public SaveOwnerCommand(Owner owner)
		{
			base.StoredProcedureName = AdminStoredProcedures.SpPutOwner;
			this._result = owner;
		}

		protected override void CommandBody(SqlCommand command)
		{
			object valueOrDefault;
			command.CommandText = base.StoredProcedureName;
			command.CommandType = CommandType.StoredProcedure;
			command.Parameters.Add("@OwnerClassId", SqlDbType.Int).Value = (int)this._result.OwnerType;
			SqlParameter sqlParameter = command.Parameters.Add("@OwnerId", SqlDbType.BigInt);
			long? id = this._result.Id;
			if (id.HasValue)
			{
				valueOrDefault = id.GetValueOrDefault();
			}
			else
			{
				valueOrDefault = DBNull.Value;
			}
			sqlParameter.Value = valueOrDefault;
			command.Parameters.Add("@Name", SqlDbType.VarChar, 50).Value = this._result.Name;
			command.Parameters.Add("@WebsiteUrl", SqlDbType.VarChar, 200).Value = this._result.WebsiteUrl.ValueOrDBNull<string>();
			command.Parameters.Add("@IsDisplayName", SqlDbType.Bit).Value = this._result.DisplayName;
			command.Parameters.Add("@IsDisplayAddress", SqlDbType.Bit).Value = this._result.DisplayAddress;
			command.Parameters.Add("@IsDisplayPhone", SqlDbType.Bit).Value = this._result.DisplayPhone;
			command.Parameters.Add("@IsDisplayWebsite", SqlDbType.Bit).Value = this._result.DisplayWebsiteUrl;
			command.Parameters.Add("@IsDisplayLogo", SqlDbType.Bit).Value = this._result.DisplayLogo;
			command.Parameters.Add("@ScopeOwnerId", SqlDbType.BigInt).Direction = ParameterDirection.Output;
			command.Parameters.Add("@Sequence", SqlDbType.Int).Value = 1;
			command.Parameters.Add("@UserId", SqlDbType.UniqueIdentifier).Value = this._result.UserId;
			DataTable addressTable = this._result.Address.GetAddressTable();
			command.Parameters.Add("@AddressTable", SqlDbType.Structured).Value = addressTable;
			DataTable phoneTable = this._result.Phones.GetPhoneTable();
			command.Parameters.Add("@PhoneTable", SqlDbType.Structured).Value = phoneTable;
			DataTable emailTable = this._result.Emails.GetEmailTable();
			command.Parameters.Add("@EmailTable", SqlDbType.Structured).Value = emailTable;
			DataTable contactTable = this._result.Contacts.GetContactTable();
			command.Parameters.Add("@ContactTable", SqlDbType.Structured).Value = contactTable;
			DataTable imageTable = this._result.LogoImages.GetImageTable();
			command.Parameters.Add("@ImageTable", SqlDbType.Structured).Value = imageTable;
			command.ExecuteNonQuery();
		}

		protected override Owner GetCommandResult(SqlCommand command)
		{
			this._result.Id = new long?(Convert.ToInt64(command.Parameters["@ScopeOwnerId"].Value));
			return this._result;
		}
	}
}