using MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters;
using MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.Core;
using MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver;
using MSLivingChoices.Mvc.Uipc.Client.ViewModels;
using System;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.Formatters
{
	internal class FloorPlanVmFormatter : Formatter<FloorPlanVm, EntityLocation>
	{
		public FloorPlanVmFormatter()
		{
		}

		protected override void Apply(FloorPlanVm vm, EntityLocation location)
		{
			FormatterResolver.ApplyFormatting<EntityLocation>(vm, typeof(FloorPlanQuickViewVm), location);
			FloorPlanDisplayProperties displayProperties = vm.DisplayProperties;
			Ensure.String(vm.Deposit, displayProperties.Deposit, (string i) => vm.Deposit = i, (bool f) => displayProperties.Deposit = f);
			Ensure.String(vm.ApplicationFee, displayProperties.ApplicationFee, (string i) => vm.ApplicationFee = i, (bool f) => displayProperties.ApplicationFee = f);
			Ensure.String(vm.PetDeposit, displayProperties.PetDeposit, (string i) => vm.PetDeposit = i, (bool f) => displayProperties.PetDeposit = f);
			Ensure.Collection<string>(vm.Amenities, displayProperties.Amenities, (bool f) => displayProperties.Amenities = f);
		}
	}
}