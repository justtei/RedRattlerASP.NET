using MSLivingChoices.Entities.Client.Enums;
using System;

namespace MSLivingChoices.Entities.Client.Search.Criteria
{
	public interface ISearchCriteria
	{
		SearchDepth Depth
		{
			get;
		}

		ISearchCriteria Component(string key, object value);

		T Component<T>(string key);
	}
}