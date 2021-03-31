using System;
using System.Data;

namespace MSLivingChoices.SqlDacs.Client.Helpers
{
	internal abstract class DataTableWrapper
	{
		protected DataTable Table;

		protected DataTableWrapper()
		{
		}

		public void AddRow(params object[] list)
		{
			this.Table.Rows.Add(list);
		}

		protected static DataColumn GetDataColumn<T>(string columnName, bool allowDbNull = true)
		{
			DataColumn dataColumn = new DataColumn(columnName)
			{
				DataType = typeof(T),
				AllowDBNull = allowDbNull
			};
			if (allowDbNull)
			{
				dataColumn.DefaultValue = null;
			}
			return dataColumn;
		}

		public DataTable GetTable()
		{
			return this.Table;
		}
	}
}