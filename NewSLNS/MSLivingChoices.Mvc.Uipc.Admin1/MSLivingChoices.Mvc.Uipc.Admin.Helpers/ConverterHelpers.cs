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
		public static List<KeyValuePair<int, string>> CheckBoxListToDictionary(List<CheckBoxVm> checkBoxList)
		{
			int key;
			List<KeyValuePair<int, string>> result = new List<KeyValuePair<int, string>>();
			foreach (CheckBoxVm checkBox in 
				from m in checkBoxList
				where m.IsChecked
				select m)
			{
				if (!int.TryParse(checkBox.Value, out key))
				{
					continue;
				}
				result.Add(new KeyValuePair<int, string>(key, checkBox.Text));
			}
			return result;
		}

		public static List<T> CheckBoxListToEnumList<T>(List<CheckBoxVm> checkBoxList)
		where T : struct
		{
			if (!typeof(T).IsEnum)
			{
				throw new ArgumentException(ErrorMessages.NotEnumType);
			}
			List<T> allEnumValues = (
				from T  in Enum.GetValues(typeof(T))
				select m).ToList<T>();
			List<T> result = new List<T>();
			foreach (CheckBoxVm checkBoxVm in 
				from  in checkBoxList
				where m.IsChecked
				select )
			{
				T enumValue = allEnumValues.SingleOrDefault<T>((T m) => Convert.ToInt32(m).ToString() == checkBoxVm.Value);
				result.Add(enumValue);
			}
			return result;
		}

		public static List<long> CheckBoxListToLongArray(List<CheckBoxVm> checkBoxList)
		{
			long number;
			List<long> result = new List<long>();
			foreach (CheckBoxVm checkBoxVm in 
				from m in checkBoxList
				where m.IsChecked
				select m)
			{
				if (!long.TryParse(checkBoxVm.Value, out number))
				{
					continue;
				}
				result.Add(number);
			}
			return result;
		}

		public static List<SelectListItem> CountryListToSelectListItems(IEnumerable<Country> countryList, string selectedCountryCode)
		{
			List<SelectListItem> result = new List<SelectListItem>();
			foreach (Country country in countryList)
			{
				SelectListItem item = new SelectListItem();
				item.set_Text(country.Name);
				item.set_Value(country.Code);
				item.set_Selected((selectedCountryCode == null ? false : country.Code == selectedCountryCode));
				result.Add(item);
			}
			return result;
		}

		public static List<CheckBoxVm> DictionaryToCheckBoxList(List<KeyValuePair<int, string>> items)
		{
			return items.ConvertAll<CheckBoxVm>((KeyValuePair<int, string> m) => new CheckBoxVm()
			{
				Text = m.Value,
				Value = m.Key.ToString()
			});
		}

		public static List<CheckBoxVm> DictionaryToCheckBoxList(List<KeyValuePair<int, string>> items, List<long> selectedIds)
		{
			return items.ConvertAll<CheckBoxVm>((KeyValuePair<int, string> m) => new CheckBoxVm()
			{
				Text = m.Value,
				Value = m.Key.ToString(),
				IsChecked = selectedIds.Contains((long)m.Key)
			});
		}

		public static List<CheckBoxVm> EnumToCheckBoxList<T>()
		where T : struct
		{
			return ConverterHelpers.EnumToCheckBoxList<T>(new List<T>());
		}

		public static List<CheckBoxVm> EnumToCheckBoxList<T>(List<T> selectedEnums)
		where T : struct
		{
			if (!typeof(T).IsEnum)
			{
				throw new ArgumentException(ErrorMessages.NotEnumType);
			}
			return (
				from  in ConverterHelpers.EnumToList<T>()
				select new CheckBoxVm()
				{
					IsChecked = (selectedEnums == null ? false : selectedEnums.Contains(m)),
					Text = m.GetEnumLocalizedValue<T>(),
					Value = Convert.ToInt64(m).ToString()
				}).ToList<CheckBoxVm>();
		}

		public static List<SelectListItem> EnumToKoSelectListItems<T>()
		where T : struct
		{
			if (!typeof(T).IsEnum)
			{
				throw new ArgumentException(ErrorMessages.NotEnumType);
			}
			return ConverterHelpers.EnumToList<T>().Select<T, SelectListItem>((T enumItem) => {
				string text = enumItem.ToString();
				string value = ((int)(object)enumItem).ToString();
				SelectListItem selectListItem = new SelectListItem();
				selectListItem.set_Text(enumItem.GetEnumLocalizedValue<T>() ?? text);
				selectListItem.set_Value(value);
				return selectListItem;
			}).ToList<SelectListItem>();
		}

		public static List<SelectListItem> EnumToKoSelectListItems<T>(T selectedValue)
		where T : struct
		{
			if (!typeof(T).IsEnum)
			{
				throw new ArgumentException(ErrorMessages.NotEnumType);
			}
			return ConverterHelpers.EnumToList<T>().Select<T, SelectListItem>((T enumItem) => {
				string text = enumItem.ToString();
				string value = ((int)(object)enumItem).ToString();
				SelectListItem selectListItem = new SelectListItem();
				selectListItem.set_Text(enumItem.GetEnumLocalizedValue<T>() ?? text);
				selectListItem.set_Value(value);
				return selectListItem;
			}).ToList<SelectListItem>();
		}

		public static List<T> EnumToList<T>()
		where T : struct
		{
			if (!typeof(T).IsEnum)
			{
				throw new ArgumentException(ErrorMessages.NotEnumType);
			}
			return Enum.GetValues(typeof(T)).Cast<T>().ToList<T>();
		}

		public static List<SelectListItem> EnumToSelectListItems<T>(Nullable<T> selectedItem = null)
		where T : struct
		{
			if (!typeof(T).IsEnum)
			{
				throw new ArgumentException(ErrorMessages.NotEnumType);
			}
			return ConverterHelpers.EnumToList<T>().Select<T, SelectListItem>((T enumItem) => {
				string text = enumItem.ToString();
				SelectListItem selectListItem = new SelectListItem();
				selectListItem.set_Text(enumItem.GetEnumLocalizedValue<T>() ?? text);
				selectListItem.set_Value(text);
				selectListItem.set_Selected((!selectedItem.HasValue ? false : enumItem.Equals(selectedItem.Value)));
				return selectListItem;
			}).ToList<SelectListItem>();
		}
	}
}