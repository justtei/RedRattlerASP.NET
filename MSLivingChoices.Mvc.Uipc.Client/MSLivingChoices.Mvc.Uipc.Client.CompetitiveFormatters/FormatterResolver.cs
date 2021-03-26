using MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.Core;
using MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.Formatters;
using MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver;
using MSLivingChoices.Mvc.Uipc.Client.ViewModels;
using System;
using System.Collections.Generic;

namespace MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters
{
	internal static class FormatterResolver
	{
		private static readonly Dictionary<Type, object> Formatters;

		static FormatterResolver()
		{
			Formatters = new Dictionary<Type, object>();
			RegisterFormatter<OwnerVm>(new OwnerVmFormatter());
			RegisterFormatter<List<OwnerVm>>(new CollectionFormatter<OwnerVmFormatter, EntityLocation>());
			RegisterFormatter<FloorPlanQuickViewVm>(new FloorPlanQuickViewVmFormatter());
			RegisterFormatter<FloorPlanVm>(new FloorPlanVmFormatter());
			RegisterFormatter<HomeQuickViewVm>(new HomeQuickViewVmFormatter());
			RegisterFormatter<HomeVm>(new HomeVmFormatter());
			RegisterFormatter<SpecHomeQuickViewVm>(new SpecHomeQuickViewVmFormatter());
			RegisterFormatter<SpecHomeVm>(new SpecHomeVmFormatter());
			RegisterFormatter<List<FloorPlanQuickViewVm>>(new CollectionFormatter<FloorPlanQuickViewVm, EntityLocation>());
			RegisterFormatter<List<FloorPlanVm>>(new CollectionFormatter<FloorPlanVm, EntityLocation>());
			RegisterFormatter<List<HomeQuickViewVm>>(new CollectionFormatter<HomeQuickViewVm, EntityLocation>());
			RegisterFormatter<List<HomeVm>>(new CollectionFormatter<HomeVm, EntityLocation>());
			RegisterFormatter<List<SpecHomeQuickViewVm>>(new CollectionFormatter<SpecHomeQuickViewVm, EntityLocation>());
			RegisterFormatter<List<SpecHomeVm>>(new CollectionFormatter<SpecHomeVm, EntityLocation>());
			RegisterFormatter<CommunityShortVm>(new CommunityShortVmFormatter());
			RegisterFormatter<CommunityBlockVm>(new CommunityBlockVmFormatter());
			RegisterFormatter<CommunityQuickViewVm>(new CommunityQuickViewVmFormatter());
			RegisterFormatter<List<CommunityShortVm>>(new CollectionFormatter<CommunityShortVm, EntityLocation>());
			RegisterFormatter<List<CommunityBlockVm>>(new CollectionFormatter<CommunityBlockVm, EntityLocation>());
			RegisterFormatter<List<CommunityQuickViewVm>>(new CollectionFormatter<CommunityQuickViewVm, EntityLocation>());
			RegisterFormatter<ServiceProviderShortVm>(new ServiceProviderShortVmFormatter());
			RegisterFormatter<ServiceProviderBlockVm>(new ServiceProviderBlockVmFormatter());
			RegisterFormatter<ServiceProviderQuickViewVm>(new ServiceProviderQuickViewVmFormatter());
			RegisterFormatter<List<ServiceProviderShortVm>>(new CollectionFormatter<ServiceProviderShortVm, EntityLocation>());
			RegisterFormatter<List<ServiceProviderBlockVm>>(new CollectionFormatter<ServiceProviderBlockVm, EntityLocation>());
			RegisterFormatter<List<ServiceProviderQuickViewVm>>(new CollectionFormatter<ServiceProviderQuickViewVm, EntityLocation>());
			RegisterFormatter<CommunityDetailsVm>(new CommunityDetailsVmFormatter());
			RegisterFormatter<CommunityPrintDirectionVm>(new CommunityDetailsVmFormatter());
			RegisterFormatter<ServiceProviderDetailsVm>(new ServiceProviderDetailsVmFormatter());
			RegisterFormatter<ServiceProviderPrintDirectionVm>(new ServiceProviderDetailsVmFormatter());
			RegisterFormatter<CommunitiesSearchVm>(new CommunitiesSearchVmFormatter());
			RegisterFormatter<ServiceProvidersSearchVm>(new ServiceProvidersSearchVmFormatter());
		}

		public static void ApplyFormatting<TPage>(object obj, TPage page = default(TPage))
		{
			if (obj != null)
			{
				ApplyFormatting(obj, obj.GetType(), page);
			}
		}

		public static void ApplyFormatting<TPage>(object obj, Type type, TPage page = default(TPage))
		{
			if (obj != null)
			{
				ResolveFormatter<TPage>(type)?.Apply(obj, page);
			}
		}

		private static void RegisterFormatter<TEntity>(object formatter)
		{
			Formatters.Add(typeof(TEntity), formatter);
		}

		private static IFormatter<TPage> ResolveFormatter<TPage>(Type type)
		{
			IFormatter<TPage> result = null;
			if (Formatters.ContainsKey(type))
			{
				result = (IFormatter<TPage>)Formatters[type];
			}
			return result;
		}
	}
}