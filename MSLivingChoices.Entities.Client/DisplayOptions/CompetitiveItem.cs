using System;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Entities.Client.DisplayOptions
{
	[Serializable]
	public class CompetitiveItem
	{
		public int Id
		{
			get;
			set;
		}

		public string Key
		{
			get;
			set;
		}

		public CompetitiveItem()
		{
		}
	}
}