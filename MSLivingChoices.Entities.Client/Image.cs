using MSLivingChoices.Entities.Client.Enums;
using System;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Entities.Client
{
	[Serializable]
	public class Image
	{
		private string _thumbnailUrl;

		public string ThumbnailUrl
		{
			get
			{
				return this._thumbnailUrl ?? this.Url;
			}
			set
			{
				this._thumbnailUrl = value;
			}
		}

		public ImageType Type
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

		public override string ToString()
		{
			return this.Url;
		}
	}
}