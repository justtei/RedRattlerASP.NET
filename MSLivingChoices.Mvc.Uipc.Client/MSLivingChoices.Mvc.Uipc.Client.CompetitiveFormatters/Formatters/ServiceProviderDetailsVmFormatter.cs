using MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters;
using MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.Core;
using MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver;
using MSLivingChoices.Mvc.Uipc.Client.Enums;
using MSLivingChoices.Mvc.Uipc.Client.ViewModels;
using System;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.Formatters
{
	internal class ServiceProviderDetailsVmFormatter : Formatter<ServiceProviderDetailsVm, PageType>
	{
		public ServiceProviderDetailsVmFormatter()
		{
		}

		protected override void Apply(ServiceProviderDetailsVm vm, PageType location)
		{
			FormatterResolver.ApplyFormatting<EntityLocation>(vm.ServiceProvider, typeof(ServiceProviderQuickViewVm), EntityLocation.ServiceProviderDetails);
			ServiceProviderDisplayProperties displayProperties = vm.ServiceProvider.DisplayProperties;
			Ensure.String(vm.WebsiteUrl, displayProperties.WebsiteUrl, (string i) => vm.WebsiteUrl = i, (bool f) => displayProperties.WebsiteUrl = f);
			Ensure.Entity<CouponVm>(vm.Coupon, displayProperties.Coupon, (CouponVm i) => vm.Coupon = i, (bool f) => displayProperties.Coupon = f);
			Ensure.Collection<string>(vm.PaymentsAccepted, displayProperties.PaymentsAccepted, (bool f) => displayProperties.PaymentsAccepted = f);
			Ensure.Collection<string>(vm.OfficeHours, displayProperties.OfficeHours, (bool f) => displayProperties.OfficeHours = f);
			Ensure.Collection<ImageVm>(vm.ServiceProvider.Images, displayProperties.PhotoTour, (bool f) => displayProperties.PhotoTour = f);
			vm.DisplayProperties = vm.DisplayProperties.ServiceProviderDetails(vm.ServiceProvider.Package);
			if (vm.FeaturedServices != null)
			{
				Ensure.Collection<ServiceProviderShortVm>(vm.FeaturedServices.Items, vm.DisplayProperties.FeaturedProviders, (bool f) => vm.DisplayProperties.FeaturedProviders = f);
				FormatterResolver.ApplyFormatting<EntityLocation>(vm.FeaturedServices.Items, EntityLocation.FeaturedWidget);
			}
		}
	}
}