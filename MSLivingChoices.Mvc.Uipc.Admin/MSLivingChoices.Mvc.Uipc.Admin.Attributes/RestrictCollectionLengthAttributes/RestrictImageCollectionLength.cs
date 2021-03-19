using MSLivingChoices.Mvc.Uipc.Admin.ViewModels;
using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace MSLivingChoices.Mvc.Uipc.Admin.Attributes.RestrictCollectionLengthAttributes
{
	public abstract class RestrictImageCollectionLength : RestrictCollectionLength
	{
		protected virtual string ImageCollectinFieldName
		{
			get
			{
				return "Images";
			}
		}

		protected RestrictImageCollectionLength()
		{
		}

		public override string FormatErrorMessage(string name)
		{
			return string.Format(base.ErrorMessageString, name, this.Length);
		}

		private string GetExceptionMessage(ValidationContext validationContext)
		{
			return string.Format("'{0}' can not be null", validationContext.DisplayName);
		}

		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			PropertyInfo property = validationContext.ObjectType.GetProperty(this.ImageCollectinFieldName);
			if (property == null)
			{
				throw new Exception(this.GetExceptionMessage(validationContext));
			}
			object obj = property.GetValue(validationContext.ObjectInstance, null);
			if (obj == null)
			{
				throw new Exception(this.GetExceptionMessage(validationContext));
			}
			ImageListVm imageList = obj as ImageListVm;
			if (imageList == null)
			{
				throw new Exception(this.GetExceptionMessage(validationContext));
			}
			if (base.CheckCollectionOnValidLength(imageList.Images))
			{
				return ValidationResult.Success;
			}
			return new ValidationResult(base.ErrorMessage);
		}
	}
}