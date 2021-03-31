using MSLivingChoices.Entities.Client.Enums;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Mvc.Uipc.Client.ViewModels
{
	public class CommunityBlockVm : CommunityShortVm
	{
		public string Description { get; set; }
		public List<string> Amenities
		{
			get;
			set;
		}

		public PropertyVm Area
		{
			get;
			set;
		}

		public PropertyVm Bathes
		{
			get;
			set;
		}

		public PropertyVm Beds
		{
			get;
			set;
		}

		public List<ImageVm> Images
		{
			get;
			set;
		}

		public List<ListingType> ListingTypes
		{
			get;
			set;
		}

		public string Phone
		{
			get;
			set;
		}

		public string PrintDirectionBaseUrl
		{
			get;
			set;
		}

		public string PrintUrl
		{
			get;
			set;
		}

		public string SearchRadiusDesignation
		{
			get;
			set;
		}

		public CommunityBlockVm()
		{
		}
	}
}