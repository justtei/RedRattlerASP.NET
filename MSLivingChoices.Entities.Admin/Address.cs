using System;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Entities.Admin
{
	[Serializable]
	public class Address
	{
		public string AddressLine1
		{
			get;
			set;
		}

		public string AddressLine2
		{
			get;
			set;
		}

		public MSLivingChoices.Entities.Admin.City City
		{
			get;
			set;
		}

		public long? CommunityId
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

		public MSLivingChoices.Entities.Admin.Location Location
		{
			get;
			set;
		}

		public string PostalCode
		{
			get;
			set;
		}

		public int Sequence
		{
			get;
			set;
		}

		public long? ServiceId
		{
			get;
			set;
		}

		public MSLivingChoices.Entities.Admin.State State
		{
			get;
			set;
		}

		public string StreetAddress
		{
			get
			{
				return this.AddressLine1;
			}
			set
			{
				this.AddressLine1 = value;
			}
		}

		public Address()
		{
			this.Country = new MSLivingChoices.Entities.Admin.Country();
			this.State = new MSLivingChoices.Entities.Admin.State();
			this.City = new MSLivingChoices.Entities.Admin.City();
			this.Location = new MSLivingChoices.Entities.Admin.Location();
		}
	}
}