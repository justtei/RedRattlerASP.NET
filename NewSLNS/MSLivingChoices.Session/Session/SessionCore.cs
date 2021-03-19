using System;
using System.Web;
using System.Web.SessionState;

namespace MSLivingChoices.Session
{
	internal static class SessionCore
	{
		internal static bool GetDataFromSession<T>(SessionKeys key, out T data)
		{
			if (HttpContext.get_Current() != null && HttpContext.get_Current().get_Session() != null)
			{
				object item = HttpContext.get_Current().get_Session().get_Item(key.ToString());
				if (item is T)
				{
					data = (T)item;
					return true;
				}
			}
			data = default(T);
			return false;
		}

		internal static void PutDataToSession<T>(SessionKeys key, T data)
		{
			if (HttpContext.get_Current() != null && HttpContext.get_Current().get_Session() != null)
			{
				HttpContext.get_Current().get_Session().set_Item(key.ToString(), data);
			}
		}

		internal static void RemoveDataFromSession(params SessionKeys[] keys)
		{
			if (HttpContext.get_Current() != null && HttpContext.get_Current().get_Session() != null)
			{
				SessionKeys[] sessionKeysArray = keys;
				for (int i = 0; i < (int)sessionKeysArray.Length; i++)
				{
					SessionKeys sessionKey = sessionKeysArray[i];
					HttpContext.get_Current().get_Session().Remove(sessionKey.ToString());
				}
			}
		}
	}
}