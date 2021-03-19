using System;
using System.Collections.Generic;

namespace MSLivingChoices.SqlDacs.SqlCommands
{
	public class GetShcCategoriesForCommunityCommand : GetItemTypesCommand
	{
		public GetShcCategoriesForCommunityCommand()
		{
			base.StoredProcedureName = CommonStoredProcedures.SpGetAdditionalInformationType;
			this.SpParameter = new int?(2);
			this.ParameterName = "@AdditionalInformationClassId";
			this.DescriptionColumnName = "Description";
			this.IdColumnName = "AdditionalInformationTypeId";
			base.CacheKey = CachedBaseCommand<List<KeyValuePair<int, string>>>.GetCacheKey(new string[] { base.StoredProcedureName, this.SpParameter.ToString(), this.ParameterName, this.DescriptionColumnName, this.IdColumnName });
		}
	}
}