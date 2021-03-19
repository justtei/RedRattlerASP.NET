using MSLivingChoices.IDacs.Admin;
using MSLivingChoices.SqlDacs.Admin;
using System;

namespace MSLivingChoices.Bcs.Admin
{
	internal class AdminDacFactoryClient
	{
		private static IAdminDacFactory _dacFactory;

		private readonly static object Locker;

		static AdminDacFactoryClient()
		{
			AdminDacFactoryClient.Locker = new object();
		}

		private AdminDacFactoryClient()
		{
		}

		public static IAdminDacFactory GetConcreteFactory()
		{
			if (AdminDacFactoryClient._dacFactory == null)
			{
				lock (AdminDacFactoryClient.Locker)
				{
					if (AdminDacFactoryClient._dacFactory == null)
					{
						AdminDacFactoryClient._dacFactory = new SqlAdminDacFactory();
					}
				}
			}
			return AdminDacFactoryClient._dacFactory;
		}
	}
}