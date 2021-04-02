using MSLivingChoices.Entities.Admin;
using System.Collections.Generic;

namespace MSLivingChoices.IDacs.Admin.Components
{
	public interface ICommunityServiceDac
	{
		List<CommunityService> GetDefaultCommunityServices();
	}
}