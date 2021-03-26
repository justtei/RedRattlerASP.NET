using MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters;
using MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.Core;
using MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver;
using MSLivingChoices.Mvc.Uipc.Client.ViewModels;
using System;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.Formatters
{
	internal class ServiceProviderQuickViewVmFormatter : Formatter<ServiceProviderQuickViewVm, EntityLocation>
	{
		public ServiceProviderQuickViewVmFormatter()
		{
		}

		protected override void Apply(ServiceProviderQuickViewVm vm, EntityLocation location)
		{
			FormatterResolver.ApplyFormatting<EntityLocation>(vm, typeof(ServiceProviderBlockVm), EntityLocation.ServiceProviderDetails);
			ServiceProviderDisplayProperties displayProperties = vm.DisplayProperties;
			Ensure.String(vm.Description, displayProperties.Description, (string i) => vm.Description = i, (bool f) => displayProperties.Description = f);
		}
	}
}