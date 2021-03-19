using MSLivingChoices.Entities.Admin;
using MSLivingChoices.IDacs.Admin.Components;
using MSLivingChoices.SqlDacs.Admin.Helpers;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.SqlDacs.Admin.Components
{
	public class SqlCommunityServiceDac : ICommunityServiceDac
	{
		public SqlCommunityServiceDac()
		{
		}

		public List<CommunityService> GetDefaultCommunityServices()
		{
			return DefaultItemsProvider.Instance.DefaultServiceTypes().ConvertAll<CommunityService>((KeyValuePair<int, string> m) => new CommunityService()
			{
				AdditionInfoTypeId = new int?(m.Key),
				Name = m.Value
			});
		}
	}
}