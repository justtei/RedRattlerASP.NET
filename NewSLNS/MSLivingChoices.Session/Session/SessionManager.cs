using MSLivingChoices.Configuration;
using System;

namespace MSLivingChoices.Session
{
	public static class SessionManager
	{
		public static bool GetCurrentUserData<T>(Guid userId, SessionKeys key, out T data)
		{
			Guid? nullable;
			bool flag;
			if (!ConfigurationManager.Instance.IsWebSessionDisabled && SessionManager.GetCurrentUserId(out nullable))
			{
				Guid? nullable1 = nullable;
				Guid guid = userId;
				if (nullable1.HasValue)
				{
					flag = (nullable1.HasValue ? nullable1.GetValueOrDefault() == guid : true);
				}
				else
				{
					flag = false;
				}
				if (flag)
				{
					return SessionCore.GetDataFromSession<T>(key, out data);
				}
			}
			data = default(T);
			return false;
		}

		public static bool GetCurrentUserId(out Guid? currentUserId)
		{
			if (!ConfigurationManager.Instance.IsWebSessionDisabled)
			{
				return SessionCore.GetDataFromSession<Guid?>(SessionKeys.CurrentUserId, out currentUserId);
			}
			currentUserId = null;
			return false;
		}

		public static T GetDataFromSession<T>(SessionKeys key)
		{
			T t;
			if (!ConfigurationManager.Instance.IsWebSessionDisabled && SessionCore.GetDataFromSession<T>(key, out t))
			{
				return t;
			}
			return default(T);
		}

		public static void PutCurrentUserData<T>(Guid userId, SessionKeys key, T data)
		{
			Guid? nullable;
			bool flag;
			if (!ConfigurationManager.Instance.IsWebSessionDisabled && SessionManager.GetCurrentUserId(out nullable))
			{
				Guid? nullable1 = nullable;
				Guid guid = userId;
				if (nullable1.HasValue)
				{
					flag = (nullable1.HasValue ? nullable1.GetValueOrDefault() == guid : true);
				}
				else
				{
					flag = false;
				}
				if (flag)
				{
					SessionCore.PutDataToSession<T>(key, data);
				}
			}
		}

		public static void PutCurrentUserId(Guid? currentUserId)
		{
			if (!ConfigurationManager.Instance.IsWebSessionDisabled)
			{
				SessionCore.PutDataToSession<Guid?>(SessionKeys.CurrentUserId, currentUserId);
			}
		}

		public static void PutDataToSession<T>(SessionKeys key, T data)
		{
			if (!ConfigurationManager.Instance.IsWebSessionDisabled)
			{
				SessionCore.PutDataToSession<T>(key, data);
			}
		}

		public static void RemoveDataFromSession(params SessionKeys[] keys)
		{
			if (!ConfigurationManager.Instance.IsWebSessionDisabled)
			{
				SessionCore.RemoveDataFromSession(keys);
			}
		}
	}
}