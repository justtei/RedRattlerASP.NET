using System;
using System.Data;

namespace MSLivingChoices.SqlDacs.Client.Helpers
{
	internal class KeyValueStorage : DataTableWrapper
	{
		public KeyValueStorage()
		{
			this.Table = new DataTable("KeyValueStorage");
			this.Table.Columns.Add(DataTableWrapper.GetDataColumn<string>("ItemKey", false));
			this.Table.Columns.Add(DataTableWrapper.GetDataColumn<long>("LongValue", true));
			this.Table.Columns.Add(DataTableWrapper.GetDataColumn<string>("StringValue", true));
			this.Table.Columns.Add(DataTableWrapper.GetDataColumn<bool>("BoolValue", true));
			this.Table.Columns.Add(DataTableWrapper.GetDataColumn<DateTime>("DateTimeValue", true));
			this.Table.Columns.Add(DataTableWrapper.GetDataColumn<decimal>("DecimalValue", true));
		}

		public void AddRow(string key, object value)
		{
			long? nullable = null;
			string name = null;
			bool? nullable1 = null;
			DateTime? nullable2 = null;
			decimal? nullable3 = null;
			Type type = value.GetType();
			if (type == typeof(long) || type == typeof(int) || type == typeof(short))
			{
				nullable = new long?((long)value);
			}
			if (type == typeof(string))
			{
				name = (string)value;
			}
			if (type == typeof(bool))
			{
				nullable1 = new bool?((bool)value);
			}
			if (type == typeof(DateTime))
			{
				nullable2 = new DateTime?((DateTime)value);
			}
			if (type == typeof(decimal))
			{
				nullable3 = new decimal?((decimal)value);
			}
			if (type.IsEnum)
			{
				name = Enum.GetName(type, value);
			}
			base.AddRow(new object[] { key, nullable, name, nullable1, nullable2, nullable3 });
		}
	}
}