using MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.Core;
using MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver;
using MSLivingChoices.Mvc.Uipc.Client.ViewModels;
using System;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.Formatters
{
	internal class FloorPlanQuickViewVmFormatter : Formatter<FloorPlanQuickViewVm, EntityLocation>
	{
		public FloorPlanQuickViewVmFormatter()
		{
		}

		protected override void Apply(FloorPlanQuickViewVm vm, EntityLocation location)
		{
			vm.DisplayProperties = vm.DisplayProperties.FloorPlan(vm.Package, EntityLocation.QuickView);
			FloorPlanDisplayProperties displayProperties = vm.DisplayProperties;
			Ensure.Entity<ImageVm>(vm.Image, displayProperties.Image, (ImageVm i) => vm.Image = i, (bool f) => displayProperties.Image = f);
			Ensure.PropertyDescription(vm.Beds, displayProperties.Beds, (bool f) => displayProperties.Beds = f);
			Ensure.PropertyDescription(vm.Bathes, displayProperties.Bathes, (bool f) => displayProperties.Bathes = f);
			Ensure.PropertyDescription(vm.Area, displayProperties.Area, (bool f) => displayProperties.Area = f);
			Ensure.String(vm.Price, displayProperties.Price, (string i) => vm.Price = i, (bool f) => displayProperties.Price = f);
			Ensure.String(vm.Name, displayProperties.Name, (string i) => vm.Name = i, (bool f) => displayProperties.Name = f);
		}
	}
}