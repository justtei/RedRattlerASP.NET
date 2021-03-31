using System;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Entities.Client
{
	[Serializable]
	public class County
	{
		public long? Id
		{
			get;
			set;
		}

		public string Name
		{
			get;
			set;
		}

		public County()
		{
		}
	}
}