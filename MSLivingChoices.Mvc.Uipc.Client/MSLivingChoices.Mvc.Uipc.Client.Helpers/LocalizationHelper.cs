using MSLivingChoices.Configuration;
using MSLivingChoices.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Mvc.Uipc.Client.Helpers
{
	public static class LocalizationHelper
	{
		private const string CurrentDatePlaceholder = "{CURRENT_DATE}";

		public static Dictionary<string, string> GetLocalization(this ResourceManager resourceManager)
		{
			return resourceManager.GetLocalization(CultureInfo.GetCultureInfo("en-us"));
		}

		public static Dictionary<string, string> GetLocalization(this ResourceManager resourceManager, CultureInfo culture)
		{
			string str = resourceManager.BaseName.Substring(resourceManager.BaseName.LastIndexOf('.') + 1);
			return LocalizationHelper.GetLocalization(resourceManager.GetResourceSet(culture, true, true), str);
		}

		private static Dictionary<string, string> GetLocalization(ResourceSet resourceSet, string prefix)
		{
			Dictionary<string, string> strs = new Dictionary<string, string>();
			foreach (DictionaryEntry dictionaryEntry in resourceSet)
			{
				string key = dictionaryEntry.Key as string;
				string value = dictionaryEntry.Value as string;
				DateTime now = DateTime.Now;
				value = value.Replace("{CURRENT_DATE}", now.ToString(ConfigurationManager.Instance.ClientServerDateFormat));
				if (key.IsNullOrEmpty() || value.IsNullOrEmpty())
				{
					continue;
				}
				strs.Add(string.Join("_", new string[] { prefix, key }), value);
			}
			return strs;
		}
	}
}