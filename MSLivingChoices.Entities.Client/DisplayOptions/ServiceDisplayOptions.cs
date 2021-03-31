using System;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Entities.Client.DisplayOptions
{
	[Serializable]
	public class ServiceDisplayOptions
	{
		public bool Address
		{
			get;
			set;
		}

		public bool Website
		{
			get;
			set;
		}

		public ServiceDisplayOptions()
		{
		}
	}
}