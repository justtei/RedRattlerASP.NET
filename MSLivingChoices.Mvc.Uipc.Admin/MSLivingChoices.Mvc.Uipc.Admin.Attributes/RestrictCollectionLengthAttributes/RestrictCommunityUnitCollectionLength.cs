using MSLivingChoices.Configuration;
using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace MSLivingChoices.Mvc.Uipc.Admin.Attributes.RestrictCollectionLengthAttributes
{
	public class RestrictCommunityUnitCollectionLength : RestrictCollectionLength
	{
		protected override int Length
		{
			get
			{
				return ConfigurationManager.Instance.CommunityUnitsMaxLength;
			}
		}

		public RestrictCommunityUnitCollectionLength()
		{
		}

		public override string FormatErrorMessage(string name)
		{
			return string.Format(base.ErrorMessageString, name, this.Length);
		}

		public override bool IsValid(object value)
		{
			return base.CheckCollectionOnValidLength(value as ICollection);
		}
	}
}