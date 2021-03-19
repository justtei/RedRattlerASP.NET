using UserManagementSystem.DAL.Interfaces.Components;

namespace UserManagementSystem.DAL.Interfaces
{
	public interface IDacFactory
	{
		IAccountDac GetAccountDac();

		ILocationDac GetLocationDac();

		IPublicationDac GetPublicationDac();
	}
}