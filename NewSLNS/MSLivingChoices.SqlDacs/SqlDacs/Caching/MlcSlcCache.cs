using MSLivingChoices.Logging;
using MSLivingChoices.Logging.Messages;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Caching;

namespace MSLivingChoices.SqlDacs.Caching
{
	public static class MlcSlcCache
	{
		private readonly static ConcurrentDictionary<string, object> CacheLockers;

		private readonly static string BaseKey;

		private readonly static char KeySeparator;

		static MlcSlcCache()
		{
			MlcSlcCache.CacheLockers = new ConcurrentDictionary<string, object>();
			MlcSlcCache.BaseKey = Guid.NewGuid().ToString();
			MlcSlcCache.KeySeparator = '\u005F';
		}

		internal static void ClearCache(string tokenValue)
		{
			try
			{
				MlcSlcCache.RemoveItemsFromCache(new string[] { MlcSlcCache.BaseKey });
				Logger.InfoFormat(LogMessages.SqlDacs.Caching.CacheClearedSuccessfully, new object[] { tokenValue });
			}
			catch (Exception exception)
			{
				Logger.ErrorFormat(LogMessages.SqlDacs.Caching.CacheClearingError, new object[] { tokenValue });
			}
		}

		private static T DeepClone<T>(T obj)
		{
			T t;
			try
			{
				using (MemoryStream memoryStream = new MemoryStream())
				{
					BinaryFormatter binaryFormatter = new BinaryFormatter();
					binaryFormatter.Serialize(memoryStream, obj);
					memoryStream.Position = (long)0;
					t = (T)binaryFormatter.Deserialize(memoryStream);
				}
			}
			catch (Exception exception)
			{
				Logger.Error(LogMessages.SqlDacs.Caching.DeepCloningError, exception);
				return default(T);
			}
			return t;
		}

		internal static string GetCacheKey(params string[] args)
		{
			return args.Aggregate<string, StringBuilder>(new StringBuilder(MlcSlcCache.BaseKey), (StringBuilder sb, string pref) => sb.AppendFormat("_{0}", pref)).ToString().ToLower();
		}

		internal static string GetCacheKeyPrefix(string storedProcedureName)
		{
			return string.Format("{0}{1}{2}", MlcSlcCache.BaseKey, MlcSlcCache.KeySeparator, storedProcedureName).ToLower();
		}

		internal static T GetItemFromCache<T>(string key)
		where T : class
		{
			T t;
			try
			{
				t = (T)HttpRuntime.get_Cache().Get(key);
				if (t != null)
				{
					t = MlcSlcCache.DeepClone<T>(t);
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				Logger.ErrorFormat(LogMessages.SqlDacs.Caching.ExtractingItemError, exception, new object[] { key });
				t = default(T);
			}
			return t;
		}

		private static object GetKeyLocker(string key)
		{
			return MlcSlcCache.CacheLockers.GetOrAdd(key, new object());
		}

		internal static void InsertItemInCache<T>(string key, T item, AggregateCacheDependency dependency, TimeSpan slidingExpiration, CacheItemPriority priority)
		{
			try
			{
				T t = item;
				if (item != null)
				{
					t = MlcSlcCache.DeepClone<T>(item);
				}
				if (!EqualityComparer<T>.Default.Equals(t, default(T)))
				{
					HttpRuntime.get_Cache().Insert(key, t, dependency, Cache.NoAbsoluteExpiration, slidingExpiration, priority, null);
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				Logger.ErrorFormat(LogMessages.SqlDacs.Caching.InsertItemError, exception, new object[] { key });
				throw;
			}
		}

		internal static void LockKey(string key)
		{
			try
			{
				Monitor.Enter(MlcSlcCache.GetKeyLocker(key));
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				Logger.ErrorFormat(LogMessages.SqlDacs.Caching.KeyLockingError, exception, new object[] { key });
			}
		}

		internal static void RemoveItemsFromCache(params string[] prefixes)
		{
			try
			{
				IDictionaryEnumerator enumerator = HttpRuntime.get_Cache().GetEnumerator();
				while (enumerator.MoveNext())
				{
					string str = enumerator.Key.ToString();
					if (!prefixes.Any<string>(new Func<string, bool>(str.StartsWith)))
					{
						continue;
					}
					HttpRuntime.get_Cache().Remove(str);
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				Logger.ErrorFormat(LogMessages.SqlDacs.Caching.RemoveItemsError, exception, new object[] { string.Join(" ", prefixes) });
				throw;
			}
		}

		internal static void UnlockKey(string key)
		{
			try
			{
				Monitor.Exit(MlcSlcCache.GetKeyLocker(key));
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				Logger.ErrorFormat(LogMessages.SqlDacs.Caching.KeyUnlockingError, exception, new object[] { key });
				throw;
			}
		}
	}
}