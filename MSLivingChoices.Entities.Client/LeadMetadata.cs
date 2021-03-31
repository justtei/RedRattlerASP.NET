using MSLivingChoices.Entities.Client.Enums;
using System;

namespace MSLivingChoices.Entities.Client
{
	[Serializable]
	public class LeadMetadata : KeyValueStorage<LeadMetadataKey>
	{
		public DeviceMetric? Device
		{
			get
			{
				return base.GetValue<DeviceMetric?>(LeadMetadataKey.Device);
			}
			set
			{
				base.AddValue(LeadMetadataKey.Device, value);
			}
		}

		public string Partner
		{
			get
			{
				return base.GetValue<string>(LeadMetadataKey.Partner);
			}
			set
			{
				base.AddValue(LeadMetadataKey.Partner, value);
			}
		}

		public LeadMetadata()
		{
		}
	}
}