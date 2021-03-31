using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Entities.Client.Search
{
	[Serializable]
	public class SearchResult<TResult>
	{
		public bool HasItemsInLocation
		{
			get;
			set;
		}

		public List<TResult> Results
		{
			get;
			set;
		}

		public int TotalCount
		{
			get;
			set;
		}

		public SearchResult()
		{
			this.Results = new List<TResult>();
		}
	}
}