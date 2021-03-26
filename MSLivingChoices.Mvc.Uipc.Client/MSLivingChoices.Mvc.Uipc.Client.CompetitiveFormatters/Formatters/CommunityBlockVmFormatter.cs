using MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters;
using MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.Core;
using MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver;
using MSLivingChoices.Mvc.Uipc.Client.ViewModels;
using System;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.Formatters
{
	internal class CommunityBlockVmFormatter : Formatter<CommunityBlockVm, EntityLocation>
	{
		public CommunityBlockVmFormatter()
		{
		}

		protected override void Apply(CommunityBlockVm vm, EntityLocation location)
		{
			FormatterResolver.ApplyFormatting<EntityLocation>(vm, typeof(CommunityShortVm), location);
			CommunityDisplayProperties displayProperties = vm.DisplayProperties;
			Ensure.String(vm.Phone, displayProperties.Phone, (string i) => vm.Phone = i, (bool f) => displayProperties.Phone = f);
			Ensure.PropertyDescription(vm.Bathes, displayProperties.Bathes, (bool f) => displayProperties.Bathes = f);
			Ensure.PropertyDescription(vm.Beds, displayProperties.Beds, (bool f) => displayProperties.Beds = f);
			Ensure.PropertyDescription(vm.Area, displayProperties.Area, (bool f) => displayProperties.Area = f);
			Ensure.Collection<string>(vm.Amenities, displayProperties.Amenities, (bool f) => displayProperties.Amenities = f);
			Ensure.Collection<ImageVm>(vm.Images, displayProperties.AdditionalImages, (bool f) => displayProperties.AdditionalImages = f);
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
			Ensure.String(vm.SearchRadiusDesignation, displayProperties.RadiusDesignation, (string i) => vm.SearchRadiusDesignation = i, (bool f) => displayProperties.RadiusDesignation = f);
		}
	}
}