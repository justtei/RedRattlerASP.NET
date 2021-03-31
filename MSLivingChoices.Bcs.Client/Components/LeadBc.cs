using MSLivingChoices.Bcs.Client;
using MSLivingChoices.Entities.Client;
using MSLivingChoices.IDacs.Client;
using MSLivingChoices.IDacs.Client.Components;
using System;

namespace MSLivingChoices.Bcs.Client.Components
{
	public class LeadBc
	{
		private readonly ILeadDac _leadDac;

		private static LeadBc _leadBc;

		private readonly static object Locker;

		public static LeadBc Instance
		{
			get
			{
				if (LeadBc._leadBc == null)
				{
					lock (LeadBc.Locker)
					{
						if (LeadBc._leadBc == null)
						{
							LeadBc._leadBc = new LeadBc();
						}
					}
				}
				return LeadBc._leadBc;
			}
		}

		static LeadBc()
		{
			LeadBc.Locker = new object();
		}

		private LeadBc()
		{
			this._leadDac = ClientDacFactoryClient.GetConcreteFactory().GetLeadDac();
		}

		public void ProcessLead(Lead lead)
		{
			this._leadDac.SaveLead(lead);
		}
	}
}