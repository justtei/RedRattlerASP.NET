using System;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Entities.Client.Search
{
	[Serializable]
	public class ResultSetSearchModel<TResult, TSortType> : SearchModel<TResult>
	where TSortType : struct, IConvertible
	{
		public int PageNumber
		{
			get;
			set;
		}

		public int PageSize
		{
			get;
			set;
		}

		public TSortType SortType
		{
			get;
			set;
		}

		public ResultSetSearchModel()
		{
		}

		public override string ToString()
		{
			string[] str = new string[] { base.ToString(), null, null, null };
			int pageNumber = this.PageNumber;
			str[1] = pageNumber.ToString(CultureInfo.InvariantCulture);
			pageNumber = this.PageSize;
			str[2] = pageNumber.ToString(CultureInfo.InvariantCulture);
			TSortType sortType = this.SortType;
			str[3] = sortType.ToString(CultureInfo.InvariantCulture);
			return string.Join("_", str);
		}
	}
}