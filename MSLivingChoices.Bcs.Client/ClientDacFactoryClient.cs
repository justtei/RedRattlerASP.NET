using MSLivingChoices.IDacs.Client;
using MSLivingChoices.SqlDacs.Client;
using System;

namespace MSLivingChoices.Bcs.Client
{
	internal class ClientDacFactoryClient
	{
		private static IClientDacFactory _dacFactory;

		private readonly static object Locker;

		static ClientDacFactoryClient()
		{
			ClientDacFactoryClient.Locker = new object();
		}

		private ClientDacFactoryClient()
		{
		}

		public static IClientDacFactory GetConcreteFactory()
		{
			if (ClientDacFactoryClient._dacFactory == null)
			{
				lock (ClientDacFactoryClient.Locker)
				{
					if (ClientDacFactoryClient._dacFactory == null)
					{
						ClientDacFactoryClient._dacFactory = new SqlClientDacFactory();
					}
				}
			}
			return ClientDacFactoryClient._dacFactory;
		}
	}
}