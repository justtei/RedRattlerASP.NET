using MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.Core;
using MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver;
using MSLivingChoices.Mvc.Uipc.Client.ViewModels;
using System;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.Formatters
{
	internal class OwnerVmFormatter : Formatter<OwnerVm, EntityLocation>
	{
		public OwnerVmFormatter()
		{
		}

		protected override void Apply(OwnerVm vm, EntityLocation location)
		{
			vm.DisplayProperties = vm.DisplayProperties.Owner(vm.Package, location);
			OwnerDisplayProperties displayProperties = vm.DisplayProperties;
			Ensure.Entity<ImageVm>(vm.Logo, displayProperties.Logo, (ImageVm i) => vm.Logo = i, (bool f) => displayProperties.Logo = f);
			Ensure.String(vm.Address.Line, displayProperties.Address, (string i) => vm.Address.Line = i, (bool f) => displayProperties.Address = f);
			Ensure.String(vm.Name, displayProperties.Name, (string i) => vm.Name = i, (bool f) => displayProperties.Name = f);
			Ensure.String(vm.Phone, displayProperties.Phone, (string i) => vm.Phone = i, (bool f) => displayProperties.Phone = f);
			Ensure.String(vm.WebsiteUrl, displayProperties.WebsiteUrl, (string i) => vm.WebsiteUrl = i, (bool f) => displayProperties.WebsiteUrl = f);
		}
	}
}