using MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters;
using MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.Core;
using MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver;
using MSLivingChoices.Mvc.Uipc.Client.Enums;
using MSLivingChoices.Mvc.Uipc.Client.ViewModels;
using System;

namespace MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.Formatters
{
	internal class ServiceProvidersSearchVmFormatter : Formatter<ServiceProvidersSearchVm, PageType>
	{
		public ServiceProvidersSearchVmFormatter()
		{
		}

		protected override void Apply(ServiceProvidersSearchVm vm, PageType location)
		{
			FormatterResolver.ApplyFormatting<EntityLocation>(vm.Result, EntityLocation.Search);
			if (vm.FeaturedServices != null)
			{
				FormatterResolver.ApplyFormatting<EntityLocation>(vm.FeaturedServices.Items, EntityLocation.FeaturedWidget);
			}
			vm.DisplayProperties = vm.DisplayProperties.Search();
		}
	}
}