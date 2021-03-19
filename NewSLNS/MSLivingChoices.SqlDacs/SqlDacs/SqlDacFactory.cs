using MSLivingChoices.IDacs;
using MSLivingChoices.IDacs.Components;
using MSLivingChoices.SqlDacs.Components;
using System;

namespace MSLivingChoices.SqlDacs
{
	public class SqlDacFactory : IDacFactory
	{
		public SqlDacFactory()
		{
		}

		public IItemTypeDac GetItemTypeDac()
		{
			return new SqlItemTypeDac();
		}
	}
}