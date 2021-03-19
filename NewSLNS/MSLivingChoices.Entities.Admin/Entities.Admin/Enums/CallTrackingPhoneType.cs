using System;

namespace MSLivingChoices.Entities.Admin.Enums
{
	[Serializable]
	public enum CallTrackingPhoneType
	{
		ProvisionOnline = 11,
		ProvisionPrintAd = 12,
		ProvisionCampaign = 13,
		ProvisionOnlineAndPrintAd = 16
	}
}