using MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters;
using MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.Core;
using MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver;
using MSLivingChoices.Mvc.Uipc.Client.ViewModels;
using System;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.Formatters
{
	internal class CommunityQuickViewVmFormatter : Formatter<CommunityQuickViewVm, EntityLocation>
	{
		public CommunityQuickViewVmFormatter()
		{
		}

		protected override void Apply(CommunityQuickViewVm vm, EntityLocation location)
		{
			FormatterResolver.ApplyFormatting<EntityLocation>(vm, typeof(CommunityBlockVm), location);
			CommunityDisplayProperties displayProperties = vm.DisplayProperties;
			Ensure.String(vm.Description, displayProperties.Description, (string i) => vm.Description = i, (bool f) => displayProperties.Description = f);
			Ensure.Collection<string>(vm.CommunityServices, displayProperties.CommunityServices, (bool f) => displayProperties.CommunityServices = f);
		}
	}
}