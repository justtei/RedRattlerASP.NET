using System;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Entities.Admin
{
	[Serializable]
	public class CommunityService
	{
		public int? AdditionInfoTypeId
		{
			get;
			set;
		}

		public long? CommunityId
		{
			get;
			set;
		}

		public string Name
		{
			get;
			set;
		}

		public CommunityService()
		{
		}
	}
}