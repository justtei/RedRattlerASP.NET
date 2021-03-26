using MSLivingChoices.Entities.Client.Enums;
using MSLivingChoices.Localization;
using MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver;
using MSLivingChoices.Mvc.Uipc.Client.Helpers;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Mvc.Uipc.Client.ViewModels
{
	public class CommunitiesSearchVm : ResultSetSearchVm<CommunityBlockVm, CommunitySortType>
	{
		public List<int> Amenities
		{
			get;
			set;
		}

		public int? Bathes
		{
			get;
			set;
		}

		public int? Beds
		{
			get;
			set;
		}

		public SearchDisplayProperties DisplayProperties
		{
			get;
			set;
		}

		public List<CommunityShortVm> FeaturedCommunities
		{
			get;
			set;
		}

		public decimal? MaxPrice
		{
			get;
			set;
		}

		public decimal? MinPrice
		{
			get;
			set;
		}

		public CommunityRefineVm Refine
		{
			get;
			set;
		}

		public List<int> ShcCategories
		{
			get;
			set;
		}

		public CommunitiesSearchVm()
		{
		}

		protected override ExpandoObject ToDimensionsData()
		{
			dynamic dimensionsData = base.ToDimensionsData();
			dimensionsData.listingType = base.PageType.ToSearchType().ToListingType().GetEnumLocalizedValue<ListingType>();
			dimensionsData.beds = this.Beds;
			dimensionsData.bathes = this.Bathes;
			dimensionsData.minPrice = this.MinPrice;
			dimensionsData.maxPrice = this.MaxPrice;
			return (ExpandoObject)dimensionsData;
		}
	}
}