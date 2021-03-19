using MSLivingChoices.IDacs.Admin;
using MSLivingChoices.IDacs.Admin.Components;
using MSLivingChoices.SqlDacs.Admin.Components;
using System;

namespace MSLivingChoices.SqlDacs.Admin
{
	public class SqlAdminDacFactory : IAdminDacFactory
	{
		public SqlAdminDacFactory()
		{
		}

		public IAmenityDac GetAmenityDac()
		{
			return new SqlAmenityDac();
		}

		public ICallTrackingDac GetCallTrackingDac()
		{
			return new SqlCallTrackingDac();
		}

		public ICommunityDac GetCommunityDac()
		{
			return new SqlCommunityDac();
		}

		public ICommunityServiceDac GetCommunityServiceDac()
		{
			return new SqlCommunityServiceDac();
		}

		public IItemTypeDac GetItemTypeDac()
		{
			return new SqlItemTypeDac();
		}

		public ILocationDac GetLocationDac()
		{
			return new SqlLocationDac();
		}

		public IOwnerDac GetOwnerDac()
		{
			return new SqlOwnerDac();
		}

		public IProcessingDac GetProcessingDac()
		{
			return new SqlProcessingDac();
		}

		public ISeoDac GetSeoDac()
		{
			return new SqlSeoDac();
		}

		public IServiceProviderDac GetServiceProviderDac()
		{
			return new SqlServiceProviderDac();
		}
	}
}