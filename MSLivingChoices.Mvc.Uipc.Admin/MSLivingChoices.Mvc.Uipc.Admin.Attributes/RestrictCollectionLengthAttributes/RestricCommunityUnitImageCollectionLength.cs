using MSLivingChoices.Configuration;
using System;

namespace MSLivingChoices.Mvc.Uipc.Admin.Attributes.RestrictCollectionLengthAttributes
{
	public class RestricCommunityUnitImageCollectionLength : RestrictImageCollectionLength
	{
		protected override int Length
		{
			get
			{
				return ConfigurationManager.Instance.CommunityUnitImagesMaxLength;
			}
		}

		public RestricCommunityUnitImageCollectionLength()
		{
		}
	}
}