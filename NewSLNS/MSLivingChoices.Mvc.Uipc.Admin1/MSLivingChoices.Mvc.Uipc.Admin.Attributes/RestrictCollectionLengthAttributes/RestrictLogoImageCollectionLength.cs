using MSLivingChoices.Configuration;
using System;

namespace MSLivingChoices.Mvc.Uipc.Admin.Attributes.RestrictCollectionLengthAttributes
{
	public class RestrictLogoImageCollectionLength : RestrictImageCollectionLength
	{
		protected override string ImageCollectinFieldName
		{
			get
			{
				return "LogoImages";
			}
		}

		protected override int Length
		{
			get
			{
				return ConfigurationManager.Instance.LogoImagesMaxLength;
			}
		}

		public RestrictLogoImageCollectionLength()
		{
		}
	}
}