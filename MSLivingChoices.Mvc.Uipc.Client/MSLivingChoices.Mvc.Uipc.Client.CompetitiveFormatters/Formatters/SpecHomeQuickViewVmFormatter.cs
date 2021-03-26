using MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.Core;
using MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver;
using MSLivingChoices.Mvc.Uipc.Client.ViewModels;
using System;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.Formatters
{
	internal class SpecHomeQuickViewVmFormatter : Formatter<SpecHomeQuickViewVm, EntityLocation>
	{
		public SpecHomeQuickViewVmFormatter()
		{
		}

		protected override void Apply(SpecHomeQuickViewVm vm, EntityLocation location)
		{
			vm.DisplayProperties = vm.DisplayProperties.SpecHome(vm.Package, EntityLocation.QuickView);
			SpecHomeDisplayProperties displayProperties = vm.DisplayProperties;
			Ensure.Entity<ImageVm>(vm.Image, displayProperties.Image, (ImageVm i) => vm.Image = i, (bool f) => displayProperties.Image = f);
			Ensure.PropertyDescription(vm.Beds, displayProperties.Beds, (bool f) => displayProperties.Beds = f);
			Ensure.PropertyDescription(vm.Bathes, displayProperties.Bathes, (bool f) => displayProperties.Bathes = f);
			Ensure.PropertyDescription(vm.Area, displayProperties.Area, (bool f) => displayProperties.Area = f);
			Ensure.String(vm.Price, displayProperties.Price, (string i) => vm.Price = i, (bool f) => displayProperties.Price = f);
			Ensure.String(vm.Name, displayProperties.Name, (string i) => vm.Name = i, (bool f) => displayProperties.Name = f);
			Ensure.String(vm.SaleType, displayProperties.SaleType, (string i) => vm.SaleType = i, (bool f) => displayProperties.SaleType = f);
			Ensure.String(vm.Status, displayProperties.Status, (string i) => vm.Status = i, (bool f) => displayProperties.Status = f);
		}
	}
}