using MSLivingChoices.Entities.Admin.Enums;
using System;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Entities.Admin
{
	[Serializable]
	public class Image
	{
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

		public long? Id
		{
			get;
			set;
		}

		public MSLivingChoices.Entities.Admin.Enums.ImageType ImageType
		{
			get;
			set;
		}

		public string Name
		{
			get;
			set;
		}

		public long? ServiceId
		{
			get;
			set;
		}

		public ImageStatus Status
		{
			get;
			set;
		}

		public string ThumbnailUrl
		{
			get;
			set;
		}

		public string Url
		{
			get;
			set;
		}

		public Image()
		{
		}
	}
}