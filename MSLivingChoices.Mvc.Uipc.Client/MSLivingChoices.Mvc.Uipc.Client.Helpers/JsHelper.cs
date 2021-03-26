using MSLivingChoices.Mvc.Uipc.Client.JsSerialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;

namespace MSLivingChoices.Mvc.Uipc.Client.Helpers
{
	public class JsHelper
	{
		public JsHelper()
		{
		}

		public static string MapToJson(object data)
		{
			JsonSerializerSettings jsonSerializerSetting = new JsonSerializerSettings()
			{
				ContractResolver = new CamelCasePropertyNamesContractResolver()
			};
			jsonSerializerSetting.Converters.Add(new SearchCriteriaVmJsonConverter());
			jsonSerializerSetting.Converters.Add(new SearchBarTemplatesJsonConverter());
			jsonSerializerSetting.Converters.Add(new ExpandoObjectConverter());
			return JsonConvert.SerializeObject(data, jsonSerializerSetting);
		}
	}
}