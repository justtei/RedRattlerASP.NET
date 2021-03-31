using MSLivingChoices.Entities.Client;
using MSLivingChoices.Entities.Client.Enums;
using MSLivingChoices.SqlDacs.Client.Utilities;
using MSLivingChoices.SqlDacs.Helpers;
using MSLivingChoices.SqlDacs.SqlCommands;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace MSLivingChoices.SqlDacs.Client.SqlCommands
{
	internal class SaveNewLeadCommand : FreeCacheBaseCommand<Lead>
	{
		private readonly Lead _lead;

		public SaveNewLeadCommand(Lead lead)
		{
			base.StoredProcedureName = ClientStoredProcedures.SpPutNewLead;
			this._lead = lead;
		}

		protected override void CommandBody(SqlCommand command)
		{
			command.CommandText = base.StoredProcedureName;
			command.CommandType = CommandType.StoredProcedure;
			LeadTarget leadTarget = this._lead.Targets.First<LeadTarget>();
			LeadTargetType type = leadTarget.Type;
			if (type == LeadTargetType.Community)
			{
				command.Parameters.Add("@CommunityId", SqlDbType.BigInt).Value = leadTarget.InnerId;
			}
			else if (type == LeadTargetType.ServiceProvider)
			{
				command.Parameters.Add("@ServiceId", SqlDbType.BigInt).Value = leadTarget.InnerId;
			}
			command.Parameters.Add("@ConsumerFullName", SqlDbType.VarChar, 100).Value = this._lead.Customer.Name ?? string.Empty;
			command.Parameters.Add("@ConsumerEmail", SqlDbType.VarChar, 100).Value = this._lead.Customer.Email ?? string.Empty;
			command.Parameters.Add("@ConsumerPhone", SqlDbType.VarChar, 20).Value = this._lead.Customer.Phone ?? string.Empty;
			command.Parameters.Add("@ConsumerMessage", SqlDbType.VarChar, 800).Value = this._lead.Message ?? string.Empty;
			command.Parameters.Add("@ConsumerMoveInDate", SqlDbType.DateTime).Value = this._lead.Data.MoveInDate.ValueOrDBNull<DateTime?>();
			command.Parameters.Add("@ConsumerLookingForTypeId", SqlDbType.Int).Value = this._lead.Data.LookingFor.ValueOrDBNull<LookingForType?>();
			command.Parameters.Add("@LeadTypeId", SqlDbType.Int).Value = (int)this._lead.Metadata.Device.ToLegacyLeadType();
			command.Parameters.Add("@LeadPageTypeId", SqlDbType.Int).Value = this._lead.Inquiry.ToLegacyLeadPageType();
			command.Parameters.Add("@LeadEventTypeId", SqlDbType.Int).Value = this._lead.Inquiry.ToLeadEventType();
			command.Parameters.Add("@LeadBrand", SqlDbType.VarChar, 3).Value = this._lead.Data.Brand.ToLegacyBrand();
			command.ExecuteNonQuery();
		}
	}
}