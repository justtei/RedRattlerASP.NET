using System;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Entities.Admin
{
	[Serializable]
	public class Contact
	{
		public long? ContactTypeId
		{
			get;
			set;
		}

		public string FirstName
		{
			get;
			set;
		}

		public long? Id
		{
			get;
			set;
		}

		public string LastName
		{
			get;
			set;
		}

		public int Sequence
		{
			get;
			set;
		}

		public Contact()
		{
		}
	}
}