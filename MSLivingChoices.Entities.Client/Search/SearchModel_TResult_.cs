using MSLivingChoices.Entities.Client.Search.Criteria;
using System;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Entities.Client.Search
{
	[Serializable]
	public class SearchModel<TResult>
	{
		public SearchCriteria Criteria
		{
			get;
			set;
		}

		public TResult Result
		{
			get;
			set;
		}

		public SearchModel()
		{
			this.Criteria = new SearchCriteria();
		}

		public override string ToString()
		{
			return this.Criteria.ToString();
		}
	}
}