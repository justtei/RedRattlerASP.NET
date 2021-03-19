using System;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Entities.Admin
{
	[Serializable]
	public class Email
	{
		public long? EmailTypeId
		{
			get;
			set;
		}

		public long? Id
		{
			get;
			set;
		}

		public int Sequence
		{
			get;
			set;
		}

		public string Value
		{
			get;
			set;
		}

		public Email()
		{
		}
	}
}