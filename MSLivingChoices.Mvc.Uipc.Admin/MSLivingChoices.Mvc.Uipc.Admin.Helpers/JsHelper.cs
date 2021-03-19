using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;

namespace MSLivingChoices.Mvc.Uipc.Admin.Helpers
{
	public class JsHelper
	{
		public JsHelper()
		{
		}

		public static string MapToJson(object data)
		{
			JsonSerializerSettings settings = new JsonSerializerSettings()
			{
				ContractResolver = new CamelCasePropertyNamesContractResolver()
			};
			settings.Converters.Add(new ExpandoObjectConverter());
			return JsonConvert.SerializeObject(data, settings);
		}
	}
}