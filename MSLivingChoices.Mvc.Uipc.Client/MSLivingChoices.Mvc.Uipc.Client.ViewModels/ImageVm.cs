using MSLivingChoices.Configuration;
using MSLivingChoices.Entities.Client.Enums;
using MSLivingChoices.Utilities;
using Newtonsoft.Json;
using System;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Mvc.Uipc.Client.ViewModels
{
	public class ImageVm
	{
		private string _src;

		private string _thumbnailSrc;

		public string Alt
		{
			get;
			set;
		}

		public string OnErrorSrc
		{
			get
			{
				if (this.Owner != ImageOwner.CommunityUnit)
				{
					return ConfigurationManager.Instance.NoImageListingSrc;
				}
				return ConfigurationManager.Instance.NoImageUnitSrc;
			}
		}

		[JsonIgnore]
		public ImageOwner Owner
		{
			get;
			set;
		}

		public string Src
		{
			get
			{
				string str;
				str = (this._src.IsNullOrEmpty() ? this.OnErrorSrc : this._src);
				string str1 = str;
				this._src = str;
				return str1;
			}
			set
			{
				this._src = value;
			}
		}

		public string ThumbnailSrc
		{
			get
			{
				if (!this._thumbnailSrc.IsNullOrEmpty())
				{
					return this._thumbnailSrc;
				}
				return this.OnErrorSrc;
			}
			set
			{
				this._thumbnailSrc = value;
			}
		}

		public ImageVm()
		{
		}
	}
}