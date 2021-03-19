using System;
using UserManagementSystem.DAL;
using UserManagementSystem.DAL.Interfaces;

namespace UserManagementSystem.Business
{
	public class DacFactoryClient
	{
		private static IDacFactory _dacFactory;

		private readonly static object Locker;

		static DacFactoryClient()
		{
			DacFactoryClient.Locker = new object();
		}

		private DacFactoryClient()
		{
		}

		public static IDacFactory GetFactory()
		{
			if (DacFactoryClient._dacFactory == null)
			{
				lock (DacFactoryClient.Locker)
				{
					if (DacFactoryClient._dacFactory == null)
					{
						DacFactoryClient._dacFactory = new SqlDacFactory();
					}
				}
			}
			return DacFactoryClient._dacFactory;
		}
	}
}