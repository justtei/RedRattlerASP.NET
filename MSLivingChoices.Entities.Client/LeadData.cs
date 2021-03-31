using MSLivingChoices.Entities.Client.Enums;
using System;

namespace MSLivingChoices.Entities.Client
{
	[Serializable]
	public class LeadData : KeyValueStorage<LeadDataKey>
	{
		public BrandType? Brand
		{
			get
			{
				return base.GetValue<BrandType?>(LeadDataKey.Brand);
			}
			set
			{
				base.AddValue(LeadDataKey.Brand, value);
			}
		}

		public long? CommunityUnitId
		{
			get
			{
				return base.GetValue<long?>(LeadDataKey.CommunityUnitId);
			}
			set
			{
				base.AddValue(LeadDataKey.CommunityUnitId, value);
			}
		}

		public LookingForType? LookingFor
		{
			get
			{
				return base.GetValue<LookingForType?>(LeadDataKey.LookingFor);
			}
			set
			{
				base.AddValue(LeadDataKey.LookingFor, value);
			}
		}

		public DateTime? MoveInDate
		{
			get
			{
				return base.GetValue<DateTime?>(LeadDataKey.MoveInDate);
			}
			set
			{
				base.AddValue(LeadDataKey.MoveInDate, value);
			}
		}

		public LeadData()
		{
		}
	}
}