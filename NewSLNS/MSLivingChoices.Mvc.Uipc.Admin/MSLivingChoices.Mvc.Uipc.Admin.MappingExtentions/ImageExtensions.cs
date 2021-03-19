using MSLivingChoices.Entities.Admin;
using MSLivingChoices.Mvc.Uipc.Admin.ViewModels;
using System;

namespace MSLivingChoices.Mvc.Uipc.Admin.MappingExtentions
{
	internal class ImageExtensions
	{
		public ImageExtensions()
		{
		}

		public static ImageVm MapToImageVm(Image image)
		{
			return new ImageVm()
			{
				Id = image.Id,
				Name = image.Name,
				Url = image.Url
			};
		}
	}
}