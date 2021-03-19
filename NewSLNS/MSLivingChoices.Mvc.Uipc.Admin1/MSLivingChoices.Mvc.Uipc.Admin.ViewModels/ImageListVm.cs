using MSLivingChoices.Entities.Admin;
using MSLivingChoices.Entities.Admin.Enums;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Mvc.Uipc.Admin.ViewModels
{
	public class ImageListVm
	{
		public string DisplayName
		{
			get;
			set;
		}

		public List<ImageVm> Images
		{
			get;
			set;
		}

		public ImageListVm()
		{
			this.Images = new List<ImageVm>();
		}

		public ImageListVm(string displayName)
		{
			this.Images = new List<ImageVm>();
			this.DisplayName = displayName;
		}

		public List<Image> ToEntity(ImageType imageType)
		{
			return this.Images.ConvertAll<Image>((ImageVm i) => i.ToEntity(imageType));
		}
	}
}