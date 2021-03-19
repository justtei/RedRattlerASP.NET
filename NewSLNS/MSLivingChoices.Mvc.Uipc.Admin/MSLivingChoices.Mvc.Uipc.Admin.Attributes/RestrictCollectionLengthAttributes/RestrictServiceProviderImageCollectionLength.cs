using MSLivingChoices.Configuration;
using System;

namespace MSLivingChoices.Mvc.Uipc.Admin.Attributes.RestrictCollectionLengthAttributes
{
	public class RestrictServiceProviderImageCollectionLength : RestrictImageCollectionLength
	{
		protected override int Length
		{
			get
			{
				return ConfigurationManager.Instance.ServiceProviderImagesMaxLength;
			}
		}

		public RestrictServiceProviderImageCollectionLength()
		{
		}
	}
}