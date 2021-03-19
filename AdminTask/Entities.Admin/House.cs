using MSLivingChoices.Entities.Admin.Enums;
using System;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Entities.Admin
{
	[Serializable]
	public class House : FloorPlan
	{
		public MSLivingChoices.Entities.Admin.Address Address
		{
			get;
			set;
		}

		public string Description
		{
			get;
			set;
		}

		public HomeSaleType SaleType
		{
			get;
			set;
		}

		public int? YearBuilt
		{
			get;
			set;
		}

		public House()
		{
		}

		public House(MSLivingChoices.Entities.Admin.Community community) : this()
		{
			base.Community = community;
		}
	}
}