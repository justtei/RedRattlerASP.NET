using MSLivingChoices.Entities.Admin.Enums;
using System;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Entities.Admin
{
	[Serializable]
	public class SpecHome : FloorPlan
	{
		public string Description
		{
			get;
			set;
		}

		public MSLivingChoices.Entities.Admin.Enums.SaleType SaleType
		{
			get;
			set;
		}

		public SpecHomeStatus Status
		{
			get;
			set;
		}

		public SpecHome()
		{
		}

		public SpecHome(MSLivingChoices.Entities.Admin.Community community) : this()
		{
			base.Community = community;
		}
	}
}