using System;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Entities.Admin
{
	[Serializable]
	public class Country
	{
		public string Code
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

		public Country()
		{
		}

		public Country(long? id, string code, string name)
		{
			this.Id = id;
			this.Code = code;
			this.Name = name;
		}
	}
}