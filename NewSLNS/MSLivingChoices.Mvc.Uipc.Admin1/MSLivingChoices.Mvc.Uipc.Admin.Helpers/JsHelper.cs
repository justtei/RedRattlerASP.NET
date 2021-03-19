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
			JsonSerializerSettings jsonSerializerSetting = new JsonSerializerSettings();
			jsonSerializerSetting.set_ContractResolver(new CamelCasePropertyNamesContractResolver());
			JsonSerializerSettings settings = jsonSerializerSetting;
			settings.get_Converters().Add(new ExpandoObjectConverter());
			return JsonConvert.SerializeObject(data, settings);
		}
	}
}