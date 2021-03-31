using System;

namespace MSLivingChoices.Entities.Client
{
	public interface IProvider
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