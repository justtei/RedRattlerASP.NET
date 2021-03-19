using MSLivingChoices.Entities.Admin.Enums;
using MSLivingChoices.SqlDacs.SqlCommands;
using System;
using System.Collections.Generic;

namespace MSLivingChoices.SqlDacs.Admin.SqlCommands
{
	internal class GetAdditionalInfoCommand : GetItemTypesCommand
	{
		public GetAdditionalInfoCommand(AdditionalInfoClass additionalInfoClass)
		{
			base.StoredProcedureName = AdminStoredProcedures.SpGetAdditionalInformationType;
			this.SpParameter = new int?(additionalInfoClass);
			this.ParameterName = "@AdditionalInformationClassId";
			this.DescriptionColumnName = "Description";
			this.IdColumnName = "AdditionalInformationTypeId";
			base.CacheKey = CachedBaseCommand<List<KeyValuePair<int, string>>>.GetCacheKey(new string[] { base.StoredProcedureName, this.SpParameter.ToString(), this.ParameterName, this.DescriptionColumnName, this.IdColumnName });
		}
	}
}