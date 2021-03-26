using MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver;
using System;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Mvc.Uipc.Client.ViewModels
{
	public class OwnerVm
	{
		public AddressVm Address
		{
			get;
			set;
		}

		public OwnerDisplayProperties DisplayProperties
		{
			get;
			set;
		}

		public ImageVm Logo
		{
			get;
			set;
		}

		public string Name
		{
			get;
			set;
		}

		public int Package
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

		public OwnerVm()
		{
		}
	}
}