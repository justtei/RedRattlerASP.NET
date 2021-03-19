using MSLivingChoices.Configuration;
using System;

namespace MSLivingChoices.Mvc.Uipc.Admin.Attributes.RestrictCollectionLengthAttributes
{
	public class RestrictCommunityImageCollectionLength : RestrictImageCollectionLength
	{
		protected override int Length
		{
			get
			{
				return ConfigurationManager.Instance.CommunityImagesMaxLength;
			}
		}

		public RestrictCommunityImageCollectionLength()
		{
		}
	}
}