using System;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Entities.Admin
{
	[Serializable]
	public class State
	{
		public string Code
		{
			get;
			set;
		}

		public MSLivingChoices.Entities.Admin.Country Country
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

		public State()
		{
		}

		public State(long? id, string code, string name)
		{
			this.Id = id;
			this.Code = code;
			this.Name = name;
		}
	}
}