using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Entities.Admin
{
	[Serializable]
	public class Book
	{
		public Owner Distributor
		{
			get;
			set;
		}

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

		public string Number
		{
			get;
			set;
		}

		public List<Address> Regions
		{
			get;
			set;
		}

		public Book()
		{
		}
	}
}