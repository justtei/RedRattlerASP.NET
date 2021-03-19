using MSLivingChoices.Entities.Admin.Enums;
using MSLivingChoices.Localization;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Web;

namespace MSLivingChoices.Mvc.Uipc.Admin.ViewModels
{
	public class UploadImageVm
	{
		public string Base64Image
		{
			get;
			set;
		}

		[Display(Name="LocalFile", ResourceType=typeof(DisplayNames))]
		public HttpPostedFileBase File
		{
			get;
			set;
		}

		[Range(1, 2147483647)]
		public int Height
		{
			get;
			set;
		}

		public MSLivingChoices.Entities.Admin.Enums.ImageType ImageType
		{
			get;
			set;
		}

		public bool IsCropImage
		{
			get;
			set;
		}

		[Range(1, 2147483647)]
		public int Width
		{
			get;
			set;
		}

		[Range(0, 2147483647)]
		public int X
		{
			get;
			set;
		}

		[Range(0, 2147483647)]
		public int Y
		{
			get;
			set;
		}

		public UploadImageVm()
		{
			this.ImageType = MSLivingChoices.Entities.Admin.Enums.ImageType.Photo;
			this.X = 0;
			this.Y = 0;
			this.Width = 1;
			this.Height = 1;
			this.IsCropImage = true;
		}
	}
}