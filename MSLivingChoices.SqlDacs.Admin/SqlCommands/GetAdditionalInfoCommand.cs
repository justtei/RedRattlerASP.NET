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
			SpParameter = (int)additionalInfoClass;
			ParameterName = "@AdditionalInformationClassId";
			DescriptionColumnName = "Description";
			IdColumnName = "AdditionalInformationTypeId";
			base.CacheKey = CachedBaseCommand<List<KeyValuePair<int, string>>>.GetCacheKey(base.StoredProcedureName, SpParameter.ToString(), ParameterName, DescriptionColumnName, IdColumnName);
		}
	}
}