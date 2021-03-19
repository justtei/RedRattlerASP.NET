using MSLivingChoices.Bcs.Admin.Components;
using MSLivingChoices.Entities.Admin;
using MSLivingChoices.Entities.Admin.Enums;
using MSLivingChoices.Mvc.Uipc.Admin.Helpers;
using MSLivingChoices.Mvc.Uipc.Admin.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Mvc.Uipc.Admin.MappingExtentions
{
	internal static class GridEtentions
	{
		internal static CommunityForGridVm MapToCommunityForGridVm(this Community community)
		{
			string name;
			CommunityForGridVm communityForGridVm = new CommunityForGridVm();
			List<KeyValuePair<int, string>> seniorHousingAndCareCategories = ItemTypeBc.Instance.GetSHCCategoriesForCommunity();
			communityForGridVm.Id = community.Id;
			communityForGridVm.Name = community.Name;
			communityForGridVm.BookNumber = community.Book.Number;
			communityForGridVm.CreateUser = community.CreateUserId;
			if (community.Package.HasValue)
			{
				name = Enum.GetName(typeof(PackageType), community.Package);
			}
			else
			{
				name = null;
			}
			communityForGridVm.Package = name;
			communityForGridVm.Packages = new List<string>(Enum.GetNames(typeof(PackageType)));
			communityForGridVm.ActiveAdultCommunities = community.ListingTypes.Any<ListingType>((ListingType m) => m == ListingType.ActiveAdultCommunities);
			communityForGridVm.ActiveAdultHomes = community.ListingTypes.Any<ListingType>((ListingType m) => m == ListingType.ActiveAdultHomes);
			communityForGridVm.SeniorHousingAndCare = (!community.ListingTypes.Any<ListingType>((ListingType m) => m == ListingType.SeniorHousingAndCare) || community.SeniorHousingAndCareCategoryIds == null ? false : community.SeniorHousingAndCareCategoryIds.Any<long>());
			communityForGridVm.SeniorHousingAndCareCategories = ConverterHelpers.DictionaryToCheckBoxList(seniorHousingAndCareCategories, community.SeniorHousingAndCareCategoryIds);
			communityForGridVm.ShowcaseStartDate = community.Showcase.StartDate;
			communityForGridVm.ShowcaseEndDate = community.Showcase.EndDate;
			communityForGridVm.PublishStartDate = community.Publishing.StartDate;
			communityForGridVm.PublishEndDate = community.Publishing.EndDate;
			return communityForGridVm;
		}

		internal static List<CommunityForGridVm> MapToCommunityForGridVmList(this List<Community> communities)
		{
			return communities.ConvertAll<CommunityForGridVm>(new Converter<Community, CommunityForGridVm>(GridEtentions.MapToCommunityForGridVm));
		}

		internal static FilterForCommunityGridVm MapToFilterForCommunityGridVm(this CommunityGridFilter filter)
		{
			return new FilterForCommunityGridVm()
			{
				AAC = filter.AAC,
				AAH = filter.AAH,
				Community = filter.Community,
				Packages = ConverterHelpers.DictionaryToCheckBoxList(ItemTypeBc.Instance.GetAdditionalInfo(AdditionalInfoClass.Package), filter.Packages.ConvertAll<long>((KeyValuePair<int, string> x) => (long)x.Key)),
				Publish = filter.Publish,
				PublishEnd = filter.PublishEnd,
				PublishStart = filter.PublishStart,
				SHC = filter.SHC,
				Showcase = filter.Showcase,
				ShowcaseStart = filter.ShowcaseStart,
				ShowcaseEnd = filter.ShowcaseEnd,
				SHCCategories = ConverterHelpers.DictionaryToCheckBoxList(ItemTypeBc.Instance.GetSHCCategoriesForCommunity(), filter.Categories.ConvertAll<long>((KeyValuePair<int, string> x) => (long)x.Key))
			};
		}

		internal static FilterForServiceProviderGridVm MapToFilterForServiceProviderGridVm(this ServiceProviderGridFilter filter)
		{
			return new FilterForServiceProviderGridVm()
			{
				ServiceProvider = filter.ServiceProvider,
				Feature = filter.Feature,
				FeatureStart = filter.FeatureStart,
				FeatureEnd = filter.FeatureEnd,
				Publish = filter.Publish,
				PublishStart = filter.PublishStart,
				PublishEnd = filter.PublishEnd,
				Packages = ConverterHelpers.DictionaryToCheckBoxList(ItemTypeBc.Instance.GetAdditionalInfo(AdditionalInfoClass.Package), filter.Packages.ConvertAll<long>((KeyValuePair<int, string> x) => (long)x.Key)),
				Categories = ConverterHelpers.DictionaryToCheckBoxList(ItemTypeBc.Instance.GetSHCCategoriesForServiceProvider(), filter.Categories.ConvertAll<long>((KeyValuePair<int, string> x) => (long)x.Key))
			};
		}

		internal static OwnerForGridVm MapToOwnerForGridVm(this Owner owner)
		{
			return new OwnerForGridVm()
			{
				Id = owner.Id,
				Name = owner.Name,
				WebSiteUrl = owner.WebsiteUrl
			};
		}

		internal static List<OwnerForGridVm> MapToOwnerForGridVmList(this List<Owner> owners)
		{
			return owners.ConvertAll<OwnerForGridVm>(new Converter<Owner, OwnerForGridVm>(GridEtentions.MapToOwnerForGridVm));
		}

		internal static ServiceProviderForGridVm MapToServiceProviderForGridVm(this ServiceProvider serviceProvider)
		{
			string name;
			ServiceProviderForGridVm serviceProviderForGridVm = new ServiceProviderForGridVm();
			List<KeyValuePair<int, string>> seniorHousingAndCareCategories = ItemTypeBc.Instance.GetSHCCategoriesForServiceProvider();
			serviceProviderForGridVm.Id = serviceProvider.Id;
			serviceProviderForGridVm.Name = serviceProvider.Name;
			if (serviceProvider.Package.HasValue)
			{
				name = Enum.GetName(typeof(PackageType), serviceProvider.Package);
			}
			else
			{
				name = null;
			}
			serviceProviderForGridVm.Package = name;
			serviceProviderForGridVm.Packages = new List<string>(Enum.GetNames(typeof(PackageType)));
			serviceProviderForGridVm.SeniorHousingAndCareCategories = ConverterHelpers.DictionaryToCheckBoxList(seniorHousingAndCareCategories, (
				from sc in serviceProvider.ServiceCategories
				select sc.Key).ToList<long>());
			serviceProviderForGridVm.FeatureStartDate = serviceProvider.FeatureStartDate;
			serviceProviderForGridVm.FeatureEndDate = serviceProvider.FeatureEndDate;
			serviceProviderForGridVm.PublishStartDate = serviceProvider.PublishStartDate;
			serviceProviderForGridVm.PublishEndDate = serviceProvider.PublishEndDate;
			return serviceProviderForGridVm;
		}

		internal static List<ServiceProviderForGridVm> MapToServiceProviderForGridVmList(this List<ServiceProvider> serviceProviders)
		{
			return serviceProviders.ConvertAll<ServiceProviderForGridVm>(new Converter<ServiceProvider, ServiceProviderForGridVm>(GridEtentions.MapToServiceProviderForGridVm));
		}
	}
}