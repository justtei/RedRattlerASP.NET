using MSLivingChoices.Mvc.Uipc.Client.ViewModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace MSLivingChoices.Mvc.Uipc.Client.JsSerialization
{
	public class SearchCriteriaVmJsonConverter : JsonConverter
	{
		public override bool CanRead
		{
			get
			{
				return false;
			}
		}

		public SearchCriteriaVmJsonConverter()
		{
		}

		public override bool CanConvert(Type objectType)
		{
			return objectType == typeof(SearchCriteriaVm);
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			throw new NotImplementedException("Requested unnecessary serialization");
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			SearchCriteriaVm searchCriteriaVm = value as SearchCriteriaVm;
			if (searchCriteriaVm == null)
			{
				return;
			}
			JObject jObjects = new JObject();
			foreach (KeyValuePair<string, object> component in searchCriteriaVm.Components)
			{
				char lowerInvariant = char.ToLowerInvariant(component.Key[0]);
				string str = string.Concat(lowerInvariant.ToString(), component.Key.Substring(1));
				jObjects.Add(str, JToken.FromObject(component.Value));
			}
			jObjects.WriteTo(writer, new JsonConverter[0]);
		}
	}
}