using MSLivingChoices.Entities.Client.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace MSLivingChoices.Entities.Client.Search
{
	[Serializable]
	public class CommunitySearchModel<TResult> : ResultSetSearchModel<TResult, CommunitySortType>
	{
		public List<long> AmenitiesIds
		{
			get;
			set;
		}

		public long? BathroomFromId
		{
			get;
			set;
		}

		public long? BedroomFromId
		{
			get;
			set;
		}

		public MSLivingChoices.Entities.Client.Enums.ListingType ListingType
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

		public List<long> ShcCategoriesIds
		{
			get;
			set;
		}

		public CommunitySearchModel()
		{
			this.AmenitiesIds = new List<long>();
			this.ShcCategoriesIds = new List<long>();
		}

		public override string ToString()
		{
			decimal value;
			long num;
			string str;
			string empty;
			string str1;
			string empty1;
			string[] strArrays = new string[] { base.ToString(), null, null, null, null, null, null, null };
			strArrays[1] = this.ListingType.ToString();
			if (this.MaxPrice.HasValue)
			{
				value = this.MaxPrice.Value;
				str = value.ToString(CultureInfo.InvariantCulture);
			}
			else
			{
				str = string.Empty;
			}
			strArrays[2] = str;
			if (this.MinPrice.HasValue)
			{
				value = this.MinPrice.Value;
				empty = value.ToString(CultureInfo.InvariantCulture);
			}
			else
			{
				empty = string.Empty;
			}
			strArrays[3] = empty;
			if (this.BathroomFromId.HasValue)
			{
				num = this.BathroomFromId.Value;
				str1 = num.ToString(CultureInfo.InvariantCulture);
			}
			else
			{
				str1 = string.Empty;
			}
			strArrays[4] = str1;
			if (this.BedroomFromId.HasValue)
			{
				num = this.BedroomFromId.Value;
				empty1 = num.ToString(CultureInfo.InvariantCulture);
			}
			else
			{
				empty1 = string.Empty;
			}
			strArrays[5] = empty1;
			strArrays[6] = (this.AmenitiesIds != null ? this.AmenitiesIds.Aggregate<long, StringBuilder>(new StringBuilder(), (StringBuilder res, long cur) => res.AppendFormat("_{0}", cur.ToString(CultureInfo.InvariantCulture))).ToString() : string.Empty);
			strArrays[7] = (this.ShcCategoriesIds != null ? this.ShcCategoriesIds.Aggregate<long, StringBuilder>(new StringBuilder(), (StringBuilder res, long cur) => res.AppendFormat("_{0}", cur.ToString(CultureInfo.InvariantCulture))).ToString() : string.Empty);
			return string.Join("_", strArrays);
		}
	}
}