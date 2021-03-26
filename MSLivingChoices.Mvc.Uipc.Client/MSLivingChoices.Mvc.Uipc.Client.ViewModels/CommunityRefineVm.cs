using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Web.Mvc;

namespace MSLivingChoices.Mvc.Uipc.Client.ViewModels
{
	public class CommunityRefineVm
	{
		public IEnumerable<SelectListItem> Amenities
		{
			get;
			set;
		}

		public IEnumerable<SelectListItem> Bathes
		{
			get;
			set;
		}

		public IEnumerable<SelectListItem> Beds
		{
			get;
			set;
		}

		public IEnumerable<SelectListItem> ShcCategories
		{
			get;
			set;
		}

		public IEnumerable<SelectListItem> SortTypes
		{
			get;
			set;
		}

		public CommunityRefineVm()
		{
			this.ShcCategories = new List<SelectListItem>();
			this.SortTypes = new List<SelectListItem>();
			this.Amenities = new List<SelectListItem>();
			this.Bathes = new List<SelectListItem>();
			this.Beds = new List<SelectListItem>();
		}
	}
}