using System;

namespace MSLivingChoices.Entities.Client
{
	public interface IAddress
	{
		string City
		{
			get;
			set;
		}

		string StateCode
		{
			get;
			set;
		}
	}
}