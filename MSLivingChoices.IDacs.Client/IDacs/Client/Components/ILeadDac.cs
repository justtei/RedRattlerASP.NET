using MSLivingChoices.Entities.Client;
using System;

namespace MSLivingChoices.IDacs.Client.Components
{
	public interface ILeadDac
	{
		void SaveLead(Lead lead);
	}
}