using System;
using UserManagementSystem.DAL.Components;
using UserManagementSystem.DAL.Interfaces;
using UserManagementSystem.DAL.Interfaces.Components;

namespace UserManagementSystem.DAL
{
	public class SqlDacFactory : IDacFactory
	{
		public SqlDacFactory()
		{
		}

		public IAccountDac GetAccountDac()
		{
			return new SqlAccountDac();
		}

		public ILocationDac GetLocationDac()
		{
			return new SqlLocationDac();
		}

		public IPublicationDac GetPublicationDac()
		{
			return new SqlPublicationDac();
		}
	}
}