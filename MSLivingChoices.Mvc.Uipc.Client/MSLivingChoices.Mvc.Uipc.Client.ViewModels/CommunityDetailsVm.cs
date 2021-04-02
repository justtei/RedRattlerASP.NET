using MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Mvc.Uipc.Client.ViewModels
{
	public class CommunityDetailsVm : SearchWithServicesVm
	{
		
		public List<string> AgeRestrictions
		{
			get;
			set;
		}

		public string ApplicationFee
		{
			get;
			set;
		}

		public CommunityQuickViewVm Community
		{
			get;
			set;
		}

		public CouponVm Coupon
		{
			get;
			set;
		}

		public string Deposit
		{
			get;
			set;
		}

		public DetailsDisplayProperties DisplayProperties
		{
			get;
			set;
		}

		public List<FloorPlanVm> FloorPlans
		{
			get;
			set;
		}

		public List<HomeVm> Homes
		{
			get;
			set;
		}

		public ImageVm Logo
		{
			get;
			set;
		}

		public List<string> OfficeHours
		{
			get;
			set;
		}

		public List<string> PaymentsAccepted
		{
			get;
			set;
		}

		public string PetDeposit
		{
			get;
			set;
		}

		public OwnerVm Pmc
		{
			get;
			set;
		}

		public List<string> ShcCategories
		{
			get;
			set;
		}

		public List<SpecHomeVm> SpecHomes
		{
			get;
			set;
		}

		public string VirtualTourUrl
		{
			get;
			set;
		}

		public string WebsiteUrl
		{
			get;
			set;
		}

		public CommunityDetailsVm()
		{
		}
	}
}