using System;

namespace MSLivingChoices.Entities.Client.Enums
{
	[Serializable]
	public enum SearchDepth
	{
		Country,
		State,
		City,
		Zip,
		Invalid
	}
}