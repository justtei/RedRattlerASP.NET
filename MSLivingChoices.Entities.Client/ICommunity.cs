using System;

namespace MSLivingChoices.Entities.Client
{
	public interface ICommunity
	{
		IAddress Address
		{
			get;
			set;
		}

		long Id
		{
			get;
			set;
		}

		string Name
		{
			get;
			set;
		}
	}
}