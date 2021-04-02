using MSLivingChoices.IDacs.Admin.Components;

namespace MSLivingChoices.IDacs.Admin
{
	public interface IAdminDacFactory
	{
		IAmenityDac GetAmenityDac();

		ICallTrackingDac GetCallTrackingDac();

		ICommunityDac GetCommunityDac();

		ICommunityServiceDac GetCommunityServiceDac();

		IItemTypeDac GetItemTypeDac();

		ILocationDac GetLocationDac();

		IOwnerDac GetOwnerDac();

		IProcessingDac GetProcessingDac();

		ISeoDac GetSeoDac();

		IServiceProviderDac GetServiceProviderDac();
	}
}