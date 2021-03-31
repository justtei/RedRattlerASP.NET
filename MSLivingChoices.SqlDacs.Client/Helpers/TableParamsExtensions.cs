using MSLivingChoices.Entities.Client;
using MSLivingChoices.Entities.Client.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.SqlDacs.Client.Helpers
{
	internal static class TableParamsExtensions
	{
		internal static DataTable GetIdsTable(this IEnumerable<long> ids)
		{
			DataTable dataTable = new DataTable("IdTableType");
			dataTable.Columns.Add(new DataColumn("Id")
			{
				DataType = typeof(long),
				AllowDBNull = false
			});
			if (ids == null)
			{
				return dataTable;
			}
			foreach (long id in ids)
			{
				dataTable.Rows.Add(new object[] { id });
			}
			return dataTable;
		}

		internal static DataTable GetKeyValueStorageTable<TKey>(this IEnumerable<KeyValuePair<TKey, object>> pairs)
		{
			KeyValueStorage keyValueStorage = new KeyValueStorage();
			if (pairs == null)
			{
				return keyValueStorage.GetTable();
			}
			foreach (KeyValuePair<TKey, object> pair in pairs)
			{
				keyValueStorage.AddRow(pair.Key.ToString(), pair.Value);
			}
			return keyValueStorage.GetTable();
		}

		internal static Tuple<DataTable, DataTable> GetLeadTargets(this IEnumerable<LeadTarget> targets)
		{
			LeadTargetTable leadTargetTable = new LeadTargetTable();
			EntityRelatedKeyValueStorage entityRelatedKeyValueStorage = new EntityRelatedKeyValueStorage();
			if (targets == null)
			{
				return new Tuple<DataTable, DataTable>(leadTargetTable.GetTable(), entityRelatedKeyValueStorage.GetTable());
			}
			long num = (long)0;
			foreach (LeadTarget target in targets)
			{
				object[] type = new object[4];
				long num1 = num + (long)1;
				num = num1;
				type[0] = num1;
				type[1] = (int)target.Type;
				type[2] = target.InnerId;
				type[3] = target.OuterId;
				leadTargetTable.AddRow(type);
				foreach (KeyValuePair<LeadTargetDataKey, object> item in target.Data.Items)
				{
					LeadTargetDataKey key = item.Key;
					entityRelatedKeyValueStorage.AddRow(num, key.ToString(), item.Value);
				}
			}
			return new Tuple<DataTable, DataTable>(leadTargetTable.GetTable(), entityRelatedKeyValueStorage.GetTable());
		}
	}
}