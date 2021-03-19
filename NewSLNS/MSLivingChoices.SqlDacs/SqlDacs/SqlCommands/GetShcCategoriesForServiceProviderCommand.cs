using System;
using System.Collections.Generic;

namespace MSLivingChoices.SqlDacs.SqlCommands
{
	public class GetShcCategoriesForServiceProviderCommand : GetItemTypesCommand
	{
		public GetShcCategoriesForServiceProviderCommand()
		{
			base.StoredProcedureName = CommonStoredProcedures.SpGetAdditionalInformationType;
			this.SpParameter = new int?(10);
			this.ParameterName = "@AdditionalInformationClassId";
			this.DescriptionColumnName = "Description";
			this.IdColumnName = "AdditionalInformationTypeId";
			base.CacheKey = CachedBaseCommand<List<KeyValuePair<int, string>>>.GetCacheKey(new string[] { base.StoredProcedureName, this.SpParameter.ToString(), this.ParameterName, this.DescriptionColumnName, this.IdColumnName });
		}
	}
}