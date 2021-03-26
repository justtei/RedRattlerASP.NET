using MSLivingChoices.Mvc.Uipc.Client.ViewModels;
using MSLivingChoices.Mvc.Uipc.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace MSLivingChoices.Mvc.Uipc.Client.JsSerialization
{
	public class SearchBarTemplatesJsonConverter : JsonConverter
	{
		public override bool CanRead
		{
			get
			{
				return false;
			}
		}

		public SearchBarTemplatesJsonConverter()
		{
		}

		public override bool CanConvert(Type objectType)
		{
			return objectType == typeof(Dictionary<SearchType, List<AutocompleteVm>>);
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			throw new NotImplementedException("Requested unnecessary serialization");
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			Dictionary<SearchType, List<AutocompleteVm>> searchTypes = value as Dictionary<SearchType, List<AutocompleteVm>>;
			if (searchTypes == null)
			{
				return;
			}
			JObject jObjects = new JObject();
			foreach (KeyValuePair<SearchType, List<AutocompleteVm>> keyValuePair in searchTypes)
			{
				List<Dictionary<string, object>> dictionaries = new List<Dictionary<string, object>>();
				foreach (AutocompleteVm autocompleteVm in keyValuePair.Value)
				{
					Dictionary<string, object> strs = new Dictionary<string, object>()
					{
						{ "lookupLocation", autocompleteVm.LookupLocation },
						{ "start", autocompleteVm.Start },
						{ "end", autocompleteVm.End },
						{ "url", autocompleteVm.Url },
						{ "template", autocompleteVm.Template }
					};
					dictionaries.Add(strs);
				}
				int key = (int)keyValuePair.Key;
				jObjects.Add(key.ToString(), JToken.FromObject(dictionaries));
			}
			jObjects.WriteTo(writer, new JsonConverter[0]);
		}
	}
}