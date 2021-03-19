using System;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Entities.Admin
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