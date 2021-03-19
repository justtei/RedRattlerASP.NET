using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.SqlDacs.Helpers
{
	public static class CoreDataReaderHelper
	{
		public static bool FromNullable(this bool? item)
		{
			if (!item.HasValue)
			{
				return false;
			}
			return item.Value;
		}

		public static T GetEnum<T>(this SqlDataReader reader, string columnName)
		{
			T value;
			try
			{
				int ordinal = reader.GetOrdinal(columnName);
				if (!reader.IsDBNull(ordinal))
				{
					value = (T)reader.GetValue(ordinal);
				}
				else
				{
					value = default(T);
					value = value;
				}
			}
			catch (Exception exception)
			{
				value = default(T);
			}
			return value;
		}

		public static T GetEnum<T>(this SqlDataReader reader, string columnName, Nullable<T> defaultValue)
		where T : struct
		{
			T t = (defaultValue.HasValue ? defaultValue.Value : default(T));
			try
			{
				if (typeof(T).IsEnum)
				{
					List<T> list = Enum.GetValues(typeof(T)).Cast<T>().ToList<T>();
					int ordinal = reader.GetOrdinal(columnName);
					if (!reader.IsDBNull(ordinal))
					{
						T value = (T)reader.GetValue(ordinal);
						if (list.Contains(value))
						{
							t = value;
						}
					}
				}
			}
			catch (Exception exception)
			{
			}
			return t;
		}

		public static Nullable<T> GetNullableValue<T>(this SqlDataReader reader, string columnName)
		where T : struct
		{
			Nullable<T> nullable;
			try
			{
				int ordinal = reader.GetOrdinal(columnName);
				if (!reader.IsDBNull(ordinal))
				{
					nullable = new Nullable<T>((T)reader.GetValue(ordinal));
				}
				else
				{
					nullable = null;
					nullable = nullable;
				}
			}
			catch (Exception exception)
			{
				nullable = null;
			}
			return nullable;
		}

		public static T GetValue<T>(this SqlDataReader dataReader, string columnName)
		{
			if (dataReader.IsDBNull(dataReader.GetOrdinal(columnName)))
			{
				return default(T);
			}
			return (T)dataReader[columnName];
		}

		public static T GetValueOrDefault<T>(this SqlDataReader dataReader, string columnName)
		{
			if (!dataReader.HasValue(columnName))
			{
				return default(T);
			}
			return dataReader.GetValue<T>(columnName);
		}

		private static bool HasValue(this SqlDataReader reader, string columnName)
		{
			bool flag;
			try
			{
				int ordinal = reader.GetOrdinal(columnName);
				flag = (ordinal < 0 ? false : !reader.IsDBNull(ordinal));
			}
			catch (IndexOutOfRangeException indexOutOfRangeException)
			{
				flag = false;
			}
			return flag;
		}

		public static object ValueOrDBNull<T>(this T value)
		{
			if (value == null)
			{
				return DBNull.Value;
			}
			return value;
		}
	}
}