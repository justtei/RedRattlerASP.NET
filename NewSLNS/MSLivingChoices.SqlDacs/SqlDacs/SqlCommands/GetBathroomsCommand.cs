using System;
using System.Collections.Generic;

namespace MSLivingChoices.SqlDacs.SqlCommands
{
	internal class GetBathroomsCommand : GetItemTypesCommand
	{
		public GetBathroomsCommand()
		{
			base.StoredProcedureName = CommonStoredProcedures.SpGetBathroom;
			this.SpParameter = null;
			this.DescriptionColumnName = "BathroomDescription";
			this.IdColumnName = "BathroomId";
			base.CacheKey = CachedBaseCommand<List<KeyValuePair<int, string>>>.GetCacheKey(new string[] { base.StoredProcedureName, this.DescriptionColumnName, this.IdColumnName });
		}
	}
}