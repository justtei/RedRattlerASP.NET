using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Entities.Admin
{
	public class AddressValidation
	{
		public long? AddressId
		{
			get;
			set;
		}

		public List<AddressValidationItem> Condidates
		{
			get;
			set;
		}

		public bool IsValid
		{
			get;
			set;
		}

		public AddressValidationItem ValidAddress
		{
			get;
			set;
		}

		public AddressValidation()
		{
		}
	}
}