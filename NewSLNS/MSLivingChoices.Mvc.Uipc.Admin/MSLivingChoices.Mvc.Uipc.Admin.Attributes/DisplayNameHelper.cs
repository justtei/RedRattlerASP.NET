using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Web.Mvc;

namespace MSLivingChoices.Mvc.Uipc.Admin.Attributes
{
	public static class DisplayNameHelper
	{
		public static string GetDisplayName(string propertyName, PropertyInfo propertyInfo)
		{
			string displayName;
			object custromAttribute = propertyInfo.GetCustomAttributes(typeof(DisplayAttribute), false).FirstOrDefault<object>();
			if (custromAttribute == null)
			{
				custromAttribute = propertyInfo.GetCustomAttributes(typeof(DisplayNameAttribute), false).FirstOrDefault<object>();
				if (custromAttribute == null)
				{
					displayName = propertyName;
				}
				else
				{
					DisplayNameAttribute displayNameAttribute = custromAttribute as DisplayNameAttribute;
					displayName = (displayNameAttribute != null ? displayNameAttribute.DisplayName : propertyName);
				}
			}
			else
			{
				DisplayAttribute displayAttribute = custromAttribute as DisplayAttribute;
				displayName = (displayAttribute != null ? displayAttribute.GetName() : propertyName);
			}
			return displayName;
		}

		public static string GetDisplayName(string propertyName, ModelMetadata metadata, ControllerContext context)
		{
			ModelMetadata propertyMetaData = ModelMetadataProviders.Current.GetMetadataForProperties(context.Controller.ViewData.Model, metadata.ContainerType).FirstOrDefault<ModelMetadata>((ModelMetadata m) => m.PropertyName == propertyName);
			if (propertyMetaData == null)
			{
				return propertyName;
			}
			return propertyMetaData.DisplayName;
		}
	}
}