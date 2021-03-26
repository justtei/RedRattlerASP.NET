using MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters;
using MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.Core;
using MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver;
using MSLivingChoices.Mvc.Uipc.Client.Enums;
using MSLivingChoices.Mvc.Uipc.Client.ViewModels;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.Formatters
{
	internal class CommunitiesSearchVmFormatter : Formatter<CommunitiesSearchVm, PageType>
	{
		public CommunitiesSearchVmFormatter()
		{
		}

		protected override void Apply(CommunitiesSearchVm vm, PageType location)
		{
			FormatterResolver.ApplyFormatting<EntityLocation>(vm.Result, EntityLocation.Search);
			if ((int)location - (int)PageType.ShcByType <= (int)PageType.ShcByState)
			{
				vm.Result.ForEach((CommunityBlockVm c) => c.DisplayProperties.SpecHomes = false);
				vm.Result.ForEach((CommunityBlockVm c) => c.DisplayProperties.Homes = false);
			}
			if (vm.FeaturedCommunities != null)
			{
				FormatterResolver.ApplyFormatting<EntityLocation>(vm.FeaturedCommunities, EntityLocation.FeaturedWidget);
			}
			if (vm.FeaturedServices != null)
			{
				FormatterResolver.ApplyFormatting<EntityLocation>(vm.FeaturedServices.Items, EntityLocation.FeaturedWidget);
			}
			vm.DisplayProperties = vm.DisplayProperties.Search();
		}
	}
}