using System;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Entities.Client
{
	[Serializable]
	public class Customer
	{
		public string Email
		{
			get;
			set;
		}

		public string Name
		{
			get;
			set;
		}

		public string Phone
		{
			get;
			set;
		}

		public Customer()
		{
		}
	}
}