using System;
using System.Collections.Generic;

namespace MSLivingChoices.SqlDacs.SqlCommands
{
	internal class GetBedroomsCommand : GetItemTypesCommand
	{
		public GetBedroomsCommand()
		{
			base.StoredProcedureName = CommonStoredProcedures.SpGetBedroom;
			this.SpParameter = null;
			this.DescriptionColumnName = "BedroomDescription";
			this.IdColumnName = "BedroomId";
			base.CacheKey = CachedBaseCommand<List<KeyValuePair<int, string>>>.GetCacheKey(new string[] { base.StoredProcedureName, this.DescriptionColumnName, this.IdColumnName });
		}
	}
}