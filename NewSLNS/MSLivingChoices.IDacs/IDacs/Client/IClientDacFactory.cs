using MSLivingChoices.IDacs.Client.Components;

namespace MSLivingChoices.IDacs.Client
{
	public interface IClientDacFactory
	{
		ICommonDac GetCommonDac();

		ILeadDac GetLeadDac();

		ILocationDac GetLocationDac();

		ISearchDac GetSearchDac();

		ISeoDac GetSeoDac();
	}
}