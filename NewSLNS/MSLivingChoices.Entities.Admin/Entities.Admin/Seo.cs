using MSLivingChoices.Entities.Admin.Enums;
using System;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Entities.Admin
{
	[Serializable]
	public class Seo
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

		public string MetaDescription
		{
			get;
			set;
		}

		public string MetaKeyword
		{
			get;
			set;
		}

		public MSLivingChoices.Entities.Admin.Enums.SearchType? SearchType
		{
			get;
			set;
		}

		public string SeoCopyText
		{
			get;
			set;
		}

		public int? SeoId
		{
			get;
			set;
		}

		public MSLivingChoices.Entities.Admin.Enums.SeoPage SeoPage
		{
			get;
			set;
		}

		public long? StateId
		{
			get;
			set;
		}

		public Guid UserId
		{
			get;
			set;
		}

		public Seo()
		{
		}
	}
}