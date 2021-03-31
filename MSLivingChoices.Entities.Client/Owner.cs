using MSLivingChoices.Entities.Client.DisplayOptions;
using System;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Entities.Client
{
	[Serializable]
	public class Owner
	{
		public MSLivingChoices.Entities.Client.Address Address
		{
			get;
			set;
		}

		public OwnerDisplayOptions DisplayOptions
		{
			get;
			set;
		}

		public Image Logo
		{
			get;
			set;
		}

		public string Name
		{
			get;
			set;
		}

		public string Phone
		{
			get;
			set;
		}

		public string WebsiteUrl
		{
			get;
			set;
		}

		public Owner()
		{
			this.DisplayOptions = new OwnerDisplayOptions();
		}

		public override string ToString()
		{
			return this.Name;
		}
	}
}