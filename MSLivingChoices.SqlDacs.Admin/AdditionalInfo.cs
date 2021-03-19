using MSLivingChoices.Entities.Admin.Enums;
using System;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.SqlDacs.Admin
{
	[Serializable]
	internal class AdditionalInfo
	{
		public MSLivingChoices.Entities.Admin.Enums.AdditionalInfoClass AdditionalInfoClass
		{
			get;
			set;
		}

		public int? AdditionalInfoTypeId
		{
			get;
			set;
		}

		public long? CommunityId
		{
			get;
			set;
		}

		public long? CommunityUnitId
		{
			get;
			set;
		}

		public string Description
		{
			get;
			set;
		}

		public DateTime? EndDate
		{
			get;
			set;
		}

		public long? Id
		{
			get;
			set;
		}

		public string LongText
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

		public string ShortText
		{
			get;
			set;
		}

		public DateTime? StartDate
		{
			get;
			set;
		}

		public AdditionalInfo()
		{
		}
	}
}