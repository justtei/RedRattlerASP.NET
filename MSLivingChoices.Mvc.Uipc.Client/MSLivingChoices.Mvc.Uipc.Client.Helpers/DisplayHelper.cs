using MSLivingChoices.Bcs.Components;
using MSLivingChoices.Configuration;
using MSLivingChoices.Entities.Client;
using MSLivingChoices.Entities.Client.Enums;
using MSLivingChoices.Localization;
using MSLivingChoices.Mvc.Uipc.Client.ViewModels;
using MSLivingChoices.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Mvc.Uipc.Client.Helpers
{
	internal static class DisplayHelper
	{
		private static List<KeyValuePair<int, string>> Beds;

		private static List<KeyValuePair<int, string>> Bathes;

		static DisplayHelper()
		{
			DisplayHelper.Beds = ItemTypeBc.Instance.GetBedrooms();
			DisplayHelper.Bathes = ItemTypeBc.Instance.GetBathrooms();
		}

		internal static PropertyVm AreaCaption(this MeasureBoundary<int, Area> livingSpace)
		{
			PropertyVm propertyVm = new PropertyVm();
			if (livingSpace != null && (livingSpace.Min.HasValue || livingSpace.Max.HasValue))
			{
				propertyVm.Unit = livingSpace.Measure.GetEnumLocalizedValue<Area>();
				if (!livingSpace.Min.HasValue || !livingSpace.Max.HasValue || livingSpace.Min.Value == livingSpace.Max.Value || livingSpace.Min.Value == 0 || livingSpace.Max.Value == 0)
				{
					decimal num = (livingSpace.Min.HasValue ? livingSpace.Min.Value : livingSpace.Max.Value);
					if (num != decimal.Zero)
					{
						decimal num1 = Math.Round(num);
						propertyVm.Value = string.Format("{0}", num1.ToString(ConfigurationManager.Instance.NumberFormat));
					}
				}
				else
				{
					int value = livingSpace.Min.Value;
					string str = value.ToString(ConfigurationManager.Instance.NumberFormat);
					value = livingSpace.Max.Value;
					propertyVm.Value = string.Format("{0} - {1}", str, value.ToString(ConfigurationManager.Instance.NumberFormat));
				}
			}
			return propertyVm;
		}

		internal static PropertyVm BathesCaption(this Boundary<long> bathes)
		{
			string bathesCaption = DisplayHelper.GetBathesCaption(bathes);
			return new PropertyVm(bathesCaption, (bathesCaption.Equals("1", StringComparison.InvariantCulture) ? "Bath" : "Baths"));
		}

		internal static PropertyVm BedsCaption(this Boundary<long> beds)
		{
			string bedsCaption = DisplayHelper.GetBedsCaption(beds);
			return new PropertyVm(bedsCaption, (bedsCaption.Equals("1", StringComparison.InvariantCultureIgnoreCase) || bedsCaption.Equals("Studio", StringComparison.InvariantCultureIgnoreCase) || bedsCaption.Equals("Efficiency", StringComparison.InvariantCultureIgnoreCase) ? "Bed" : "Beds"));
		}

		internal static string ExternalUrl(this string url)
		{
			string empty = string.Empty;
			if (!string.IsNullOrWhiteSpace(url))
			{
				empty = (url.StartsWith("http://", StringComparison.OrdinalIgnoreCase) || url.StartsWith("https://", StringComparison.OrdinalIgnoreCase) ? url : string.Format("http://{0}", url));
			}
			return empty;
		}

		private static string GetBathesCaption(Boundary<long> boundary)
		{
			KeyValuePair<int, string> keyValuePair;
			string value;
			string str;
			if (boundary == null || !boundary.Min.HasValue)
			{
				str = null;
			}
			else
			{
				keyValuePair = DisplayHelper.Bathes.FirstOrDefault<KeyValuePair<int, string>>((KeyValuePair<int, string> m) => (long)m.Key == boundary.Min.Value);
				str = keyValuePair.Value;
			}
			if (boundary == null || !boundary.Max.HasValue)
			{
				value = null;
			}
			else
			{
				keyValuePair = DisplayHelper.Bathes.FirstOrDefault<KeyValuePair<int, string>>((KeyValuePair<int, string> m) => (long)m.Key == boundary.Max.Value);
				value = keyValuePair.Value;
			}
			return DisplayHelper.GetRange(str, value);
		}

		private static string GetBedsCaption(Boundary<long> boundary)
		{
			KeyValuePair<int, string> keyValuePair;
			string value;
			string str;
			if (boundary == null || !boundary.Min.HasValue)
			{
				str = null;
			}
			else
			{
				keyValuePair = DisplayHelper.Beds.FirstOrDefault<KeyValuePair<int, string>>((KeyValuePair<int, string> m) => (long)m.Key == boundary.Min.Value);
				str = keyValuePair.Value;
			}
			if (boundary == null || !boundary.Max.HasValue)
			{
				value = null;
			}
			else
			{
				keyValuePair = DisplayHelper.Beds.FirstOrDefault<KeyValuePair<int, string>>((KeyValuePair<int, string> m) => (long)m.Key == boundary.Max.Value);
				value = keyValuePair.Value;
			}
			return DisplayHelper.GetRange(str, value);
		}

		private static string GetRange(string from, string to)
		{
			string empty = string.Empty;
			if (!string.IsNullOrWhiteSpace(from) || !string.IsNullOrWhiteSpace(to))
			{
				if (string.IsNullOrWhiteSpace(from) || string.IsNullOrWhiteSpace(to) || from.Trim().Equals(to.Trim(), StringComparison.InvariantCultureIgnoreCase))
				{
					empty = (string.IsNullOrWhiteSpace(from) ? to : from);
				}
				else
				{
					empty = string.Format("{0} - {1}", from, to);
				}
			}
			return empty;
		}

		internal static string PriceCaption(this MeasureBoundary<decimal, Currency> price, string phone)
		{
			decimal num;
			string empty = string.Empty;
			if (price != null)
			{
				if (!price.Min.HasValue && !price.Max.HasValue)
				{
					if (!phone.IsNullOrEmpty())
					{
						empty = string.Format("Call {0} for rates", phone);
					}
					return empty;
				}
				string enumLocalizedValue = price.Measure.GetEnumLocalizedValue<Currency>();
				if (!price.Min.HasValue || !price.Max.HasValue || !(price.Min.Value != price.Max.Value) || !(price.Min.Value != decimal.Zero) || !(price.Max.Value != decimal.Zero))
				{
					decimal num1 = (price.Min.HasValue ? price.Min.Value : price.Max.Value);
					if (num1 != decimal.Zero)
					{
						num = Math.Round(num1);
						empty = string.Format("{0}{1}", enumLocalizedValue, num.ToString(ConfigurationManager.Instance.NumberFormat));
					}
				}
				else
				{
					decimal? min = price.Min;
					num = Math.Round(min.Value);
					string str = num.ToString(ConfigurationManager.Instance.NumberFormat);
					min = price.Max;
					num = Math.Round(min.Value);
					empty = string.Format("{0}{1} - {0}{2}", enumLocalizedValue, str, num.ToString(ConfigurationManager.Instance.NumberFormat));
				}
			}
			return empty;
		}

		internal static string PriceCaption(this MeasureBoundary<decimal, Currency> price)
		{
			return price.PriceCaption(string.Empty);
		}
	}
}