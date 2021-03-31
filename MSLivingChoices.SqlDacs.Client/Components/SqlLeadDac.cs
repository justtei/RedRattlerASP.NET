using MSLivingChoices.Entities.Client;
using MSLivingChoices.IDacs.Client.Components;
using MSLivingChoices.SqlDacs.Client.SqlCommands;
using MSLivingChoices.SqlDacs.SqlCommands;
using System;

namespace MSLivingChoices.SqlDacs.Client.Components
{
	public class SqlLeadDac : ILeadDac
	{
		public SqlLeadDac()
		{
		}

		public void SaveLead(Lead lead)
		{
			(new SaveNewLeadCommand(lead)).Execute();
		}
	}
}