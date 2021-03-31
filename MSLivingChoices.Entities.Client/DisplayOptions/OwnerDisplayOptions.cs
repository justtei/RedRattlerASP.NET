using System;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Entities.Client.DisplayOptions
{
	[Serializable]
	public class OwnerDisplayOptions
	{
		public bool Address
		{
			get;
			set;
		}

		public bool Logo
		{
			get;
			set;
		}

		public bool Name
		{
			get;
			set;
		}

		public bool Phone
		{
			get;
			set;
		}

		public bool Website
		{
			get;
			set;
		}

		public OwnerDisplayOptions()
		{
		}
	}
}