using MSLivingChoices.Entities.Client;
using MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver;
using System;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Mvc.Uipc.Client.ViewModels
{
	public class ServiceProviderShortVm : IProvider
	{
		public AddressVm Address
		{
			get;
			set;
		}
		public string Description { get; set; }
		public string BookNumber
		{
			get;
			set;
		}

		public string DetailsUrl
		{
			get;
			set;
		}

		public ServiceProviderDisplayProperties DisplayProperties
		{
			get;
			set;
		}

		public long Id
		{
			get;
			set;
		}

		public ImageVm Image
		{
			get;
			set;
		}

		IAddress MSLivingChoices.Entities.Client.IProvider.Address
		{
			get
			{
				return this.Address;
			}
			set
			{
				this.Address = value as AddressVm;
			}
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

		public int PhotoCount
		{
			get;
			set;
		}

		public ServiceProviderShortVm()
		{
		}
	}
}