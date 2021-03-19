using MSLivingChoices.Localization;
using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace MSLivingChoices.Mvc.Uipc.Admin.Attributes.RestrictCollectionLengthAttributes
{
	[AttributeUsage(AttributeTargets.Property)]
	public abstract class RestrictCollectionLength : ValidationAttribute
	{
		protected abstract int Length
		{
			get;
		}

		protected RestrictCollectionLength()
		{
			base.ErrorMessageResourceName = "MaxCollectionLength";
			base.ErrorMessageResourceType = typeof(ErrorMessages);
		}

		protected bool CheckCollectionOnValidLength(ICollection collection)
		{
			if (collection == null)
			{
				throw new Exception("Attribute 'MaxCollectionLength' can be applied only to collections.");
			}
			return collection.Count <= this.Length;
		}
	}
}