using MSLivingChoices.Entities.Client;
using MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters;
using MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.Core;
using MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver;
using MSLivingChoices.Mvc.Uipc.Client.ViewModels;
using System;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.Formatters
{
	internal class ServiceProviderBlockVmFormatter : Formatter<ServiceProviderBlockVm, EntityLocation>
	{
		public ServiceProviderBlockVmFormatter()
		{
		}

		protected override void Apply(ServiceProviderBlockVm vm, EntityLocation location)
		{
			FormatterResolver.ApplyFormatting<EntityLocation>(vm, typeof(ServiceProviderShortVm), location);
			ServiceProviderDisplayProperties displayProperties = vm.DisplayProperties;
			Ensure.String(vm.Phone, displayProperties.Phone, (string i) => vm.Phone = i, (bool f) => displayProperties.Phone = f);
			Ensure.Collection<County>(vm.CountiesServed, displayProperties.CountiesServed, (bool f) => displayProperties.CountiesServed = f);
			Ensure.Collection<string>(vm.ServiceCategories, displayProperties.ServiceCategories, (bool f) => displayProperties.ServiceCategories = f);
			Ensure.Collection<ImageVm>(vm.Images, displayProperties.AdditionalImages, (bool f) => displayProperties.AdditionalImages = f);
			Ensure.String(vm.SearchRadiusDesignation, displayProperties.RadiusDesignation, (string i) => vm.SearchRadiusDesignation = i, (bool f) => displayProperties.RadiusDesignation = f);
			Ensure.Boolean(displayProperties.Map, (!displayProperties.Address || !vm.Address.Longitude.HasValue ? false : vm.Address.Latitude.HasValue), (bool i) => {
				if (!i)
				{
					double? nullable = null;
					vm.Address.Latitude = nullable;
					nullable = null;
					vm.Address.Longitude = nullable;
					displayProperties.Map = false;
				}
			}, (bool f) => displayProperties.Map = f);
		}
	}
}