using MSLivingChoices.Configuration;
using System;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver
{
	internal static class OptionsResolver
	{
		public static CommunityDisplayProperties Community(this CommunityDisplayProperties displayProperties, int package, EntityLocation location)
		{
			CommunityDisplayProperties communityDisplayProperty = displayProperties;
			communityDisplayProperty = communityDisplayProperty.CommunityDefault(package);
			switch (location)
			{
				case EntityLocation.Search:
				{
					communityDisplayProperty.Address = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Search.Community.Address");
					communityDisplayProperty.Featured = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Search.Community.Featured");
					communityDisplayProperty.Name = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Search.Community.Name");
					communityDisplayProperty.Price = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Search.Community.Price");
					communityDisplayProperty.PhotoCount = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Search.Community.PhotoCount");
					communityDisplayProperty.Image = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Search.Community.Image");
					communityDisplayProperty.Bathes = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Search.Community.Bathes");
					communityDisplayProperty.Beds = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Search.Community.Beds");
					communityDisplayProperty.Area = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Search.Community.Area");
					communityDisplayProperty.Amenities = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Search.Community.Amenities");
					communityDisplayProperty.AdditionalImages = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Search.Community.AdditionalImages");
					communityDisplayProperty.Phone = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Search.Community.Phone");
					communityDisplayProperty.FloorPlans = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Search.Community.QuickView.FloorPlans");
					communityDisplayProperty.SpecHomes = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Search.Community.QuickView.SpecHomes");
					communityDisplayProperty.Homes = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Search.Community.QuickView.Homes");
					communityDisplayProperty.LeadForm = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Search.Community.LeadForm");
					communityDisplayProperty.Map = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Search.Community.QuickView.Map");
					communityDisplayProperty.QuickView = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Search.Community.QuickView");
					break;
				}
				case EntityLocation.QuickView:
				{
					communityDisplayProperty.Address = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Search.QuickView.Community.Address");
					communityDisplayProperty.Name = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Search.QuickView.Community.Name");
					communityDisplayProperty.Price = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Search.QuickView.Community.Price");
					communityDisplayProperty.PhotoCount = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Search.QuickView.Community.PhotoCount");
					communityDisplayProperty.Image = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Search.QuickView.Community.Image");
					communityDisplayProperty.Bathes = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Search.QuickView.Community.Bathes");
					communityDisplayProperty.Beds = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Search.QuickView.Community.Beds");
					communityDisplayProperty.Area = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Search.QuickView.Community.Area");
					communityDisplayProperty.Amenities = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Search.QuickView.Community.Amenities");
					communityDisplayProperty.AdditionalImages = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Search.QuickView.Community.AdditionalImages");
					communityDisplayProperty.Phone = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Search.QuickView.Community.Phone");
					communityDisplayProperty.Description = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Search.QuickView.Community.Description");
					communityDisplayProperty.CommunityServices = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Search.QuickView.Community.CommunityServices");
					communityDisplayProperty.LeadForm = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Search.QuickView.Community.LeadForm");
					communityDisplayProperty.PhotoTour = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Search.QuickView.Community.PhotoTour");
					break;
				}
				case EntityLocation.FeaturedWidget:
				{
					communityDisplayProperty.Address = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.FeaturedWidget.Community.Address");
					communityDisplayProperty.Name = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.FeaturedWidget.Community.Name");
					communityDisplayProperty.Price = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.FeaturedWidget.Community.Price");
					communityDisplayProperty.PhotoCount = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.FeaturedWidget.Community.PhotoCount");
					communityDisplayProperty.Image = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.FeaturedWidget.Community.Image");
					break;
				}
				case EntityLocation.CommunityDetails:
				{
					communityDisplayProperty.Address = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Details.Community.Address");
					communityDisplayProperty.WebsiteUrl = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Details.Community.WebsiteUrl");
					communityDisplayProperty.Name = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Details.Community.Name");
					communityDisplayProperty.Price = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Details.Community.Price");
					communityDisplayProperty.PhotoCount = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Details.Community.PhotoCount");
					communityDisplayProperty.Image = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Details.Community.Image");
					communityDisplayProperty.Bathes = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Details.Community.Bathes");
					communityDisplayProperty.Beds = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Details.Community.Beds");
					communityDisplayProperty.Area = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Details.Community.Area");
					communityDisplayProperty.Amenities = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Details.Community.Amenities");
					communityDisplayProperty.AdditionalImages = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Details.Community.AdditionalImages");
					communityDisplayProperty.Phone = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Details.Community.Phone");
					communityDisplayProperty.Description = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Details.Community.Description");
					communityDisplayProperty.CommunityServices = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Details.Community.CommunityServices");
					communityDisplayProperty.Deposit = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Details.Community.Deposit");
					communityDisplayProperty.ApplicationFee = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Details.Community.ApplicationFee");
					communityDisplayProperty.PetDeposit = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Details.Community.PetDeposit");
					communityDisplayProperty.VirtualTourUrl = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Details.Community.VirtualTour");
					communityDisplayProperty.Logo = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Details.Community.Logo");
					communityDisplayProperty.Coupon = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Details.Community.Coupon");
					communityDisplayProperty.Pmc = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Details.Community.Pmc");
					communityDisplayProperty.ShcCategories = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Details.Community.ShcCategories");
					communityDisplayProperty.AgeRestrictions = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Details.Community.AgeRestrictions");
					communityDisplayProperty.PaymentsAccepted = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Details.Community.PaymentsAccepted");
					communityDisplayProperty.OfficeHours = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Details.Community.OfficeHours");
					communityDisplayProperty.FloorPlans = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Details.Community.FloorPlans");
					communityDisplayProperty.SpecHomes = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Details.Community.SpecHomes");
					communityDisplayProperty.Homes = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Details.Community.Homes");
					communityDisplayProperty.LeadForm = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Details.Community.LeadForm");
					communityDisplayProperty.PhotoTour = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Details.Community.PhotoTour");
					break;
				}
			}
			return communityDisplayProperty;
		}

		private static CommunityDisplayProperties CommunityDefault(this CommunityDisplayProperties dp, int package)
		{
			dp.Address = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Community.Address");
			dp.WebsiteUrl = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Community.WebsiteUrl");
			dp.Featured = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Community.Featured");
			dp.Name = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Community.Name");
			dp.Price = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Community.Price");
			dp.PhotoCount = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Community.PhotoCount");
			dp.Image = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Community.Image");
			dp.Bathes = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Community.Bathes");
			dp.Beds = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Community.Beds");
			dp.Area = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Community.Area");
			dp.Amenities = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Community.Amenities");
			dp.AdditionalImages = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Community.AdditionalImages");
			dp.Phone = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Community.Phone");
			dp.Description = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Community.Description");
			dp.CommunityServices = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Community.CommunityServices");
			dp.Deposit = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Community.Deposit");
			dp.ApplicationFee = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Community.ApplicationFee");
			dp.PetDeposit = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Community.PetDeposit");
			dp.VirtualTourUrl = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Community.VirtualTour");
			dp.Logo = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Community.Logo");
			dp.Coupon = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Community.Coupon");
			dp.Pmc = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Community.Pmc");
			dp.ShcCategories = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Community.ShcCategories");
			dp.AgeRestrictions = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Community.AgeRestrictions");
			dp.PaymentsAccepted = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Community.PaymentsAccepted");
			dp.OfficeHours = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Community.OfficeHours");
			dp.FloorPlans = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Community.FloorPlans");
			dp.SpecHomes = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Community.SpecHomes");
			dp.Homes = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Community.Homes");
			dp.LeadForm = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Community.LeadForm");
			dp.Map = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Community.Map");
			dp.PhotoTour = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Community.PhotoTour");
			dp.QuickView = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Community.QuickView");
			dp.RadiusDesignation = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Community.SearchRadiusDesignation");
			return dp;
		}

		public static DetailsDisplayProperties CommunityDetails(this DetailsDisplayProperties displayProperties, int package)
		{
			DetailsDisplayProperties detailsDisplayProperty = displayProperties ?? new DetailsDisplayProperties();
			detailsDisplayProperty.SocialButtons = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Details.Community.SocialButtons");
			detailsDisplayProperty.PartnerAds = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Details.Community.PartnerAds");
			detailsDisplayProperty.BookOrder = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Details.Community.BookOrder");
			detailsDisplayProperty.Map = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Details.Community.Map");
			detailsDisplayProperty.FeaturedProviders = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Details.Community.FeaturedProviders");
			return detailsDisplayProperty;
		}

		public static FloorPlanDisplayProperties FloorPlan(this FloorPlanDisplayProperties displayProperties, int package, EntityLocation location)
		{
			FloorPlanDisplayProperties floorPlanDisplayProperty = displayProperties ?? new FloorPlanDisplayProperties();
			floorPlanDisplayProperty = floorPlanDisplayProperty.FloorPlanDefault(package);
			if (location == EntityLocation.QuickView)
			{
				floorPlanDisplayProperty.Name = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Search.QuickView.FloorPlan.Name");
				floorPlanDisplayProperty.Image = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Search.QuickView.FloorPlan.Image");
				floorPlanDisplayProperty.Beds = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Search.QuickView.FloorPlan.Beds");
				floorPlanDisplayProperty.Bathes = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Search.QuickView.FloorPlan.Bathes");
				floorPlanDisplayProperty.Area = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Search.QuickView.FloorPlan.Area");
				floorPlanDisplayProperty.Price = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Search.QuickView.FloorPlan.Price");
				floorPlanDisplayProperty.LeadForm = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Search.QuickView.FloorPlan.LeadForm");
				floorPlanDisplayProperty.PhotoTour = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Search.QuickView.Community.PhotoTour");
			}
			else if (location == EntityLocation.CommunityDetails)
			{
				floorPlanDisplayProperty.Name = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Details.FloorPlan.Name");
				floorPlanDisplayProperty.Image = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Details.FloorPlan.Image");
				floorPlanDisplayProperty.Beds = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Details.FloorPlan.Beds");
				floorPlanDisplayProperty.Bathes = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Details.FloorPlan.Bathes");
				floorPlanDisplayProperty.Area = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Details.FloorPlan.Area");
				floorPlanDisplayProperty.Price = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Details.FloorPlan.Price");
				floorPlanDisplayProperty.Deposit = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Details.FloorPlan.Deposit");
				floorPlanDisplayProperty.ApplicationFee = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Details.FloorPlan.ApplicationFee");
				floorPlanDisplayProperty.PetDeposit = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Details.FloorPlan.PetDeposit");
				floorPlanDisplayProperty.Amenities = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Details.FloorPlan.Amenities");
				floorPlanDisplayProperty.LeadForm = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Details.FloorPlan.LeadForm");
				floorPlanDisplayProperty.PhotoTour = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Search.QuickView.Community.PhotoTour");
			}
			return floorPlanDisplayProperty;
		}

		private static FloorPlanDisplayProperties FloorPlanDefault(this FloorPlanDisplayProperties dp, int package)
		{
			dp.Name = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.FloorPlan.Name");
			dp.Image = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.FloorPlan.Image");
			dp.Beds = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.FloorPlan.Beds");
			dp.Bathes = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.FloorPlan.Bathes");
			dp.Area = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.FloorPlan.Area");
			dp.Price = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.FloorPlan.Price");
			dp.Deposit = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.FloorPlan.Deposit");
			dp.ApplicationFee = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.FloorPlan.ApplicationFee");
			dp.PetDeposit = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.FloorPlan.PetDeposit");
			dp.Amenities = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.FloorPlan.Amenities");
			return dp;
		}

		public static HomeDisplayProperties Home(this HomeDisplayProperties displayProperties, int package, EntityLocation location)
		{
			HomeDisplayProperties homeDisplayProperty = displayProperties ?? new HomeDisplayProperties();
			homeDisplayProperty = homeDisplayProperty.HomeDefault(package);
			if (location == EntityLocation.QuickView)
			{
				homeDisplayProperty.Name = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Search.QuickView.Home.Name");
				homeDisplayProperty.Image = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Search.QuickView.Home.Image");
				homeDisplayProperty.Beds = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Search.QuickView.Home.Beds");
				homeDisplayProperty.Bathes = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Search.QuickView.Home.Bathes");
				homeDisplayProperty.Area = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Search.QuickView.Home.Area");
				homeDisplayProperty.Price = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Search.QuickView.Home.Price");
				homeDisplayProperty.SaleType = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Search.QuickView.Home.SaleType");
				homeDisplayProperty.Address = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Search.QuickView.Home.Address");
				homeDisplayProperty.YearBuilt = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Search.QuickView.Home.YearBuilt");
				homeDisplayProperty.LeadForm = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Search.QuickView.Home.LeadForm");
				homeDisplayProperty.PhotoTour = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Search.QuickView.Community.PhotoTour");
			}
			else if (location == EntityLocation.CommunityDetails)
			{
				homeDisplayProperty.Name = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Details.Home.Name");
				homeDisplayProperty.Image = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Details.Home.Image");
				homeDisplayProperty.Beds = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Details.Home.Beds");
				homeDisplayProperty.Bathes = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Details.Home.Bathes");
				homeDisplayProperty.Area = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Details.Home.Area");
				homeDisplayProperty.Price = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Details.Home.Price");
				homeDisplayProperty.SaleType = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Details.Home.SaleType");
				homeDisplayProperty.Address = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Details.Home.Address");
				homeDisplayProperty.YearBuilt = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Details.Home.YearBuilt");
				homeDisplayProperty.Deposit = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Details.Home.Deposit");
				homeDisplayProperty.ApplicationFee = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Details.Home.ApplicationFee");
				homeDisplayProperty.PetDeposit = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Details.Home.PetDeposit");
				homeDisplayProperty.Description = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Details.Home.Description");
				homeDisplayProperty.LeadForm = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Details.Home.LeadForm");
				homeDisplayProperty.PhotoTour = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Search.QuickView.Community.PhotoTour");
			}
			return homeDisplayProperty;
		}

		private static HomeDisplayProperties HomeDefault(this HomeDisplayProperties dp, int package)
		{
			dp.Name = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Home.Name");
			dp.Image = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Home.Image");
			dp.Beds = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Home.Beds");
			dp.Bathes = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Home.Bathes");
			dp.Area = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Home.Area");
			dp.Price = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Home.Price");
			dp.SaleType = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Home.SaleType");
			dp.Address = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Home.Address");
			dp.YearBuilt = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Home.YearBuilt");
			dp.Deposit = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Home.Deposit");
			dp.ApplicationFee = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Home.ApplicationFee");
			dp.PetDeposit = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Home.PetDeposit");
			dp.Description = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Home.Description");
			dp.Amenities = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Home.Amenities");
			return dp;
		}

		private static bool IsActive(int package, string itemKey)
		{
			return ConfigurationManager.Instance.IsActiveCompetitiveItem(package, itemKey);
		}

		public static OwnerDisplayProperties Owner(this OwnerDisplayProperties displayProperties, int package, EntityLocation location)
		{
			OwnerDisplayProperties ownerDisplayProperty = displayProperties ?? new OwnerDisplayProperties();
			ownerDisplayProperty = ownerDisplayProperty.OwnerDefault(package);
			if (location == EntityLocation.CommunityDetails)
			{
				ownerDisplayProperty.Name = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Details.Owner.Name");
				ownerDisplayProperty.Phone = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Details.Owner.Phone");
				ownerDisplayProperty.WebsiteUrl = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Details.Owner.WebsiteUrl");
				ownerDisplayProperty.Logo = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Details.Owner.Logo");
				ownerDisplayProperty.Address = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Details.Owner.Address");
			}
			return ownerDisplayProperty;
		}

		private static OwnerDisplayProperties OwnerDefault(this OwnerDisplayProperties dp, int package)
		{
			dp.Name = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Owner.Name");
			dp.Phone = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Owner.Phone");
			dp.WebsiteUrl = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Owner.WebsiteUrl");
			dp.Logo = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Owner.Logo");
			dp.Address = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Owner.Address");
			return dp;
		}

		public static SearchDisplayProperties Search(this SearchDisplayProperties displayProperties)
		{
			SearchDisplayProperties searchDisplayProperty = displayProperties ?? new SearchDisplayProperties();
			searchDisplayProperty.BookOrder = true;
			searchDisplayProperty.PartnerAds = true;
			searchDisplayProperty.FeaturedCommunities = true;
			searchDisplayProperty.FeaturedServiceProviders = true;
			searchDisplayProperty.NearbyCities = true;
			searchDisplayProperty.NearbyCategories = true;
			return searchDisplayProperty;
		}

		public static ServiceProviderDisplayProperties ServiceProvider(this ServiceProviderDisplayProperties displayProperties, int package, EntityLocation location)
		{
			ServiceProviderDisplayProperties serviceProviderDisplayProperty = displayProperties;
			serviceProviderDisplayProperty = serviceProviderDisplayProperty.ServiceProviderDefault(package);
			switch (location)
			{
				case EntityLocation.Search:
				{
					serviceProviderDisplayProperty.Address = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Search.ServiceProvider.Address");
					serviceProviderDisplayProperty.Featured = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Search.ServiceProvider.Featured");
					serviceProviderDisplayProperty.Name = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Search.ServiceProvider.Name");
					serviceProviderDisplayProperty.PhotoCount = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Search.ServiceProvider.PhotoCount");
					serviceProviderDisplayProperty.Image = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Search.ServiceProvider.Image");
					serviceProviderDisplayProperty.ServiceCategories = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Search.ServiceProvider.ServiceCategories");
					serviceProviderDisplayProperty.AdditionalImages = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Search.ServiceProvider.AdditionalImages");
					serviceProviderDisplayProperty.Phone = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Search.ServiceProvider.Phone");
					serviceProviderDisplayProperty.LeadForm = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Search.ServiceProvider.LeadForm");
					serviceProviderDisplayProperty.QuickView = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Search.ServiceProvider.QuickView");
					serviceProviderDisplayProperty.Map = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Search.ServiceProvider.Map");
					return serviceProviderDisplayProperty;
				}
				case EntityLocation.QuickView:
				{
					serviceProviderDisplayProperty.Address = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Search.QuickView.ServiceProvider.Address");
					serviceProviderDisplayProperty.Name = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Search.QuickView.ServiceProvider.Name");
					serviceProviderDisplayProperty.PhotoCount = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Search.QuickView.ServiceProvider.PhotoCount");
					serviceProviderDisplayProperty.Image = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Search.QuickView.ServiceProvider.Image");
					serviceProviderDisplayProperty.ServiceCategories = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Search.QuickView.ServiceProvider.ServiceCategories");
					serviceProviderDisplayProperty.AdditionalImages = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Search.QuickView.ServiceProvider.AdditionalImages");
					serviceProviderDisplayProperty.Phone = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Search.QuickView.ServiceProvider.Phone");
					serviceProviderDisplayProperty.Description = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Search.QuickView.ServiceProvider.Description");
					serviceProviderDisplayProperty.LeadForm = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Search.QuickView.ServiceProvider.LeadForm");
					serviceProviderDisplayProperty.PhotoTour = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Search.QuickView.ServiceProvider.PhotoTour");
					return serviceProviderDisplayProperty;
				}
				case EntityLocation.FeaturedWidget:
				{
					serviceProviderDisplayProperty.Address = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.FeaturedWidget.ServiceProvider.Address");
					serviceProviderDisplayProperty.Name = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.FeaturedWidget.ServiceProvider.Name");
					serviceProviderDisplayProperty.PhotoCount = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.FeaturedWidget.ServiceProvider.PhotoCount");
					serviceProviderDisplayProperty.Image = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.FeaturedWidget.ServiceProvider.Image");
					return serviceProviderDisplayProperty;
				}
				case EntityLocation.CommunityDetails:
				{
					return serviceProviderDisplayProperty;
				}
				case EntityLocation.ServiceProviderDetails:
				{
					serviceProviderDisplayProperty.Address = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Details.ServiceProvider.Address");
					serviceProviderDisplayProperty.WebsiteUrl = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Details.ServiceProvider.WebsiteUrl");
					serviceProviderDisplayProperty.Name = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Details.ServiceProvider.Name");
					serviceProviderDisplayProperty.PhotoCount = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Details.ServiceProvider.PhotoCount");
					serviceProviderDisplayProperty.Image = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Details.ServiceProvider.Image");
					serviceProviderDisplayProperty.CountiesServed = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Details.ServiceProvider.CountiesServed");
					serviceProviderDisplayProperty.ServiceCategories = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Details.ServiceProvider.ServiceCategories");
					serviceProviderDisplayProperty.AdditionalImages = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Details.ServiceProvider.AdditionalImages");
					serviceProviderDisplayProperty.Phone = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Details.ServiceProvider.Phone");
					serviceProviderDisplayProperty.Description = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Details.ServiceProvider.Description");
					serviceProviderDisplayProperty.OfficeHours = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Details.ServiceProvider.OfficeHours");
					serviceProviderDisplayProperty.PaymentsAccepted = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Details.ServiceProvider.PaymentsAccepted");
					serviceProviderDisplayProperty.Coupon = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Details.ServiceProvider.Coupon");
					serviceProviderDisplayProperty.LeadForm = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Details.ServiceProvider.LeadForm");
					serviceProviderDisplayProperty.PhotoTour = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Details.ServiceProvider.PhotoTour");
					serviceProviderDisplayProperty.Map = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Details.ServiceProvider.Map");
					return serviceProviderDisplayProperty;
				}
				default:
				{
					return serviceProviderDisplayProperty;
				}
			}
		}

		private static ServiceProviderDisplayProperties ServiceProviderDefault(this ServiceProviderDisplayProperties dp, int package)
		{
			dp.Address = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.ServiceProvider.Address");
			dp.Featured = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.ServiceProvider.Featured");
			dp.WebsiteUrl = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.ServiceProvider.WebsiteUrl");
			dp.Name = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.ServiceProvider.Name");
			dp.PhotoCount = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.ServiceProvider.PhotoCount");
			dp.Image = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.ServiceProvider.Image");
			dp.CountiesServed = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.ServiceProvider.CountiesServed");
			dp.ServiceCategories = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.ServiceProvider.ServiceCategories");
			dp.AdditionalImages = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.ServiceProvider.AdditionalImages");
			dp.Phone = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.ServiceProvider.Phone");
			dp.Description = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.ServiceProvider.Description");
			dp.OfficeHours = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.ServiceProvider.OfficeHours");
			dp.PaymentsAccepted = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.ServiceProvider.PaymentsAccepted");
			dp.Coupon = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.ServiceProvider.Coupon");
			dp.RadiusDesignation = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.ServiceProvider.SearchRadiusDesignation");
			return dp;
		}

		public static DetailsDisplayProperties ServiceProviderDetails(this DetailsDisplayProperties displayProperties, int package)
		{
			DetailsDisplayProperties detailsDisplayProperty = displayProperties ?? new DetailsDisplayProperties();
			detailsDisplayProperty.SocialButtons = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Details.ServiceProvider.SocialButtons");
			detailsDisplayProperty.PartnerAds = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Details.ServiceProvider.PartnerAds");
			detailsDisplayProperty.BookOrder = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Details.ServiceProvider.BookOrder");
			detailsDisplayProperty.Map = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Details.ServiceProvider.Map");
			detailsDisplayProperty.FeaturedProviders = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Details.ServiceProvider.FeaturedProviders");
			return detailsDisplayProperty;
		}

		public static SpecHomeDisplayProperties SpecHome(this SpecHomeDisplayProperties displayProperties, int package, EntityLocation location)
		{
			SpecHomeDisplayProperties specHomeDisplayProperty = displayProperties ?? new SpecHomeDisplayProperties();
			specHomeDisplayProperty = specHomeDisplayProperty.SpecHomeDefault(package);
			if (location == EntityLocation.QuickView)
			{
				specHomeDisplayProperty.Name = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Search.QuickView.SpecHome.Name");
				specHomeDisplayProperty.Image = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Search.QuickView.SpecHome.Image");
				specHomeDisplayProperty.Beds = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Search.QuickView.SpecHome.Beds");
				specHomeDisplayProperty.Bathes = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Search.QuickView.SpecHome.Bathes");
				specHomeDisplayProperty.Area = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Search.QuickView.SpecHome.Area");
				specHomeDisplayProperty.SaleType = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Search.QuickView.SpecHome.SaleType");
				specHomeDisplayProperty.Status = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Search.QuickView.SpecHome.Status");
				specHomeDisplayProperty.Price = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Search.QuickView.SpecHome.Price");
				specHomeDisplayProperty.LeadForm = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Search.QuickView.SpecHome.LeadForm");
				specHomeDisplayProperty.PhotoTour = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Search.QuickView.Community.PhotoTour");
			}
			else if (location == EntityLocation.CommunityDetails)
			{
				specHomeDisplayProperty.Name = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Details.SpecHome.Name");
				specHomeDisplayProperty.Image = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Details.SpecHome.Image");
				specHomeDisplayProperty.Beds = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Details.SpecHome.Beds");
				specHomeDisplayProperty.Bathes = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Details.SpecHome.Bathes");
				specHomeDisplayProperty.Area = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Details.SpecHome.Area");
				specHomeDisplayProperty.SaleType = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Details.SpecHome.SaleType");
				specHomeDisplayProperty.Status = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Details.SpecHome.Status");
				specHomeDisplayProperty.Price = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Details.SpecHome.Price");
				specHomeDisplayProperty.Deposit = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Details.SpecHome.Deposit");
				specHomeDisplayProperty.ApplicationFee = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Details.SpecHome.ApplicationFee");
				specHomeDisplayProperty.PetDeposit = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Details.SpecHome.PetDeposit");
				specHomeDisplayProperty.Amenities = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Details.SpecHome.Amenities");
				specHomeDisplayProperty.Description = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Details.SpecHome.Description");
				specHomeDisplayProperty.LeadForm = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Details.SpecHome.LeadForm");
				specHomeDisplayProperty.PhotoTour = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.Search.QuickView.Community.PhotoTour");
			}
			return specHomeDisplayProperty;
		}

		private static SpecHomeDisplayProperties SpecHomeDefault(this SpecHomeDisplayProperties dp, int package)
		{
			dp.Name = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.SpecHome.Name");
			dp.Image = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.SpecHome.Image");
			dp.Beds = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.SpecHome.Beds");
			dp.Bathes = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.SpecHome.Bathes");
			dp.Area = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.SpecHome.Area");
			dp.SaleType = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.SpecHome.SaleType");
			dp.Status = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.SpecHome.Status");
			dp.Price = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.SpecHome.Price");
			dp.Deposit = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.SpecHome.Deposit");
			dp.ApplicationFee = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.SpecHome.ApplicationFee");
			dp.PetDeposit = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.SpecHome.PetDeposit");
			dp.Amenities = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.SpecHome.Amenities");
			dp.Description = MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver.OptionsResolver.IsActive(package, "Mslc.Ui.SpecHome.Description");
			return dp;
		}
	}
}