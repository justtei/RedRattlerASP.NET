using System;
using System.Data;

namespace MSLivingChoices.SqlDacs.Client.Helpers
{
	internal class LeadTargetTable : DataTableWrapper
	{
		public LeadTargetTable()
		{
			this.Table = new DataTable("LeadTargetTable");
			this.Table.Columns.Add(DataTableWrapper.GetDataColumn<long>("LocalId", true));
			this.Table.Columns.Add(DataTableWrapper.GetDataColumn<int>("TargetTypeId", true));
			this.Table.Columns.Add(DataTableWrapper.GetDataColumn<long>("InnerId", true));
			this.Table.Columns.Add(DataTableWrapper.GetDataColumn<string>("OuterId", true));
		}
	}
}