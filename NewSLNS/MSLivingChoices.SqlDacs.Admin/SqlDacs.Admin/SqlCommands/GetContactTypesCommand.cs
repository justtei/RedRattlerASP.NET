using MSLivingChoices.Entities.Admin.Enums;
using MSLivingChoices.SqlDacs.SqlCommands;
using System;
using System.Collections.Generic;

namespace MSLivingChoices.SqlDacs.Admin.SqlCommands
{
	internal class GetContactTypesCommand : ThreeParamGenericGetCommand
	{
		protected GetContactTypesCommand()
		{
			base.StoredProcedureName = AdminStoredProcedures.SpGetContactType;
			this.IdColumnName = "ContactTypeId";
			this.DescriptionColumnName = "Description";
		}

		public GetContactTypesCommand(MSLivingChoices.Entities.Admin.Enums.CommunityType communityType) : this()
		{
			this.CommunityType = new MSLivingChoices.Entities.Admin.Enums.CommunityType?(communityType);
			base.CacheKey = CachedBaseCommand<List<KeyValuePair<int, string>>>.GetCacheKey(new string[] { base.StoredProcedureName, this.CommunityType.ToString(), this.OwnerType.ToString(), this.ServiceType.ToString(), this.IdColumnName, this.DescriptionColumnName });
		}

		public GetContactTypesCommand(MSLivingChoices.Entities.Admin.Enums.OwnerType ownerType) : this()
		{
			this.OwnerType = new MSLivingChoices.Entities.Admin.Enums.OwnerType?(ownerType);
			base.CacheKey = CachedBaseCommand<List<KeyValuePair<int, string>>>.GetCacheKey(new string[] { base.StoredProcedureName, this.CommunityType.ToString(), this.OwnerType.ToString(), this.ServiceType.ToString(), this.IdColumnName, this.DescriptionColumnName });
		}

		public GetContactTypesCommand(MSLivingChoices.Entities.Admin.Enums.ServiceType serviceType) : this()
		{
			this.ServiceType = new MSLivingChoices.Entities.Admin.Enums.ServiceType?(serviceType);
			base.CacheKey = CachedBaseCommand<List<KeyValuePair<int, string>>>.GetCacheKey(new string[] { base.StoredProcedureName, this.CommunityType.ToString(), this.OwnerType.ToString(), this.ServiceType.ToString(), this.IdColumnName, this.DescriptionColumnName });
		}
	}
}