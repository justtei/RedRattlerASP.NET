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
	public class ServiceProviderSearchModel<TResult> : ResultSetSearchModel<TResult, ServiceProviderSortType>
	{
		public List<long> ServiceCategoriesIds
		{
			get;
			set;
		}

		public ServiceProviderSearchModel()
		{
			this.ServiceCategoriesIds = new List<long>();
		}

		public override string ToString()
		{
			string[] str = new string[] { base.ToString(), null };
			str[1] = (this.ServiceCategoriesIds != null ? this.ServiceCategoriesIds.Aggregate<long, StringBuilder>(new StringBuilder(), (StringBuilder res, long cur) => res.AppendFormat("_{0}", cur.ToString(CultureInfo.InvariantCulture))).ToString() : string.Empty);
			return string.Join("_", str);
		}
	}
}