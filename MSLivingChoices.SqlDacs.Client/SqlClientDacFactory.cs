using MSLivingChoices.IDacs.Client;
using MSLivingChoices.IDacs.Client.Components;
using MSLivingChoices.SqlDacs.Client.Components;
using System;

namespace MSLivingChoices.SqlDacs.Client
{
	public class SqlClientDacFactory : IClientDacFactory
	{
		public SqlClientDacFactory()
		{
		}

		public ICommonDac GetCommonDac()
		{
			return new SqlCommonDac();
		}

		public ILeadDac GetLeadDac()
		{
			return new SqlLeadDac();
		}

		public ILocationDac GetLocationDac()
		{
			return new SqlLocationDac();
		}

		public ISearchDac GetSearchDac()
		{
			return new SqlSearchDac();
		}

		public ISeoDac GetSeoDac()
		{
			return new SqlSeoDac();
		}
	}
}