using MSLivingChoices.Entities.Admin;
using MSLivingChoices.Localization;
using MSLivingChoices.Mvc.Uipc.Admin.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web.Mvc;

namespace MSLivingChoices.Mvc.Uipc.Admin.Helpers
{
	public static class ConverterHelpers
	{
		public static List<SelectListItem> CountryListToSelectListItems(IEnumerable<Country> countryList, string selectedCountryCode)
		{
			List<SelectListItem> result = new List<SelectListItem>();
			foreach (Country country in countryList)
			{
				SelectListItem item = new SelectListItem();
				item.Text = country.Name;
				item.Value = country.Code;
				item.Selected = selectedCountryCode != null && country.Code == selectedCountryCode;
				result.Add(item);
			}
			return result;
		}

		public static List<T> EnumToList<T>() where T : struct
		{
			if (!typeof(T).IsEnum)
			{
				throw new ArgumentException(ErrorMessages.NotEnumType);
			}
			return Enum.GetValues(typeof(T)).Cast<T>().ToList();
		}

		public static List<SelectListItem> EnumToSelectListItems<T>(T? selectedItem = null) where T : struct
		{
			if (!typeof(T).IsEnum)
			{
				throw new ArgumentException(ErrorMessages.NotEnumType);
			}
			return EnumToList<T>().Select(delegate (T enumItem)
			{
				string text = enumItem.ToString();
				return new SelectListItem
				{
					Text = (enumItem.GetEnumLocalizedValue() ?? text),
					Value = text,
					Selected = (selectedItem.HasValue && enumItem.Equals(selectedItem.Value))
				};
			}).ToList();
		}

		public static List<SelectListItem> EnumToKoSelectListItems<T>() where T : struct
		{
			if (!typeof(T).IsEnum)
			{
				throw new ArgumentException(ErrorMessages.NotEnumType);
			}
			return EnumToList<T>().Select(delegate (T enumItem)
			{
				string text = enumItem.ToString();
				string value = ((int)(object)enumItem).ToString();
				return new SelectListItem
				{
					Text = (enumItem.GetEnumLocalizedValue() ?? text),
					Value = value
				};
			}).ToList();
		}

		public static List<SelectListItem> EnumToKoSelectListItems<T>(T selectedValue) where T : struct
		{
			if (!typeof(T).IsEnum)
			{
				throw new ArgumentException(ErrorMessages.NotEnumType);
			}
			return EnumToList<T>().Select(delegate (T enumItem)
			{
				string text = enumItem.ToString();
				string value = ((int)(object)enumItem).ToString();
				return new SelectListItem
				{
					Text = (enumItem.GetEnumLocalizedValue() ?? text),
					Value = value
				};
			}).ToList();
		}

		public static List<CheckBoxVm> EnumToCheckBoxList<T>() where T : struct
		{
			return EnumToCheckBoxList(new List<T>());
		}

		public static List<CheckBoxVm> EnumToCheckBoxList<T>(List<T> selectedEnums) where T : struct
		{
			if (!typeof(T).IsEnum)
			{
				throw new ArgumentException(ErrorMessages.NotEnumType);
			}
			return (from m in EnumToList<T>()
					select new CheckBoxVm
					{
						IsChecked = (selectedEnums != null && selectedEnums.Contains(m)),
						Text = m.GetEnumLocalizedValue(),
						Value = Convert.ToInt64(m).ToString()
					}).ToList();
		}

		public static List<T> CheckBoxListToEnumList<T>(List<CheckBoxVm> checkBoxList) where T : struct
		{
			if (!typeof(T).IsEnum)
			{
				throw new ArgumentException(ErrorMessages.NotEnumType);
			}
			List<T> allEnumValues = (from T m in Enum.GetValues(typeof(T))
									 select (m)).ToList();
			List<T> result = new List<T>();
			foreach (CheckBoxVm checkBox in checkBoxList.Where((CheckBoxVm m) => m.IsChecked))
			{
				T enumValue = allEnumValues.SingleOrDefault((T m) => Convert.ToInt32(m).ToString() == checkBox.Value);
				result.Add(enumValue);
			}
			return result;
		}

		public static List<KeyValuePair<int, string>> CheckBoxListToDictionary(List<CheckBoxVm> checkBoxList)
		{
			List<KeyValuePair<int, string>> result = new List<KeyValuePair<int, string>>();
			foreach (CheckBoxVm checkBox in checkBoxList.Where((CheckBoxVm m) => m.IsChecked))
			{
				if (int.TryParse(checkBox.Value, out var key))
				{
					result.Add(new KeyValuePair<int, string>(key, checkBox.Text));
				}
			}
			return result;
		}

		public static List<CheckBoxVm> DictionaryToCheckBoxList(List<KeyValuePair<int, string>> items)
		{
			return items.ConvertAll((KeyValuePair<int, string> m) => new CheckBoxVm
			{
				Text = m.Value,
				Value = m.Key.ToString()
			});
		}

		public static List<CheckBoxVm> DictionaryToCheckBoxList(List<KeyValuePair<int, string>> items, List<long> selectedIds)
		{
			return items.ConvertAll((KeyValuePair<int, string> m) => new CheckBoxVm
			{
				Text = m.Value,
				Value = m.Key.ToString(),
				IsChecked = selectedIds.Contains(m.Key)
			});
		}

		public static List<long> CheckBoxListToLongArray(List<CheckBoxVm> checkBoxList)
		{
			List<long> result = new List<long>();
			foreach (CheckBoxVm item in checkBoxList.Where((CheckBoxVm m) => m.IsChecked))
			{
				if (long.TryParse(item.Value, out var number))
				{
					result.Add(number);
				}
			}
			return result;
		}
	}
}