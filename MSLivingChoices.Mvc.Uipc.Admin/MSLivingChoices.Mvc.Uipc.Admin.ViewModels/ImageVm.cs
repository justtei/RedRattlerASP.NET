using MSLivingChoices.Entities.Admin;
using MSLivingChoices.Entities.Admin.Enums;
using MSLivingChoices.Mvc.Uipc.Admin.Helpers;
using System;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Mvc.Uipc.Admin.ViewModels
{
	public class ImageVm
	{
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

		public string Url
		{
			get;
			set;
		}

		public ImageVm()
		{
		}

		public Image ToEntity(ImageType imageType)
		{
			string url = MslcUrlBuilder.ImageHandlerUrl(this);
			return new Image()
			{
				Id = this.Id,
				Name = this.Name,
				Url = url,
				ImageType = imageType
			};
		}
	}
}