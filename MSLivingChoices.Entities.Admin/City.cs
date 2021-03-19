using System;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Entities.Admin
{
	[Serializable]
	public class City
	{
		public MSLivingChoices.Entities.Admin.Country Country
		{
			get
			{
				if (this.State == null)
				{
					return null;
				}
				return this.State.Country;
			}
			set
			{
				if (this.State != null)
				{
					this.State.Country = value;
				}
			}
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

		public MSLivingChoices.Entities.Admin.State State
		{
			get;
			set;
		}

		public City()
		{
		}

		public City(long? id, string name)
		{
			this.Id = id;
			this.Name = name;
		}
	}
}