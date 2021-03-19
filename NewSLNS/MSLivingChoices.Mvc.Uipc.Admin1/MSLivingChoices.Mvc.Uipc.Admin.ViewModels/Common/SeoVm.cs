using MSLivingChoices.Entities.Admin.Enums;
using MSLivingChoices.Mvc.Uipc.Admin.Helpers;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Web.Mvc;

namespace MSLivingChoices.Mvc.Uipc.Admin.ViewModels.Common
{
	public class SeoVm
	{
		public long? CityId
		{
			get;
			set;
		}

		public long? CountryId
		{
			get;
			set;
		}

		public MSLivingChoices.Entities.Admin.Enums.SearchType? SearchType
		{
			get;
			set;
		}

		public List<SelectListItem> SearchTypes
		{
			get
			{
				return ConverterHelpers.EnumToKoSelectListItems<MSLivingChoices.Entities.Admin.Enums.SearchType>();
			}
		}

		public int? SeoId
		{
			get;
			set;
		}

		public SeoMetadataVm SeoMetadata
		{
			get;
			set;
		}

		public MSLivingChoices.Entities.Admin.Enums.SeoPage SeoPage
		{
			get;
			set;
		}

		public List<SelectListItem> SeoPages
		{
			get
			{
				return ConverterHelpers.EnumToKoSelectListItems<MSLivingChoices.Entities.Admin.Enums.SeoPage>();
			}
		}

		public long? StateId
		{
			get;
			set;
		}

		public SeoVm()
		{
			this.SeoMetadata = new SeoMetadataVm();
		}
	}
}