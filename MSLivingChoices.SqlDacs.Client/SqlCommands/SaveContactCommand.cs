using MSLivingChoices.Entities.Client;
using MSLivingChoices.SqlDacs.SqlCommands;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSLivingChoices.SqlDacs.Client.SqlCommands
{
    class SaveContactCommand : BaseCommand<Contact>
    {
        private Contact _Contact;
        public SaveContactCommand(Contact contact)
        {
            this._Contact = contact;
            base.StoredProcedureName = "RspAddContact";
        }
        protected override void CommandBody(SqlCommand command)
        {
            command.CommandText = base.StoredProcedureName;
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Name", SqlDbType.VarChar).Value = _Contact.Name;
            command.Parameters.Add("@Email", SqlDbType.VarChar).Value = _Contact.Email;
            command.Parameters.Add("@PhoneNumber", SqlDbType.VarChar).Value = _Contact.PhoneNumber;
            command.Parameters.Add("@Interest", SqlDbType.Int).Value = _Contact.Interest;
            command.Parameters.Add("@Message", SqlDbType.VarChar).Value = _Contact.Message;
            command.ExecuteNonQuery();
            _Contact.Result = true;

        }
        protected override Contact GetCommandResult(SqlCommand command)
        {
            return _Contact;
        }
    }
}
