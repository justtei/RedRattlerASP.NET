using MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.Core;
using MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver;
using MSLivingChoices.Mvc.Uipc.Client.ViewModels;
using System;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.Formatters
{
	internal class HomeQuickViewVmFormatter : Formatter<HomeQuickViewVm, EntityLocation>
	{
		public HomeQuickViewVmFormatter()
		{
		}

		protected override void Apply(HomeQuickViewVm vm, EntityLocation location)
		{
			vm.DisplayProperties = vm.DisplayProperties.Home(vm.Package, EntityLocation.QuickView);
			HomeDisplayProperties displayProperties = vm.DisplayProperties;
			Ensure.Entity<ImageVm>(vm.Image, displayProperties.Image, (ImageVm i) => vm.Image = i, (bool f) => displayProperties.Image = f);
			Ensure.PropertyDescription(vm.Beds, displayProperties.Beds, (bool f) => displayProperties.Beds = f);
			Ensure.PropertyDescription(vm.Bathes, displayProperties.Bathes, (bool f) => displayProperties.Bathes = f);
			Ensure.PropertyDescription(vm.Area, displayProperties.Area, (bool f) => displayProperties.Area = f);
			Ensure.String(vm.Price, displayProperties.Price, (string i) => vm.Price = i, (bool f) => displayProperties.Price = f);
			Ensure.String(vm.Name, displayProperties.Name, (string i) => vm.Name = i, (bool f) => displayProperties.Name = f);
			Ensure.String(vm.SaleType, displayProperties.SaleType, (string i) => vm.SaleType = i, (bool f) => displayProperties.SaleType = f);
			Ensure.String(vm.YearBuilt, displayProperties.YearBuilt, (string i) => vm.YearBuilt = i, (bool f) => displayProperties.YearBuilt = f);
			Ensure.String(vm.Address.Line, displayProperties.Address, (string i) => vm.Address.Line = i, (bool f) => displayProperties.Address = f);
		}
	}
}