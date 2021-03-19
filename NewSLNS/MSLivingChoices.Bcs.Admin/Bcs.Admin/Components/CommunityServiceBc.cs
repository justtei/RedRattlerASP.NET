using MSLivingChoices.Bcs.Admin;
using MSLivingChoices.Entities.Admin;
using MSLivingChoices.IDacs.Admin;
using MSLivingChoices.IDacs.Admin.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Bcs.Admin.Components
{
	public class CommunityServiceBc
	{
		private readonly ICommunityServiceDac _communityServiceDac;

		private static CommunityServiceBc _communityServiceBc;

		private readonly static object Locker;

		public static CommunityServiceBc Instance
		{
			get
			{
				if (CommunityServiceBc._communityServiceBc == null)
				{
					lock (CommunityServiceBc.Locker)
					{
						if (CommunityServiceBc._communityServiceBc == null)
						{
							CommunityServiceBc._communityServiceBc = new CommunityServiceBc();
						}
					}
				}
				return CommunityServiceBc._communityServiceBc;
			}
		}

		static CommunityServiceBc()
		{
			CommunityServiceBc.Locker = new object();
		}

		private CommunityServiceBc()
		{
			this._communityServiceDac = AdminDacFactoryClient.GetConcreteFactory().GetCommunityServiceDac();
		}

		public List<CommunityService> GetDefaultCommunityServices()
		{
			return (
				from c in this._communityServiceDac.GetDefaultCommunityServices()
				where !c.Name.Equals("Custom Community Service")
				select c).ToList<CommunityService>();
		}
	}
}