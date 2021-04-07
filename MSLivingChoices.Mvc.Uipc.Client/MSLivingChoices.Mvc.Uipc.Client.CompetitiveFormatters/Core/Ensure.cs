using MSLivingChoices.Mvc.Uipc.Client.ViewModels;
//using MSLivingChoices.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.Core
{
	internal static class Ensure
	{
		public static void String(string item, bool flag, Action<string> itemSetter, Action<bool> flagSetter)
		{
			if (!flag)
			{
				itemSetter(null);
			}
			else if (string.IsNullOrWhiteSpace(item))
			{
				flagSetter(obj: false);
			}
		}

		public static void Entity<T>(T item, bool flag, Action<T> itemSetter, Action<bool> flagSetter) where T : class
		{
			if (!flag)
			{
				itemSetter(null);
			}
			else if (item == null)
			{
				flagSetter(obj: false);
			}
		}

		public static void Int(int item, bool flag, Action<int> itemSetter, Action<bool> flagSetter)
		{
			if (!flag)
			{
				itemSetter(0);
			}
			else if (item == 0)
			{
				flagSetter(obj: false);
			}
		}

		public static void IntAboveOne(int item, bool flag, Action<int> itemSetter, Action<bool> flagSetter)
		{
			if (!flag)
			{
				itemSetter(0);
			}
			else if (item < 2)
			{
				flagSetter(obj: false);
			}
		}

		public static void Boolean(bool item, bool flag, Action<bool> itemSetter, Action<bool> flagSetter)
		{
			if (!flag)
			{
				itemSetter(obj: false);
			}
			else if (!item)
			{
				flagSetter(obj: false);
			}
		}

		public static void PropertyDescription(PropertyVm item, bool flag, Action<bool> flagSetter)
		{
			if (!flag)
			{
				item.Clear();
			}
			else if (!item.IsValued)
			{
				flagSetter(obj: false);
			}
		}

		public static void Collection<T>(ICollection<T> item, bool flag, Action<bool> flagSetter)
		{
			if (item == null)
			{
				flagSetter(obj: false);
			}
			else if (!flag)
			{
				item.Clear();
			}
			else if (!item.Any())
			{
				flagSetter(obj: false);
			}
		}
	}
}