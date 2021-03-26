using MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.Core;
using MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver;
using MSLivingChoices.Mvc.Uipc.Client.ViewModels;
using System;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.Formatters
{
	internal class ServiceProviderShortVmFormatter : Formatter<ServiceProviderShortVm, EntityLocation>
	{
		public ServiceProviderShortVmFormatter()
		{
		}

		protected override void Apply(ServiceProviderShortVm vm, EntityLocation location)
		{
			vm.DisplayProperties = vm.DisplayProperties.ServiceProvider(vm.Package, location);
			ServiceProviderDisplayProperties displayProperties = vm.DisplayProperties;
			Ensure.Entity<ImageVm>(vm.Image, displayProperties.Image, (ImageVm i) => vm.Image = i, (bool f) => displayProperties.Image = f);
			Ensure.IntAboveOne(vm.PhotoCount, displayProperties.PhotoCount, (int i) => vm.PhotoCount = i, (bool f) => displayProperties.PhotoCount = f);
			Ensure.String(vm.Address.Line, displayProperties.Address, (string i) => vm.Address.Line = i, (bool f) => displayProperties.Address = f);
			Ensure.String(vm.Name, displayProperties.Name, (string i) => vm.Name = i, (bool f) => displayProperties.Name = f);
		}
	}
}