using System;

namespace MSLivingChoices.Entities.Client.Search
{
	[Serializable]
	public class ServiceProviderSearchModel : ServiceProviderSearchModel<ServiceProviderSearchResult>
	{
		public ServiceProviderSearchModel()
		{
			base.Result = new ServiceProviderSearchResult();
		}
	}
}