using System;
using System.Collections.Generic;
using MSLivingChoices.Entities.Client;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSLivingChoices.SqlDacs.Client.SqlCommands
{
    class SaveEbookOrderCommand : SqlDacs.SqlCommands.BaseCommand<Entities.Client.EbookOrder>
    {
        private readonly Entities.Client.EbookOrder _eb;
        private bool Result = false;
        public SaveEbookOrderCommand(Entities.Client.EbookOrder eb)
        {
            this._eb = eb;
            this.StoredProcedureName = "RspSavEbook";
        }
        protected override void CommandBody(System.Data.SqlClient.SqlCommand command)
        {
            command.CommandText = base.StoredProcedureName;
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add("@FirstName", System.Data.SqlDbType.VarChar).Value = _eb.FirstName;
            command.Parameters.Add("@LastName", System.Data.SqlDbType.VarChar).Value = _eb.LastName;
            command.Parameters.Add("@Email", System.Data.SqlDbType.VarChar).Value = _eb.Email;
            command.Parameters.Add("@Phone", System.Data.SqlDbType.VarChar).Value = _eb.Phone;
            command.Parameters.Add("@Magazine", System.Data.SqlDbType.VarChar).Value = _eb.Magazine;
            command.Parameters.Add("@street", System.Data.SqlDbType.VarChar).Value = _eb.street;
            command.Parameters.Add("@city", System.Data.SqlDbType.VarChar).Value = _eb.city;
            command.Parameters.Add("@state", System.Data.SqlDbType.VarChar).Value = _eb.state;
            command.Parameters.Add("@zip", System.Data.SqlDbType.VarChar).Value = _eb.zip;
            command.Parameters.Add("@isCommunities", System.Data.SqlDbType.Bit).Value = _eb.chkCommunities;
            command.Parameters.Add("@isHomeHealth", System.Data.SqlDbType.Bit).Value = _eb.chkHomeHealth;
            command.Parameters.Add("@isPAS", System.Data.SqlDbType.Bit).Value = _eb.chkPAS;
            command.Parameters.Add("@isContactBack", System.Data.SqlDbType.Bit).Value = _eb.rad;
            command.Parameters.Add("@ExtraMessage", System.Data.SqlDbType.VarChar).Value = _eb.ExtraMessage;
            command.ExecuteNonQuery();
            Result = true;
        }
        protected override Entities.Client.EbookOrder GetCommandResult(System.Data.SqlClient.SqlCommand command)
        {
            _eb.Result = Result;
            return _eb;
        }
    }
}
