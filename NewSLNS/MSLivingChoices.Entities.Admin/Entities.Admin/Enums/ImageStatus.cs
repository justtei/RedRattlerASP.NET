using System;

namespace MSLivingChoices.Entities.Admin.Enums
{
	[Serializable]
	public enum ImageStatus
	{
		NotProcessed = 1,
		ProcessingStarted = 2,
		ProcessingFailed = 3,
		Processed = 4
	}
}