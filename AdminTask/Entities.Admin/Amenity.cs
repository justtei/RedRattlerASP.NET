using System;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Entities.Admin
{
	[Serializable]
	public class Amenity
	{
		public int? ClassId
		{
			get;
			set;
		}

		public long? CommunityId
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

		public Amenity()
		{
			this.ClassId = new int?(-1);
		}

		public Amenity(long? id, int? classId, string name)
		{
			this.Id = id;
			this.ClassId = classId;
			this.Name = name;
		}
	}
}