using MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters;
using MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.Core;
using MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver;
using MSLivingChoices.Mvc.Uipc.Client.Enums;
using MSLivingChoices.Mvc.Uipc.Client.ViewModels;
using System;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.Formatters
{
	internal class CommunityDetailsVmFormatter : Formatter<CommunityDetailsVm, PageType>
	{
		public CommunityDetailsVmFormatter()
		{
		}

		protected override void Apply(CommunityDetailsVm vm, PageType location)
		{
			FormatterResolver.ApplyFormatting<EntityLocation>(vm.Community, typeof(CommunityQuickViewVm), EntityLocation.CommunityDetails);
			CommunityDisplayProperties displayProperties = vm.Community.DisplayProperties;
			if (location == PageType.ShcDetails)
			{
				vm.Community.DisplayProperties.SpecHomes = false;
				vm.Community.DisplayProperties.Homes = false;
			}
			Ensure.String(vm.Deposit, displayProperties.Deposit, (string i) => vm.Deposit = i, (bool f) => displayProperties.Deposit = f);
			Ensure.String(vm.ApplicationFee, displayProperties.ApplicationFee, (string i) => vm.ApplicationFee = i, (bool f) => displayProperties.ApplicationFee = f);
			Ensure.String(vm.PetDeposit, displayProperties.PetDeposit, (string i) => vm.PetDeposit = i, (bool f) => displayProperties.PetDeposit = f);
			Ensure.String(vm.VirtualTourUrl, displayProperties.VirtualTourUrl, (string i) => vm.VirtualTourUrl = i, (bool f) => displayProperties.VirtualTourUrl = f);
			Ensure.String(vm.WebsiteUrl, displayProperties.WebsiteUrl, (string i) => vm.WebsiteUrl = i, (bool f) => displayProperties.WebsiteUrl = f);
			Ensure.Entity<ImageVm>(vm.Logo, displayProperties.Logo, (ImageVm i) => vm.Logo = i, (bool f) => displayProperties.Logo = f);
			Ensure.Entity<CouponVm>(vm.Coupon, displayProperties.Coupon, (CouponVm i) => vm.Coupon = i, (bool f) => displayProperties.Coupon = f);
			Ensure.Entity<OwnerVm>(vm.Pmc, displayProperties.Pmc, (OwnerVm i) => vm.Pmc = i, (bool f) => displayProperties.Pmc = f);
			Ensure.Collection<string>(vm.ShcCategories, displayProperties.ShcCategories, (bool f) => displayProperties.ShcCategories = f);
			Ensure.Collection<string>(vm.AgeRestrictions, displayProperties.AgeRestrictions, (bool f) => displayProperties.AgeRestrictions = f);
			Ensure.Collection<string>(vm.PaymentsAccepted, displayProperties.PaymentsAccepted, (bool f) => displayProperties.PaymentsAccepted = f);
			Ensure.Collection<string>(vm.OfficeHours, displayProperties.OfficeHours, (bool f) => displayProperties.OfficeHours = f);
			Ensure.Collection<FloorPlanVm>(vm.FloorPlans, displayProperties.FloorPlans, (bool f) => displayProperties.FloorPlans = f);
			Ensure.Collection<SpecHomeVm>(vm.SpecHomes, displayProperties.SpecHomes, (bool f) => displayProperties.SpecHomes = f);
			Ensure.Collection<HomeVm>(vm.Homes, displayProperties.Homes, (bool f) => displayProperties.Homes = f);
			Ensure.Collection<ImageVm>(vm.Community.Images, displayProperties.PhotoTour, (bool f) => displayProperties.PhotoTour = f);
			vm.DisplayProperties = vm.DisplayProperties.CommunityDetails(vm.Community.Package);
			DetailsDisplayProperties detailsDisplayProperty = vm.DisplayProperties;
			Ensure.Boolean(detailsDisplayProperty.Map, (!displayProperties.Address || !vm.Community.Address.Longitude.HasValue ? false : vm.Community.Address.Latitude.HasValue), (bool i) => {
				if (!i)
				{
					double? nullable = null;
					vm.Community.Address.Latitude = nullable;
					nullable = null;
					vm.Community.Address.Longitude = nullable;
				}
			}, (bool f) => detailsDisplayProperty.Map = f);
			if (vm.Pmc != null)
			{
				FormatterResolver.ApplyFormatting<EntityLocation>(vm.Pmc, EntityLocation.CommunityDetails);
			}
			if (vm.FloorPlans != null)
			{
				FormatterResolver.ApplyFormatting<EntityLocation>(vm.FloorPlans, EntityLocation.CommunityDetails);
			}
			if (vm.SpecHomes != null)
			{
				FormatterResolver.ApplyFormatting<EntityLocation>(vm.SpecHomes, EntityLocation.CommunityDetails);
			}
			if (vm.Homes != null)
			{
				FormatterResolver.ApplyFormatting<EntityLocation>(vm.Homes, EntityLocation.CommunityDetails);
			}
			if (vm.FeaturedServices != null)
			{
				Ensure.Collection<ServiceProviderShortVm>(vm.FeaturedServices.Items, detailsDisplayProperty.FeaturedProviders, (bool f) => detailsDisplayProperty.FeaturedProviders = f);
				FormatterResolver.ApplyFormatting<EntityLocation>(vm.FeaturedServices.Items, EntityLocation.FeaturedWidget);
			}
		}
	}
}