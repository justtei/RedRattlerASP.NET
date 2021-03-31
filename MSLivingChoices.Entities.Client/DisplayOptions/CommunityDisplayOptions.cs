using System;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Entities.Client.DisplayOptions
{
	[Serializable]
	public class CommunityDisplayOptions
	{
		public bool Address
		{
			get;
			set;
		}

		public bool FloorPlans
		{
			get;
			set;
		}

		public bool Homes
		{
			get;
			set;
		}

		public bool SpecHomes
		{
			get;
			set;
		}

		public bool Website
		{
			get;
			set;
		}

		public CommunityDisplayOptions()
		{
		}
	}
}