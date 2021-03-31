using MSLivingChoices.Entities.Client.Search.Criteria;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Entities.Client.Search
{
	[Serializable]
	public class LookupLocationValidationResult
	{
		public SearchCriteria Criteria
		{
			get;
			set;
		}

		public bool IsValid
		{
			get;
			set;
		}

		public List<SearchCriteria> Variants
		{
			get;
			set;
		}

		public LookupLocationValidationResult()
		{
			this.Variants = new List<SearchCriteria>();
		}
	}
}